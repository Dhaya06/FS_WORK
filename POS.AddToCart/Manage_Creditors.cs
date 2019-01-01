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
using System.Threading;
namespace POS.AddToCart
{
    public partial class Manage_Creditors : MetroFramework.Forms.MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        List<Sales_BM> SalesList_Public = new List<Sales_BM>();
        List<Sales_BM> GridLoadedSalesList_Public = new List<Sales_BM>();
        public Sales_BM publicSales = new Sales_BM();
       
        public Manage_Creditors()
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();
            this.Resizable = false;
            //this.WindowState = FormWindowState.Maximized;
            this.Movable = false;
         //   this.TopMost = true; ;

            this.ControlBox = true;
            this.MaximizeBox = false;
            
            this.TopLevel = true;
            autoComplete();
            InitialloadGrid();
            increaseWidth();
            SetMyCustomFormat();
            panelSideMenu.Width = 0;
        //    notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Visible = false;
           // t.Abort();
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




        void autoComplete()

        {

            try
            {
                txtReceiptNo.AutoCompleteMode = AutoCompleteMode.None;
                txtReceiptNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCustName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCustName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection stringColl = new AutoCompleteStringCollection();
                AutoCompleteStringCollection stringColl2 = new AutoCompleteStringCollection();

               
                BusinessObjects.Sales_BM s = new Sales_BM();

                 List<Sales_BM> SList = new List<Sales_BM>();
                 SList = s.getSales(con);

                SalesList_Public = SList;


                
                foreach (Sales_BM item in SList)
                {
                    stringColl.Add(item.customer_name);
                    stringColl2.Add(item.sales_id.ToString());
                }


                txtCustName.AutoCompleteCustomSource = stringColl;
                txtReceiptNo.AutoCompleteCustomSource = stringColl2;

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        void InitialloadGrid()
        {
            try
            {

          

            List<Sales_BM> slist = new List<Sales_BM>();
            Sales_BM sal = new Sales_BM();
            slist = sal.getSalesCreditors(con);
            GridLoadedSalesList_Public = slist;

            tblSales.Rows.Clear();
            int i = 0;
            foreach (BusinessObjects.Sales_BM item in slist)
            {
                tblSales.Rows.Add();
                tblSales.Rows[i].Cells[0].Value = item.sales_id.ToString();
                tblSales.Rows[i].Cells[1].Value = item.customer_name;
                tblSales.Rows[i].Cells[2].Value = item.total.ToString();
                tblSales.Rows[i].Cells[3].Value = item.date_time.ToString();

                tblSales.Rows[i].Cells[4].Value = item.paid.ToString();
                tblSales.Rows[i].Cells[5].Value = item.credit.ToString();

                tblSales.Rows[i].Cells[6].Value = "View";
                tblSales.Rows[i].Cells[7].Value = "Update";

                i++;
            }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        void loadGrid(List<Sales_BM> slist)
        {
            try
            {

           
            GridLoadedSalesList_Public.Clear();
            GridLoadedSalesList_Public = slist;



            double totalGlobal = 0;
            double creditGlobal = 0;
            double paidGlobal = 0;

            tblSales.Rows.Clear();
            int i = 0;
            //MessageBox.Show(cObjList.Count.ToString());
            foreach (BusinessObjects.Sales_BM item in slist)
            {
                if (item.credit > 0)
                {
                    tblSales.Rows.Add();
                    tblSales.Rows[i].Cells[0].Value = item.sales_id.ToString();
                    tblSales.Rows[i].Cells[1].Value = item.customer_name;
                    tblSales.Rows[i].Cells[2].Value = item.total.ToString();
                    tblSales.Rows[i].Cells[3].Value = item.date_time.ToString();

                    tblSales.Rows[i].Cells[4].Value = item.paid.ToString();
                    tblSales.Rows[i].Cells[5].Value = item.credit.ToString();

                    tblSales.Rows[i].Cells[6].Value = "View";
                    tblSales.Rows[i].Cells[7].Value = "Update";

                    totalGlobal = totalGlobal + Convert.ToDouble(item.total);
                    creditGlobal = creditGlobal + Convert.ToDouble(item.credit);
                    paidGlobal = paidGlobal + Convert.ToDouble(item.paid);

                    i++;
                }
            }

            //lblTotalSales.Text = totalGlobal.ToString() + " LKR";
            //lblTotalPaid.Text = paidGlobal.ToString() + " LKR";
            lblCredit.Text = creditGlobal.ToString() + " LKR";
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    
        
        private void txtCustName_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtCustName.Text == string.Empty)
                { return; }

                if (txtCustName.Text.Length > 0)
                {
                    string cname = txtCustName.Text;

                    Sales_BM sale = new Sales_BM();

                    List<Sales_BM> saleList = new List<Sales_BM>();
                    saleList = sale.getSalesByC_Name(con, cname);

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

                    double totalGlobal = 0;
                    double creditGlobal = 0;
                    double paidGlobal = 0;

                   
                    

                    foreach (BusinessObjects.Sales_BM item in SalesList_Public)
                    {
                        if (item.credit > 0)
                        {
                            tblSales.Rows.Add();
                            tblSales.Rows[i].Cells[0].Value = item.sales_id.ToString();
                            tblSales.Rows[i].Cells[1].Value = item.customer_name;
                            tblSales.Rows[i].Cells[2].Value = item.total.ToString();
                            tblSales.Rows[i].Cells[3].Value = item.date_time.ToString();

                            tblSales.Rows[i].Cells[4].Value = item.paid.ToString();
                            tblSales.Rows[i].Cells[5].Value = item.credit.ToString();

                            tblSales.Rows[i].Cells[6].Value = "View";
                            tblSales.Rows[i].Cells[7].Value = "Update";

                            totalGlobal = totalGlobal + Convert.ToDouble(item.total);
                            creditGlobal = creditGlobal + Convert.ToDouble(item.credit);
                            paidGlobal = paidGlobal + Convert.ToDouble(item.paid);

                            i++;
                        }
                    }

                    //lblTotalSales.Text = totalGlobal.ToString() + " LKR";
                    //lblTotalPaid.Text = paidGlobal.ToString() + " LKR";
                    lblCredit.Text = creditGlobal.ToString() + " LKR";
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

            
            DateTime sDate = Convert.ToDateTime(dateStart.Text);

            DateTime eDate = Convert.ToDateTime(dateEnd.Text);

            List<Sales_BM> salesList = new List<Sales_BM>();
            Sales_BM sales = new Sales_BM();




            salesList = sales.getSalesByDateCredit(con, sDate, eDate);
            // GridLoadedSalesList_Public = salesList;
            loadGrid(salesList);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tblSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
	    {	        
		
	
              int rw = e.RowIndex;
            int cl = e.ColumnIndex;
            if (Convert.ToString(tblSales.Rows[rw].Cells[0].Value) == string.Empty)
            {
                return;
            }
            int saleID=Convert.ToInt32(  tblSales.Rows[rw].Cells[0].Value.ToString());


            if (cl == 6)
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType().Name == "View_Sales_Product")
                    {
                        MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }
                }

                
                View_Sales_Product vsd = new View_Sales_Product(saleID);

                vsd.Show();
                
            }
            if (cl == 7)
            {
                //MessageBox.Show("Fuck you");
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType().Name == "Edit_Credit")
                    {
                        MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }
                }

                if(Convert.ToString(tblSales.Rows[rw].Cells[5].Value) != string.Empty)
                {
                    decimal credi = Convert.ToDecimal(tblSales.Rows[rw].Cells[5].Value);
                    if (credi < 0)
                    {
                        MessageBox.Show("No Credit Amount Found for This Transaction");
                        return;
                    }

                    publicSales.sales_id = Convert.ToInt32(tblSales.Rows[rw].Cells[0].Value);
                    publicSales.customer_name = tblSales.Rows[rw].Cells[1].Value.ToString();
                    publicSales.credit= Convert.ToDecimal(tblSales.Rows[rw].Cells[5].Value.ToString());
                    publicSales.total = Convert.ToDecimal(tblSales.Rows[rw].Cells[2].Value.ToString());
                    publicSales.date_time = Convert.ToDateTime(tblSales.Rows[rw].Cells[3].Value.ToString());
                    publicSales.paid = Convert.ToDecimal(tblSales.Rows[rw].Cells[4].Value.ToString());

                Edit_Credit ec = new Edit_Credit(this);
                ec.Show();
                }
            }
            else if (cl == 1)
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType().Name == "V_Customer")
                    {
                        MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }
                }


                int cid = Convert.ToInt32(tblSales.Rows[rw].Cells[0].Value.ToString());
                //Customer cust=new Customer ();
                //int cid =cust.getIdByName(custName, con);
                //Customer cust = new Customer();
                //int cid = cust.getIdByName(custName, con);
                using (V_Customer ms = new V_Customer(cid))
                {
                    ms.ShowDialog();
                }
            }

             }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            autoComplete();
            InitialloadGrid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panelSideMenu.Width >= 200)
            {
                this.timer1.Enabled = false;

            }
            else
            {
                panelSideMenu.Width += 12;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (panelSideMenu.Width >= 200)
            {
                // this.panelSideMenu.Enabled = false;
                panelSideMenu.Width = 0;


            }
            else
                this.timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show(); 
            
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new ManageStock();
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

        private void metroTile2_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new FormBilling();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
             BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
        }

        private void Manage_Creditors_SizeChanged(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                // notifyIcon1.Icon = SystemIcons.Application;
                createBitIcon();


                notifyIcon1.BalloonTipText = "System Has Been Minimized. You Can Maximise here";
                notifyIcon1.ShowBalloonTip(3000);
            }
            else
            {
                notifyIcon1.Icon = null;

            }
        }

        private void Manage_Creditors_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        


    }
}
