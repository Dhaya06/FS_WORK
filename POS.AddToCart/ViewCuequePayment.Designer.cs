namespace POS.AddToCart
{
    partial class ViewChequePayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewChequePayment));
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lnkBack = new System.Windows.Forms.Button();
            this.lnkBtnShow = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.dateStart = new MetroFramework.Controls.MetroDateTime();
            this.dateEnd = new MetroFramework.Controls.MetroDateTime();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSalesID = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.tblSales = new MetroFramework.Controls.MetroGrid();
            this.S_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SR_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.pnlSideMenuContent = new MetroFramework.Controls.MetroPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.panel7 = new System.Windows.Forms.Panel();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.panel6 = new System.Windows.Forms.Panel();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.panel5 = new System.Windows.Forms.Panel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalCredit = new System.Windows.Forms.Label();
            this.lblTotalPaid = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.Panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSales)).BeginInit();
            this.panelSideMenu.SuspendLayout();
            this.pnlSideMenuContent.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.Controls.Add(this.lnkBack);
            this.Panel2.Controls.Add(this.lnkBtnShow);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Location = new System.Drawing.Point(0, 20);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1327, 45);
            this.Panel2.TabIndex = 4;
            // 
            // lnkBack
            // 
            this.lnkBack.BackColor = System.Drawing.Color.White;
            this.lnkBack.BackgroundImage = global::POS.AddToCart.Properties.Resources.right_arrow1;
            this.lnkBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lnkBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkBack.Location = new System.Drawing.Point(0, 0);
            this.lnkBack.Name = "lnkBack";
            this.lnkBack.Size = new System.Drawing.Size(44, 45);
            this.lnkBack.TabIndex = 101;
            this.lnkBack.UseVisualStyleBackColor = false;
            this.lnkBack.Click += new System.EventHandler(this.lnkBack_Click);
            // 
            // lnkBtnShow
            // 
            this.lnkBtnShow.BackColor = System.Drawing.Color.White;
            this.lnkBtnShow.BackgroundImage = global::POS.AddToCart.Properties.Resources.left_arrow1;
            this.lnkBtnShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lnkBtnShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkBtnShow.Location = new System.Drawing.Point(3, 0);
            this.lnkBtnShow.Name = "lnkBtnShow";
            this.lnkBtnShow.Size = new System.Drawing.Size(44, 45);
            this.lnkBtnShow.TabIndex = 101;
            this.lnkBtnShow.UseVisualStyleBackColor = false;
            this.lnkBtnShow.Click += new System.EventHandler(this.lnkBtnShow_Click);
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(531, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(212, 24);
            this.Label1.TabIndex = 97;
            this.Label1.Text = "View Cheque Payment";
            // 
            // dateStart
            // 
            this.dateStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateStart.Location = new System.Drawing.Point(125, 22);
            this.dateStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(200, 29);
            this.dateStart.TabIndex = 335;
            // 
            // dateEnd
            // 
            this.dateEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateEnd.Location = new System.Drawing.Point(440, 19);
            this.dateEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(200, 29);
            this.dateEnd.TabIndex = 334;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(748, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 29);
            this.btnSearch.TabIndex = 333;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 18);
            this.label2.TabIndex = 329;
            this.label2.Text = "Customer Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(396, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 18);
            this.label4.TabIndex = 330;
            this.label4.Text = "To :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 331;
            this.label3.Text = "From :";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(12, 17);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(102, 18);
            this.Label11.TabIndex = 332;
            this.Label11.Text = "Cheque No :";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(435, 13);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(176, 26);
            this.txtCustomerName.TabIndex = 327;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtChequeNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtChequeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(116, 13);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(167, 26);
            this.txtChequeNo.TabIndex = 328;
            this.txtChequeNo.TextChanged += new System.EventHandler(this.txtReceiptNo_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(620, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 18);
            this.label9.TabIndex = 329;
            this.label9.Text = "Sales Number:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateStart);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dateEnd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(162, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 64);
            this.groupBox1.TabIndex = 337;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Label11);
            this.panel1.Controls.Add(this.txtChequeNo);
            this.panel1.Controls.Add(this.txtSalesID);
            this.panel1.Controls.Add(this.txtCustomerName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(117, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 50);
            this.panel1.TabIndex = 339;
            // 
            // txtSalesID
            // 
            this.txtSalesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSalesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSalesID.Enabled = false;
            this.txtSalesID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesID.Location = new System.Drawing.Point(769, 13);
            this.txtSalesID.Name = "txtSalesID";
            this.txtSalesID.Size = new System.Drawing.Size(176, 26);
            this.txtSalesID.TabIndex = 327;
            this.txtSalesID.TextChanged += new System.EventHandler(this.txtSalesID_TextChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.tblSales);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Location = new System.Drawing.Point(83, 91);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1173, 674);
            this.panel4.TabIndex = 340;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::POS.AddToCart.Properties.Resources.Printer_20and_20Fax;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1060, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 59);
            this.button2.TabIndex = 345;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tblSales
            // 
            this.tblSales.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tblSales.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tblSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tblSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tblSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tblSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Code,
            this.ChequeNo,
            this.P_Name,
            this.SR_Type,
            this.S_ID,
            this.bank,
            this.branch,
            this.details});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblSales.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblSales.EnableHeadersVisualStyles = false;
            this.tblSales.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tblSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tblSales.Location = new System.Drawing.Point(73, 151);
            this.tblSales.Name = "tblSales";
            this.tblSales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblSales.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.tblSales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tblSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblSales.Size = new System.Drawing.Size(1042, 326);
            this.tblSales.TabIndex = 1;
            this.tblSales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblSales_CellClick);
            // 
            // S_Code
            // 
            this.S_Code.HeaderText = "S_Code";
            this.S_Code.Name = "S_Code";
            this.S_Code.ReadOnly = true;
            // 
            // ChequeNo
            // 
            this.ChequeNo.HeaderText = "Cheque No";
            this.ChequeNo.Name = "ChequeNo";
            // 
            // P_Name
            // 
            this.P_Name.HeaderText = "Customer";
            this.P_Name.Name = "P_Name";
            this.P_Name.ReadOnly = true;
            // 
            // SR_Type
            // 
            this.SR_Type.HeaderText = "Date";
            this.SR_Type.Name = "SR_Type";
            this.SR_Type.ReadOnly = true;
            // 
            // S_ID
            // 
            this.S_ID.HeaderText = "Amount";
            this.S_ID.Name = "S_ID";
            this.S_ID.ReadOnly = true;
            // 
            // bank
            // 
            this.bank.HeaderText = "Bank ";
            this.bank.Name = "bank";
            // 
            // branch
            // 
            this.branch.HeaderText = "Branch";
            this.branch.Name = "branch";
            // 
            // details
            // 
            this.details.HeaderText = "Remarks";
            this.details.Name = "details";
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.White;
            this.panelSideMenu.Controls.Add(this.pnlSideMenuContent);
            this.panelSideMenu.Location = new System.Drawing.Point(-2, 66);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(136, 702);
            this.panelSideMenu.TabIndex = 133;
            // 
            // pnlSideMenuContent
            // 
            this.pnlSideMenuContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlSideMenuContent.Controls.Add(this.panel3);
            this.pnlSideMenuContent.Controls.Add(this.panel7);
            this.pnlSideMenuContent.Controls.Add(this.panel6);
            this.pnlSideMenuContent.Controls.Add(this.panel5);
            this.pnlSideMenuContent.Controls.Add(this.label5);
            this.pnlSideMenuContent.Controls.Add(this.panel8);
            this.pnlSideMenuContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSideMenuContent.HorizontalScrollbarBarColor = true;
            this.pnlSideMenuContent.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlSideMenuContent.HorizontalScrollbarSize = 10;
            this.pnlSideMenuContent.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenuContent.Name = "pnlSideMenuContent";
            this.pnlSideMenuContent.Size = new System.Drawing.Size(136, 702);
            this.pnlSideMenuContent.TabIndex = 101;
            this.pnlSideMenuContent.VerticalScrollbarBarColor = true;
            this.pnlSideMenuContent.VerticalScrollbarHighlightOnWheel = false;
            this.pnlSideMenuContent.VerticalScrollbarSize = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.metroTile2);
            this.panel3.Location = new System.Drawing.Point(-10, 236);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 61);
            this.panel3.TabIndex = 101;
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
            this.metroTile3.Text = "VIEW  STOCK";
            this.metroTile3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile3.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile3.UseSelectable = true;
            this.metroTile3.Click += new System.EventHandler(this.metroTile3_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.metroTile1);
            this.panel5.Location = new System.Drawing.Point(-10, 173);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(291, 61);
            this.panel5.TabIndex = 101;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(71, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 50);
            this.label5.TabIndex = 5;
            this.label5.Text = "Menu";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel8.Location = new System.Drawing.Point(132, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(7, 746);
            this.panel8.TabIndex = 100;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.AutoSize = true;
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(762, 774);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(131, 24);
            this.btnPrint.TabIndex = 341;
            this.btnPrint.Text = "Total Sales  :";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(772, 816);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 24);
            this.label7.TabIndex = 341;
            this.label7.Text = "Total Paid  :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(758, 852);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 24);
            this.label8.TabIndex = 341;
            this.label8.Text = "Total Credit  :";
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCredit.AutoSize = true;
            this.lblTotalCredit.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCredit.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCredit.Location = new System.Drawing.Point(945, 852);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(135, 24);
            this.lblTotalCredit.TabIndex = 342;
            this.lblTotalCredit.Text = "Total Credit  :";
            // 
            // lblTotalPaid
            // 
            this.lblTotalPaid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPaid.AutoSize = true;
            this.lblTotalPaid.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPaid.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPaid.Location = new System.Drawing.Point(959, 816);
            this.lblTotalPaid.Name = "lblTotalPaid";
            this.lblTotalPaid.Size = new System.Drawing.Size(121, 24);
            this.lblTotalPaid.TabIndex = 343;
            this.lblTotalPaid.Text = "Total Paid  :";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.ForeColor = System.Drawing.Color.Black;
            this.lblTotalSales.Location = new System.Drawing.Point(949, 774);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(131, 24);
            this.lblTotalSales.TabIndex = 344;
            this.lblTotalSales.Text = "Total Sales  :";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // ViewChequePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 780);
            this.Controls.Add(this.lblTotalCredit);
            this.Controls.Add(this.lblTotalPaid);
            this.Controls.Add(this.lblTotalSales);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnPrint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewChequePayment";
            this.Load += new System.EventHandler(this.ViewChequePayment_Load);
            this.SizeChanged += new System.EventHandler(this.ViewSales_SizeChanged);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSales)).EndInit();
            this.panelSideMenu.ResumeLayout(false);
            this.pnlSideMenuContent.ResumeLayout(false);
            this.pnlSideMenuContent.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.Button lnkBack;
        private System.Windows.Forms.Button lnkBtnShow;
        internal System.Windows.Forms.Label Label1;
        private MetroFramework.Controls.MetroDateTime dateStart;
        private MetroFramework.Controls.MetroDateTime dateEnd;
        private MetroFramework.Controls.MetroButton btnSearch;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtCustomerName;
        internal System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelSideMenu;
        private MetroFramework.Controls.MetroPanel pnlSideMenuContent;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroTile metroTile2;
        private System.Windows.Forms.Panel panel7;
        private MetroFramework.Controls.MetroTile metroTile4;
        private System.Windows.Forms.Panel panel6;
        private MetroFramework.Controls.MetroTile metroTile3;
        private System.Windows.Forms.Panel panel5;
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        internal System.Windows.Forms.Label btnPrint;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label lblTotalCredit;
        internal System.Windows.Forms.Label lblTotalPaid;
        internal System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.TextBox txtSalesID;
        private MetroFramework.Controls.MetroGrid tblSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn SR_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn details;
    }
}