namespace POS.AddToCart
{
    partial class Report_Sales
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
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lnkBack = new System.Windows.Forms.Button();
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
            this._SalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Sale_Data_Set = new POS.AddToCart.Sale_Data_Set();
            this._SalesTableAdapter = new POS.AddToCart.Sale_Data_SetTableAdapters._SalesTableAdapter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.dateEnd = new MetroFramework.Controls.MetroDateTime();
            this.dateStart = new MetroFramework.Controls.MetroDateTime();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Panel2.SuspendLayout();
            this.panelSideMenu.SuspendLayout();
            this.pnlSideMenuContent.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sale_Data_Set)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.Controls.Add(this.lnkBack);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Location = new System.Drawing.Point(0, 23);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1382, 45);
            this.Panel2.TabIndex = 3;
            // 
            // lnkBack
            // 
            this.lnkBack.BackColor = System.Drawing.Color.White;
            this.lnkBack.BackgroundImage = global::POS.AddToCart.Properties.Resources.right_arrow1;
            this.lnkBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lnkBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkBack.Location = new System.Drawing.Point(6, -1);
            this.lnkBack.Name = "lnkBack";
            this.lnkBack.Size = new System.Drawing.Size(44, 45);
            this.lnkBack.TabIndex = 101;
            this.lnkBack.UseVisualStyleBackColor = false;
            this.lnkBack.Click += new System.EventHandler(this.lnkBack_Click);
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(595, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(82, 24);
            this.Label1.TabIndex = 97;
            this.Label1.Text = "Reports";
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSideMenu.BackColor = System.Drawing.Color.White;
            this.panelSideMenu.Controls.Add(this.pnlSideMenuContent);
            this.panelSideMenu.Location = new System.Drawing.Point(3, 65);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(217, 712);
            this.panelSideMenu.TabIndex = 134;
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
            this.pnlSideMenuContent.Size = new System.Drawing.Size(217, 712);
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
            this.panel5.Location = new System.Drawing.Point(213, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(7, 756);
            this.panel5.TabIndex = 100;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // _SalesBindingSource
            // 
            this._SalesBindingSource.DataMember = "_Sales";
            this._SalesBindingSource.DataSource = this.Sale_Data_Set;
            // 
            // Sale_Data_Set
            // 
            this.Sale_Data_Set.DataSetName = "Sale_Data_Set";
            this.Sale_Data_Set.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _SalesTableAdapter
            // 
            this._SalesTableAdapter.ClearBeforeFill = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(110, 95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1179, 568);
            this.tabControl1.TabIndex = 4;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(257, 68);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(908, 460);
            this.reportViewer1.TabIndex = 0;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtReceiptNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtReceiptNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptNo.Location = new System.Drawing.Point(60, 130);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(164, 26);
            this.txtReceiptNo.TabIndex = 322;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(60, 222);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(164, 26);
            this.txtCustomerName.TabIndex = 322;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(57, 109);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(0, 18);
            this.Label11.TabIndex = 323;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 18);
            this.label3.TabIndex = 323;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(628, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 18);
            this.label4.TabIndex = 323;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 18);
            this.label2.TabIndex = 323;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(946, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 29);
            this.btnSearch.TabIndex = 324;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateEnd
            // 
            this.dateEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateEnd.Location = new System.Drawing.Point(692, 19);
            this.dateEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(200, 31);
            this.dateEnd.TabIndex = 325;
            // 
            // dateStart
            // 
            this.dateStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateStart.Location = new System.Drawing.Point(382, 19);
            this.dateStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(200, 31);
            this.dateStart.TabIndex = 326;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dateStart);
            this.tabPage2.Controls.Add(this.dateEnd);
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.Label11);
            this.tabPage2.Controls.Add(this.txtCustomerName);
            this.tabPage2.Controls.Add(this.txtReceiptNo);
            this.tabPage2.Controls.Add(this.reportViewer1);
            this.tabPage2.Font = new System.Drawing.Font("Californian FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1171, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sales Report";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Report_Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 624);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Panel2);
            this.Name = "Report_Sales";
            this.Load += new System.EventHandler(this.Report_Sales_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.panelSideMenu.ResumeLayout(false);
            this.pnlSideMenuContent.ResumeLayout(false);
            this.pnlSideMenuContent.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._SalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sale_Data_Set)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _SalesBindingSource;
        private Sale_Data_Set Sale_Data_Set;
        private Sale_Data_SetTableAdapters._SalesTableAdapter _SalesTableAdapter;
        internal System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.Button lnkBack;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private MetroFramework.Controls.MetroDateTime dateStart;
        private MetroFramework.Controls.MetroDateTime dateEnd;
        private MetroFramework.Controls.MetroButton btnSearch;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtCustomerName;
        internal System.Windows.Forms.TextBox txtReceiptNo;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}