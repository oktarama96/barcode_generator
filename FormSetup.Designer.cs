namespace NetBarcodeDotNet
{
    partial class FormSetup
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pgSetup = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabBarcode = new System.Windows.Forms.TabPage();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.tabPrice = new System.Windows.Forms.TabPage();
            this.tabCompany = new System.Windows.Forms.TabPage();
            this.tabOptional = new System.Windows.Forms.TabPage();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // General Controls
            this.numTopMargin = new System.Windows.Forms.NumericUpDown();
            this.numLeftMargin = new System.Windows.Forms.NumericUpDown();
            this.numLabelWidth = new System.Windows.Forms.NumericUpDown();
            this.numLabelHeight = new System.Windows.Forms.NumericUpDown();
            this.numVGap = new System.Windows.Forms.NumericUpDown();
            this.numHGap = new System.Windows.Forms.NumericUpDown();
            this.numColumns = new System.Windows.Forms.NumericUpDown();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.chkShowGuide = new System.Windows.Forms.CheckBox();
            this.cmbPreset = new System.Windows.Forms.ComboBox();

            // Barcode Controls
            this.cmbBarcodeType = new System.Windows.Forms.ComboBox();
            this.numBarcodeHeight = new System.Windows.Forms.NumericUpDown();
            this.numBarcodeTop = new System.Windows.Forms.NumericUpDown();
            this.numBarcodeLeft = new System.Windows.Forms.NumericUpDown();
            this.txtBarcodePrefiks = new System.Windows.Forms.TextBox();
            this.numBarWidth = new System.Windows.Forms.NumericUpDown();
            this.chkPrintHuman = new System.Windows.Forms.CheckBox();
            this.cmbBarcodeAlign = new System.Windows.Forms.ComboBox();

            // Description Controls
            this.chkShowDesc = new System.Windows.Forms.CheckBox();
            this.numDescTop = new System.Windows.Forms.NumericUpDown();
            this.numDescLeft = new System.Windows.Forms.NumericUpDown();
            this.btnDescFont = new System.Windows.Forms.Button();
            this.lblDescFontInfo = new System.Windows.Forms.Label();

            // Price Controls
            this.chkShowPrice = new System.Windows.Forms.CheckBox();
            this.numPriceTop = new System.Windows.Forms.NumericUpDown();
            this.numPriceLeft = new System.Windows.Forms.NumericUpDown();
            this.txtPriceSymbol = new System.Windows.Forms.TextBox();
            this.numPriceDecimal = new System.Windows.Forms.NumericUpDown();
            this.chkPriceGrouping = new System.Windows.Forms.CheckBox();
            this.btnPriceFont = new System.Windows.Forms.Button();
            this.lblPriceFontInfo = new System.Windows.Forms.Label();

            // Company Controls
            this.chkShowCompany = new System.Windows.Forms.CheckBox();
            this.txtCompanyText = new System.Windows.Forms.TextBox();
            this.numCompanyTop = new System.Windows.Forms.NumericUpDown();
            this.numCompanyLeft = new System.Windows.Forms.NumericUpDown();
            this.btnCompanyFont = new System.Windows.Forms.Button();
            this.lblCompanyFontInfo = new System.Windows.Forms.Label();

            // Optional Header Controls
            this.chkShowHeaders = new System.Windows.Forms.CheckBox();
            this.txtHeader1 = new System.Windows.Forms.TextBox();
            this.txtHeader2 = new System.Windows.Forms.TextBox();
            this.txtHeader3 = new System.Windows.Forms.TextBox();
            this.numHeaderTop = new System.Windows.Forms.NumericUpDown();
            this.numHeaderLeft = new System.Windows.Forms.NumericUpDown();
            this.btnHeaderFont = new System.Windows.Forms.Button();
            this.lblHeaderFontInfo = new System.Windows.Forms.Label();

            this.pgSetup.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTopMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeftMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLabelWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLabelHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            this.tabBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBarcodeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBarcodeTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBarcodeLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBarWidth)).BeginInit();
            this.tabDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDescTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescLeft)).BeginInit();
            this.tabPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceDecimal)).BeginInit();
            this.tabCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCompanyTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompanyLeft)).BeginInit();
            this.tabOptional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeaderTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeaderLeft)).BeginInit();
            this.SuspendLayout();

            // 
            // pgSetup
            // 
            this.pgSetup.Controls.Add(this.tabGeneral);
            this.pgSetup.Controls.Add(this.tabBarcode);
            this.pgSetup.Controls.Add(this.tabDesc);
            this.pgSetup.Controls.Add(this.tabPrice);
            this.pgSetup.Controls.Add(this.tabCompany);
            this.pgSetup.Controls.Add(this.tabOptional);
            this.pgSetup.Location = new System.Drawing.Point(12, 12);
            this.pgSetup.Name = "pgSetup";
            this.pgSetup.SelectedIndex = 0;
            this.pgSetup.Size = new System.Drawing.Size(460, 310);
            this.pgSetup.TabIndex = 0;

            // 
            // tabGeneral (Page Layout & Labels)
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.White;
            this.tabGeneral.Location = new System.Drawing.Point(4, 24);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(10);
            this.tabGeneral.Size = new System.Drawing.Size(452, 282);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            
            AddLabel("Label Preset:", 15, 20, this.tabGeneral);
            this.cmbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreset.Items.AddRange(new object[] {
            "No. 108 (18 x 38 mm)",
            "No. 103 (32 x 64 mm)",
            "No. 121 (38 x 75 mm)",
            "No. 107 (18 x 50 mm)",
            "No. 112 (8 x 20 mm)",
            "Custom"});
            this.cmbPreset.Location = new System.Drawing.Point(150, 17);
            this.cmbPreset.Size = new System.Drawing.Size(200, 23);
            this.cmbPreset.TabIndex = 0;
            this.tabGeneral.Controls.Add(this.cmbPreset);

            AddLabel("Top margin (mm):", 15, 55, this.tabGeneral);
            SetupUpDown(this.numTopMargin, 150, 53, 0, 100, 0.1m, this.tabGeneral);
            
            AddLabel("Left margin (mm):", 15, 90, this.tabGeneral);
            SetupUpDown(this.numLeftMargin, 150, 88, 0, 100, 0.1m, this.tabGeneral);

            AddLabel("Label width (mm):", 15, 125, this.tabGeneral);
            SetupUpDown(this.numLabelWidth, 150, 123, 1, 200, 0.1m, this.tabGeneral);

            AddLabel("Label height (mm):", 15, 160, this.tabGeneral);
            SetupUpDown(this.numLabelHeight, 150, 158, 1, 200, 0.1m, this.tabGeneral);

            AddLabel("Vertical gap (mm):", 240, 55, this.tabGeneral);
            SetupUpDown(this.numVGap, 360, 53, 0, 50, 0.1m, this.tabGeneral);

            AddLabel("Horizontal gap (mm):", 240, 90, this.tabGeneral);
            SetupUpDown(this.numHGap, 360, 88, 0, 50, 0.1m, this.tabGeneral);

            AddLabel("Number across:", 240, 125, this.tabGeneral);
            SetupUpDown(this.numColumns, 360, 123, 1, 20, 1m, this.tabGeneral);

            AddLabel("Number down:", 240, 160, this.tabGeneral);
            SetupUpDown(this.numRows, 360, 158, 1, 50, 1m, this.tabGeneral);

            this.chkShowGuide.AutoSize = true;
            this.chkShowGuide.Location = new System.Drawing.Point(18, 195);
            this.chkShowGuide.Name = "chkShowGuide";
            this.chkShowGuide.Size = new System.Drawing.Size(135, 19);
            this.chkShowGuide.TabIndex = 8;
            this.chkShowGuide.Text = "View Guide Lines";
            this.chkShowGuide.UseVisualStyleBackColor = true;
            this.tabGeneral.Controls.Add(this.chkShowGuide);

            // 
            // tabBarcode (Barcode Encoding & Positioning)
            // 
            this.tabBarcode.BackColor = System.Drawing.Color.White;
            this.tabBarcode.Padding = new System.Windows.Forms.Padding(10);
            this.tabBarcode.Text = "Barcode";

            AddLabel("Type:", 15, 20, this.tabBarcode);
            this.cmbBarcodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarcodeType.Items.AddRange(new object[] { "Code 128", "Code 39", "EAN-13", "EAN-8" });
            this.cmbBarcodeType.Location = new System.Drawing.Point(120, 18);
            this.cmbBarcodeType.Size = new System.Drawing.Size(120, 23);
            this.tabBarcode.Controls.Add(this.cmbBarcodeType);

            AddLabel("Top pos (mm):", 15, 55, this.tabBarcode);
            SetupUpDown(this.numBarcodeTop, 120, 53, 0, 100, 0.1m, this.tabBarcode);

            AddLabel("Left pos (mm):", 15, 90, this.tabBarcode);
            SetupUpDown(this.numBarcodeLeft, 120, 88, 0, 100, 0.1m, this.tabBarcode);

            AddLabel("Height (mm):", 15, 125, this.tabBarcode);
            SetupUpDown(this.numBarcodeHeight, 120, 123, 1, 100, 0.1m, this.tabBarcode);

            AddLabel("Prefix code:", 250, 20, this.tabBarcode);
            this.txtBarcodePrefiks.Location = new System.Drawing.Point(340, 18);
            this.txtBarcodePrefiks.Size = new System.Drawing.Size(95, 23);
            this.tabBarcode.Controls.Add(this.txtBarcodePrefiks);

            AddLabel("Bar width (mm):", 250, 55, this.tabBarcode);
            SetupUpDown(this.numBarWidth, 340, 53, 0.05m, 5.0m, 0.01m, this.tabBarcode);

            AddLabel("Alignment:", 250, 90, this.tabBarcode);
            this.cmbBarcodeAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarcodeAlign.Items.AddRange(new object[] { "Left", "Center", "Right" });
            this.cmbBarcodeAlign.Location = new System.Drawing.Point(340, 88);
            this.cmbBarcodeAlign.Size = new System.Drawing.Size(95, 23);
            this.tabBarcode.Controls.Add(this.cmbBarcodeAlign);

            this.chkPrintHuman.AutoSize = true;
            this.chkPrintHuman.Location = new System.Drawing.Point(252, 125);
            this.chkPrintHuman.Name = "chkPrintHuman";
            this.chkPrintHuman.Size = new System.Drawing.Size(180, 19);
            this.chkPrintHuman.Text = "Print Human Readable Text";
            this.chkPrintHuman.UseVisualStyleBackColor = true;
            this.tabBarcode.Controls.Add(this.chkPrintHuman);

            // 
            // tabDesc (Item Name & Font Layout)
            // 
            this.tabDesc.BackColor = System.Drawing.Color.White;
            this.tabDesc.Padding = new System.Windows.Forms.Padding(10);
            this.tabDesc.Text = "Description";

            this.chkShowDesc.AutoSize = true;
            this.chkShowDesc.Location = new System.Drawing.Point(15, 20);
            this.chkShowDesc.Text = "Show Product Description Text";
            this.chkShowDesc.UseVisualStyleBackColor = true;
            this.tabDesc.Controls.Add(this.chkShowDesc);

            AddLabel("Top pos (mm):", 15, 55, this.tabDesc);
            SetupUpDown(this.numDescTop, 120, 53, 0, 100, 0.1m, this.tabDesc);

            AddLabel("Left pos (mm):", 15, 90, this.tabDesc);
            SetupUpDown(this.numDescLeft, 120, 88, 0, 100, 0.1m, this.tabDesc);

            this.btnDescFont.Location = new System.Drawing.Point(15, 130);
            this.btnDescFont.Size = new System.Drawing.Size(100, 25);
            this.btnDescFont.Text = "Select Font...";
            this.btnDescFont.UseVisualStyleBackColor = true;
            this.tabDesc.Controls.Add(this.btnDescFont);

            this.lblDescFontInfo.AutoSize = true;
            this.lblDescFontInfo.Location = new System.Drawing.Point(125, 135);
            this.lblDescFontInfo.Text = "Font: Segoe UI, 7pt";
            this.tabDesc.Controls.Add(this.lblDescFontInfo);

            // 
            // tabPrice (Price Symbols & Layout)
            // 
            this.tabPrice.BackColor = System.Drawing.Color.White;
            this.tabPrice.Padding = new System.Windows.Forms.Padding(10);
            this.tabPrice.Text = "Harga";

            this.chkShowPrice.AutoSize = true;
            this.chkShowPrice.Location = new System.Drawing.Point(15, 20);
            this.chkShowPrice.Text = "Show Product Price Text";
            this.chkShowPrice.UseVisualStyleBackColor = true;
            this.tabPrice.Controls.Add(this.chkShowPrice);

            AddLabel("Top pos (mm):", 15, 55, this.tabPrice);
            SetupUpDown(this.numPriceTop, 120, 53, 0, 100, 0.1m, this.tabPrice);

            AddLabel("Left pos (mm):", 15, 90, this.tabPrice);
            SetupUpDown(this.numPriceLeft, 120, 88, 0, 100, 0.1m, this.tabPrice);

            AddLabel("Currency:", 240, 20, this.tabPrice);
            this.txtPriceSymbol.Location = new System.Drawing.Point(340, 18);
            this.txtPriceSymbol.Size = new System.Drawing.Size(95, 23);
            this.tabPrice.Controls.Add(this.txtPriceSymbol);

            AddLabel("Decimals:", 240, 55, this.tabPrice);
            SetupUpDown(this.numPriceDecimal, 340, 53, 0, 4, 1m, this.tabPrice);

            this.chkPriceGrouping.AutoSize = true;
            this.chkPriceGrouping.Location = new System.Drawing.Point(242, 90);
            this.chkPriceGrouping.Text = "Use Thousands Grouping (.)";
            this.chkPriceGrouping.UseVisualStyleBackColor = true;
            this.tabPrice.Controls.Add(this.chkPriceGrouping);

            this.btnPriceFont.Location = new System.Drawing.Point(15, 130);
            this.btnPriceFont.Size = new System.Drawing.Size(100, 25);
            this.btnPriceFont.Text = "Select Font...";
            this.btnPriceFont.UseVisualStyleBackColor = true;
            this.tabPrice.Controls.Add(this.btnPriceFont);

            this.lblPriceFontInfo.AutoSize = true;
            this.lblPriceFontInfo.Location = new System.Drawing.Point(125, 135);
            this.lblPriceFontInfo.Text = "Font: Segoe UI, 8pt, Bold";
            this.tabPrice.Controls.Add(this.lblPriceFontInfo);

            // 
            // tabCompany (Store Branding Name)
            // 
            this.tabCompany.BackColor = System.Drawing.Color.White;
            this.tabCompany.Padding = new System.Windows.Forms.Padding(10);
            this.tabCompany.Text = "Company";

            this.chkShowCompany.AutoSize = true;
            this.chkShowCompany.Location = new System.Drawing.Point(15, 20);
            this.chkShowCompany.Text = "Show Company/Branding Name";
            this.chkShowCompany.UseVisualStyleBackColor = true;
            this.tabCompany.Controls.Add(this.chkShowCompany);

            AddLabel("Branding:", 15, 55, this.tabCompany);
            this.txtCompanyText.Location = new System.Drawing.Point(120, 53);
            this.txtCompanyText.Size = new System.Drawing.Size(200, 23);
            this.tabCompany.Controls.Add(this.txtCompanyText);

            AddLabel("Top pos (mm):", 15, 90, this.tabCompany);
            SetupUpDown(this.numCompanyTop, 120, 88, 0, 100, 0.1m, this.tabCompany);

            AddLabel("Left pos (mm):", 15, 125, this.tabCompany);
            SetupUpDown(this.numCompanyLeft, 120, 123, 0, 100, 0.1m, this.tabCompany);

            this.btnCompanyFont.Location = new System.Drawing.Point(15, 165);
            this.btnCompanyFont.Size = new System.Drawing.Size(100, 25);
            this.btnCompanyFont.Text = "Select Font...";
            this.btnCompanyFont.UseVisualStyleBackColor = true;
            this.tabCompany.Controls.Add(this.btnCompanyFont);

            this.lblCompanyFontInfo.AutoSize = true;
            this.lblCompanyFontInfo.Location = new System.Drawing.Point(125, 170);
            this.lblCompanyFontInfo.Text = "Font: Segoe UI, 6pt, Bold";
            this.tabCompany.Controls.Add(this.lblCompanyFontInfo);

            // 
            // tabOptional (Special Headers)
            // 
            this.tabOptional.BackColor = System.Drawing.Color.White;
            this.tabOptional.Padding = new System.Windows.Forms.Padding(10);
            this.tabOptional.Text = "Optional";

            this.chkShowHeaders.AutoSize = true;
            this.chkShowHeaders.Location = new System.Drawing.Point(15, 20);
            this.chkShowHeaders.Text = "Show Special Promo Headers";
            this.chkShowHeaders.UseVisualStyleBackColor = true;
            this.tabOptional.Controls.Add(this.chkShowHeaders);

            AddLabel("Header 1:", 15, 55, this.tabOptional);
            this.txtHeader1.Location = new System.Drawing.Point(120, 53);
            this.txtHeader1.Size = new System.Drawing.Size(100, 23);
            this.tabOptional.Controls.Add(this.txtHeader1);

            AddLabel("Header 2:", 15, 90, this.tabOptional);
            this.txtHeader2.Location = new System.Drawing.Point(120, 88);
            this.txtHeader2.Size = new System.Drawing.Size(100, 23);
            this.tabOptional.Controls.Add(this.txtHeader2);

            AddLabel("Header 3:", 15, 125, this.tabOptional);
            this.txtHeader3.Location = new System.Drawing.Point(120, 123);
            this.txtHeader3.Size = new System.Drawing.Size(100, 23);
            this.tabOptional.Controls.Add(this.txtHeader3);

            AddLabel("Top pos (mm):", 240, 55, this.tabOptional);
            SetupUpDown(this.numHeaderTop, 340, 53, 0, 100, 0.1m, this.tabOptional);

            AddLabel("Left pos (mm):", 240, 90, this.tabOptional);
            SetupUpDown(this.numHeaderLeft, 340, 88, 0, 100, 0.1m, this.tabOptional);

            this.btnHeaderFont.Location = new System.Drawing.Point(240, 130);
            this.btnHeaderFont.Size = new System.Drawing.Size(100, 25);
            this.btnHeaderFont.Text = "Select Font...";
            this.btnHeaderFont.UseVisualStyleBackColor = true;
            this.tabOptional.Controls.Add(this.btnHeaderFont);

            this.lblHeaderFontInfo.AutoSize = true;
            this.lblHeaderFontInfo.Location = new System.Drawing.Point(240, 165);
            this.lblHeaderFontInfo.Text = "Font: Segoe UI, 6.5pt, Italic";
            this.tabOptional.Controls.Add(this.lblHeaderFontInfo);

            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(312, 330);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(393, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            
            // 
            // FormSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 368);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pgSetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Label Setup";
            this.pgSetup.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTopMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeftMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLabelWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLabelHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            this.tabBarcode.ResumeLayout(false);
            this.tabBarcode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBarcodeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBarcodeTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBarcodeLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBarWidth)).EndInit();
            this.tabDesc.ResumeLayout(false);
            this.tabDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDescTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescLeft)).EndInit();
            this.tabPrice.ResumeLayout(false);
            this.tabPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceDecimal)).EndInit();
            this.tabCompany.ResumeLayout(false);
            this.tabCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCompanyTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompanyLeft)).EndInit();
            this.tabOptional.ResumeLayout(false);
            this.tabOptional.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeaderTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeaderLeft)).EndInit();
            this.ResumeLayout(false);
        }

        private void AddLabel(string text, int x, int y, System.Windows.Forms.Control parent)
        {
            var lbl = new System.Windows.Forms.Label();
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Text = text;
            parent.Controls.Add(lbl);
        }

        private void SetupUpDown(System.Windows.Forms.NumericUpDown nud, int x, int y, decimal min, decimal max, decimal increment, System.Windows.Forms.Control parent)
        {
            nud.Location = new System.Drawing.Point(x, y);
            nud.Size = new System.Drawing.Size(65, 23);
            nud.Minimum = min;
            nud.Maximum = max;
            nud.Increment = increment;
            
            // Set decimal places based on increment
            if (increment == 0.01m) nud.DecimalPlaces = 2;
            else if (increment == 0.1m) nud.DecimalPlaces = 1;
            else nud.DecimalPlaces = 0;

            parent.Controls.Add(nud);
        }
        #endregion

        private System.Windows.Forms.TabControl pgSetup;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabBarcode;
        private System.Windows.Forms.TabPage tabDesc;
        private System.Windows.Forms.TabPage tabPrice;
        private System.Windows.Forms.TabPage tabCompany;
        private System.Windows.Forms.TabPage tabOptional;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        // General
        public System.Windows.Forms.NumericUpDown numTopMargin;
        public System.Windows.Forms.NumericUpDown numLeftMargin;
        public System.Windows.Forms.NumericUpDown numLabelWidth;
        public System.Windows.Forms.NumericUpDown numLabelHeight;
        public System.Windows.Forms.NumericUpDown numVGap;
        public System.Windows.Forms.NumericUpDown numHGap;
        public System.Windows.Forms.NumericUpDown numColumns;
        public System.Windows.Forms.NumericUpDown numRows;
        public System.Windows.Forms.CheckBox chkShowGuide;
        public System.Windows.Forms.ComboBox cmbPreset;

        // Barcode
        public System.Windows.Forms.ComboBox cmbBarcodeType;
        public System.Windows.Forms.NumericUpDown numBarcodeHeight;
        public System.Windows.Forms.NumericUpDown numBarcodeTop;
        public System.Windows.Forms.NumericUpDown numBarcodeLeft;
        public System.Windows.Forms.TextBox txtBarcodePrefiks;
        public System.Windows.Forms.NumericUpDown numBarWidth;
        public System.Windows.Forms.CheckBox chkPrintHuman;
        public System.Windows.Forms.ComboBox cmbBarcodeAlign;

        // Desc
        public System.Windows.Forms.CheckBox chkShowDesc;
        public System.Windows.Forms.NumericUpDown numDescTop;
        public System.Windows.Forms.NumericUpDown numDescLeft;
        public System.Windows.Forms.Button btnDescFont;
        public System.Windows.Forms.Label lblDescFontInfo;

        // Price
        public System.Windows.Forms.CheckBox chkShowPrice;
        public System.Windows.Forms.NumericUpDown numPriceTop;
        public System.Windows.Forms.NumericUpDown numPriceLeft;
        public System.Windows.Forms.TextBox txtPriceSymbol;
        public System.Windows.Forms.NumericUpDown numPriceDecimal;
        public System.Windows.Forms.CheckBox chkPriceGrouping;
        public System.Windows.Forms.Button btnPriceFont;
        public System.Windows.Forms.Label lblPriceFontInfo;

        // Company
        public System.Windows.Forms.CheckBox chkShowCompany;
        public System.Windows.Forms.TextBox txtCompanyText;
        public System.Windows.Forms.NumericUpDown numCompanyTop;
        public System.Windows.Forms.NumericUpDown numCompanyLeft;
        public System.Windows.Forms.Button btnCompanyFont;
        public System.Windows.Forms.Label lblCompanyFontInfo;

        // Optional Headers
        public System.Windows.Forms.CheckBox chkShowHeaders;
        public System.Windows.Forms.TextBox txtHeader1;
        public System.Windows.Forms.TextBox txtHeader2;
        public System.Windows.Forms.TextBox txtHeader3;
        public System.Windows.Forms.NumericUpDown numHeaderTop;
        public System.Windows.Forms.NumericUpDown numHeaderLeft;
        public System.Windows.Forms.Button btnHeaderFont;
        public System.Windows.Forms.Label lblHeaderFontInfo;
    }
}
