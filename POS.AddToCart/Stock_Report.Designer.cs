namespace POS.AddToCart
{
    partial class Stock_Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this._CategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StockDS = new POS.AddToCart.StockDS();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this._CategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockDS)).BeginInit();
            this.SuspendLayout();
            // 
            // _CategoryBindingSource
            // 
            this._CategoryBindingSource.DataMember = "_Category";
            this._CategoryBindingSource.DataSource = this.StockDS;
            // 
            // StockDS
            // 
            this.StockDS.DataSetName = "StockDS";
            this.StockDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this._CategoryBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.Location = new System.Drawing.Point(236, 74);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewer1.Size = new System.Drawing.Size(660, 319);
            this.reportViewer1.TabIndex = 0;
            // 
            // Stock_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 583);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Stock_Report";
            this.Load += new System.EventHandler(this.Stock_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this._CategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _CategoryBindingSource;
        private StockDS StockDS;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}