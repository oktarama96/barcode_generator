using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace NetBarcodeDotNet
{
    public partial class FormMain : Form
    {
        private BindingList<ProductItem> productsList = new BindingList<ProductItem>();
        private LabelTemplate currentTemplate = LabelTemplate.GetDefault();
        private string templateFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "template.json");
        private string itemsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "items.json");

        // Printing fields
        private int printItemIndex = 0;
        private int printCopyRemaining = 0;
        private bool[] selectedSlots = Array.Empty<bool>();

        public FormMain()
        {
            InitializeComponent();

            // Setup DataGridView
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = productsList;

            // Load saved settings
            currentTemplate = LabelTemplate.Load(templateFilePath);
            LoadProductsList();

            // Bind Event Handlers
            btnSetup.Click += BtnSetup_Click;
            btnPrint.Click += BtnPrint_Click;
            btnImportList.Click += BtnImportList_Click;
            btnExportList.Click += BtnExportList_Click;
            btnLoadSample.Click += BtnLoadSample_Click;

            btnAddItem.Click += BtnAddItem_Click;
            btnUpdateItem.Click += BtnUpdateItem_Click;
            dgvProducts.CellContentClick += DgvProducts_CellContentClick;
            btnClearFields.Click += BtnClearFields_Click;

            btnRupiah.Click += (s, e) => { SetPriceCurrency("Rp"); };
            btnDollar.Click += (s, e) => { SetPriceCurrency("$"); };
            btnEuro.Click += (s, e) => { SetPriceCurrency("€"); };

            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
            pbCanvas.Paint += PbCanvas_Paint;
            cmbZoom.SelectedIndexChanged += CmbZoom_SelectedIndexChanged;

            btnCheckAllSlots.Click += (s, e) => SetAllSlotsState(true);
            btnUncheckAllSlots.Click += (s, e) => SetAllSlotsState(false);

            // Default zoom to "Auto Fit"
            cmbZoom.SelectedIndex = 4;

            // Initialize slot checkboxes layout
            RegenerateSlotCheckboxes();

            // Force refresh UI preview
            UpdateCanvasDimensions();
        }

        private void SetPriceCurrency(string symbol)
        {
            currentTemplate.PriceSymbol = symbol;
            currentTemplate.Save(templateFilePath);
            pbCanvas.Invalidate();
        }

        private void LoadProductsList()
        {
            try
            {
                if (File.Exists(itemsFilePath))
                {
                    string json = File.ReadAllText(itemsFilePath);
                    var list = JsonSerializer.Deserialize<BindingList<ProductItem>>(json);
                    if (list != null)
                    {
                        productsList.Clear();
                        foreach (var item in list)
                        {
                            productsList.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load saved items list: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveProductsList()
        {
            try
            {
                string json = JsonSerializer.Serialize(productsList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(itemsFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to auto-save products list: " + ex.Message);
            }
        }

        private void UpdateCanvasDimensions()
        {
            // Base sheet page size (A4 defaults to 210mm x 297mm)
            // But we size the sheet canvas based on columns, label dimensions, and gaps to dynamically represent the print zone
            float totalWidthMm = currentTemplate.LeftMargin * 2 + 
                                 currentTemplate.Columns * currentTemplate.LabelWidth + 
                                 (currentTemplate.Columns - 1) * currentTemplate.HorizontalGap;
            float totalHeightMm = currentTemplate.TopMargin * 2 + 
                                  currentTemplate.Rows * currentTemplate.LabelHeight + 
                                  (currentTemplate.Rows - 1) * currentTemplate.VerticalGap;

            // Convert to pixels at standard screen DPI (96)
            float baseWidth = BarcodeRenderer.MmToUnits(totalWidthMm, 96f);
            float baseHeight = BarcodeRenderer.MmToUnits(totalHeightMm, 96f);

            // Apply zoom scaling factor
            float scale = GetZoomScale();
            pbCanvas.Width = (int)(baseWidth * scale);
            pbCanvas.Height = (int)(baseHeight * scale);

            pbCanvas.Invalidate();
        }

        private float GetZoomScale()
        {
            switch (cmbZoom.SelectedItem?.ToString())
            {
                case "200%": return 2.0f;
                case "150%": return 1.5f;
                case "100%": return 1.0f;
                case "75%": return 0.75f;
                case "Auto Fit":
                default:
                    // Auto scale to fit the container width (with padding)
                    float containerWidth = pnlCanvasScroll.Width - 50;
                    float baseWidth = BarcodeRenderer.MmToUnits(
                        currentTemplate.LeftMargin * 2 + 
                        currentTemplate.Columns * currentTemplate.LabelWidth + 
                        (currentTemplate.Columns - 1) * currentTemplate.HorizontalGap, 96f);
                    float ratio = containerWidth / baseWidth;
                    return Math.Max(0.25f, Math.Min(ratio, 1.5f)); // Cap between 25% and 150%
            }
        }

        private void CmbZoom_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateCanvasDimensions();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (cmbZoom.SelectedItem?.ToString() == "Auto Fit")
            {
                UpdateCanvasDimensions();
            }
        }

        #region Sidebar Operations
        private void DgvProducts_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var row = dgvProducts.SelectedRows[0];
                txtBarcode.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
                txtDesc.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                numPrice.Value = row.Cells[2].Value is decimal price ? price : 0.00m;
                numCopies.Value = row.Cells[3].Value is int copies ? copies : 1;
            }
        }

        private void BtnAddItem_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Please enter a valid barcode value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create new item
            var item = new ProductItem(
                txtBarcode.Text.Trim(),
                txtDesc.Text.Trim(),
                numPrice.Value,
                (int)numCopies.Value
            );

            productsList.Add(item);
            SaveProductsList();
            pbCanvas.Invalidate();
            ClearInputFields();
        }

        private void BtnUpdateItem_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int index = dgvProducts.SelectedRows[0].Index;
                productsList[index].Barcode = txtBarcode.Text.Trim();
                productsList[index].Name = txtDesc.Text.Trim();
                productsList[index].Price = numPrice.Value;
                productsList[index].CopyCount = (int)numCopies.Value;

                dgvProducts.Refresh();
                SaveProductsList();
                pbCanvas.Invalidate();
            }
        }

        private void DgvProducts_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Columns[e.ColumnIndex].Name == "colDelete")
            {
                productsList.RemoveAt(e.RowIndex);
                SaveProductsList();
                pbCanvas.Invalidate();
                ClearInputFields();
            }
        }

        private void BtnClearFields_Click(object? sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            txtBarcode.Clear();
            txtDesc.Clear();
            numPrice.Value = 0.00m;
            numCopies.Value = 1;
            dgvProducts.ClearSelection();
        }
        #endregion

        #region Toolbar Configurations
        private void BtnSetup_Click(object? sender, EventArgs e)
        {
            using (var setupForm = new FormSetup(currentTemplate))
            {
                if (setupForm.ShowDialog() == DialogResult.OK)
                {
                    currentTemplate.Save(templateFilePath);
                    RegenerateSlotCheckboxes();
                    UpdateCanvasDimensions();
                }
            }
        }

        private void BtnLoadSample_Click(object? sender, EventArgs e)
        {
            productsList.Clear();
            
            // Generate clean sample products
            productsList.Add(new ProductItem("8991234567890", "Aqua Air Mineral 600ml", 3500.00m, 3));
            productsList.Add(new ProductItem("8992345678901", "Indomie Goreng Spesial", 3100.00m, 2));
            productsList.Add(new ProductItem("8993456789012", "Pepsodent Herbal 190g", 14500.00m, 4));
            productsList.Add(new ProductItem("8994567890234", "Kopi Kapal Api Mix 10s", 12500.00m, 2));
            productsList.Add(new ProductItem("8995678901234", "Bango Kecap Manis 550ml", 22000.00m, 1));
            productsList.Add(new ProductItem("A101", "Premium Cotton T-Shirt L", 125000.00m, 3));
            productsList.Add(new ProductItem("A102", "Canvas Messenger Bag Blk", 299000.00m, 1));
            productsList.Add(new ProductItem("B205", "Stainless Steel Tumbler 1L", 85000.00m, 2));

            SaveProductsList();
            pbCanvas.Invalidate();
        }

        private void BtnImportList_Click(object? sender, EventArgs e)
        {
            using (var openDlg = new OpenFileDialog())
            {
                openDlg.Filter = "JSON Files (*.json)|*.json|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                openDlg.Title = "Import Products List";

                if (openDlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string ext = Path.GetExtension(openDlg.FileName).ToLower();
                        if (ext == ".json")
                        {
                            string json = File.ReadAllText(openDlg.FileName);
                            var list = JsonSerializer.Deserialize<BindingList<ProductItem>>(json);
                            if (list != null)
                            {
                                foreach (var item in list) productsList.Add(item);
                            }
                        }
                        else if (ext == ".csv")
                        {
                            var lines = File.ReadAllLines(openDlg.FileName);
                            // Expect headers: Barcode, Name, Price, Copies
                            for (int i = 1; i < lines.Length; i++)
                            {
                                var parts = lines[i].Split(',');
                                if (parts.Length >= 3)
                                {
                                    string barcode = parts[0].Trim();
                                    string name = parts[1].Trim().Replace("\"", "");
                                    decimal price = decimal.TryParse(parts[2], out decimal p) ? p : 0.00m;
                                    int copies = parts.Length >= 4 && int.TryParse(parts[3], out int c) ? c : 1;

                                    productsList.Add(new ProductItem(barcode, name, price, copies));
                                }
                            }
                        }

                        SaveProductsList();
                        pbCanvas.Invalidate();
                        MessageBox.Show("Successfully imported list of items!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to import list: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnExportList_Click(object? sender, EventArgs e)
        {
            using (var saveDlg = new SaveFileDialog())
            {
                saveDlg.Filter = "JSON Files (*.json)|*.json|CSV Files (*.csv)|*.csv";
                saveDlg.Title = "Export Products List";

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string ext = Path.GetExtension(saveDlg.FileName).ToLower();
                        if (ext == ".json")
                        {
                            string json = JsonSerializer.Serialize(productsList, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText(saveDlg.FileName, json);
                        }
                        else if (ext == ".csv")
                        {
                            var sb = new StringBuilder();
                            sb.AppendLine("Barcode,Name,Price,Copies");
                            foreach (var item in productsList)
                            {
                                sb.AppendLine($"{item.Barcode},\"{item.Name.Replace("\"", "\"\"")}\",{item.Price},{item.CopyCount}");
                            }
                            File.WriteAllText(saveDlg.FileName, sb.ToString());
                        }

                        MessageBox.Show("List successfully exported!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to export: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Real-time Graphics Preview Paint
        private void PbCanvas_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float scale = GetZoomScale();
            g.ScaleTransform(scale, scale);

            // Sheet layout size definitions in standard 96 DPI screen pixels
            float leftMarginPx = BarcodeRenderer.MmToUnits(currentTemplate.LeftMargin, 96f);
            float topMarginPx = BarcodeRenderer.MmToUnits(currentTemplate.TopMargin, 96f);
            float lWidthPx = BarcodeRenderer.MmToUnits(currentTemplate.LabelWidth, 96f);
            float lHeightPx = BarcodeRenderer.MmToUnits(currentTemplate.LabelHeight, 96f);
            float vGapPx = BarcodeRenderer.MmToUnits(currentTemplate.VerticalGap, 96f);
            float hGapPx = BarcodeRenderer.MmToUnits(currentTemplate.HorizontalGap, 96f);

            int columns = currentTemplate.Columns;
            int rows = currentTemplate.Rows;

            // Draw a soft grey guide line representing page bounds
            using (var borderPen = new Pen(Color.FromArgb(148, 163, 184), 1.5f))
            {
                float w = leftMarginPx * 2 + columns * lWidthPx + (columns - 1) * hGapPx;
                float h = topMarginPx * 2 + rows * lHeightPx + (rows - 1) * vGapPx;
                g.DrawRectangle(borderPen, 0, 0, w, h);
            }

            // We fill labels sequentially based on product copies
            int itemIndex = 0;
            int copyRemaining = 0;
            int slotIndex = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    // Calculate bounds of individual label block in pixels
                    float lx = leftMarginPx + c * (lWidthPx + hGapPx);
                    float ly = topMarginPx + r * (lHeightPx + vGapPx);
                    var rect = new RectangleF(lx, ly, lWidthPx, lHeightPx);

                    bool isSlotEnabled = slotIndex < selectedSlots.Length ? selectedSlots[slotIndex] : true;
                    slotIndex++;

                    if (isSlotEnabled)
                    {
                        // Locate next available product with remaining copies
                        while (itemIndex < productsList.Count && copyRemaining <= 0)
                        {
                            copyRemaining = productsList[itemIndex].CopyCount;
                            if (copyRemaining <= 0) itemIndex++;
                        }

                        if (itemIndex < productsList.Count)
                        {
                            var product = productsList[itemIndex];
                            copyRemaining--;

                            // Check if the current row in DataGridView is selected to draw a highlight guide
                            bool isSelected = false;
                            if (dgvProducts.SelectedRows.Count > 0 && dgvProducts.SelectedRows[0].Index == itemIndex)
                            {
                                isSelected = true;
                            }

                            BarcodeRenderer.DrawLabel(g, rect, currentTemplate, product, isSelected);
                            
                            if (copyRemaining <= 0)
                            {
                                itemIndex++;
                            }
                        }
                        else
                        {
                            DrawEmptySlotPlaceholder(g, rect);
                        }
                    }
                    else
                    {
                        DrawEmptySlotPlaceholder(g, rect);
                    }
                }
            }
        }

        private void DrawEmptySlotPlaceholder(Graphics g, RectangleF rect)
        {
            if (currentTemplate.ShowGuide)
            {
                using (var pen = new Pen(Color.FromArgb(203, 213, 225), 1f))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                }
            }
        }
        #endregion

        #region Native Print Services
        private void BtnPrint_Click(object? sender, EventArgs e)
        {
            if (productsList.Count == 0)
            {
                MessageBox.Show("There are no product items in the list to print.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var pd = new PrintDocument())
            {
                pd.DocumentName = "Barcode Label Sheet";
                
                // Initialize print indexing
                printItemIndex = 0;
                printCopyRemaining = 0;

                pd.PrintPage += Pd_PrintPage;

                using (var printDlg = new PrintDialog())
                {
                    printDlg.Document = pd;
                    printDlg.UseEXDialog = true;

                    if (printDlg.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            pd.Print();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Printing error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics? g = e.Graphics;
            if (g == null) return;

            // Important: PrintPageEventArgs Graphics is typically measured in hundredths of an inch (1 unit = 0.01 inch)
            // So DPI is exactly 100!
            float dpi = 100f;

            // Translate mm template units to hundredths of an inch
            float leftMarginPx = BarcodeRenderer.MmToUnits(currentTemplate.LeftMargin, dpi);
            float topMarginPx = BarcodeRenderer.MmToUnits(currentTemplate.TopMargin, dpi);
            float lWidthPx = BarcodeRenderer.MmToUnits(currentTemplate.LabelWidth, dpi);
            float lHeightPx = BarcodeRenderer.MmToUnits(currentTemplate.LabelHeight, dpi);
            float vGapPx = BarcodeRenderer.MmToUnits(currentTemplate.VerticalGap, dpi);
            float hGapPx = BarcodeRenderer.MmToUnits(currentTemplate.HorizontalGap, dpi);

            int columns = currentTemplate.Columns;
            int rows = currentTemplate.Rows;
            int slotIndex = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    // Calculate printable label bounding block
                    float lx = leftMarginPx + c * (lWidthPx + hGapPx);
                    float ly = topMarginPx + r * (lHeightPx + vGapPx);
                    var rect = new RectangleF(lx, ly, lWidthPx, lHeightPx);

                    bool isSlotEnabled = slotIndex < selectedSlots.Length ? selectedSlots[slotIndex] : true;
                    slotIndex++;

                    if (isSlotEnabled)
                    {
                        // Grab next product copies
                        while (printItemIndex < productsList.Count && printCopyRemaining <= 0)
                        {
                            printCopyRemaining = productsList[printItemIndex].CopyCount;
                            if (printCopyRemaining <= 0) printItemIndex++;
                        }

                        if (printItemIndex < productsList.Count)
                        {
                            var product = productsList[printItemIndex];
                            printCopyRemaining--;

                            // Draw label onto document (never draw selected blue outline guide on printer)
                            BarcodeRenderer.DrawLabel(g, rect, currentTemplate, product, false);

                            if (printCopyRemaining <= 0)
                            {
                                printItemIndex++;
                            }
                        }
                        else
                        {
                            // Layout completed fully
                            e.HasMorePages = false;
                            return;
                        }
                    }
                    else
                    {
                        // Slot is skipped on printer
                    }
                }
            }

            // Check if we still have remaining items queue to feed subsequent pages
            while (printItemIndex < productsList.Count && printCopyRemaining <= 0)
            {
                printCopyRemaining = productsList[printItemIndex].CopyCount;
                if (printCopyRemaining <= 0) printItemIndex++;
            }

            if (printItemIndex < productsList.Count)
            {
                e.HasMorePages = true; // Feed next page
            }
            else
            {
                e.HasMorePages = false;
            }
        }
        #endregion

        #region Checkbox Slot Selection Logic
        private void RegenerateSlotCheckboxes()
        {
            pnlCheckScroll.Controls.Clear();

            int columns = currentTemplate.Columns;
            int rows = currentTemplate.Rows;
            int totalSlots = columns * rows;

            // Preserve existing selections if the size is the same, otherwise re-initialize to true
            if (selectedSlots.Length != totalSlots)
            {
                selectedSlots = new bool[totalSlots];
                for (int i = 0; i < totalSlots; i++)
                {
                    selectedSlots[i] = true;
                }
            }

            // Calculate checkbox grid sizing.
            // Width of pnlCheckScroll is 240px. With scrollbar, usable width is ~215px.
            int usableWidth = pnlCheckScroll.Width - 25;
            int itemWidth = Math.Max(35, (usableWidth / columns) - 4);
            int itemHeight = 22;
            int padding = 4;

            pnlCheckScroll.SuspendLayout();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    int index = r * columns + c;
                    
                    var cb = new CheckBox();
                    cb.AutoSize = false;
                    cb.Size = new Size(itemWidth, itemHeight);
                    cb.Location = new Point(5 + c * (itemWidth + padding), 5 + r * (itemHeight + padding));
                    cb.Text = (index + 1).ToString();
                    cb.Checked = selectedSlots[index];
                    cb.Font = new Font("Segoe UI", 7.5f, FontStyle.Regular);
                    cb.Tag = index;
                    
                    cb.CheckedChanged += (sender, e) =>
                    {
                        if (sender is CheckBox checkbox && checkbox.Tag is int idx)
                        {
                            selectedSlots[idx] = checkbox.Checked;
                            pbCanvas.Invalidate();
                        }
                    };

                    pnlCheckScroll.Controls.Add(cb);
                }
            }

            pnlCheckScroll.ResumeLayout();
            pbCanvas.Invalidate();
        }

        private void SetAllSlotsState(bool state)
        {
            for (int i = 0; i < selectedSlots.Length; i++)
            {
                selectedSlots[i] = state;
            }

            foreach (Control control in pnlCheckScroll.Controls)
            {
                if (control is CheckBox cb)
                {
                    cb.Checked = state;
                }
            }

            pbCanvas.Invalidate();
        }
        #endregion
    }
}
