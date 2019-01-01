namespace POS.AddToCart
{
    partial class Stock_Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stock_Update));
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.txtQuantity = new MetroFramework.Controls.MetroTextBox();
            this.txtPName = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkStockAdjust = new MetroFramework.Controls.MetroRadioButton();
            this.chkStockReturn = new MetroFramework.Controls.MetroRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnupdate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAdjustedQuantity = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(171, 141);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(274, 82);
            this.txtDesc.TabIndex = 0;
            this.txtDesc.Text = "";
            // 
            // txtQuantity
            // 
            // 
            // 
            // 
            this.txtQuantity.CustomButton.Image = null;
            this.txtQuantity.CustomButton.Location = new System.Drawing.Point(106, 2);
            this.txtQuantity.CustomButton.Name = "";
            this.txtQuantity.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtQuantity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQuantity.CustomButton.TabIndex = 1;
            this.txtQuantity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQuantity.CustomButton.UseSelectable = true;
            this.txtQuantity.CustomButton.Visible = false;
            this.txtQuantity.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtQuantity.Lines = new string[0];
            this.txtQuantity.Location = new System.Drawing.Point(171, 87);
            this.txtQuantity.MaxLength = 13;
            this.txtQuantity.Multiline = true;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PasswordChar = '\0';
            this.txtQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.SelectionLength = 0;
            this.txtQuantity.SelectionStart = 0;
            this.txtQuantity.ShortcutsEnabled = true;
            this.txtQuantity.Size = new System.Drawing.Size(140, 36);
            this.txtQuantity.TabIndex = 1;
            this.txtQuantity.UseSelectable = true;
            this.txtQuantity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtQuantity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtQuantity.TabStopChanged += new System.EventHandler(this.txtQuantity_TabStopChanged);
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            this.txtQuantity.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // txtPName
            // 
            // 
            // 
            // 
            this.txtPName.CustomButton.Image = null;
            this.txtPName.CustomButton.Location = new System.Drawing.Point(240, 2);
            this.txtPName.CustomButton.Name = "";
            this.txtPName.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtPName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPName.CustomButton.TabIndex = 1;
            this.txtPName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPName.CustomButton.UseSelectable = true;
            this.txtPName.CustomButton.Visible = false;
            this.txtPName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtPName.Lines = new string[0];
            this.txtPName.Location = new System.Drawing.Point(171, 35);
            this.txtPName.MaxLength = 32767;
            this.txtPName.Multiline = true;
            this.txtPName.Name = "txtPName";
            this.txtPName.PasswordChar = '\0';
            this.txtPName.ReadOnly = true;
            this.txtPName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPName.SelectedText = "";
            this.txtPName.SelectionLength = 0;
            this.txtPName.SelectionStart = 0;
            this.txtPName.ShortcutsEnabled = true;
            this.txtPName.Size = new System.Drawing.Size(274, 36);
            this.txtPName.TabIndex = 1;
            this.txtPName.UseSelectable = true;
            this.txtPName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Porduct Name :-";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Quantity :-";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Description :-";
            // 
            // chkStockAdjust
            // 
            this.chkStockAdjust.AutoSize = true;
            this.chkStockAdjust.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkStockAdjust.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkStockAdjust.Location = new System.Drawing.Point(207, 19);
            this.chkStockAdjust.Name = "chkStockAdjust";
            this.chkStockAdjust.Size = new System.Drawing.Size(135, 25);
            this.chkStockAdjust.TabIndex = 8;
            this.chkStockAdjust.Text = "Stock Adjust";
            this.chkStockAdjust.UseSelectable = true;
            // 
            // chkStockReturn
            // 
            this.chkStockReturn.AutoSize = true;
            this.chkStockReturn.Checked = true;
            this.chkStockReturn.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkStockReturn.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkStockReturn.Location = new System.Drawing.Point(18, 19);
            this.chkStockReturn.Name = "chkStockReturn";
            this.chkStockReturn.Size = new System.Drawing.Size(138, 25);
            this.chkStockReturn.TabIndex = 9;
            this.chkStockReturn.TabStop = true;
            this.chkStockReturn.Text = "Stock Return";
            this.chkStockReturn.UseSelectable = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkStockReturn);
            this.groupBox1.Controls.Add(this.chkStockAdjust);
            this.groupBox1.Location = new System.Drawing.Point(51, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 56);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(340, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 21);
            this.label5.TabIndex = 117;
            this.label5.Text = "(+)";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(153, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 21);
            this.label4.TabIndex = 116;
            this.label4.Text = "(-)";
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.White;
            this.btnupdate.BackgroundImage = global::POS.AddToCart.Properties.Resources.reload;
            this.btnupdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnupdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdate.Location = new System.Drawing.Point(240, 291);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(153, 68);
            this.btnupdate.TabIndex = 115;
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::POS.AddToCart.Properties.Resources.letter_x;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(69, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 68);
            this.button1.TabIndex = 115;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAdjustedQuantity
            // 
            // 
            // 
            // 
            this.txtAdjustedQuantity.CustomButton.Image = null;
            this.txtAdjustedQuantity.CustomButton.Location = new System.Drawing.Point(94, 2);
            this.txtAdjustedQuantity.CustomButton.Name = "";
            this.txtAdjustedQuantity.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtAdjustedQuantity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAdjustedQuantity.CustomButton.TabIndex = 1;
            this.txtAdjustedQuantity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAdjustedQuantity.CustomButton.UseSelectable = true;
            this.txtAdjustedQuantity.CustomButton.Visible = false;
            this.txtAdjustedQuantity.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtAdjustedQuantity.Lines = new string[0];
            this.txtAdjustedQuantity.Location = new System.Drawing.Point(317, 87);
            this.txtAdjustedQuantity.MaxLength = 13;
            this.txtAdjustedQuantity.Multiline = true;
            this.txtAdjustedQuantity.Name = "txtAdjustedQuantity";
            this.txtAdjustedQuantity.PasswordChar = '\0';
            this.txtAdjustedQuantity.ReadOnly = true;
            this.txtAdjustedQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdjustedQuantity.SelectedText = "";
            this.txtAdjustedQuantity.SelectionLength = 0;
            this.txtAdjustedQuantity.SelectionStart = 0;
            this.txtAdjustedQuantity.ShortcutsEnabled = true;
            this.txtAdjustedQuantity.Size = new System.Drawing.Size(128, 36);
            this.txtAdjustedQuantity.TabIndex = 1;
            this.txtAdjustedQuantity.UseSelectable = true;
            this.txtAdjustedQuantity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAdjustedQuantity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtAdjustedQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtAdjustedQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            this.txtAdjustedQuantity.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // Stock_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(492, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.txtAdjustedQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtDesc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Stock_Update";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtDesc;
        private MetroFramework.Controls.MetroTextBox txtQuantity;
        private MetroFramework.Controls.MetroTextBox txtPName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroRadioButton chkStockAdjust;
        private MetroFramework.Controls.MetroRadioButton chkStockReturn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button button1;
        private MetroFramework.Controls.MetroTextBox txtAdjustedQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}