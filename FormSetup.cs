using System;
using System.Drawing;
using System.Windows.Forms;

namespace NetBarcodeDotNet
{
    public partial class FormSetup : Form
    {
        private readonly LabelTemplate _template;

        // Intermediate font settings
        private string descFontName;
        private float descFontSize;
        private string descFontStyle;

        private string priceFontName;
        private float priceFontSize;
        private string priceFontStyle;

        private string companyFontName;
        private float companyFontSize;
        private string companyFontStyle;

        private string headerFontName;
        private float headerFontSize;
        private string headerFontStyle;

        private bool isUpdatingPreset = false;

        public FormSetup(LabelTemplate template)
        {
            InitializeComponent();
            _template = template;

            // Load Font variables
            descFontName = template.DescFontName;
            descFontSize = template.DescFontSize;
            descFontStyle = template.DescFontStyle;

            priceFontName = template.PriceFontName;
            priceFontSize = template.PriceFontSize;
            priceFontStyle = template.PriceFontStyle;

            companyFontName = template.CompanyFontName;
            companyFontSize = template.CompanyFontSize;
            companyFontStyle = template.CompanyFontStyle;

            headerFontName = template.HeaderFontName;
            headerFontSize = template.HeaderFontSize;
            headerFontStyle = template.HeaderFontStyle;

            // Bind Event Handlers for Fonts
            btnDescFont.Click += BtnDescFont_Click;
            btnPriceFont.Click += BtnPriceFont_Click;
            btnCompanyFont.Click += BtnCompanyFont_Click;
            btnHeaderFont.Click += BtnHeaderFont_Click;

            // Bind Event Handlers for Presets
            cmbPreset.SelectedIndexChanged += CmbPreset_SelectedIndexChanged;

            numTopMargin.ValueChanged += GeneralControl_ValueChanged;
            numLeftMargin.ValueChanged += GeneralControl_ValueChanged;
            numLabelWidth.ValueChanged += GeneralControl_ValueChanged;
            numLabelHeight.ValueChanged += GeneralControl_ValueChanged;
            numVGap.ValueChanged += GeneralControl_ValueChanged;
            numHGap.ValueChanged += GeneralControl_ValueChanged;
            numColumns.ValueChanged += GeneralControl_ValueChanged;
            numRows.ValueChanged += GeneralControl_ValueChanged;

            LoadTemplateValues();
        }

        private void LoadTemplateValues()
        {
            // General
            numTopMargin.Value = (decimal)_template.TopMargin;
            numLeftMargin.Value = (decimal)_template.LeftMargin;
            numLabelWidth.Value = (decimal)_template.LabelWidth;
            numLabelHeight.Value = (decimal)_template.LabelHeight;
            numVGap.Value = (decimal)_template.VerticalGap;
            numHGap.Value = (decimal)_template.HorizontalGap;
            numColumns.Value = _template.Columns;
            numRows.Value = _template.Rows;
            chkShowGuide.Checked = _template.ShowGuide;

            // Determine active preset based on current template values
            isUpdatingPreset = true;
            if (IsMatchingPreset(4.0f, 4.0f, 38.0f, 18.0f, 2.0f, 3.0f, 5, 8))
            {
                cmbPreset.SelectedItem = "No. 108 (18 x 38 mm)";
            }
            else if (IsMatchingPreset(2.0f, 2.0f, 64.0f, 32.0f, 2.0f, 2.0f, 3, 4))
            {
                cmbPreset.SelectedItem = "No. 103 (32 x 64 mm)";
            }
            else if (IsMatchingPreset(2.0f, 2.0f, 75.0f, 38.0f, 2.0f, 2.0f, 2, 5))
            {
                cmbPreset.SelectedItem = "No. 121 (38 x 75 mm)";
            }
            else if (IsMatchingPreset(3.0f, 3.0f, 50.0f, 18.0f, 2.0f, 2.0f, 4, 8))
            {
                cmbPreset.SelectedItem = "No. 107 (18 x 50 mm)";
            }
            else if (IsMatchingPreset(2.0f, 2.0f, 20.0f, 8.0f, 2.0f, 2.0f, 8, 12))
            {
                cmbPreset.SelectedItem = "No. 112 (8 x 20 mm)";
            }
            else
            {
                cmbPreset.SelectedItem = "Custom";
            }
            isUpdatingPreset = false;

            // Barcode
            cmbBarcodeType.SelectedItem = cmbBarcodeType.Items.Contains(_template.BarcodeType) ? _template.BarcodeType : "Code 128";
            numBarcodeTop.Value = (decimal)_template.BarcodeTop;
            numBarcodeLeft.Value = (decimal)_template.BarcodeLeft;
            numBarcodeHeight.Value = (decimal)_template.BarcodeHeight;
            txtBarcodePrefiks.Text = _template.BarcodePrefiks;
            numBarWidth.Value = (decimal)_template.BarWidth;
            cmbBarcodeAlign.SelectedItem = cmbBarcodeAlign.Items.Contains(_template.BarcodeAlignment) ? _template.BarcodeAlignment : "Center";
            chkPrintHuman.Checked = _template.PrintHumanReadable;

            // Description
            chkShowDesc.Checked = _template.ShowDesc;
            numDescTop.Value = (decimal)_template.DescTop;
            numDescLeft.Value = (decimal)_template.DescLeft;
            UpdateFontLabel(lblDescFontInfo, descFontName, descFontSize, descFontStyle);

            // Price
            chkShowPrice.Checked = _template.ShowPrice;
            numPriceTop.Value = (decimal)_template.PriceTop;
            numPriceLeft.Value = (decimal)_template.PriceLeft;
            txtPriceSymbol.Text = _template.PriceSymbol;
            numPriceDecimal.Value = _template.PriceDecimal;
            chkPriceGrouping.Checked = _template.PriceUseGrouping;
            UpdateFontLabel(lblPriceFontInfo, priceFontName, priceFontSize, priceFontStyle);

            // Company
            chkShowCompany.Checked = _template.ShowCompany;
            txtCompanyText.Text = _template.CompanyText;
            numCompanyTop.Value = (decimal)_template.CompanyTop;
            numCompanyLeft.Value = (decimal)_template.CompanyLeft;
            UpdateFontLabel(lblCompanyFontInfo, companyFontName, companyFontSize, companyFontStyle);

            // Optional Headers
            chkShowHeaders.Checked = _template.ShowHeaders;
            txtHeader1.Text = _template.Header1;
            txtHeader2.Text = _template.Header2;
            txtHeader3.Text = _template.Header3;
            numHeaderTop.Value = (decimal)_template.HeaderTop;
            numHeaderLeft.Value = (decimal)_template.HeaderLeft;
            UpdateFontLabel(lblHeaderFontInfo, headerFontName, headerFontSize, headerFontStyle);
        }

        private void UpdateFontLabel(Label label, string name, float size, string style)
        {
            label.Text = $"{name}, {size}pt, {style}";
        }

        private void BtnDescFont_Click(object? sender, EventArgs e)
        {
            ShowFontDialog(ref descFontName, ref descFontSize, ref descFontStyle, lblDescFontInfo);
        }

        private void BtnPriceFont_Click(object? sender, EventArgs e)
        {
            ShowFontDialog(ref priceFontName, ref priceFontSize, ref priceFontStyle, lblPriceFontInfo);
        }

        private void BtnCompanyFont_Click(object? sender, EventArgs e)
        {
            ShowFontDialog(ref companyFontName, ref companyFontSize, ref companyFontStyle, lblCompanyFontInfo);
        }

        private void BtnHeaderFont_Click(object? sender, EventArgs e)
        {
            ShowFontDialog(ref headerFontName, ref headerFontSize, ref headerFontStyle, lblHeaderFontInfo);
        }

        private void ShowFontDialog(ref string fontName, ref float fontSize, ref string fontStyle, Label label)
        {
            using (var fd = new FontDialog())
            {
                FontStyle style = FontStyle.Regular;
                if (fontStyle.Contains("Bold")) style |= FontStyle.Bold;
                if (fontStyle.Contains("Italic")) style |= FontStyle.Italic;

                fd.Font = new Font(fontName, fontSize, style);
                fd.ShowColor = false;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    fontName = fd.Font.Name;
                    fontSize = fd.Font.Size;
                    
                    var styles = new System.Collections.Generic.List<string>();
                    if (fd.Font.Bold) styles.Add("Bold");
                    if (fd.Font.Italic) styles.Add("Italic");
                    
                    fontStyle = styles.Count > 0 ? string.Join(" ", styles) : "Regular";
                    
                    UpdateFontLabel(label, fontName, fontSize, fontStyle);
                }
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Save visual components to template
            _template.TopMargin = (float)numTopMargin.Value;
            _template.LeftMargin = (float)numLeftMargin.Value;
            _template.LabelWidth = (float)numLabelWidth.Value;
            _template.LabelHeight = (float)numLabelHeight.Value;
            _template.VerticalGap = (float)numVGap.Value;
            _template.HorizontalGap = (float)numHGap.Value;
            _template.Columns = (int)numColumns.Value;
            _template.Rows = (int)numRows.Value;
            _template.ShowGuide = chkShowGuide.Checked;

            // Barcode
            _template.BarcodeType = cmbBarcodeType.SelectedItem?.ToString() ?? "Code 128";
            _template.BarcodeTop = (float)numBarcodeTop.Value;
            _template.BarcodeLeft = (float)numBarcodeLeft.Value;
            _template.BarcodeHeight = (float)numBarcodeHeight.Value;
            _template.BarcodePrefiks = txtBarcodePrefiks.Text;
            _template.BarWidth = (float)numBarWidth.Value;
            _template.BarcodeAlignment = cmbBarcodeAlign.SelectedItem?.ToString() ?? "Center";
            _template.PrintHumanReadable = chkPrintHuman.Checked;

            // Description
            _template.ShowDesc = chkShowDesc.Checked;
            _template.DescTop = (float)numDescTop.Value;
            _template.DescLeft = (float)numDescLeft.Value;
            _template.DescFontName = descFontName;
            _template.DescFontSize = descFontSize;
            _template.DescFontStyle = descFontStyle;

            // Price
            _template.ShowPrice = chkShowPrice.Checked;
            _template.PriceTop = (float)numPriceTop.Value;
            _template.PriceLeft = (float)numPriceLeft.Value;
            _template.PriceSymbol = txtPriceSymbol.Text;
            _template.PriceDecimal = (int)numPriceDecimal.Value;
            _template.PriceUseGrouping = chkPriceGrouping.Checked;
            _template.PriceFontName = priceFontName;
            _template.PriceFontSize = priceFontSize;
            _template.PriceFontStyle = priceFontStyle;

            // Company
            _template.ShowCompany = chkShowCompany.Checked;
            _template.CompanyText = txtCompanyText.Text;
            _template.CompanyTop = (float)numCompanyTop.Value;
            _template.CompanyLeft = (float)numCompanyLeft.Value;
            _template.CompanyFontName = companyFontName;
            _template.CompanyFontSize = companyFontSize;
            _template.CompanyFontStyle = companyFontStyle;

            // Optional Headers
            _template.ShowHeaders = chkShowHeaders.Checked;
            _template.Header1 = txtHeader1.Text;
            _template.Header2 = txtHeader2.Text;
            _template.Header3 = txtHeader3.Text;
            _template.HeaderTop = (float)numHeaderTop.Value;
            _template.HeaderLeft = (float)numHeaderLeft.Value;
            _template.HeaderFontName = headerFontName;
            _template.HeaderFontSize = headerFontSize;
            _template.HeaderFontStyle = headerFontStyle;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region Preset Helpers
        private void GeneralControl_ValueChanged(object? sender, EventArgs e)
        {
            if (isUpdatingPreset) return;
            
            // If the user modified a value manually, switch preset selection to "Custom"
            if (cmbPreset.SelectedItem?.ToString() != "Custom")
            {
                isUpdatingPreset = true;
                cmbPreset.SelectedItem = "Custom";
                isUpdatingPreset = false;
            }
        }

        private void CmbPreset_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (isUpdatingPreset) return;
            isUpdatingPreset = true;

            string? selected = cmbPreset.SelectedItem?.ToString();
            if (selected != null && selected != "Custom")
            {
                if (selected.StartsWith("No. 108"))
                {
                    SetGeneralSettings(4.0m, 4.0m, 38.0m, 18.0m, 2.0m, 3.0m, 5, 8);
                }
                else if (selected.StartsWith("No. 103"))
                {
                    SetGeneralSettings(2.0m, 2.0m, 64.0m, 32.0m, 2.0m, 2.0m, 3, 4);
                }
                else if (selected.StartsWith("No. 121"))
                {
                    SetGeneralSettings(2.0m, 2.0m, 75.0m, 38.0m, 2.0m, 2.0m, 2, 5);
                }
                else if (selected.StartsWith("No. 107"))
                {
                    SetGeneralSettings(3.0m, 3.0m, 50.0m, 18.0m, 2.0m, 2.0m, 4, 8);
                }
                else if (selected.StartsWith("No. 112"))
                {
                    SetGeneralSettings(2.0m, 2.0m, 20.0m, 8.0m, 2.0m, 2.0m, 8, 12);
                }
            }

            isUpdatingPreset = false;
        }

        private void SetGeneralSettings(decimal top, decimal left, decimal width, decimal height, decimal vgap, decimal hgap, int cols, int rows)
        {
            numTopMargin.Value = top;
            numLeftMargin.Value = left;
            numLabelWidth.Value = width;
            numLabelHeight.Value = height;
            numVGap.Value = vgap;
            numHGap.Value = hgap;
            numColumns.Value = cols;
            numRows.Value = rows;
        }

        private bool IsMatchingPreset(float top, float left, float width, float height, float vgap, float hgap, int cols, int rows)
        {
            const float epsilon = 0.05f; // floating point tolerance
            return Math.Abs(_template.TopMargin - top) < epsilon &&
                   Math.Abs(_template.LeftMargin - left) < epsilon &&
                   Math.Abs(_template.LabelWidth - width) < epsilon &&
                   Math.Abs(_template.LabelHeight - height) < epsilon &&
                   Math.Abs(_template.VerticalGap - vgap) < epsilon &&
                   Math.Abs(_template.HorizontalGap - hgap) < epsilon &&
                   _template.Columns == cols &&
                   _template.Rows == rows;
        }
        #endregion
    }
}
