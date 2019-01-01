namespace POS.AddToCart
{
    partial class VIewPrinters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VIewPrinters));
            this.cmbPrinterName = new MetroFramework.Controls.MetroComboBox();
            this.mlnkChoose = new MetroFramework.Controls.MetroLink();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.comboPaperSize = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.comboPaperSource = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cmbPrintResolution = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.lnkHome = new MetroFramework.Controls.MetroLink();
            this.SuspendLayout();
            // 
            // cmbPrinterName
            // 
            this.cmbPrinterName.FormattingEnabled = true;
            this.cmbPrinterName.ItemHeight = 23;
            this.cmbPrinterName.Location = new System.Drawing.Point(207, 115);
            this.cmbPrinterName.Name = "cmbPrinterName";
            this.cmbPrinterName.Size = new System.Drawing.Size(332, 29);
            this.cmbPrinterName.TabIndex = 0;
            this.cmbPrinterName.UseSelectable = true;
            // 
            // mlnkChoose
            // 
            this.mlnkChoose.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.mlnkChoose.Image = ((System.Drawing.Image)(resources.GetObject("mlnkChoose.Image")));
            this.mlnkChoose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mlnkChoose.ImageSize = 40;
            this.mlnkChoose.Location = new System.Drawing.Point(223, 439);
            this.mlnkChoose.Name = "mlnkChoose";
            this.mlnkChoose.Size = new System.Drawing.Size(114, 50);
            this.mlnkChoose.TabIndex = 1;
            this.mlnkChoose.Text = "Choose";
            this.mlnkChoose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mlnkChoose.UseSelectable = true;
            this.mlnkChoose.Click += new System.EventHandler(this.mlnkChoose_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(40, 115);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(126, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Select Printer";
            // 
            // comboPaperSize
            // 
            this.comboPaperSize.FormattingEnabled = true;
            this.comboPaperSize.ItemHeight = 23;
            this.comboPaperSize.Location = new System.Drawing.Point(207, 200);
            this.comboPaperSize.Name = "comboPaperSize";
            this.comboPaperSize.Size = new System.Drawing.Size(332, 29);
            this.comboPaperSize.TabIndex = 0;
            this.comboPaperSize.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(40, 204);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(100, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Paper Size";
            // 
            // comboPaperSource
            // 
            this.comboPaperSource.FormattingEnabled = true;
            this.comboPaperSource.ItemHeight = 23;
            this.comboPaperSource.Location = new System.Drawing.Point(207, 298);
            this.comboPaperSource.Name = "comboPaperSource";
            this.comboPaperSource.Size = new System.Drawing.Size(332, 29);
            this.comboPaperSource.TabIndex = 0;
            this.comboPaperSource.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(40, 302);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(124, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Paper Source";
            // 
            // cmbPrintResolution
            // 
            this.cmbPrintResolution.FormattingEnabled = true;
            this.cmbPrintResolution.ItemHeight = 23;
            this.cmbPrintResolution.Location = new System.Drawing.Point(207, 398);
            this.cmbPrintResolution.Name = "cmbPrintResolution";
            this.cmbPrintResolution.Size = new System.Drawing.Size(332, 29);
            this.cmbPrintResolution.TabIndex = 0;
            this.cmbPrintResolution.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(40, 402);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(149, 25);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = "Print Resolution";
            // 
            // lnkHome
            // 
            this.lnkHome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lnkHome.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.lnkHome.Image = ((System.Drawing.Image)(resources.GetObject("lnkHome.Image")));
            this.lnkHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkHome.ImageSize = 40;
            this.lnkHome.Location = new System.Drawing.Point(418, 11);
            this.lnkHome.Name = "lnkHome";
            this.lnkHome.Size = new System.Drawing.Size(120, 80);
            this.lnkHome.TabIndex = 46;
            this.lnkHome.Text = "HOME";
            this.lnkHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkHome.UseSelectable = true;
            this.lnkHome.Click += new System.EventHandler(this.lnkHome_Click);
            // 
            // VIewPrinters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 525);
            this.Controls.Add(this.lnkHome);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.mlnkChoose);
            this.Controls.Add(this.cmbPrintResolution);
            this.Controls.Add(this.comboPaperSource);
            this.Controls.Add(this.comboPaperSize);
            this.Controls.Add(this.cmbPrinterName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VIewPrinters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cmbPrinterName;
        private MetroFramework.Controls.MetroLink mlnkChoose;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox comboPaperSize;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox comboPaperSource;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cmbPrintResolution;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLink lnkHome;
    }
}