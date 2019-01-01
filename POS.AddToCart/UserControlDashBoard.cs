using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  BusinessObjects;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using MetroFramework;
namespace POS.AddToCart
{
    public partial class UserControlDashBoard : UserControl
    {
         string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
         public List<Sales_BM> SalesList_Public = new List<Sales_BM>();
         public List<sales_product> Sales_product_list_public;
         private static UserControlDashBoard _instance;
        public UserControlDashBoard()
        {
            InitializeComponent();

            loadCharts();
            loadSoldTable();
            increaseWidth();
            loadTodaySale();
            setWidgetValues();
            setOutofStockandLowStock();
        }

        public static UserControlDashBoard Instance()
        { 
                if(_instance==null)
                    _instance=new UserControlDashBoard();
                return _instance;
            
        
        }

        public static UserControlDashBoard Refresh()
        {
            _instance = null;
                _instance = new UserControlDashBoard();
            return _instance;


        }

        void increaseWidth()
        {
            gridSOldItem.EnableHeadersVisualStyles = false;
            gridSOldItem.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridSOldItem.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            gridSOldItem.Columns[0].Width = 80;
            gridSOldItem.Columns[1].Width = 180;
            gridSOldItem.Columns[2].Width = 95;
            gridSOldItem.Columns[3].Width = 95;
            gridSOldItem.Columns[4].Width = 80;

        }
        public class salesByDateData
        {
            public decimal amount { get; set; }
            public DateTime date_time { get; set; }
            public decimal paid { get; set; }
            public decimal credit { get; set; }

        }
       
        void loadCharts()
        {
            try
            {

             //this.salesChartLine.Series["SALES"].Points.AddXY("dues",1500);
            //this.salesChartLine.Series["SALES"].Points.AddXY("Blaow", 1800);
            //this.salesChartLine.Series["SALES"].Points.AddXY("dsa", 80);

            BusinessObjects.Sales_BM ss = new Sales_BM();
            List<Sales_BM> salesList = new List<Sales_BM>();
            List<salesByDateData> salesByDateList = new List<salesByDateData>();
            DateTime dateNow = DateTime.Now;

            DateTime date10Before = dateNow.AddDays(-10);
            DateTime date9Before = dateNow.AddDays(-9);
            DateTime date8Before = dateNow.AddDays(-8);
            DateTime date7Before = dateNow.AddDays(-7);
            DateTime date6Before = dateNow.AddDays(-6);
            DateTime date5Before = dateNow.AddDays(-5);
            DateTime date4Before = dateNow.AddDays(-4);
            DateTime date3Before = dateNow.AddDays(-3);
            DateTime date2Before = dateNow.AddDays(-2);
            DateTime date1Before = dateNow.AddDays(-1);

            salesByDateData filterObj10 = new salesByDateData();
            salesByDateData filterObj9 = new salesByDateData();
            salesByDateData filterObj8 = new salesByDateData();
            salesByDateData filterObj7 = new salesByDateData();
            salesByDateData filterObj6 = new salesByDateData();
            salesByDateData filterObj5 = new salesByDateData();
            salesByDateData filterObj4 = new salesByDateData();
            salesByDateData filterObj3 = new salesByDateData();
            salesByDateData filterObj2 = new salesByDateData();
            salesByDateData filterObj1 = new salesByDateData();
            salesByDateData filterObjNow = new salesByDateData();

            salesList = ss.getSalesByDate(con, date10Before, dateNow);
            foreach (var item in salesList)
            {
                if (item.date_time.Date == date10Before.Date)
                {
                    filterObj10.amount += item.total;
                    filterObj10.date_time = item.date_time;

                    if (item.total > item.paid)
                    {
                        filterObj10.paid += item.paid;
                        Decimal temSto = 0;
                        temSto = item.total - item.paid;
                        filterObj10.credit += temSto;

                    }
                    else
                    {
                        filterObj10.paid += item.total;
                        filterObj10.credit += 0;
                    }




                }
                if (item.date_time.Date == date9Before.Date)
                {
                    filterObj9.amount += item.total;
                    filterObj9.date_time = item.date_time;
                    if (item.total > item.paid)
                    {
                        filterObj9.paid += item.paid;
                        Decimal temSto = 0;
                        temSto = item.total - item.paid;
                        filterObj9.credit += temSto;

                    }
                    else
                    {
                        filterObj9.paid += item.total;
                        filterObj9.credit += 0;
                    }
                }
                if (item.date_time.Date == date8Before.Date)
                {
                    filterObj8.amount += item.total;
                    filterObj8.date_time = item.date_time;
                    if (item.total > item.paid)
                    {
                        filterObj8.paid += item.paid;
                        Decimal temSto = 0;
                        temSto = item.total - item.paid;
                        filterObj8.credit += temSto;

                    }
                    else
                    {
                        filterObj8.paid += item.total;
                        filterObj8.credit += 0;
                    }
                }
                if (item.date_time.Date == date7Before.Date)
                {
                    filterObj7.amount += item.total;
                    filterObj7.date_time = item.date_time;
                    
                    if (item.total > item.paid)
                    {
                        filterObj7.paid += item.paid;
                        Decimal temSto = 0;
                        temSto = item.total - item.paid;
                        filterObj7.credit += temSto;

                    }
                    else
                    {
                        filterObj7.paid += item.total;
                        filterObj7.credit += 0;
                    }
                }
                if (item.date_time.Date == date6Before.Date)
                {
                    filterObj6.amount += item.total;
                    filterObj6.date_time = item.date_time;
                    if (item.total > item.paid)
                    {
                        filterObj6.paid += item.paid;
                        Decimal temSto = 0;
                        temSto = item.total - item.paid;
                        filterObj6.credit += temSto;

                    }
                    else
                    {
                        filterObj6.paid += item.total;
                        filterObj6.credit += 0;
                    }
                }
                if (item.date_time.Date == date5Before.Date)
                {
                    filterObj5.amount += item.total;
                    filterObj5.date_time = item.date_time;
                    if (item.total > item.paid)
                    {
                        filterObj5.paid += item.paid;
                        Decimal temSto = 0;
                        temSto = item.total - item.paid;
                        filterObj5.credit += temSto;

                    }
                    else
                    {
                        filterObj5.paid += item.total;
                        filterObj5.credit += 0;
                    }
                }
                if (item.date_time.Date == date4Before.Date)
                {
                    filterObj4.amount += item.total;
                    filterObj4.date_time = item.date_time;
                    if (item.total > item.paid)
                    {
                        filterObj4.paid += item.paid;
                        Decimal temSto = 0;
                        temSto = item.total - item.paid;
                        filterObj4.credit += temSto;

                    }
                    else
                    {
                        filterObj4.paid += item.total;
                        filterObj4.credit += 0;
                    }

                }
                if (item.date_time.Date == date3Before.Date)
                {
                    filterObj3.amount += item.total;
                    filterObj3.date_time = item.date_time;
                    if (item.total > item.paid)
                    {
                        filterObj3.paid += item.paid;
                        Decimal temSto = 0;
                        temSto = item.total - item.paid;
                        filterObj3.credit += temSto;

                    }
                    else
                    {
                        filterObj3.paid += item.total;
                        filterObj3.credit += 0;
                    }
                }
                if (item.date_time.Date == date2Before.Date)
                {
                    filterObj2.amount += item.total;
                    filterObj2.date_time = item.date_time;
                    if (item.total > item.paid)
                    {
                        filterObj2.paid += item.paid;
                        Decimal temSto = 0;
                        temSto = item.total - item.paid;
                        filterObj2.credit += temSto;

                    }
                    else
                    {
                        filterObj2.paid += item.total;
                        filterObj2.credit += 0;
                    }
                }
                if (item.date_time.Date == date1Before.Date)
                {
                    filterObj1.amount += item.total;
                    filterObj1.date_time = item.date_time;
                    if (item.total > item.paid)
                    {
                        filterObj1.paid += item.paid;
                        Decimal temSto = 0;
                        temSto = item.total - item.paid;
                        filterObj1.credit += temSto;

                    }
                    else
                    {
                        filterObj1.paid += item.total;
                        filterObj1.credit += 0;
                    }
                }
                if (item.date_time.Date == dateNow.Date)
                {
                    filterObjNow.amount += item.total;
                    filterObjNow.date_time = item.date_time;
                    if (item.total > item.paid)
                    {
                        filterObjNow.paid += item.paid;
                        Decimal temSto = 0;
                        temSto = item.total - item.paid;
                        filterObjNow.credit += temSto;

                    }
                    else
                    {
                        filterObjNow.paid += item.total;
                        filterObjNow.credit += 0;
                    }
                }

            }


            salesByDateList.Add(filterObj10);
            salesByDateList.Add(filterObj9);
            salesByDateList.Add(filterObj8);
            salesByDateList.Add(filterObj7);
            salesByDateList.Add(filterObj6);
            salesByDateList.Add(filterObj5);
            salesByDateList.Add(filterObj4);
            salesByDateList.Add(filterObj3);
            salesByDateList.Add(filterObj2);
            salesByDateList.Add(filterObj1);
            salesByDateList.Add(filterObjNow);


            //salesChartLine.Series.Add("Sales");
            //salesChartLine.Series["Sales"].ChartType = SeriesChartType.Area;
            //salesChartLine.Palette = ChartColorPalette.None;
            //salesChartLine.PaletteCustomColors = new Color[] { Color.Red, Color.Blue, Color.Yellow };
            ////salesChartLine.Series["Sales"].Points.AddXY( (10);



            salesChartLine.Series["Sales"].ChartArea = "ChartArea1";
            foreach (var item in salesByDateList)
            {
                int date = Convert.ToInt32(item.date_time.Day);
                int month = Convert.ToInt32(item.date_time.Month);
                this.salesChartLine.Series["Sales"].Points.AddXY(month.ToString() + "/" + date.ToString(), Convert.ToInt32(item.amount));

                this.salesChartLine.Series["Cash"].Points.AddY(item.paid);
                this.salesChartLine.Series["Credit"].Points.AddY(item.credit);
            }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


  
    
        void loadSoldTable()
        {
            DateTime sDate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));

            DateTime eDate = Convert.ToDateTime(DateTime.Now.AddDays(+1).ToString("MM/dd/yyyy"));
            //eDate.ToString("dd-MMM-yyyy")
            //DateTime sDate = DateTime.ParseExact(sDates, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            // DateTime eDate = DateTime.ParseExact(eDates, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            List<GetProductStock> ListItem = new List<GetProductStock>();
            GetProductStock lObj = new GetProductStock();
            ListItem = lObj.getProdAlongWithSalesQuantity_ByDate(con, sDate, eDate);


            int i = 0;
            gridSOldItem.Rows.Clear();
            foreach (GetProductStock item in ListItem)
            {
                gridSOldItem.Rows.Add();

                gridSOldItem.Rows[i].Cells[1].Value = item.name;
                gridSOldItem.Rows[i].Cells[0].Value = item.ID;
                gridSOldItem.Rows[i].Cells[2].Value = item.cost;
                gridSOldItem.Rows[i].Cells[3].Value = item.unitPrice;
                gridSOldItem.Rows[i].Cells[4].Value = item.TotalQuantity;



                i++;
            }
        }

        void loadTodaySale()
        {
            DateTime sDate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));

            DateTime eDate = Convert.ToDateTime(DateTime.Now.AddDays(+1).ToString("MM/dd/yyyy"));

            List<Sales_BM> salesList = new List<Sales_BM>();
            Sales_BM sales = new Sales_BM();

            SalesList_Public = salesList = sales.getSalesByDate(con, sDate, eDate);

            // chartTodaySale.Series["Sales"].ChartArea = "ChartArea1";
            foreach (var item in salesList)
            {
                decimal cash = 0;
                cash = (item.total > item.paid) ? item.paid : item.total;

                this.chartTodaySale.Series["Sales"].Points.AddXY(item.customer_name, item.total);
                this.chartTodaySale.Series["Cash"].Points.AddY(cash);
            }

        }

        void setWidgetValues()
        {
            decimal total = 0;
            decimal credit = 0;
            decimal paid = 0;
            foreach (var item in SalesList_Public)
            {
                total = total + item.total;
                //credit = credit + item.credit;
                if (item.total > item.paid)
                {
                    paid += item.paid;
                    decimal sum = item.total - item.paid;
                    credit = credit + sum;
                }
                else
                {
                    paid += item.total;
                }
            }



            lblCredit.Text = "RS:" + credit;
            lblPaid.Text = "RS:" + paid;
            lblSales.Text = "RS:" + total.ToString();



        }


       

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    

       

        void setOutofStockandLowStock()
        {
            try
            {

           
            int LowStockcount = 0;
            int outOfStockcount = 0;

            BusinessObjects.stock_product stoProduct = new stock_product();
            outOfStockcount = stoProduct.GetOutOfStock(con);

            BusinessObjects.GetProductStock spObj = new GetProductStock();
            List<GetProductStock> avalibilityList = new List<GetProductStock>();
            avalibilityList = spObj.getProdAlongWithStockQuantity_All(con);

            foreach (var item in avalibilityList)
            {
                if (item.TotalQuantity < 5)
                {
                    LowStockcount++;
                }
            }
            lblOutOfStock.Text = outOfStockcount.ToString() + " Prods";
            lblLowStock.Text = LowStockcount.ToString() + " Prods";
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void chartTodaySale_MouseMove(object sender, MouseEventArgs e)
        {
            this.chartTodaySale.GetToolTipText += chartTodaySale_GetToolTipText;

        }

        void chartTodaySale_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                    //  e.Text = string.Format("X:\t{0}\nY:\t{1}", dataPoint.XValue, dataPoint.YValues[0]);
                    //e.Text ="Sales:" + dataPoint.YValues[0].ToString();
                    string result = "Sales:" + dataPoint.YValues[0].ToString();
                    toolTip2.Show(result, this.chartTodaySale);
                    break;
            }
        }

        private void salesChartLine_MouseMove(object sender, MouseEventArgs e)
        {
            this.salesChartLine.GetToolTipText += salesChartLine_GetToolTipText;
        }

        void salesChartLine_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                    //  e.Text = string.Format("X:\t{0}\nY:\t{1}", dataPoint.XValue, dataPoint.YValues[0]);
                    //e.Text ="Sales:" + dataPoint.YValues[0].ToString();
                    string result = "Sales:" + dataPoint.YValues[0].ToString();
                    toolTip1.Show(result, this.salesChartLine);
                    break;
            }
        }


        private void salesChartLine_Click(object sender, EventArgs e)
        {
            
          
        }
    }
}
