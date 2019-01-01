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

namespace POS.AddToCart
{
    public partial class ViewChequePayment : MetroFramework.Forms.MetroForm
    {
        bool checkSelectedIndexChange;//to check whether cmb is droped by user or not
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
      public  int sid = 0;
      public List<Cheque> SalesList_Public = new List<Cheque>();
        public List<BusinessObjects.Cheque> GridLoadedChequeList_Public = new List<Cheque>();
        
        public List<sales_product> Sales_product_list_public;


        public ViewChequePayment()
        {
            InitializeComponent();
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
            
            panelSideMenu.Width = 0;
            loadGridIntial();


            autoComplete();
            //notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Visible = false;
            //button2.Visible = false;
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
            tblSales.Columns[0].Width = 60;
            tblSales.Columns[1].Width = 60;
            tblSales.Columns[2].Width = 140;
            tblSales.Columns[3].Width = 150;

            tblSales.Columns[4].Width = 140;
            tblSales.Columns[5].Width = 100;
            tblSales.Columns[6].Width = 100;
            tblSales.Columns[7].Width = 150;
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
            BusinessObjects.Cheque ss = new Cheque();

            GridLoadedChequeList_Public.Clear();

            GridLoadedChequeList_Public = ss.getAll(con);
         

            tblSales.Rows.Clear();
            int i = 0;
            //MessageBox.Show(cObjList.Count.ToString());
            foreach (BusinessObjects.Cheque item in GridLoadedChequeList_Public)
            {
                tblSales.Rows.Add();
                tblSales.Rows[i].Cells[0].Value = item.salesId.ToString();
                tblSales.Rows[i].Cells[1].Value = item.cheque_no;
                tblSales.Rows[i].Cells[2].Value = item.customer_name.ToString();
                tblSales.Rows[i].Cells[3].Value = item.cheque_date.ToString();

                tblSales.Rows[i].Cells[4].Value = item.amount.ToString();
                tblSales.Rows[i].Cells[5].Value = item.bank.ToString();

                tblSales.Rows[i].Cells[6].Value = item.branch.ToString();
                tblSales.Rows[i].Cells[7].Value = item.details.ToString();

                i++;
            }
        
        
        }

        void autoComplete()
        {

            try
            {
                txtChequeNo.AutoCompleteMode = AutoCompleteMode.None;
                txtChequeNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCustomerName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtSalesID.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtSalesID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection stringColl = new AutoCompleteStringCollection();
                AutoCompleteStringCollection stringColl2 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection stringColl3 = new AutoCompleteStringCollection();


                
                foreach (Cheque item in GridLoadedChequeList_Public)
                {
                  //  stringColl.Add(item.ID.ToString());
                    stringColl.Add(item.cheque_no);
                    stringColl2.Add(item.customer_name);
                    stringColl3.Add(item.salesId.ToString());
                }


                txtChequeNo.AutoCompleteCustomSource = stringColl;
                txtCustomerName.AutoCompleteCustomSource = stringColl2;
                txtSalesID.AutoCompleteCustomSource = stringColl3;
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

            List<Cheque> salesList = new List<Cheque>();
            Cheque sales = new Cheque();

           


            salesList = sales.getAllByDate(con,sDate,eDate);
           // GridLoadedSalesList_Public = salesList;
           loadGrid(salesList);
        }

        void loadGrid(List<Cheque> slist)
        {
            GridLoadedChequeList_Public.Clear();
            GridLoadedChequeList_Public = slist;

            tblSales.Rows.Clear();
            int i = 0;

            

            //MessageBox.Show(cObjList.Count.ToString());
            foreach (BusinessObjects.Cheque item in slist)
            {
                tblSales.Rows.Add();
                tblSales.Rows[i].Cells[0].Value = item.salesId.ToString();
                tblSales.Rows[i].Cells[1].Value = item.cheque_no;
                tblSales.Rows[i].Cells[2].Value = item.customer_name.ToString();
                tblSales.Rows[i].Cells[3].Value = item.cheque_date.ToString();

                tblSales.Rows[i].Cells[4].Value = item.amount.ToString();
                tblSales.Rows[i].Cells[5].Value = item.bank.ToString();

                tblSales.Rows[i].Cells[6].Value = item.branch.ToString();
                tblSales.Rows[i].Cells[7].Value = item.details.ToString();
                
                i++;
            }

           


        }

        private void cmbECategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbECategory_DropDown(object sender, EventArgs e)
        {
          
        }


        private void loadCombo()
        {
            
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {

            
            if (txtCustomerName.Text == string.Empty)
            { return; }

            if (txtCustomerName.Text.Length > 0)
            {
                string pname = txtCustomerName.Text;

                Cheque sale = new Cheque();

                List<Cheque> saleList = new List<Cheque>();
                saleList = sale.getAllByName(con,pname);

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
            //try
            //{


                if (txtChequeNo.Text == string.Empty)
                { return; }

                if (txtChequeNo.Text.Length > 0)
                {
                    string chequeno = txtChequeNo.Text;

                    Cheque cheqe = new Cheque();

                    
                    cheqe = cheqe.getAllByChequeNo(con, chequeno);
                    SalesList_Public.Clear();

                    SalesList_Public.Add(cheqe);
                   

                    tblSales.Rows.Clear();

                    int i = 0;
                    foreach (BusinessObjects.Cheque item in SalesList_Public)
                    {
                        tblSales.Rows.Add();
                        tblSales.Rows[i].Cells[0].Value = item.salesId.ToString();
                        tblSales.Rows[i].Cells[1].Value = item.cheque_no;
                        tblSales.Rows[i].Cells[2].Value = item.customer_name;
                        tblSales.Rows[i].Cells[3].Value = item.cheque_date.ToString();

                        tblSales.Rows[i].Cells[4].Value = item.amount.ToString();
                        tblSales.Rows[i].Cells[5].Value = item.bank;

                        tblSales.Rows[i].Cells[6].Value = item.branch;
                        tblSales.Rows[i].Cells[7].Value = item.details;


                        i++;
                    }
                }
            //}
            //catch (Exception ex)
            //{

            //    MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}

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
                int saleID = Convert.ToInt32(tblSales.Rows[rw].Cells[0].Value.ToString());
                
                if (cl == 2)
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
                    using (V_Customer ms = new V_Customer(cid))
                    {
                        ms.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void metroTile1_Click(object sender, EventArgs e)
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

        private void ViewSales_SizeChanged(object sender, EventArgs e)
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

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                if (tblSales.Rows.Count  < 1)
            {

                MetroMessageBox.Show(this, "No Data found. !!!" , "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DGVPrinter printer = new DGVPrinter();

            printer.Title = "Cheque Payments ||";

            printer.SubTitle = "Cheque Payment Summary: Date : " + DateTime.Now.Date;

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

        private void txtSalesID_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void ViewChequePayment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

    }
}
