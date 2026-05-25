using System;
using System.IO;
using System.Text.Json;

namespace NetBarcodeDotNet
{
    public class LabelTemplate
    {
        // General Page Layout
        public float TopMargin { get; set; } = 4.0f; // mm
        public float LeftMargin { get; set; } = 4.0f; // mm
        public float LabelWidth { get; set; } = 38.0f; // mm
        public float LabelHeight { get; set; } = 18.0f; // mm
        public float VerticalGap { get; set; } = 2.0f; // mm
        public float HorizontalGap { get; set; } = 3.0f; // mm
        public int Columns { get; set; } = 5; // Number across
        public int Rows { get; set; } = 8; // Number down
        public bool ShowGuide { get; set; } = true;

        // Barcode Configuration
        public string BarcodeType { get; set; } = "Code 128"; // Code 128, Code 39, EAN-13, EAN-8
        public float BarcodeHeight { get; set; } = 6.0f; // mm
        public float BarcodeTop { get; set; } = 7.0f; // mm
        public float BarcodeLeft { get; set; } = 2.0f; // mm
        public string BarcodePrefiks { get; set; } = string.Empty;
        public float BarWidth { get; set; } = 0.2f; // mm (bar unit size)
        public float BarWidthRatio { get; set; } = 2.0f;
        public bool PrintHumanReadable { get; set; } = true;
        public string BarcodeAlignment { get; set; } = "Center"; // Left, Center, Right

        // Description Configuration
        public bool ShowDesc { get; set; } = true;
        public float DescTop { get; set; } = 1.0f; // mm
        public float DescLeft { get; set; } = 2.0f; // mm
        public string DescFontName { get; set; } = "Segoe UI";
        public float DescFontSize { get; set; } = 6.0f;
        public string DescFontStyle { get; set; } = "Regular"; // Regular, Bold, Italic, Bold Italic

        // Price Configuration
        public bool ShowPrice { get; set; } = true;
        public float PriceTop { get; set; } = 13.5f; // mm
        public float PriceLeft { get; set; } = 2.0f; // mm
        public string PriceFontName { get; set; } = "Segoe UI";
        public float PriceFontSize { get; set; } = 7.0f;
        public string PriceFontStyle { get; set; } = "Bold";
        public string PriceFormat { get; set; } = "Standard"; // Standard, Number
        public int PriceDecimal { get; set; } = 0;
        public string PriceSymbol { get; set; } = "Rp";
        public bool PriceUseGrouping { get; set; } = true;

        // Company Configuration
        public bool ShowCompany { get; set; } = false; // Hide by default on tiny 18mm height label
        public string CompanyText { get; set; } = "Oktarama Retail";
        public float CompanyTop { get; set; } = 4.5f; // mm
        public float CompanyLeft { get; set; } = 2.0f; // mm
        public string CompanyFontName { get; set; } = "Segoe UI";
        public float CompanyFontSize { get; set; } = 6.0f;
        public string CompanyFontStyle { get; set; } = "Bold";

        // Optional Headers Config
        public bool ShowHeaders { get; set; } = false;
        public string Header1 { get; set; } = "PROMO";
        public string Header2 { get; set; } = "";
        public string Header3 { get; set; } = "";
        public float HeaderTop { get; set; } = 1.0f; // mm
        public float HeaderLeft { get; set; } = 20.0f; // mm
        public string HeaderFontName { get; set; } = "Segoe UI";
        public float HeaderFontSize { get; set; } = 6.5f;
        public string HeaderFontStyle { get; set; } = "Bold Italic";

        public static LabelTemplate GetDefault()
        {
            return new LabelTemplate();
        }

        public void Save(string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save template: " + ex.Message);
            }
        }

        public static LabelTemplate Load(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<LabelTemplate>(json) ?? GetDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load template: " + ex.Message);
            }
            return GetDefault();
        }
    }
}
