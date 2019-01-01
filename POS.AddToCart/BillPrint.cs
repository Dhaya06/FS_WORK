using BusinessObjects;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.AddToCart
{
    public partial class BillPrint : MetroFramework.Forms.MetroForm
    {
        string connString2 = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;

        int sales_id = 0;
        string name, addrs;
        // decimal totals = 0;

        public BillPrint(int sid, string custname, string adres)
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.Resizable = false;
            this.CenterToScreen();

            sales_id = sid;
            name = custname;
            addrs = adres;


            loadParam();
            //MessageBox.Show(sid.ToString());

            this.TopMost = true;
           // t.Abort();

            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Visible = false;
        }

        public void GifLoading()
        {
            Application.Run(new loading());
        }
        // where sales_id= (select max(sales_id) from dbo.sales_product)


        private void BillPrint_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            // TODO: This line of code loads data into the 'BillDataSet.sales_product' table. You can move, or remove it, as needed.
            this.sales_productTableAdapter.Fill(this.BillDataSet.sales_product, sales_id);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();

        }

        void loadParam()
        {
            string text = "";
            Sales_BM sale = new Sales_BM();
            sale.sales_id = sales_id;
            sale = sale.getSalesByID(connString2);

            if (sale.credit > 0)
            {
                text = "Credit";
            }
            else
            {
                text = "Balance";
            }

            Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                
                new Microsoft.Reporting.WinForms.ReportParameter("ReportParamSales",sales_id.ToString()),
                
                new Microsoft.Reporting.WinForms.ReportParameter("paramCustName",name.ToString()),
                
                new Microsoft.Reporting.WinForms.ReportParameter("paramAddress",addrs.ToString()),
                   new Microsoft.Reporting.WinForms.ReportParameter("paramTotal",sale.total.ToString()),
                
                new Microsoft.Reporting.WinForms.ReportParameter("paramPayment",sale.paid.ToString()),
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParamBalance",sale.credit.ToString()),
            new Microsoft.Reporting.WinForms.ReportParameter("paramBC",text),
            new Microsoft.Reporting.WinForms.ReportParameter("paramDate",sale.date_time.ToString("dd-MMM-yyyy"))
                
            };

            reportViewer1.LocalReport.SetParameters(param);


            BusinessObjects.Print print = new Print();
            // string connString2 = @"Data Source=SURESH\SQLEXPRESS;Initial Catalog=FutureSoft;Integrated Security=True";
            print = print.GetP(connString2);
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.Document = printDocument;
            //printDocument.PrintPage +=new PrintPageEventHandler(printDocument_PrintPage);


            printDocument.PrinterSettings.PrinterName = print.PrinterName;
            printDocument.DefaultPageSettings.PaperSize = printDocument.PrinterSettings.PaperSizes[print.PaperSize];
            printDocument.DefaultPageSettings.PaperSource = printDocument.PrinterSettings.PaperSources[print.Source];
            printDocument.DefaultPageSettings.PrinterResolution = printDocument.PrinterSettings.PrinterResolutions[print.Resolution];
            printDocument.DefaultPageSettings.Margins.Left = 4;
            printDocument.DefaultPageSettings.Margins.Right = 4;
            printDocument.DefaultPageSettings.Margins.Top = 5;
            printDocument.DefaultPageSettings.Margins.Bottom = 8;
            printDocument.DocumentName = "Vista_Receipt";
            printDocument.DefaultPageSettings.PrinterSettings.MaximumPage = 1;
            printDocument.DefaultPageSettings.PrinterSettings.Duplex = Duplex.Vertical;
          
            reportViewer1.SetPageSettings(printDocument.DefaultPageSettings);
            
           // printDocument.PrintPage += printDocument_PrintPage2;
            //printDocument.Print();

        }

       
       
        void printDocument_PrintPage2(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = true;
            StringFormat stringFormat = new StringFormat();

                stringFormat.LineAlignment = StringAlignment.Near;
                
                Graphics graphics = e.Graphics;
                
                Font font = new Font("Courier New", 10);
                float FontHeight = font.GetHeight();
                int startX = 10;
                int startY = 200;
                int count = 0;
                int offset = 100;
                int middle = (e.PageSettings.PaperSize.Width / 2);

                string a ="Time: "+ DateTime.Now.ToString("h:mm:ss tt");
                string dd = DateTime.Now.ToString();

                graphics.DrawString("DATE :" + dd.PadRight(40) + a, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + 10 + (int)FontHeight + 5);
                graphics.DrawString("CUSTOMER :" + Name, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + 20 + (int)FontHeight + 5 + 15);
                
                offset = offset + 10;

                graphics.DrawString("Product".PadRight(24) + "Qty".PadRight(20) + "Amount".PadRight(20) + "Total",  
                    new Font("Courier New",12),new SolidBrush(Color.Black), startX, startY + offset+10);

                e.HasMorePages = false;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {


        }

        private void reportViewer1_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
            //this.Close();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void BillPrint_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = SystemIcons.Application;



                notifyIcon1.BalloonTipText = "System Has Been Minimized. You Can Maximise here";
                notifyIcon1.ShowBalloonTip(3000);
            }
            else
            {
                //notifyIcon1.Visible = true;
                //notifyIcon1.Icon = SystemIcons.Application;
                //notifyIcon1.BalloonTipText = "System Process Started";
                //notifyIcon1.ShowBalloonTip(3000);
                notifyIcon1.Icon = null;

            }
        }




    }
}
