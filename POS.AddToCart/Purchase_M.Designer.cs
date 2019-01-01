namespace POS.AddToCart
{
    partial class Purchase_M
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchase_M));
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.cmbAutoSuggest = new MetroFramework.Controls.MetroComboBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.tblProduct = new System.Windows.Forms.DataGridView();
            this.stock_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sup_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editProd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSNameSearch = new MetroFramework.Controls.MetroTextBox();
            this.txtPNameSearch = new MetroFramework.Controls.MetroTextBox();
            this.txtInvoiceSearch = new MetroFramework.Controls.MetroTextBox();
            this.cmbECategory = new MetroFramework.Controls.MetroComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDate = new MetroFramework.Controls.MetroDateTime();
            this.txtSupName = new MetroFramework.Controls.MetroTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtStockID = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new MetroFramework.Controls.MetroTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkBack = new System.Windows.Forms.Button();
            this.lnkshow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.pnlSideMenuContent = new MetroFramework.Controls.MetroPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.panel7 = new System.Windows.Forms.Panel();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.panel6 = new System.Windows.Forms.Panel();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.panel3 = new System.Windows.Forms.Panel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblProduct)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelSideMenu.SuspendLayout();
            this.pnlSideMenuContent.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.metroLabel4);
            this.panel1.Controls.Add(this.cmbAutoSuggest);
            this.panel1.Controls.Add(this.txtProductName);
            this.panel1.Controls.Add(this.tblProduct);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(69, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1229, 636);
            this.panel1.TabIndex = 5;
            // 
            // metroLabel4
            // 
            this.metroLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(154, 13);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(124, 19);
            this.metroLabel4.TabIndex = 356;
            this.metroLabel4.Text = "Product Name : -";
            // 
            // cmbAutoSuggest
            // 
            this.cmbAutoSuggest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAutoSuggest.FormattingEnabled = true;
            this.cmbAutoSuggest.ItemHeight = 23;
            this.cmbAutoSuggest.Location = new System.Drawing.Point(436, 9);
            this.cmbAutoSuggest.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAutoSuggest.Name = "cmbAutoSuggest";
            this.cmbAutoSuggest.Size = new System.Drawing.Size(508, 29);
            this.cmbAutoSuggest.TabIndex = 355;
            this.cmbAutoSuggest.UseSelectable = true;
            this.cmbAutoSuggest.SelectedIndexChanged += new System.EventHandler(this.cmbAutoSuggest_SelectedIndexChanged);
            this.cmbAutoSuggest.DropDownClosed += new System.EventHandler(this.cmbAutoSuggest_DropDownClosed);
            // 
            // txtProductName
            // 
            this.txtProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(281, 12);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(150, 26);
            this.txtProductName.TabIndex = 354;
            this.txtProductName.Enter += new System.EventHandler(this.txtProductName_Enter);
            this.txtProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductName_KeyPress);
            // 
            // tblProduct
            // 
            this.tblProduct.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stock_id,
            this.invoiceNo,
            this.sup_Name,
            this._Date,
            this.G_Total,
            this.editProd});
            this.tblProduct.Location = new System.Drawing.Point(250, 124);
            this.tblProduct.Name = "tblProduct";
            this.tblProduct.Size = new System.Drawing.Size(924, 509);
            this.tblProduct.TabIndex = 2;
            this.tblProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblProduct_CellClick);
            // 
            // stock_id
            // 
            this.stock_id.HeaderText = "Stock ID";
            this.stock_id.Name = "stock_id";
            // 
            // invoiceNo
            // 
            this.invoiceNo.HeaderText = "Invoice No";
            this.invoiceNo.Name = "invoiceNo";
            // 
            // sup_Name
            // 
            this.sup_Name.HeaderText = "Suppilier";
            this.sup_Name.Name = "sup_Name";
            // 
            // _Date
            // 
            this._Date.HeaderText = "Date";
            this._Date.Name = "_Date";
            // 
            // G_Total
            // 
            this.G_Total.HeaderText = "G_Total";
            this.G_Total.Name = "G_Total";
            // 
            // editProd
            // 
            this.editProd.HeaderText = "M_Product";
            this.editProd.Name = "editProd";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSNameSearch);
            this.groupBox2.Controls.Add(this.txtPNameSearch);
            this.groupBox2.Controls.Add(this.txtInvoiceSearch);
            this.groupBox2.Controls.Add(this.cmbECategory);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(17, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1185, 68);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtSNameSearch
            // 
            this.txtSNameSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtSNameSearch.CustomButton.Image = null;
            this.txtSNameSearch.CustomButton.Location = new System.Drawing.Point(199, 2);
            this.txtSNameSearch.CustomButton.Name = "";
            this.txtSNameSearch.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtSNameSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSNameSearch.CustomButton.TabIndex = 1;
            this.txtSNameSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSNameSearch.CustomButton.UseSelectable = true;
            this.txtSNameSearch.CustomButton.Visible = false;
            this.txtSNameSearch.DisplayIcon = true;
            this.txtSNameSearch.Icon = global::POS.AddToCart.Properties.Resources.glasses;
            this.txtSNameSearch.Lines = new string[0];
            this.txtSNameSearch.Location = new System.Drawing.Point(516, 16);
            this.txtSNameSearch.MaxLength = 32767;
            this.txtSNameSearch.Name = "txtSNameSearch";
            this.txtSNameSearch.PasswordChar = '\0';
            this.txtSNameSearch.PromptText = "Suppilier Name";
            this.txtSNameSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSNameSearch.SelectedText = "";
            this.txtSNameSearch.SelectionLength = 0;
            this.txtSNameSearch.SelectionStart = 0;
            this.txtSNameSearch.ShortcutsEnabled = true;
            this.txtSNameSearch.Size = new System.Drawing.Size(225, 28);
            this.txtSNameSearch.TabIndex = 9;
            this.txtSNameSearch.UseSelectable = true;
            this.txtSNameSearch.WaterMark = "Suppilier Name";
            this.txtSNameSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSNameSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSNameSearch.TextChanged += new System.EventHandler(this.txtSNameSearch_TextChanged);
            // 
            // txtPNameSearch
            // 
            this.txtPNameSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtPNameSearch.CustomButton.Image = null;
            this.txtPNameSearch.CustomButton.Location = new System.Drawing.Point(204, 2);
            this.txtPNameSearch.CustomButton.Name = "";
            this.txtPNameSearch.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPNameSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPNameSearch.CustomButton.TabIndex = 1;
            this.txtPNameSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPNameSearch.CustomButton.UseSelectable = true;
            this.txtPNameSearch.CustomButton.Visible = false;
            this.txtPNameSearch.DisplayIcon = true;
            this.txtPNameSearch.Icon = global::POS.AddToCart.Properties.Resources.glasses;
            this.txtPNameSearch.Lines = new string[0];
            this.txtPNameSearch.Location = new System.Drawing.Point(264, 16);
            this.txtPNameSearch.MaxLength = 32767;
            this.txtPNameSearch.Name = "txtPNameSearch";
            this.txtPNameSearch.PasswordChar = '\0';
            this.txtPNameSearch.PromptText = "Product Name";
            this.txtPNameSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPNameSearch.SelectedText = "";
            this.txtPNameSearch.SelectionLength = 0;
            this.txtPNameSearch.SelectionStart = 0;
            this.txtPNameSearch.ShortcutsEnabled = true;
            this.txtPNameSearch.Size = new System.Drawing.Size(230, 28);
            this.txtPNameSearch.TabIndex = 9;
            this.txtPNameSearch.UseSelectable = true;
            this.txtPNameSearch.WaterMark = "Product Name";
            this.txtPNameSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPNameSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPNameSearch.TextChanged += new System.EventHandler(this.txtPNameSearch_TextChanged);
            // 
            // txtInvoiceSearch
            // 
            this.txtInvoiceSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtInvoiceSearch.CustomButton.Image = null;
            this.txtInvoiceSearch.CustomButton.Location = new System.Drawing.Point(188, 2);
            this.txtInvoiceSearch.CustomButton.Name = "";
            this.txtInvoiceSearch.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtInvoiceSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtInvoiceSearch.CustomButton.TabIndex = 1;
            this.txtInvoiceSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtInvoiceSearch.CustomButton.UseSelectable = true;
            this.txtInvoiceSearch.CustomButton.Visible = false;
            this.txtInvoiceSearch.DisplayIcon = true;
            this.txtInvoiceSearch.Icon = global::POS.AddToCart.Properties.Resources.glasses;
            this.txtInvoiceSearch.Lines = new string[0];
            this.txtInvoiceSearch.Location = new System.Drawing.Point(25, 16);
            this.txtInvoiceSearch.MaxLength = 20;
            this.txtInvoiceSearch.Name = "txtInvoiceSearch";
            this.txtInvoiceSearch.PasswordChar = '\0';
            this.txtInvoiceSearch.PromptText = "Invoice No";
            this.txtInvoiceSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtInvoiceSearch.SelectedText = "";
            this.txtInvoiceSearch.SelectionLength = 0;
            this.txtInvoiceSearch.SelectionStart = 0;
            this.txtInvoiceSearch.ShortcutsEnabled = true;
            this.txtInvoiceSearch.Size = new System.Drawing.Size(214, 28);
            this.txtInvoiceSearch.TabIndex = 9;
            this.txtInvoiceSearch.UseSelectable = true;
            this.txtInvoiceSearch.WaterMark = "Invoice No";
            this.txtInvoiceSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtInvoiceSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtInvoiceSearch.TextChanged += new System.EventHandler(this.txtInvoiceSearch_TextChanged);
            this.txtInvoiceSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceSearch_KeyDown);
            this.txtInvoiceSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvoiceSearch_KeyPress);
            // 
            // cmbECategory
            // 
            this.cmbECategory.FormattingEnabled = true;
            this.cmbECategory.ItemHeight = 23;
            this.cmbECategory.Location = new System.Drawing.Point(763, 15);
            this.cmbECategory.Margin = new System.Windows.Forms.Padding(2);
            this.cmbECategory.Name = "cmbECategory";
            this.cmbECategory.PromptText = "Category";
            this.cmbECategory.Size = new System.Drawing.Size(179, 29);
            this.cmbECategory.TabIndex = 113;
            this.cmbECategory.UseSelectable = true;
            this.cmbECategory.DropDown += new System.EventHandler(this.cmbECategory_DropDown);
            this.cmbECategory.SelectedIndexChanged += new System.EventHandler(this.cmbECategory_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::POS.AddToCart.Properties.Resources.home;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1086, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 50);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::POS.AddToCart.Properties.Resources.circular_arrow1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1019, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 50);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDate);
            this.groupBox1.Controls.Add(this.txtSupName);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtStockID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(17, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 422);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbDate
            // 
            this.cmbDate.CustomFormat = "yyyy/mm/dd";
            this.cmbDate.Enabled = false;
            this.cmbDate.Location = new System.Drawing.Point(52, 213);
            this.cmbDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(152, 29);
            this.cmbDate.TabIndex = 3;
            // 
            // txtSupName
            // 
            // 
            // 
            // 
            this.txtSupName.CustomButton.Image = null;
            this.txtSupName.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.txtSupName.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtSupName.CustomButton.Name = "";
            this.txtSupName.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtSupName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSupName.CustomButton.TabIndex = 1;
            this.txtSupName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSupName.CustomButton.UseSelectable = true;
            this.txtSupName.CustomButton.Visible = false;
            this.txtSupName.Enabled = false;
            this.txtSupName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtSupName.Lines = new string[0];
            this.txtSupName.Location = new System.Drawing.Point(52, 296);
            this.txtSupName.Margin = new System.Windows.Forms.Padding(2);
            this.txtSupName.MaxLength = 32767;
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.PasswordChar = '\0';
            this.txtSupName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSupName.SelectedText = "";
            this.txtSupName.SelectionLength = 0;
            this.txtSupName.SelectionStart = 0;
            this.txtSupName.ShortcutsEnabled = true;
            this.txtSupName.Size = new System.Drawing.Size(148, 33);
            this.txtSupName.TabIndex = 6;
            this.txtSupName.UseSelectable = true;
            this.txtSupName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSupName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BackgroundImage = global::POS.AddToCart.Properties.Resources._return;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Minion Pro", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(71, 357);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 59);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtStockID
            // 
            // 
            // 
            // 
            this.txtStockID.CustomButton.Image = null;
            this.txtStockID.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.txtStockID.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtStockID.CustomButton.Name = "";
            this.txtStockID.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtStockID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtStockID.CustomButton.TabIndex = 1;
            this.txtStockID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtStockID.CustomButton.UseSelectable = true;
            this.txtStockID.CustomButton.Visible = false;
            this.txtStockID.Enabled = false;
            this.txtStockID.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtStockID.Lines = new string[0];
            this.txtStockID.Location = new System.Drawing.Point(52, 66);
            this.txtStockID.Margin = new System.Windows.Forms.Padding(2);
            this.txtStockID.MaxLength = 32767;
            this.txtStockID.Multiline = true;
            this.txtStockID.Name = "txtStockID";
            this.txtStockID.PasswordChar = '\0';
            this.txtStockID.ReadOnly = true;
            this.txtStockID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStockID.SelectedText = "";
            this.txtStockID.SelectionLength = 0;
            this.txtStockID.SelectionStart = 0;
            this.txtStockID.ShortcutsEnabled = true;
            this.txtStockID.Size = new System.Drawing.Size(148, 33);
            this.txtStockID.TabIndex = 6;
            this.txtStockID.UseSelectable = true;
            this.txtStockID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtStockID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Stock ID :-";
            // 
            // txtInvoiceNo
            // 
            // 
            // 
            // 
            this.txtInvoiceNo.CustomButton.Image = null;
            this.txtInvoiceNo.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.txtInvoiceNo.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoiceNo.CustomButton.Name = "";
            this.txtInvoiceNo.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtInvoiceNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtInvoiceNo.CustomButton.TabIndex = 1;
            this.txtInvoiceNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtInvoiceNo.CustomButton.UseSelectable = true;
            this.txtInvoiceNo.CustomButton.Visible = false;
            this.txtInvoiceNo.Enabled = false;
            this.txtInvoiceNo.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtInvoiceNo.Lines = new string[0];
            this.txtInvoiceNo.Location = new System.Drawing.Point(52, 140);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoiceNo.MaxLength = 32767;
            this.txtInvoiceNo.Multiline = true;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.PasswordChar = '\0';
            this.txtInvoiceNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtInvoiceNo.SelectedText = "";
            this.txtInvoiceNo.SelectionLength = 0;
            this.txtInvoiceNo.SelectionStart = 0;
            this.txtInvoiceNo.ShortcutsEnabled = true;
            this.txtInvoiceNo.Size = new System.Drawing.Size(148, 33);
            this.txtInvoiceNo.TabIndex = 6;
            this.txtInvoiceNo.UseSelectable = true;
            this.txtInvoiceNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtInvoiceNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "&Invoice No :-";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Suppilier Name :-";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "&Date :-";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.lnkBack);
            this.panel2.Controls.Add(this.lnkshow);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1309, 37);
            this.panel2.TabIndex = 132;
            // 
            // lnkBack
            // 
            this.lnkBack.BackColor = System.Drawing.Color.White;
            this.lnkBack.BackgroundImage = global::POS.AddToCart.Properties.Resources.left_arrow1;
            this.lnkBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lnkBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkBack.Location = new System.Drawing.Point(-1, -3);
            this.lnkBack.Name = "lnkBack";
            this.lnkBack.Size = new System.Drawing.Size(40, 37);
            this.lnkBack.TabIndex = 102;
            this.lnkBack.UseVisualStyleBackColor = false;
            this.lnkBack.Click += new System.EventHandler(this.lnkBack_Click);
            // 
            // lnkshow
            // 
            this.lnkshow.BackColor = System.Drawing.Color.White;
            this.lnkshow.BackgroundImage = global::POS.AddToCart.Properties.Resources.right_arrow;
            this.lnkshow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lnkshow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkshow.Location = new System.Drawing.Point(-1, 0);
            this.lnkshow.Name = "lnkshow";
            this.lnkshow.Size = new System.Drawing.Size(38, 38);
            this.lnkshow.TabIndex = 5;
            this.lnkshow.UseVisualStyleBackColor = false;
            this.lnkshow.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(595, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 24);
            this.label4.TabIndex = 98;
            this.label4.Text = "VIEW PURCHASE";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSideMenu.BackColor = System.Drawing.Color.White;
            this.panelSideMenu.Controls.Add(this.pnlSideMenuContent);
            this.panelSideMenu.Location = new System.Drawing.Point(0, 63);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(105, 769);
            this.panelSideMenu.TabIndex = 133;
            // 
            // pnlSideMenuContent
            // 
            this.pnlSideMenuContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlSideMenuContent.Controls.Add(this.panel4);
            this.pnlSideMenuContent.Controls.Add(this.panel7);
            this.pnlSideMenuContent.Controls.Add(this.panel6);
            this.pnlSideMenuContent.Controls.Add(this.panel3);
            this.pnlSideMenuContent.Controls.Add(this.label9);
            this.pnlSideMenuContent.Controls.Add(this.panel5);
            this.pnlSideMenuContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSideMenuContent.HorizontalScrollbarBarColor = true;
            this.pnlSideMenuContent.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlSideMenuContent.HorizontalScrollbarSize = 10;
            this.pnlSideMenuContent.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenuContent.Name = "pnlSideMenuContent";
            this.pnlSideMenuContent.Size = new System.Drawing.Size(105, 769);
            this.pnlSideMenuContent.TabIndex = 101;
            this.pnlSideMenuContent.VerticalScrollbarBarColor = true;
            this.pnlSideMenuContent.VerticalScrollbarHighlightOnWheel = false;
            this.pnlSideMenuContent.VerticalScrollbarSize = 10;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.metroTile2);
            this.panel4.Location = new System.Drawing.Point(-10, 236);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(294, 61);
            this.panel4.TabIndex = 101;
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTile2.Location = new System.Drawing.Point(0, 0);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(294, 61);
            this.metroTile2.TabIndex = 0;
            this.metroTile2.Text = "BILLING";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.metroTile4);
            this.panel7.Location = new System.Drawing.Point(0, 423);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(291, 61);
            this.panel7.TabIndex = 101;
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTile4.Location = new System.Drawing.Point(0, 0);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(291, 61);
            this.metroTile4.TabIndex = 0;
            this.metroTile4.Text = "CLOSE";
            this.metroTile4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile4.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile4.UseSelectable = true;
            this.metroTile4.Click += new System.EventHandler(this.metroTile4_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.metroTile3);
            this.panel6.Location = new System.Drawing.Point(-10, 300);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(301, 61);
            this.panel6.TabIndex = 101;
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTile3.Location = new System.Drawing.Point(0, 0);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(301, 61);
            this.metroTile3.TabIndex = 0;
            this.metroTile3.Text = "ADD  STOCK";
            this.metroTile3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile3.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile3.UseSelectable = true;
            this.metroTile3.Click += new System.EventHandler(this.metroTile3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.metroTile1);
            this.panel3.Location = new System.Drawing.Point(-10, 173);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(291, 61);
            this.panel3.TabIndex = 101;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.BackColor = System.Drawing.Color.DarkRed;
            this.metroTile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTile1.Location = new System.Drawing.Point(0, 0);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(291, 61);
            this.metroTile1.TabIndex = 0;
            this.metroTile1.Text = "HOME";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseStyleColors = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(71, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 50);
            this.label9.TabIndex = 5;
            this.label9.Text = "Menu";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel5.Location = new System.Drawing.Point(101, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(7, 813);
            this.panel5.TabIndex = 100;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Purchase_M
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 772);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Purchase_M";
            this.Load += new System.EventHandler(this.Purchase_M_Load);
            this.SizeChanged += new System.EventHandler(this.ManageStock_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblProduct)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelSideMenu.ResumeLayout(false);
            this.pnlSideMenuContent.ResumeLayout(false);
            this.pnlSideMenuContent.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView tblProduct;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroComboBox cmbECategory;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroDateTime cmbDate;
        private MetroFramework.Controls.MetroTextBox txtSupName;
        private System.Windows.Forms.Button btnAdd;
        private MetroFramework.Controls.MetroTextBox txtStockID;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox txtInvoiceNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button lnkshow;
        internal System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroTextBox txtInvoiceSearch;
        private MetroFramework.Controls.MetroTextBox txtSNameSearch;
        private MetroFramework.Controls.MetroTextBox txtPNameSearch;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelSideMenu;
        private MetroFramework.Controls.MetroPanel pnlSideMenuContent;
        private System.Windows.Forms.Panel panel4;
        private MetroFramework.Controls.MetroTile metroTile2;
        private System.Windows.Forms.Panel panel7;
        private MetroFramework.Controls.MetroTile metroTile4;
        private System.Windows.Forms.Panel panel6;
        private MetroFramework.Controls.MetroTile metroTile3;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button lnkBack;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sup_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn G_Total;
        private System.Windows.Forms.DataGridViewButtonColumn editProd;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox cmbAutoSuggest;
        internal System.Windows.Forms.TextBox txtProductName;

    }
}