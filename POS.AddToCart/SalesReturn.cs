using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;
using System.Configuration;
using MetroFramework;
using DGVPrinterHelper;
using System.Globalization;
using System.Threading;

namespace POS.AddToCart
{
    public partial class SalesReturn : MetroFramework.Forms.MetroForm
    {
        bool checkSelectedIndexChange;//to check whether cmb is droped by user or not
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        public int sid = 0;
        public List<Sales_BM> SalesList_Public = new List<Sales_BM>();
        public List<Sales_BM> GridLoadedSalesList_Public = new List<Sales_BM>();

        public List<sales_product> Sales_product_list_public;


        public SalesReturn()
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();
            //t.Abort();
            //  this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.TopLevel = true;
            panel3.Width = 0;
            this.Resizable = false;
            SetMyCustomFormat();
            checkSelectedIndexChange = false;
            tblSales.AllowUserToAddRows = false;
            increaseWidth();
            loadCombo();
            autoComplete();
            panelSideMenu.Width = 0;
            loadGridIntial();
            //notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Visible = false;
            //button2.Visible = false;




            //messagebox .shows datetime show. 

        }
         public void GifLoading()
        {
            Application.Run(new loading());
        }

        void createBitIcon()
        {
            Bitmap tBmp = new Bitmap(POS.AddToCart.Properties.Resources.POS_icon22);

            Icon tIco;

            tIco = Icon.FromHandle(tBmp.GetHicon());
            notifyIcon1.Icon = tIco;
            // notifyIcon1.Visible = true;


        }
        void increaseWidth()
        {
            tblSales.Columns[0].Width = 100;
            tblSales.Columns[1].Width = 140;
            tblSales.Columns[2].Width = 160;
            tblSales.Columns[3].Width = 160;

            tblSales.Columns[4].Width = 160;
            tblSales.Columns[5].Width = 160;
        }


        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            dateStart.Format = DateTimePickerFormat.Custom;
            dateStart.CustomFormat = "MM/dd/yyyy";
            dateEnd.Format = DateTimePickerFormat.Custom;
            dateEnd.CustomFormat = "MM/dd/yyyy";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panelSideMenu.Width >= 250)
            {
                this.timer1.Enabled = false;

            }
            else
            {
                panelSideMenu.Width += 12;


            }
        }

        void loadGridIntial()
        {
            BusinessObjects.Sales_BM ss = new Sales_BM();

            GridLoadedSalesList_Public.Clear();

            GridLoadedSalesList_Public = ss.getSales(con);


            tblSales.Rows.Clear();
            int i = 0;
            //MessageBox.Show(cObjList.Count.ToString());
            foreach (BusinessObjects.Sales_BM item in GridLoadedSalesList_Public)
            {
                tblSales.Rows.Add();
                tblSales.Rows[i].Cells[0].Value = item.sales_id.ToString();
                tblSales.Rows[i].Cells[1].Value = item.customer_name;
                tblSales.Rows[i].Cells[2].Value = item.total.ToString();
                tblSales.Rows[i].Cells[3].Value = item.date_time.ToString();

                tblSales.Rows[i].Cells[4].Value = item.paid.ToString();
                tblSales.Rows[i].Cells[5].Value = item.credit.ToString();

                tblSales.Rows[i].Cells[6].Value = "View";


                i++;
            }


        }

        void autoComplete()
        {

            try
            {
                txtReceiptNo.AutoCompleteMode = AutoCompleteMode.None;
                txtReceiptNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection stringColl = new AutoCompleteStringCollection();
                AutoCompleteStringCollection stringColl2 = new AutoCompleteStringCollection();

                BusinessObjects.M_Product_BS p = new M_Product_BS();
                BusinessObjects.Sales_BM s = new Sales_BM();

                List<M_Product_BS> PList = new List<M_Product_BS>();
                List<Sales_BM> SList = new List<Sales_BM>();
                PList = p.GetProducts(con);
                SList = s.getSales(con);

                SalesList_Public = SList;



                foreach (M_Product_BS item in PList)
                {
                    //  stringColl.Add(item.ID.ToString());
                    stringColl.Add(item.name);
                }

                foreach (Sales_BM item in SList)
                {
                    stringColl2.Add(item.sales_id.ToString());
                }


                txtProductName.AutoCompleteCustomSource = stringColl;
                txtReceiptNo.AutoCompleteCustomSource = stringColl2;

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }







        private void lnkBack_Click(object sender, EventArgs e)
        {
            if (panelSideMenu.Width >= 250)
            {
                // this.panelSideMenu.Enabled = false;
                panelSideMenu.Width = 0;


            }
            else
                this.timer1.Enabled = true;

            //if (panel3.Width >= 260)
            //{
            //    this.timer1.Enabled = false;
            //    panel3.Width = 0;
            //    lnkBtnShow.Visible = true;
            //    lnkBack.Visible = false;

            //}
            //else
            //    this.timer1.Enabled = true;
        }

        private void lnkBtnShow_Click(object sender, EventArgs e)
        {
            //if (panel3.Width >= 260)
            //{
            //    this.timer1.Enabled = false;
            //    panel3.Width = 0;
            //    lnkBtnShow.Visible = true;
            //    lnkBack.Visible = false;

            //}
            //else
            //    this.timer1.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime sDate = Convert.ToDateTime(dateStart.Text);

            DateTime eDate = Convert.ToDateTime(dateEnd.Text);

            List<Sales_BM> salesList = new List<Sales_BM>();
            Sales_BM sales = new Sales_BM();




            salesList = sales.getSalesByDate(con, sDate, eDate);
            // GridLoadedSalesList_Public = salesList;
            loadGrid(salesList);
        }

        void loadGrid(List<Sales_BM> slist)
        {
            GridLoadedSalesList_Public.Clear();
            GridLoadedSalesList_Public = slist;

            tblSales.Rows.Clear();
            int i = 0;

            double totalGlobal = 0;
            double creditGlobal = 0;
            double paidGlobal = 0;

            //MessageBox.Show(cObjList.Count.ToString());
            foreach (BusinessObjects.Sales_BM item in slist)
            {
                tblSales.Rows.Add();
                tblSales.Rows[i].Cells[0].Value = item.sales_id.ToString();
                tblSales.Rows[i].Cells[1].Value = item.customer_name;
                tblSales.Rows[i].Cells[2].Value = item.total.ToString();
                tblSales.Rows[i].Cells[3].Value = item.date_time.ToString();

                tblSales.Rows[i].Cells[4].Value = item.paid.ToString();
                if (item.credit > 0)
                    tblSales.Rows[i].Cells[5].Value = item.credit.ToString();

                tblSales.Rows[i].Cells[6].Value = "View";

                totalGlobal = totalGlobal + Convert.ToDouble(item.total);

                if (item.credit > 0)
                    creditGlobal = creditGlobal + Convert.ToDouble(item.credit);

                // paidGlobal = paidGlobal + Convert.ToDouble(item.paid);
                paidGlobal = totalGlobal - creditGlobal;

                i++;
            }

            lblTotalSales.Text = totalGlobal.ToString() + " LKR";
            lblTotalPaid.Text = paidGlobal.ToString() + " LKR";
            lblTotalCredit.Text = creditGlobal.ToString() + " LKR";


        }

        private void cmbECategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkSelectedIndexChange)
                {
                    Category_BS cat = (Category_BS)cmbECategory.SelectedItem;

                    Sales_BM sale = new Sales_BM();

                    List<Sales_BM> saleList = new List<Sales_BM>();
                    saleList = sale.getSalesByCatID(con, cat.ID);

                    loadGrid(saleList);

                    checkSelectedIndexChange = false;
                }
                else
                {
                    checkSelectedIndexChange = false;
                }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cmbECategory_DropDown(object sender, EventArgs e)
        {
            checkSelectedIndexChange = true;
        }


        private void loadCombo()
        {
            try
            {
                cmbECategory.DataSource = null;
                BusinessObjects.Category_BS CBS = new BusinessObjects.Category_BS();
                List<BusinessObjects.Category_BS> CList = new List<BusinessObjects.Category_BS>();
                CList = CBS.GetCategory(con);
                cmbECategory.DataSource = CList;
                cmbECategory.DisplayMember = "name";
                cmbECategory.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtProductName.Text == string.Empty)
                { return; }

                if (txtProductName.Text.Length > 0)
                {
                    string pname = txtProductName.Text;

                    Sales_BM sale = new Sales_BM();

                    List<Sales_BM> saleList = new List<Sales_BM>();
                    saleList = sale.getSalesByP_Name(con, pname);

                    loadGrid(saleList);



                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtReceiptNo_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtReceiptNo.Text == string.Empty)
                { return; }

                if (txtReceiptNo.Text.Length > 0)
                {
                    int sid = Convert.ToInt32(txtReceiptNo.Text);

                    Sales_BM sale = new Sales_BM();
                    sale.sales_id = sid;
                    List<Sales_BM> saleList = new List<Sales_BM>();
                    sale = sale.getSalesByID(con);
                    SalesList_Public.Clear();
                    SalesList_Public.Add(sale);
                    tblSales.Rows.Clear();
                    int i = 0;
                    foreach (BusinessObjects.Sales_BM item in SalesList_Public)
                    {
                        tblSales.Rows.Add();
                        tblSales.Rows[i].Cells[0].Value = item.sales_id.ToString();
                        tblSales.Rows[i].Cells[1].Value = item.customer_name;
                        tblSales.Rows[i].Cells[2].Value = item.total.ToString();
                        tblSales.Rows[i].Cells[3].Value = item.date_time.ToString();

                        tblSales.Rows[i].Cells[4].Value = item.paid.ToString();
                        tblSales.Rows[i].Cells[5].Value = item.credit.ToString();

                        tblSales.Rows[i].Cells[6].Value = "View";


                        i++;
                    }
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tblSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rw = e.RowIndex;
            int cl = e.ColumnIndex;
            if (Convert.ToString(tblSales.Rows[rw].Cells[0].Value) == string.Empty)
            {
                return;
            }
            int saleID = Convert.ToInt32(tblSales.Rows[rw].Cells[0].Value.ToString());


            if (cl == 6)
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType().Name == "ViewSalesProductCancelSale")
                    {
                        MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }
                }

                sid = saleID;
                ViewSalesProductCancelSale vsd = new ViewSalesProductCancelSale(sid);

                vsd.Show();

            }

            else if (cl == 7)
            {
                        MetroMessageBox.Show(this, "Form is asdasdasdalready opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
               
            }



        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
           // BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new ViewSalesReturn();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new FormBilling();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
           
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void ViewSales_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                // notifyIcon1.Icon = SystemIcons.Application;
                createBitIcon();


                notifyIcon1.BalloonTipText = "System Has Been Minimized. You Can Maximize here";
                notifyIcon1.ShowBalloonTip(3000);
            }
            else
            {
                notifyIcon1.Icon = null;

            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                if (tblSales.Rows.Count < 1)
                {

                    MetroMessageBox.Show(this, "No Data found. !!!", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                DGVPrinter printer = new DGVPrinter();

                printer.Title = "Sales Report";

                printer.SubTitle = "Sales Summary: Date : " + DateTime.Now.Date;

                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                              StringFormatFlags.NoClip;

                printer.PageNumbers = true;

                printer.PageNumberInHeader = false;

                printer.PorportionalColumns = true;

                printer.HeaderCellAlignment = StringAlignment.Near;

                printer.Footer = "Vista Computers";

                printer.FooterSpacing = 15;



                printer.PrintDataGridView(tblSales);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void SalesReturn_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void tblSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTile4_Click_1(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void panel4_SizeChanged(object sender, EventArgs e)
        {

        }

    }
}
