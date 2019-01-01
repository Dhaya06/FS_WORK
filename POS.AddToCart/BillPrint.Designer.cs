namespace POS.AddToCart
{
    partial class BillPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillPrint));
            this.sales_productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BillDataSet = new POS.AddToCart.BillDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sales_productTableAdapter = new POS.AddToCart.BillDataSetTableAdapters.sales_productTableAdapter();
            this.btnCLose = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sales_productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // sales_productBindingSource
            // 
            this.sales_productBindingSource.DataMember = "sales_product";
            this.sales_productBindingSource.DataSource = this.BillDataSet;
            // 
            // BillDataSet
            // 
            this.BillDataSet.DataSetName = "BillDataSet";
            this.BillDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "BillReport";
            reportDataSource1.Value = this.sales_productBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS.AddToCart.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 60);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1104, 585);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.PrintingBegin += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.reportViewer1_PrintingBegin);
            // 
            // sales_productTableAdapter
            // 
            this.sales_productTableAdapter.ClearBeforeFill = true;
            // 
            // btnCLose
            // 
            this.btnCLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLose.Location = new System.Drawing.Point(556, 21);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(108, 33);
            this.btnCLose.TabIndex = 1;
            this.btnCLose.Text = "Close";
            this.btnCLose.UseVisualStyleBackColor = true;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // BillPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1144, 665);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BillPrint";
            this.Text = "BillPrint";
            this.Load += new System.EventHandler(this.BillPrint_Load);
            this.SizeChanged += new System.EventHandler(this.BillPrint_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.sales_productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource sales_productBindingSource;
        private BillDataSet BillDataSet;
        private BillDataSetTableAdapters.sales_productTableAdapter sales_productTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnCLose;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}