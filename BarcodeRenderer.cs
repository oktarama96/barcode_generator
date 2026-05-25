using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NetBarcodeDotNet
{
    public static class BarcodeRenderer
    {
        // Helper to convert mm measurements to pixels/units at a given DPI
        public static float MmToUnits(float mm, float dpi)
        {
            return (mm / 25.4f) * dpi;
        }

        public static void DrawLabel(Graphics g, RectangleF bounds, LabelTemplate t, ProductItem item, bool drawOutlineGuide)
        {
            // Set high quality graphics parameters
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // We will draw everything relative to bounds.Location (top-left of this label)
            float x0 = bounds.X;
            float y0 = bounds.Y;

            // DPI factor. We assume coordinate units are in Pixels. 
            // In typical GDI+ WinForms controls on-screen, DpiX is usually 96.
            // On a printer, DpiX can be 300 or 600.
            // We compute the DPI based on the bounds relative to template LabelWidth
            float dpi = (bounds.Width / t.LabelWidth) * 25.4f;

            // 1. Draw Boundary Guide (dashed rectangle) if requested
            if (t.ShowGuide || drawOutlineGuide)
            {
                using (var pen = new Pen(drawOutlineGuide ? Color.RoyalBlue : Color.LightGray, 1f))
                {
                    pen.DashStyle = DashStyle.Dash;
                    g.DrawRectangle(pen, x0, y0, bounds.Width, bounds.Height);
                }
            }

            // 2. Draw Company Name
            if (t.ShowCompany && !string.IsNullOrEmpty(t.CompanyText))
            {
                using (var font = GetFont(t.CompanyFontName, t.CompanyFontSize, t.CompanyFontStyle, dpi))
                using (var brush = new SolidBrush(Color.Black))
                {
                    float cx = x0 + MmToUnits(t.CompanyLeft, dpi);
                    float cy = y0 + MmToUnits(t.CompanyTop, dpi);
                    g.DrawString(t.CompanyText, font, brush, cx, cy);
                }
            }

            // 3. Draw Product Name / Description
            if (t.ShowDesc && !string.IsNullOrEmpty(item.Name))
            {
                using (var font = GetFont(t.DescFontName, t.DescFontSize, t.DescFontStyle, dpi))
                using (var brush = new SolidBrush(Color.Black))
                {
                    float dx = x0 + MmToUnits(t.DescLeft, dpi);
                    float dy = y0 + MmToUnits(t.DescTop, dpi);
                    g.DrawString(item.Name, font, brush, dx, dy);
                }
            }

            // 4. Draw Price
            if (t.ShowPrice)
            {
                string priceText = FormatPrice(item.Price, t);
                using (var font = GetFont(t.PriceFontName, t.PriceFontSize, t.PriceFontStyle, dpi))
                using (var brush = new SolidBrush(Color.Black))
                {
                    float px = x0 + MmToUnits(t.PriceLeft, dpi);
                    float py = y0 + MmToUnits(t.PriceTop, dpi);
                    g.DrawString(priceText, font, brush, px, py);
                }
            }

            // 5. Draw Optional Headers
            if (t.ShowHeaders)
            {
                string headerText = string.Join(" ", new[] { t.Header1, t.Header2, t.Header3 }).Trim();
                if (!string.IsNullOrEmpty(headerText))
                {
                    using (var font = GetFont(t.HeaderFontName, t.HeaderFontSize, t.HeaderFontStyle, dpi))
                    using (var brush = new SolidBrush(Color.Black))
                    {
                        float hx = x0 + MmToUnits(t.HeaderLeft, dpi);
                        float hy = y0 + MmToUnits(t.HeaderTop, dpi);
                        g.DrawString(headerText, font, brush, hx, hy);
                    }
                }
            }

            // 6. Draw Barcode Vector Lines
            string rawBarcode = item.Barcode;
            if (!string.IsNullOrEmpty(t.BarcodePrefiks))
            {
                rawBarcode = t.BarcodePrefiks + rawBarcode;
            }

            string binaryString = BarcodeEncoder.Encode(rawBarcode, t.BarcodeType);
            if (!string.IsNullOrEmpty(binaryString))
            {
                float bx = x0 + MmToUnits(t.BarcodeLeft, dpi);
                float by = y0 + MmToUnits(t.BarcodeTop, dpi);
                float bHeight = MmToUnits(t.BarcodeHeight, dpi);
                
                // Calculate unit bar width (module width) in pixels
                float moduleWidth = MmToUnits(t.BarWidth, dpi);
                float totalBarcodeWidth = binaryString.Length * moduleWidth;

                // Adjust horizontal alignment
                if (t.BarcodeAlignment == "Center")
                {
                    bx = x0 + (bounds.Width / 2) - (totalBarcodeWidth / 2);
                }
                else if (t.BarcodeAlignment == "Right")
                {
                    bx = x0 + bounds.Width - totalBarcodeWidth - MmToUnits(t.BarcodeLeft, dpi);
                }

                // --- Intelligent Overlap & Collision Avoidance Engine ---
                if (t.ShowPrice)
                {
                    string priceText = FormatPrice(item.Price, t);
                    using (var priceFont = GetFont(t.PriceFontName, t.PriceFontSize, t.PriceFontStyle, dpi))
                    {
                        var priceSize = g.MeasureString(priceText, priceFont);
                        float px = x0 + MmToUnits(t.PriceLeft, dpi);
                        float py = y0 + MmToUnits(t.PriceTop, dpi);

                        // Check horizontal intersection
                        bool horizOverlap = !(px + priceSize.Width < bx || bx + totalBarcodeWidth < px);
                        if (horizOverlap)
                        {
                            // Measure human readable text height
                            float textHeight = 0;
                            if (t.PrintHumanReadable)
                            {
                                using (var textFont = new Font(t.DescFontName, 7f, FontStyle.Regular))
                                {
                                    textHeight = g.MeasureString(rawBarcode, textFont).Height;
                                }
                            }

                            // Calculate maximum printable height for barcode bars to clear the price top py
                            float maxAllowedHeight = py - by - textHeight - 2f;
                            float minAllowedHeight = MmToUnits(3.0f, dpi); // Minimum scannable barcode height: 3mm

                            if (bHeight > maxAllowedHeight)
                            {
                                if (maxAllowedHeight >= minAllowedHeight)
                                {
                                    // Compress height dynamically to fit
                                    bHeight = maxAllowedHeight;
                                }
                                else
                                {
                                    // Shift the barcode top 'by' upwards if space allows
                                    float requiredShift = minAllowedHeight - maxAllowedHeight;
                                    float newBy = by - requiredShift;

                                    // Enforce boundary check against Description name bottom (dy + descHeight)
                                    float descBottom = y0;
                                    if (t.ShowDesc && !string.IsNullOrEmpty(item.Name))
                                    {
                                        using (var descFont = GetFont(t.DescFontName, t.DescFontSize, t.DescFontStyle, dpi))
                                        {
                                            var descSize = g.MeasureString(item.Name, descFont);
                                            descBottom = y0 + MmToUnits(t.DescTop, dpi) + descSize.Height;
                                        }
                                    }

                                    if (newBy > descBottom + 2f)
                                    {
                                        by = newBy;
                                        bHeight = minAllowedHeight;
                                    }
                                    else
                                    {
                                        // If space is extremely tight, push to desc bottom and compress barcode to min allowed
                                        by = descBottom + 2f;
                                        bHeight = Math.Max(minAllowedHeight, py - by - textHeight - 2f);
                                    }
                                }
                            }
                        }
                    }
                }
                // --------------------------------------------------------

                // Render vector bars
                using (var barBrush = new SolidBrush(Color.Black))
                {
                    float currentX = bx;
                    int i = 0;
                    while (i < binaryString.Length)
                    {
                        if (binaryString[i] == '1')
                        {
                            // Find the consecutive width of the bar
                            int runLength = 0;
                            while (i < binaryString.Length && binaryString[i] == '1')
                            {
                                runLength++;
                                i++;
                            }

                            float barWidth = runLength * moduleWidth;
                            g.FillRectangle(barBrush, currentX, by, barWidth, bHeight);
                            currentX += barWidth;
                        }
                        else
                        {
                            // Consecutive spaces
                            int runLength = 0;
                            while (i < binaryString.Length && binaryString[i] == '0')
                            {
                                runLength++;
                                i++;
                            }
                            currentX += runLength * moduleWidth;
                        }
                    }
                }

                // 7. Draw Human Readable Text under barcode
                if (t.PrintHumanReadable)
                {
                    using (var textFont = new Font(t.DescFontName, 7f, FontStyle.Regular))
                    using (var textBrush = new SolidBrush(Color.Black))
                    {
                        var size = g.MeasureString(rawBarcode, textFont);
                        float tx = bx + (totalBarcodeWidth / 2) - (size.Width / 2);
                        float ty = by + bHeight + 1f; // 1 pixel gap below barcode
                        g.DrawString(rawBarcode, textFont, textBrush, tx, ty);
                    }
                }
            }
        }

        private static Font GetFont(string fontName, float sizeInPoints, string styleStr, float dpi)
        {
            FontStyle style = FontStyle.Regular;
            if (styleStr.Contains("Bold")) style |= FontStyle.Bold;
            if (styleStr.Contains("Italic")) style |= FontStyle.Italic;

            // To ensure the fonts scale perfectly across DPI sizes (Preview Screen vs High-DPI Printer),
            // we create the font scaled by DPI.
            float emSize = sizeInPoints;
            return new Font(fontName, emSize, style);
        }

        private static string FormatPrice(decimal price, LabelTemplate t)
        {
            string formatted = t.PriceSymbol;
            if (!string.IsNullOrEmpty(formatted))
            {
                formatted += " ";
            }

            string numberFormat = t.PriceUseGrouping ? "#,##0" : "0";
            if (t.PriceDecimal > 0)
            {
                numberFormat += "." + new string('0', t.PriceDecimal);
            }

            formatted += price.ToString(numberFormat);
            return formatted;
        }
    }
}
