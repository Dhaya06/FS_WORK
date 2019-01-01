namespace POS.AddToCart
{
    partial class ViewSalesProductCancelSale
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblCart = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Warranty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_Return = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblCart)).BeginInit();
            this.SuspendLayout();
            // 
            // tblCart
            // 
            this.tblCart.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.S_Price,
            this.Qty,
            this.P_Total,
            this.P_Warranty,
            this.S_Return});
            this.tblCart.Location = new System.Drawing.Point(46, 63);
            this.tblCart.Name = "tblCart";
            this.tblCart.Size = new System.Drawing.Size(745, 321);
            this.tblCart.TabIndex = 6;
            this.tblCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblCart_CellClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::POS.AddToCart.Properties.Resources.letter_x;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(46, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(745, 47);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "P_Code";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "P_Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // S_Price
            // 
            this.S_Price.HeaderText = "Price";
            this.S_Price.Name = "S_Price";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Quantity";
            this.Qty.Name = "Qty";
            // 
            // P_Total
            // 
            this.P_Total.HeaderText = "Total";
            this.P_Total.Name = "P_Total";
            // 
            // P_Warranty
            // 
            this.P_Warranty.HeaderText = "Warranty";
            this.P_Warranty.Name = "P_Warranty";
            // 
            // S_Return
            // 
            this.S_Return.HeaderText = "S_Return";
            this.S_Return.Name = "S_Return";
            this.S_Return.Text = null;
            // 
            // ViewSalesProductCancelSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 451);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tblCart);
            this.Name = "ViewSalesProductCancelSale";
            this.Text = "Sales Return";
            ((System.ComponentModel.ISupportInitialize)(this.tblCart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tblCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_Warranty;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn S_Return;
    }
}