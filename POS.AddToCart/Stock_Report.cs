using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.AddToCart
{
    public partial class Stock_Report : MetroFramework.Forms.MetroForm
    {
        public Stock_Report()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.MinimizeBox = true;
            //createData();
        }

        private void Stock_Report_Load(object sender, EventArgs e)
        {
            //createData();
            //this.StockReportViewr.RefreshReport();

            StockDS ds = new StockDS();
            string strConnString = @"Data Source=SURESH\SQLEXPRESS;Initial Catalog=FutureSoft;Integrated Security=True";

            SqlConnection conn = new SqlConnection(strConnString);
            conn.Open();
            string sql = "Select * FROM _Category";

            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
           // DataSet ds = new DataSet();
            ad.Fill(ds,ds.Tables[0].TableName);


            ReportDataSource rds = new ReportDataSource("_Category", ds.Tables[0]);
          this.  reportViewer1.LocalReport.DataSources.Clear();
          this.reportViewer1.LocalReport.DataSources.Add(rds);
          this.reportViewer1.LocalReport.Refresh();

          this.reportViewer1.Refresh();

            this.reportViewer1.RefreshReport();
        }


        void createData()
        {
            DataSet ds =  GetDataSet();
            ReportDataSource rds = new ReportDataSource("_Category", ds.Tables[0]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.Refresh();

            this.reportViewer1.Refresh();
        }



        void fillData()
        {
            StockDS sd = new StockDS();
        }


        private DataSet GetDataSet()
        {
            //var conString = ConfigurationManager.ConnectionStrings["dotnetConnectionString"];
            string strConnString = @"Data Source=SURESH\SQLEXPRESS;Initial Catalog=FutureSoft;Integrated Security=True";

            SqlConnection conn = new SqlConnection(strConnString);
            conn.Open();
            string sql = "Select * FROM _Category";

            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            return ds;
        }
    }
}
