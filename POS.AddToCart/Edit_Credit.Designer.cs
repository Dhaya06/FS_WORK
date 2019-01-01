namespace POS.AddToCart
{
    partial class Edit_Credit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_Credit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCName = new MetroFramework.Controls.MetroTextBox();
            this.txtCredit = new MetroFramework.Controls.MetroTextBox();
            this.txtAmount = new MetroFramework.Controls.MetroTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnupdate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCName);
            this.panel1.Controls.Add(this.txtCredit);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Location = new System.Drawing.Point(35, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 262);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::POS.AddToCart.Properties.Resources.letter_x;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(106, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 68);
            this.button1.TabIndex = 124;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.White;
            this.btnupdate.BackgroundImage = global::POS.AddToCart.Properties.Resources.reload;
            this.btnupdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnupdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdate.Location = new System.Drawing.Point(295, 155);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(153, 68);
            this.btnupdate.TabIndex = 125;
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(341, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 21);
            this.label4.TabIndex = 121;
            this.label4.Text = "&Update";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(153, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 21);
            this.label3.TabIndex = 121;
            this.label3.Text = "&Close";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(102, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 21);
            this.label2.TabIndex = 121;
            this.label2.Text = "&Credit :-";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 21);
            this.label1.TabIndex = 122;
            this.label1.Text = "&Customer Name :-";
            // 
            // txtCName
            // 
            // 
            // 
            // 
            this.txtCName.CustomButton.Image = null;
            this.txtCName.CustomButton.Location = new System.Drawing.Point(240, 2);
            this.txtCName.CustomButton.Name = "";
            this.txtCName.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtCName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCName.CustomButton.TabIndex = 1;
            this.txtCName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCName.CustomButton.UseSelectable = true;
            this.txtCName.CustomButton.Visible = false;
            this.txtCName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtCName.Lines = new string[0];
            this.txtCName.Location = new System.Drawing.Point(226, 28);
            this.txtCName.MaxLength = 32767;
            this.txtCName.Multiline = true;
            this.txtCName.Name = "txtCName";
            this.txtCName.PasswordChar = '\0';
            this.txtCName.ReadOnly = true;
            this.txtCName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCName.SelectedText = "";
            this.txtCName.SelectionLength = 0;
            this.txtCName.SelectionStart = 0;
            this.txtCName.ShortcutsEnabled = true;
            this.txtCName.Size = new System.Drawing.Size(274, 36);
            this.txtCName.TabIndex = 117;
            this.txtCName.UseSelectable = true;
            this.txtCName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtCredit
            // 
            // 
            // 
            // 
            this.txtCredit.CustomButton.Image = null;
            this.txtCredit.CustomButton.Location = new System.Drawing.Point(94, 2);
            this.txtCredit.CustomButton.Name = "";
            this.txtCredit.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtCredit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCredit.CustomButton.TabIndex = 1;
            this.txtCredit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCredit.CustomButton.UseSelectable = true;
            this.txtCredit.CustomButton.Visible = false;
            this.txtCredit.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtCredit.Lines = new string[0];
            this.txtCredit.Location = new System.Drawing.Point(372, 80);
            this.txtCredit.MaxLength = 13;
            this.txtCredit.Multiline = true;
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.PasswordChar = '\0';
            this.txtCredit.ReadOnly = true;
            this.txtCredit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCredit.SelectedText = "";
            this.txtCredit.SelectionLength = 0;
            this.txtCredit.SelectionStart = 0;
            this.txtCredit.ShortcutsEnabled = true;
            this.txtCredit.Size = new System.Drawing.Size(128, 36);
            this.txtCredit.TabIndex = 118;
            this.txtCredit.UseSelectable = true;
            this.txtCredit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCredit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtAmount
            // 
            // 
            // 
            // 
            this.txtAmount.CustomButton.Image = null;
            this.txtAmount.CustomButton.Location = new System.Drawing.Point(106, 2);
            this.txtAmount.CustomButton.Name = "";
            this.txtAmount.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAmount.CustomButton.TabIndex = 1;
            this.txtAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAmount.CustomButton.UseSelectable = true;
            this.txtAmount.CustomButton.Visible = false;
            this.txtAmount.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtAmount.Lines = new string[0];
            this.txtAmount.Location = new System.Drawing.Point(226, 80);
            this.txtAmount.MaxLength = 13;
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAmount.SelectedText = "";
            this.txtAmount.SelectionLength = 0;
            this.txtAmount.SelectionStart = 0;
            this.txtAmount.ShortcutsEnabled = true;
            this.txtAmount.Size = new System.Drawing.Size(140, 36);
            this.txtAmount.TabIndex = 119;
            this.txtAmount.UseSelectable = true;
            this.txtAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // Edit_Credit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 411);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Edit_Credit";
            this.Text = "Edit_Credit";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox txtCName;
        private MetroFramework.Controls.MetroTextBox txtCredit;
        private MetroFramework.Controls.MetroTextBox txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}