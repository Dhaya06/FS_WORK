namespace POS.AddToCart
{
    partial class V_Stock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_Stock));
            this.tblProduct = new MetroFramework.Controls.MetroGrid();
            this.Product_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Warranty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Avali_Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.cmbAutoSuggest = new MetroFramework.Controls.MetroComboBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbPCat = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtPID = new MetroFramework.Controls.MetroTextBox();
            this.txtPName = new MetroFramework.Controls.MetroTextBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblProduct)).BeginInit();
            this.panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.panelSideMenu.SuspendLayout();
            this.pnlSideMenuContent.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblProduct
            // 
            this.tblProduct.AllowUserToAddRows = false;
            this.tblProduct.AllowUserToDeleteRows = false;
            this.tblProduct.AllowUserToResizeRows = false;
            this.tblProduct.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tblProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tblProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tblProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_ID,
            this.Product_Name,
            this.Product_Category,
            this.Unit_Cost,
            this.Unit_Price,
            this._Warranty,
            this.Avali_Stock});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblProduct.EnableHeadersVisualStyles = false;
            this.tblProduct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tblProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tblProduct.Location = new System.Drawing.Point(76, 145);
            this.tblProduct.Margin = new System.Windows.Forms.Padding(2);
            this.tblProduct.Name = "tblProduct";
            this.tblProduct.ReadOnly = true;
            this.tblProduct.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tblProduct.RowHeadersWidth = 40;
            this.tblProduct.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tblProduct.RowTemplate.Height = 24;
            this.tblProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblProduct.Size = new System.Drawing.Size(1037, 575);
            this.tblProduct.Style = MetroFramework.MetroColorStyle.Blue;
            this.tblProduct.TabIndex = 52;
            this.tblProduct.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // Product_ID
            // 
            this.Product_ID.HeaderText = "Product ID";
            this.Product_ID.Name = "Product_ID";
            this.Product_ID.ReadOnly = true;
            // 
            // Product_Name
            // 
            this.Product_Name.HeaderText = "Product Name";
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.ReadOnly = true;
            // 
            // Product_Category
            // 
            this.Product_Category.HeaderText = "Product Category";
            this.Product_Category.Name = "Product_Category";
            this.Product_Category.ReadOnly = true;
            // 
            // Unit_Cost
            // 
            this.Unit_Cost.HeaderText = "Unit Cost";
            this.Unit_Cost.Name = "Unit_Cost";
            this.Unit_Cost.ReadOnly = true;
            // 
            // Unit_Price
            // 
            this.Unit_Price.HeaderText = "Unit Price";
            this.Unit_Price.Name = "Unit_Price";
            this.Unit_Price.ReadOnly = true;
            // 
            // _Warranty
            // 
            this._Warranty.HeaderText = "Warranty";
            this._Warranty.Name = "_Warranty";
            this._Warranty.ReadOnly = true;
            // 
            // Avali_Stock
            // 
            this.Avali_Stock.HeaderText = "Available";
            this.Avali_Stock.Name = "Avali_Stock";
            this.Avali_Stock.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.metroLabel4);
            this.panel1.Controls.Add(this.cmbAutoSuggest);
            this.panel1.Controls.Add(this.txtProductName);
            this.panel1.Controls.Add(this.btnPrintReport);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tblProduct);
            this.panel1.Controls.Add(this.cmbPCat);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.metroLabel2);
            this.panel1.Controls.Add(this.metroLabel3);
            this.panel1.Controls.Add(this.txtPID);
            this.panel1.Controls.Add(this.txtPName);
            this.panel1.Location = new System.Drawing.Point(79, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 627);
            this.panel1.TabIndex = 136;
            // 
            // metroLabel4
            // 
            this.metroLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(105, 54);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(124, 19);
            this.metroLabel4.TabIndex = 350;
            this.metroLabel4.Text = "Product Name : -";
            // 
            // cmbAutoSuggest
            // 
            this.cmbAutoSuggest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAutoSuggest.FormattingEnabled = true;
            this.cmbAutoSuggest.ItemHeight = 23;
            this.cmbAutoSuggest.Location = new System.Drawing.Point(387, 50);
            this.cmbAutoSuggest.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAutoSuggest.Name = "cmbAutoSuggest";
            this.cmbAutoSuggest.Size = new System.Drawing.Size(508, 29);
            this.cmbAutoSuggest.TabIndex = 349;
            this.cmbAutoSuggest.UseSelectable = true;
            this.cmbAutoSuggest.SelectedIndexChanged += new System.EventHandler(this.cmbAutoSuggest_SelectedIndexChanged);
            this.cmbAutoSuggest.DropDownClosed += new System.EventHandler(this.cmbAutoSuggest_DropDownClosed);
            this.cmbAutoSuggest.TextChanged += new System.EventHandler(this.cmbAutoSuggest_TextChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(232, 53);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(150, 26);
            this.txtProductName.TabIndex = 348;
            this.txtProductName.Enter += new System.EventHandler(this.txtProductName_Enter);
            this.txtProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductName_KeyPress);
            this.txtProductName.Leave += new System.EventHandler(this.txtProductName_Leave);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackColor = System.Drawing.Color.White;
            this.btnPrintReport.BackgroundImage = global::POS.AddToCart.Properties.Resources.Printer_20and_20Fax;
            this.btnPrintReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrintReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintReport.Location = new System.Drawing.Point(1111, 18);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(78, 53);
            this.btnPrintReport.TabIndex = 347;
            this.btnPrintReport.UseVisualStyleBackColor = false;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::POS.AddToCart.Properties.Resources.home;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(938, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 57);
            this.button2.TabIndex = 69;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::POS.AddToCart.Properties.Resources.circular_arrow1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1029, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 54);
            this.button1.TabIndex = 70;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbPCat
            // 
            this.cmbPCat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbPCat.FormattingEnabled = true;
            this.cmbPCat.ItemHeight = 23;
            this.cmbPCat.Items.AddRange(new object[] {
            "Normal ",
            "Original",
            "Local"});
            this.cmbPCat.Location = new System.Drawing.Point(873, 101);
            this.cmbPCat.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPCat.Name = "cmbPCat";
            this.cmbPCat.Size = new System.Drawing.Size(205, 29);
            this.cmbPCat.TabIndex = 51;
            this.cmbPCat.UseSelectable = true;
            this.cmbPCat.DropDown += new System.EventHandler(this.cmbPCat_DropDown);
            this.cmbPCat.SelectedIndexChanged += new System.EventHandler(this.cmbPCat_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(76, 102);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.TabIndex = 53;
            this.metroLabel1.Text = "Product ID : -";
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(376, 102);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(124, 19);
            this.metroLabel2.TabIndex = 54;
            this.metroLabel2.Text = "Product Name : -";
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(722, 102);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(147, 19);
            this.metroLabel3.TabIndex = 55;
            this.metroLabel3.Text = "Product Category : -";
            // 
            // txtPID
            // 
            this.txtPID.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtPID.CustomButton.Image = null;
            this.txtPID.CustomButton.Location = new System.Drawing.Point(152, 2);
            this.txtPID.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtPID.CustomButton.Name = "";
            this.txtPID.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtPID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPID.CustomButton.TabIndex = 1;
            this.txtPID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPID.CustomButton.UseSelectable = true;
            this.txtPID.CustomButton.Visible = false;
            this.txtPID.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPID.Lines = new string[0];
            this.txtPID.Location = new System.Drawing.Point(174, 100);
            this.txtPID.Margin = new System.Windows.Forms.Padding(2);
            this.txtPID.MaxLength = 15;
            this.txtPID.Name = "txtPID";
            this.txtPID.PasswordChar = '\0';
            this.txtPID.PromptText = "Product ID";
            this.txtPID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPID.SelectedText = "";
            this.txtPID.SelectionLength = 0;
            this.txtPID.SelectionStart = 0;
            this.txtPID.ShortcutsEnabled = true;
            this.txtPID.Size = new System.Drawing.Size(174, 24);
            this.txtPID.TabIndex = 49;
            this.txtPID.UseSelectable = true;
            this.txtPID.WaterMark = "Product ID";
            this.txtPID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPID.TextChanged += new System.EventHandler(this.txtPID_TextChanged);
            this.txtPID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPID_KeyDown);
            this.txtPID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPID_KeyPress);
            // 
            // txtPName
            // 
            this.txtPName.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtPName.CustomButton.Image = null;
            this.txtPName.CustomButton.Location = new System.Drawing.Point(167, 2);
            this.txtPName.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtPName.CustomButton.Name = "";
            this.txtPName.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtPName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPName.CustomButton.TabIndex = 1;
            this.txtPName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPName.CustomButton.UseSelectable = true;
            this.txtPName.CustomButton.Visible = false;
            this.txtPName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPName.Lines = new string[0];
            this.txtPName.Location = new System.Drawing.Point(507, 101);
            this.txtPName.Margin = new System.Windows.Forms.Padding(2);
            this.txtPName.MaxLength = 30;
            this.txtPName.Name = "txtPName";
            this.txtPName.PasswordChar = '\0';
            this.txtPName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPName.SelectedText = "";
            this.txtPName.SelectionLength = 0;
            this.txtPName.SelectionStart = 0;
            this.txtPName.ShortcutsEnabled = true;
            this.txtPName.Size = new System.Drawing.Size(189, 24);
            this.txtPName.TabIndex = 50;
            this.txtPName.UseSelectable = true;
            this.txtPName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPName.TextChanged += new System.EventHandler(this.txtPName_TextChanged);
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.Controls.Add(this.button3);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Location = new System.Drawing.Point(-1, 23);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1312, 45);
            this.Panel2.TabIndex = 135;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = global::POS.AddToCart.Properties.Resources.right_arrow;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(3, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 45);
            this.button3.TabIndex = 102;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(607, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(241, 24);
            this.Label1.TabIndex = 97;
            this.Label1.Text = "View Available  Products";
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.White;
            this.panelSideMenu.Controls.Add(this.pnlSideMenuContent);
            this.panelSideMenu.Location = new System.Drawing.Point(-1, 65);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(141, 699);
            this.panelSideMenu.TabIndex = 137;
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
            this.pnlSideMenuContent.Size = new System.Drawing.Size(141, 699);
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
            this.metroTile2.Text = "ADD PRODUCTS";
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
            this.metroTile3.Text = "VIEW  STOCK";
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
            this.panel5.Location = new System.Drawing.Point(137, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(7, 743);
            this.panel5.TabIndex = 100;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // V_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 743);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "V_Stock";
            this.Load += new System.EventHandler(this.V_Stock_Load);
            this.SizeChanged += new System.EventHandler(this.V_Stock_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.tblProduct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
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

        private System.Windows.Forms.Button button2;
        private MetroFramework.Controls.MetroGrid tblProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private MetroFramework.Controls.MetroComboBox cmbPCat;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtPID;
        private MetroFramework.Controls.MetroTextBox txtPName;
        internal System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Label Label1;
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Warranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Avali_Stock;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnPrintReport;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox cmbAutoSuggest;
        internal System.Windows.Forms.TextBox txtProductName;
    }
}