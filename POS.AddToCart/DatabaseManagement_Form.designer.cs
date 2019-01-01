namespace POS.AddToCart
{
    partial class DatabaseManagement_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseManagement_Form));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackup = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.btnBackupBrowser = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.txtBackupLocation = new MetroFramework.Controls.MetroTextBox();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRestore = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.btnRestoreLocation = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.txtRestoreLocation = new MetroFramework.Controls.MetroTextBox();
            this.lnkHome = new MetroFramework.Controls.MetroLink();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.btnBackup);
            this.groupPanel1.Controls.Add(this.btnBackupBrowser);
            this.groupPanel1.Controls.Add(this.txtBackupLocation);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(35, 136);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(622, 188);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Backup database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(47, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Location : -";
            // 
            // btnBackup
            // 
            this.btnBackup.Enabled = false;
            this.btnBackup.Image = null;
            this.btnBackup.Location = new System.Drawing.Point(488, 94);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(56, 19);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseSelectable = true;
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnBackupBrowser
            // 
            this.btnBackupBrowser.Image = null;
            this.btnBackupBrowser.Location = new System.Drawing.Point(488, 54);
            this.btnBackupBrowser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBackupBrowser.Name = "btnBackupBrowser";
            this.btnBackupBrowser.Size = new System.Drawing.Size(56, 19);
            this.btnBackupBrowser.TabIndex = 2;
            this.btnBackupBrowser.Text = "Browser";
            this.btnBackupBrowser.UseSelectable = true;
            this.btnBackupBrowser.UseVisualStyleBackColor = true;
            this.btnBackupBrowser.Click += new System.EventHandler(this.btnBackupBrowser_Click);
            // 
            // txtBackupLocation
            // 
            // 
            // 
            // 
            this.txtBackupLocation.CustomButton.Image = null;
            this.txtBackupLocation.CustomButton.Location = new System.Drawing.Point(235, 1);
            this.txtBackupLocation.CustomButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBackupLocation.CustomButton.Name = "";
            this.txtBackupLocation.CustomButton.Size = new System.Drawing.Size(13, 14);
            this.txtBackupLocation.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBackupLocation.CustomButton.TabIndex = 1;
            this.txtBackupLocation.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBackupLocation.CustomButton.UseSelectable = true;
            this.txtBackupLocation.CustomButton.Visible = false;
            this.txtBackupLocation.Lines = new string[0];
            this.txtBackupLocation.Location = new System.Drawing.Point(118, 54);
            this.txtBackupLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBackupLocation.MaxLength = 32767;
            this.txtBackupLocation.Name = "txtBackupLocation";
            this.txtBackupLocation.PasswordChar = '\0';
            this.txtBackupLocation.PromptText = "Backup File Location";
            this.txtBackupLocation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBackupLocation.SelectedText = "";
            this.txtBackupLocation.SelectionLength = 0;
            this.txtBackupLocation.SelectionStart = 0;
            this.txtBackupLocation.ShortcutsEnabled = true;
            this.txtBackupLocation.Size = new System.Drawing.Size(331, 19);
            this.txtBackupLocation.TabIndex = 1;
            this.txtBackupLocation.UseSelectable = true;
            this.txtBackupLocation.WaterMark = "Backup File Location";
            this.txtBackupLocation.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBackupLocation.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.btnRestore);
            this.groupPanel2.Controls.Add(this.btnRestoreLocation);
            this.groupPanel2.Controls.Add(this.txtRestoreLocation);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(35, 351);
            this.groupPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(622, 188);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "Restore database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(50, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Location : -";
            // 
            // btnRestore
            // 
            this.btnRestore.Enabled = false;
            this.btnRestore.Image = null;
            this.btnRestore.Location = new System.Drawing.Point(488, 127);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(56, 19);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseSelectable = true;
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnRestoreLocation
            // 
            this.btnRestoreLocation.Image = null;
            this.btnRestoreLocation.Location = new System.Drawing.Point(488, 89);
            this.btnRestoreLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRestoreLocation.Name = "btnRestoreLocation";
            this.btnRestoreLocation.Size = new System.Drawing.Size(56, 19);
            this.btnRestoreLocation.TabIndex = 2;
            this.btnRestoreLocation.Text = "Browser";
            this.btnRestoreLocation.UseSelectable = true;
            this.btnRestoreLocation.UseVisualStyleBackColor = true;
            this.btnRestoreLocation.Click += new System.EventHandler(this.btnRestoreLocation_Click);
            // 
            // txtRestoreLocation
            // 
            // 
            // 
            // 
            this.txtRestoreLocation.CustomButton.Image = null;
            this.txtRestoreLocation.CustomButton.Location = new System.Drawing.Point(235, 1);
            this.txtRestoreLocation.CustomButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRestoreLocation.CustomButton.Name = "";
            this.txtRestoreLocation.CustomButton.Size = new System.Drawing.Size(13, 14);
            this.txtRestoreLocation.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRestoreLocation.CustomButton.TabIndex = 1;
            this.txtRestoreLocation.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRestoreLocation.CustomButton.UseSelectable = true;
            this.txtRestoreLocation.CustomButton.Visible = false;
            this.txtRestoreLocation.Lines = new string[0];
            this.txtRestoreLocation.Location = new System.Drawing.Point(118, 89);
            this.txtRestoreLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRestoreLocation.MaxLength = 32767;
            this.txtRestoreLocation.Name = "txtRestoreLocation";
            this.txtRestoreLocation.PasswordChar = '\0';
            this.txtRestoreLocation.PromptText = "Restore File Location";
            this.txtRestoreLocation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRestoreLocation.SelectedText = "";
            this.txtRestoreLocation.SelectionLength = 0;
            this.txtRestoreLocation.SelectionStart = 0;
            this.txtRestoreLocation.ShortcutsEnabled = true;
            this.txtRestoreLocation.Size = new System.Drawing.Size(331, 19);
            this.txtRestoreLocation.TabIndex = 1;
            this.txtRestoreLocation.UseSelectable = true;
            this.txtRestoreLocation.WaterMark = "Restore File Location";
            this.txtRestoreLocation.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRestoreLocation.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lnkHome
            // 
            this.lnkHome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lnkHome.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.lnkHome.Image = ((System.Drawing.Image)(resources.GetObject("lnkHome.Image")));
            this.lnkHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkHome.ImageSize = 40;
            this.lnkHome.Location = new System.Drawing.Point(551, 19);
            this.lnkHome.Name = "lnkHome";
            this.lnkHome.Size = new System.Drawing.Size(106, 80);
            this.lnkHome.TabIndex = 46;
            this.lnkHome.Text = "HOME";
            this.lnkHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkHome.UseSelectable = true;
            this.lnkHome.Click += new System.EventHandler(this.lnkHome_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // DatabaseManagement_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 627);
            this.Controls.Add(this.lnkHome);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DatabaseManagement_Form";
            this.Padding = new System.Windows.Forms.Padding(15, 49, 15, 16);
            this.Text = "Database Management";
            this.SizeChanged += new System.EventHandler(this.DatabaseManagement_Form_SizeChanged);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private MetroFramework.Controls.MetroTextBox txtBackupLocation;
        private MetroFramework.Controls.MetroTextBox txtRestoreLocation;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton btnBackup;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton btnBackupBrowser;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton btnRestore;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton btnRestoreLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroLink lnkHome;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}