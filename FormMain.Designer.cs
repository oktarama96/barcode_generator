namespace NetBarcodeDotNet
{
    partial class FormMain
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
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnImportList = new System.Windows.Forms.Button();
            this.btnExportList = new System.Windows.Forms.Button();
            this.btnLoadSample = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSlotSelection = new System.Windows.Forms.Panel();
            this.lblSlotTitle = new System.Windows.Forms.Label();
            this.btnCheckAllSlots = new System.Windows.Forms.Button();
            this.btnUncheckAllSlots = new System.Windows.Forms.Button();
            this.pnlCheckScroll = new System.Windows.Forms.Panel();

            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnlLeftSidebar = new System.Windows.Forms.Panel();
            this.lblManualTitle = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numCopies = new System.Windows.Forms.NumericUpDown();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnUpdateItem = new System.Windows.Forms.Button();
            this.btnClearFields = new System.Windows.Forms.Button();
            this.btnDollar = new System.Windows.Forms.Button();
            this.btnEuro = new System.Windows.Forms.Button();
            this.btnRupiah = new System.Windows.Forms.Button();

            this.splitRight = new System.Windows.Forms.SplitContainer();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCopies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlPreviewContainer = new System.Windows.Forms.Panel();
            this.pnlPreviewHeader = new System.Windows.Forms.Panel();
            this.lblPreviewTitle = new System.Windows.Forms.Label();
            this.cmbZoom = new System.Windows.Forms.ComboBox();
            this.pnlCanvasScroll = new System.Windows.Forms.Panel();
            this.pbCanvas = new System.Windows.Forms.PictureBox();

            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlLeftSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.Panel2.SuspendLayout();
            this.splitRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlPreviewContainer.SuspendLayout();
            this.pnlPreviewHeader.SuspendLayout();
            this.pnlCanvasScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59))))); // Sleek dark charcoal
            this.pnlTopBar.Controls.Add(this.lblTitle);
            this.pnlTopBar.Controls.Add(this.btnSetup);
            this.pnlTopBar.Controls.Add(this.btnPrint);
            this.pnlTopBar.Controls.Add(this.btnImportList);
            this.pnlTopBar.Controls.Add(this.btnExportList);
            this.pnlTopBar.Controls.Add(this.btnLoadSample);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1100, 60);
            this.pnlTopBar.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 25);
            this.lblTitle.Text = "Oktarama Barcode v1.0";

            // 
            // btnSetup
            // 
            this.btnSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnSetup.FlatAppearance.BorderSize = 0;
            this.btnSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSetup.ForeColor = System.Drawing.Color.White;
            this.btnSetup.Location = new System.Drawing.Point(985, 12);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(100, 35);
            this.btnSetup.Text = "🔧 Label Setup";
            this.btnSetup.UseVisualStyleBackColor = false;

            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129))))); // Vibrant Green
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(875, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 35);
            this.btnPrint.Text = "🖨️ Print Sheet";
            this.btnPrint.UseVisualStyleBackColor = false;

            // 
            // btnImportList
            // 
            this.btnImportList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnImportList.FlatAppearance.BorderSize = 0;
            this.btnImportList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnImportList.ForeColor = System.Drawing.Color.White;
            this.btnImportList.Location = new System.Drawing.Point(765, 12);
            this.btnImportList.Name = "btnImportList";
            this.btnImportList.Size = new System.Drawing.Size(100, 35);
            this.btnImportList.Text = "📥 Import List";
            this.btnImportList.UseVisualStyleBackColor = false;

            // 
            // btnExportList
            // 
            this.btnExportList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnExportList.FlatAppearance.BorderSize = 0;
            this.btnExportList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportList.ForeColor = System.Drawing.Color.White;
            this.btnExportList.Location = new System.Drawing.Point(655, 12);
            this.btnExportList.Size = new System.Drawing.Size(100, 35);
            this.btnExportList.Text = "📤 Export List";
            this.btnExportList.UseVisualStyleBackColor = false;

            // 
            // btnLoadSample
            // 
            this.btnLoadSample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229))))); // Indigo
            this.btnLoadSample.FlatAppearance.BorderSize = 0;
            this.btnLoadSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadSample.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoadSample.ForeColor = System.Drawing.Color.White;
            this.btnLoadSample.Location = new System.Drawing.Point(525, 12);
            this.btnLoadSample.Size = new System.Drawing.Size(120, 35);
            this.btnLoadSample.Text = "✨ Load Samples";
            this.btnLoadSample.UseVisualStyleBackColor = false;

            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 60);
            this.splitMain.Name = "splitMain";
            
            // splitMain.Panel1 (Left Sidebar)
            this.splitMain.Panel1.Controls.Add(this.pnlLeftSidebar);
            this.splitMain.Panel1MinSize = 250;
            
            // splitMain.Panel2 (Grid + Canvas)
            this.splitMain.Panel2.Controls.Add(this.splitRight);
            this.splitMain.Size = new System.Drawing.Size(1100, 640);
            this.splitMain.SplitterDistance = 270;
            this.splitMain.TabIndex = 1;

            // 
            this.pnlLeftSidebar.Controls.Add(this.pnlSlotSelection);
            this.pnlLeftSidebar.Controls.Add(this.btnRupiah);
            this.pnlLeftSidebar.Controls.Add(this.btnEuro);
            this.pnlLeftSidebar.Controls.Add(this.btnDollar);
            this.pnlLeftSidebar.Controls.Add(this.btnClearFields);
            this.pnlLeftSidebar.Controls.Add(this.btnUpdateItem);
            this.pnlLeftSidebar.Controls.Add(this.btnAddItem);
            this.pnlLeftSidebar.Controls.Add(this.numCopies);
            this.pnlLeftSidebar.Controls.Add(this.numPrice);
            this.pnlLeftSidebar.Controls.Add(this.txtDesc);
            this.pnlLeftSidebar.Controls.Add(this.txtBarcode);
            this.pnlLeftSidebar.Controls.Add(this.lblManualTitle);
            this.pnlLeftSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftSidebar.Name = "pnlLeftSidebar";
            this.pnlLeftSidebar.Size = new System.Drawing.Size(270, 640);
            this.pnlLeftSidebar.TabIndex = 0;

            // 
            // pnlSlotSelection
            // 
            this.pnlSlotSelection.Controls.Add(this.lblSlotTitle);
            this.pnlSlotSelection.Controls.Add(this.btnCheckAllSlots);
            this.pnlSlotSelection.Controls.Add(this.btnUncheckAllSlots);
            this.pnlSlotSelection.Controls.Add(this.pnlCheckScroll);
            this.pnlSlotSelection.Location = new System.Drawing.Point(15, 380);
            this.pnlSlotSelection.Name = "pnlSlotSelection";
            this.pnlSlotSelection.Size = new System.Drawing.Size(240, 165);
            this.pnlSlotSelection.TabIndex = 11;
            // 
            // lblSlotTitle
            // 
            this.lblSlotTitle.AutoSize = true;
            this.lblSlotTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSlotTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSlotTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSlotTitle.Size = new System.Drawing.Size(100, 15);
            this.lblSlotTitle.Text = "Print Slots Grid:";
            // 
            // btnCheckAllSlots
            // 
            this.btnCheckAllSlots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnCheckAllSlots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAllSlots.FlatAppearance.BorderSize = 0;
            this.btnCheckAllSlots.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCheckAllSlots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCheckAllSlots.Location = new System.Drawing.Point(120, 0);
            this.btnCheckAllSlots.Name = "btnCheckAllSlots";
            this.btnCheckAllSlots.Size = new System.Drawing.Size(55, 18);
            this.btnCheckAllSlots.TabIndex = 1;
            this.btnCheckAllSlots.Text = "Select All";
            this.btnCheckAllSlots.UseVisualStyleBackColor = false;
            // 
            // btnUncheckAllSlots
            // 
            this.btnUncheckAllSlots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnUncheckAllSlots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUncheckAllSlots.FlatAppearance.BorderSize = 0;
            this.btnUncheckAllSlots.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUncheckAllSlots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnUncheckAllSlots.Location = new System.Drawing.Point(180, 0);
            this.btnUncheckAllSlots.Name = "btnUncheckAllSlots";
            this.btnUncheckAllSlots.Size = new System.Drawing.Size(60, 18);
            this.btnUncheckAllSlots.TabIndex = 2;
            this.btnUncheckAllSlots.Text = "Clear All";
            this.btnUncheckAllSlots.UseVisualStyleBackColor = false;
            // 
            // pnlCheckScroll
            // 
            this.pnlCheckScroll.AutoScroll = true;
            this.pnlCheckScroll.BackColor = System.Drawing.Color.White;
            this.pnlCheckScroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCheckScroll.Location = new System.Drawing.Point(0, 22);
            this.pnlCheckScroll.Name = "pnlCheckScroll";
            this.pnlCheckScroll.Size = new System.Drawing.Size(240, 140);
            this.pnlCheckScroll.TabIndex = 3;

            // 
            // lblManualTitle
            // 
            this.lblManualTitle.AutoSize = true;
            this.lblManualTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblManualTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblManualTitle.Location = new System.Drawing.Point(15, 20);
            this.lblManualTitle.Size = new System.Drawing.Size(147, 20);
            this.lblManualTitle.Text = "Manual Item Entry";

            // 
            // Textboxes & Numeric Fields Labels
            // 
            AddSidebarLabel("Barcode / Code:", 15, 60);
            this.txtBarcode.Location = new System.Drawing.Point(15, 80);
            this.txtBarcode.Size = new System.Drawing.Size(240, 23);
            this.pnlLeftSidebar.Controls.Add(this.txtBarcode);

            AddSidebarLabel("Item Description / Name:", 15, 120);
            this.txtDesc.Location = new System.Drawing.Point(15, 140);
            this.txtDesc.Size = new System.Drawing.Size(240, 23);
            this.pnlLeftSidebar.Controls.Add(this.txtDesc);

            AddSidebarLabel("Selling Price:", 15, 180);
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(15, 200);
            this.numPrice.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.numPrice.Size = new System.Drawing.Size(140, 23);
            this.pnlLeftSidebar.Controls.Add(this.numPrice);

            // Quick Currency Selector Buttons
            this.btnRupiah.Location = new System.Drawing.Point(165, 200);
            this.btnRupiah.Size = new System.Drawing.Size(30, 23);
            this.btnRupiah.Text = "Rp";
            this.btnRupiah.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pnlLeftSidebar.Controls.Add(this.btnRupiah);

            this.btnDollar.Location = new System.Drawing.Point(198, 200);
            this.btnDollar.Size = new System.Drawing.Size(24, 23);
            this.btnDollar.Text = "$";
            this.btnDollar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pnlLeftSidebar.Controls.Add(this.btnDollar);

            this.btnEuro.Location = new System.Drawing.Point(227, 200);
            this.btnEuro.Size = new System.Drawing.Size(24, 23);
            this.btnEuro.Text = "€";
            this.btnEuro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pnlLeftSidebar.Controls.Add(this.btnEuro);

            AddSidebarLabel("Copies to Print:", 15, 240);
            this.numCopies.Location = new System.Drawing.Point(15, 260);
            this.numCopies.Minimum = 1;
            this.numCopies.Maximum = 500;
            this.numCopies.Value = 1;
            this.numCopies.Size = new System.Drawing.Size(100, 23);
            this.pnlLeftSidebar.Controls.Add(this.numCopies);

            // 
            // Action Buttons
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(15, 300);
            this.btnAddItem.Size = new System.Drawing.Size(240, 32);
            this.btnAddItem.Text = "➕ Save as New Product";
            this.btnAddItem.UseVisualStyleBackColor = false;

            this.btnUpdateItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnUpdateItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateItem.ForeColor = System.Drawing.Color.White;
            this.btnUpdateItem.Location = new System.Drawing.Point(15, 340);
            this.btnUpdateItem.Size = new System.Drawing.Size(115, 32);
            this.btnUpdateItem.Text = "💾 Save Changes";
            this.btnUpdateItem.UseVisualStyleBackColor = false;
            
            this.btnClearFields.BackColor = System.Drawing.Color.White;
            this.btnClearFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFields.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnClearFields.Location = new System.Drawing.Point(140, 340);
            this.btnClearFields.Size = new System.Drawing.Size(115, 32);
            this.btnClearFields.Text = "✨ New / Clear";
            this.btnClearFields.UseVisualStyleBackColor = false;

            // 
            // splitRight (Grid vs Canvas)
            // 
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.Location = new System.Drawing.Point(0, 0);
            this.splitRight.Name = "splitRight";
            
            // splitRight.Panel1 (Grid View)
            this.splitRight.Panel1.Controls.Add(this.dgvProducts);
            this.splitRight.Panel1MinSize = 250;
            
            // splitRight.Panel2 (Label Sheet Canvas)
            this.splitRight.Panel2.Controls.Add(this.pnlPreviewContainer);
            this.splitRight.Size = new System.Drawing.Size(826, 640);
            this.splitRight.SplitterDistance = 350;
            this.splitRight.TabIndex = 0;

            // 
            // dgvProducts (Grid of queued labels)
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.ColumnHeadersHeight = 25;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBarcode,
            this.colName,
            this.colPrice,
            this.colCopies,
            this.colDelete});
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(350, 640);
            this.dgvProducts.TabIndex = 0;

            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Width = 90;

            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 65;

            // 
            // colCopies
            // 
            this.colCopies.DataPropertyName = "CopyCount";
            this.colCopies.HeaderText = "Copies";
            this.colCopies.Name = "colCopies";
            this.colCopies.Width = 50;

            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = "🗑️";
            this.colDelete.UseColumnTextForButtonValue = true;
            this.colDelete.Width = 35;
            this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.colDelete.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.colDelete.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.colDelete.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            // 
            // pnlPreviewContainer
            // 
            this.pnlPreviewContainer.Controls.Add(this.pnlCanvasScroll);
            this.pnlPreviewContainer.Controls.Add(this.pnlPreviewHeader);
            this.pnlPreviewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPreviewContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlPreviewContainer.Name = "pnlPreviewContainer";
            this.pnlPreviewContainer.Size = new System.Drawing.Size(472, 640);
            this.pnlPreviewContainer.TabIndex = 0;

            // 
            // pnlPreviewHeader
            // 
            this.pnlPreviewHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlPreviewHeader.Controls.Add(this.cmbZoom);
            this.pnlPreviewHeader.Controls.Add(this.lblPreviewTitle);
            this.pnlPreviewHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPreviewHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlPreviewHeader.Name = "pnlPreviewHeader";
            this.pnlPreviewHeader.Size = new System.Drawing.Size(472, 35);
            this.pnlPreviewHeader.TabIndex = 0;

            // 
            // lblPreviewTitle
            // 
            this.lblPreviewTitle.AutoSize = true;
            this.lblPreviewTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPreviewTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPreviewTitle.Location = new System.Drawing.Point(10, 8);
            this.lblPreviewTitle.Name = "lblPreviewTitle";
            this.lblPreviewTitle.Size = new System.Drawing.Size(107, 17);
            this.lblPreviewTitle.Text = "Live Print Preview";

            // 
            // cmbZoom
            // 
            this.cmbZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZoom.Items.AddRange(new object[] { "200%", "150%", "100%", "75%", "Auto Fit" });
            this.cmbZoom.Location = new System.Drawing.Point(375, 6);
            this.cmbZoom.Name = "cmbZoom";
            this.cmbZoom.Size = new System.Drawing.Size(85, 23);
            this.cmbZoom.TabIndex = 1;

            // 
            // pnlCanvasScroll
            // 
            this.pnlCanvasScroll.AutoScroll = true;
            this.pnlCanvasScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240))))); // Slate Gray canvas background
            this.pnlCanvasScroll.Controls.Add(this.pbCanvas);
            this.pnlCanvasScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCanvasScroll.Location = new System.Drawing.Point(0, 35);
            this.pnlCanvasScroll.Name = "pnlCanvasScroll";
            this.pnlCanvasScroll.Size = new System.Drawing.Size(472, 605);
            this.pnlCanvasScroll.TabIndex = 1;

            // 
            // pbCanvas (Double buffered preview component)
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.White;
            this.pbCanvas.Location = new System.Drawing.Point(20, 20);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(400, 500);
            this.pbCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;

            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlTopBar);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oktarama Barcode Generator";
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlLeftSidebar.ResumeLayout(false);
            this.pnlLeftSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).EndInit();
            this.splitRight.Panel1.ResumeLayout(false);
            this.splitRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlPreviewContainer.ResumeLayout(false);
            this.pnlPreviewHeader.ResumeLayout(false);
            this.pnlPreviewHeader.PerformLayout();
            this.pnlCanvasScroll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();

            // 
            // toolTipMain
            // 
            this.toolTipMain = new System.Windows.Forms.ToolTip();
            this.toolTipMain.AutomaticDelay = 500;
            this.toolTipMain.AutoPopDelay = 8000;
            this.toolTipMain.InitialDelay = 500;
            this.toolTipMain.ReshowDelay = 100;
            this.toolTipMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipMain.ToolTipTitle = "Quick Help";
            
            this.toolTipMain.SetToolTip(this.btnSetup, "Setup page size, label sticker margins, column/row count, gaps, and custom fonts.");
            this.toolTipMain.SetToolTip(this.btnPrint, "Send the current label sheet layout to your physical printer or save as a PDF file.");
            this.toolTipMain.SetToolTip(this.btnImportList, "Load products queue from an external CSV or JSON file.");
            this.toolTipMain.SetToolTip(this.btnExportList, "Export your current queued products list to a CSV or JSON file.");
            this.toolTipMain.SetToolTip(this.btnLoadSample, "Load dummy retail products into the queue to test layouts easily.");
            this.toolTipMain.SetToolTip(this.btnAddItem, "Add and save the entered product details as a new row in the queue table.");
            this.toolTipMain.SetToolTip(this.btnUpdateItem, "Save changes/edits to the product that is currently selected in the table.");
            this.toolTipMain.SetToolTip(this.btnClearFields, "Reset and clear all manual entry fields to quickly start entering a new product.");
            this.toolTipMain.SetToolTip(this.btnRupiah, "Set price currency symbol formatting to Indonesian Rupiah (Rp).");
            this.toolTipMain.SetToolTip(this.btnDollar, "Set price currency symbol formatting to US Dollar ($).");
            this.toolTipMain.SetToolTip(this.btnEuro, "Set price currency symbol formatting to Euro (€).");
            this.toolTipMain.SetToolTip(this.btnCheckAllSlots, "Check all slots in the print grid layout.");
            this.toolTipMain.SetToolTip(this.btnUncheckAllSlots, "Uncheck all slots to skip printing labels in all locations.");
            this.toolTipMain.SetToolTip(this.cmbZoom, "Select canvas scaling zoom ratio (e.g. 100%, Auto Fit).");

            this.ResumeLayout(false);
        }

        private void AddSidebarLabel(string text, int x, int y)
        {
            var lbl = new System.Windows.Forms.Label();
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            lbl.Text = text;
            this.pnlLeftSidebar.Controls.Add(lbl);
        }
        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnImportList;
        private System.Windows.Forms.Button btnExportList;
        private System.Windows.Forms.Button btnLoadSample;

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlLeftSidebar;
        private System.Windows.Forms.Label lblManualTitle;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numCopies;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnUpdateItem;
        private System.Windows.Forms.Button btnClearFields;
        private System.Windows.Forms.Button btnDollar;
        private System.Windows.Forms.Button btnEuro;
        private System.Windows.Forms.Button btnRupiah;

        private System.Windows.Forms.SplitContainer splitRight;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCopies;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;

        private System.Windows.Forms.Panel pnlPreviewContainer;
        private System.Windows.Forms.Panel pnlPreviewHeader;
        private System.Windows.Forms.Label lblPreviewTitle;
        private System.Windows.Forms.ComboBox cmbZoom;
        private System.Windows.Forms.Panel pnlCanvasScroll;
        private System.Windows.Forms.PictureBox pbCanvas;

        // Custom label slot selection grid fields
        public System.Windows.Forms.Panel pnlSlotSelection;
        public System.Windows.Forms.Label lblSlotTitle;
        public System.Windows.Forms.Button btnCheckAllSlots;
        public System.Windows.Forms.Button btnUncheckAllSlots;
        public System.Windows.Forms.Panel pnlCheckScroll;
        private System.Windows.Forms.ToolTip toolTipMain;
    }
}
