namespace POS.AddToCart
{
    partial class ViewStockUpdate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.flpLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tblStockReturn = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lnkHome = new System.Windows.Forms.Button();
            this.lnkBack = new System.Windows.Forms.Button();
            this.lnkBtnShow = new System.Windows.Forms.Button();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qauant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewButtonColumn();
            this.identity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flpLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblStockReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tblStockReturn);
            this.panel1.Location = new System.Drawing.Point(45, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1293, 489);
            this.panel1.TabIndex = 0;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.Controls.Add(this.lnkBack);
            this.Panel2.Controls.Add(this.lnkBtnShow);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Location = new System.Drawing.Point(0, 17);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1382, 45);
            this.Panel2.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(582, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(176, 24);
            this.Label1.TabIndex = 97;
            this.Label1.Text = "Stock Adjustments";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblTime);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.flpLayout);
            this.panel3.Location = new System.Drawing.Point(3, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(91, 708);
            this.panel3.TabIndex = 100;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Black;
            this.lblTime.Location = new System.Drawing.Point(101, 132);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(68, 21);
            this.lblTime.TabIndex = 109;
            this.lblTime.Text = "Timer: -";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 21);
            this.label4.TabIndex = 108;
            this.label4.Text = "Time: -";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(101, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 21);
            this.label3.TabIndex = 107;
            this.label3.Text = "Admin (User)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 106;
            this.label2.Text = "User: -";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel7.Location = new System.Drawing.Point(80, -1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 836);
            this.panel7.TabIndex = 104;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel5.Location = new System.Drawing.Point(136, -1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 739);
            this.panel5.TabIndex = 100;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(77, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 24);
            this.label8.TabIndex = 99;
            this.label8.Text = "MENU";
            // 
            // flpLayout
            // 
            this.flpLayout.AutoScroll = true;
            this.flpLayout.Controls.Add(this.lnkHome);
            this.flpLayout.Location = new System.Drawing.Point(3, 219);
            this.flpLayout.Name = "flpLayout";
            this.flpLayout.Size = new System.Drawing.Size(226, 313);
            this.flpLayout.TabIndex = 98;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tblStockReturn
            // 
            this.tblStockReturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tblStockReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblStockReturn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PID,
            this.Pname,
            this.StockID,
            this.PurDate,
            this.SupName,
            this.Qauant,
            this.ReturnType,
            this.Date,
            this.Description,
            this.identity});
            this.tblStockReturn.Location = new System.Drawing.Point(3, 13);
            this.tblStockReturn.Name = "tblStockReturn";
            this.tblStockReturn.Size = new System.Drawing.Size(1287, 451);
            this.tblStockReturn.TabIndex = 1;
            this.tblStockReturn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblStockReturn_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::POS.AddToCart.Properties.Resources.iconig1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(65, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 89);
            this.pictureBox1.TabIndex = 105;
            this.pictureBox1.TabStop = false;
            // 
            // lnkHome
            // 
            this.lnkHome.BackColor = System.Drawing.Color.White;
            this.lnkHome.BackgroundImage = global::POS.AddToCart.Properties.Resources.home;
            this.lnkHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lnkHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkHome.Location = new System.Drawing.Point(3, 3);
            this.lnkHome.Name = "lnkHome";
            this.lnkHome.Size = new System.Drawing.Size(216, 47);
            this.lnkHome.TabIndex = 103;
            this.lnkHome.UseVisualStyleBackColor = false;
            this.lnkHome.Click += new System.EventHandler(this.lnkHome_Click);
            // 
            // lnkBack
            // 
            this.lnkBack.BackColor = System.Drawing.Color.White;
            this.lnkBack.BackgroundImage = global::POS.AddToCart.Properties.Resources.right_arrow1;
            this.lnkBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lnkBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkBack.Location = new System.Drawing.Point(3, 0);
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
            // PID
            // 
            this.PID.HeaderText = "PID";
            this.PID.Name = "PID";
            this.PID.ReadOnly = true;
            // 
            // Pname
            // 
            this.Pname.HeaderText = "Pname";
            this.Pname.Name = "Pname";
            this.Pname.ReadOnly = true;
            // 
            // StockID
            // 
            this.StockID.HeaderText = "StockID";
            this.StockID.Name = "StockID";
            this.StockID.ReadOnly = true;
            // 
            // PurDate
            // 
            this.PurDate.HeaderText = "PurDate";
            this.PurDate.Name = "PurDate";
            this.PurDate.ReadOnly = true;
            // 
            // SupName
            // 
            this.SupName.HeaderText = "SupName";
            this.SupName.Name = "SupName";
            this.SupName.ReadOnly = true;
            // 
            // Qauant
            // 
            this.Qauant.HeaderText = "Qauant";
            this.Qauant.Name = "Qauant";
            this.Qauant.ReadOnly = true;
            // 
            // ReturnType
            // 
            this.ReturnType.HeaderText = "ReturnType";
            this.ReturnType.Name = "ReturnType";
            this.ReturnType.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // identity
            // 
            this.identity.HeaderText = "identity";
            this.identity.Name = "identity";
            this.identity.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = global::POS.AddToCart.Properties.Resources.Minimise;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1203, 68);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 35);
            this.btnClose.TabIndex = 104;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ViewStockUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 621);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ViewStockUpdate";
            this.panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flpLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblStockReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.Button lnkBack;
        private System.Windows.Forms.Button lnkBtnShow;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button lnkHome;
        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flpLayout;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DataGridView tblStockReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qauant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewButtonColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn identity;
        private System.Windows.Forms.Button btnClose;
    }
}