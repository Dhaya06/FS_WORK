using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.AddToCart
{
    public partial class ViewStockUpdate : MetroFramework.Forms.MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
       
        public ViewStockUpdate()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Resizable = false;
            this.WindowState = FormWindowState.Maximized;
            


            increaseWidth();

            loadData();
            panel3.Width = 0; 
            lnkBtnShow.Visible = false;
            lblTime.Text = DateTime.Now.ToLocalTime().ToShortTimeString();
            

        }

        List<BusinessObjects.StockReturn_BS> GlobalStockReturnList = new List<BusinessObjects.StockReturn_BS>();
        void loadData()
        {
            try{
            List<BusinessObjects.StockReturn_BS> stockReturnList = new List<BusinessObjects.StockReturn_BS>();
            BusinessObjects.StockReturn_BS stockReturn = new BusinessObjects.StockReturn_BS();
            GlobalStockReturnList =stockReturnList = stockReturn.GetAllProcInnjerJoin(con);

            tblStockReturn.Rows.Clear();
            int i = 0;
            foreach (BusinessObjects.StockReturn_BS item in stockReturnList)
            {
                tblStockReturn.Rows.Add();
                tblStockReturn.Rows[i].Cells[0].Value = item.prd_id.ToString();
                tblStockReturn.Rows[i].Cells[1].Value = item.product_name;
                tblStockReturn.Rows[i].Cells[2].Value = item.stock_id.ToString();
                tblStockReturn.Rows[i].Cells[3].Value = item.stock_date.ToString();

                tblStockReturn.Rows[i].Cells[4].Value = item.sup_name.ToString();

                if (item.adjusted==0)
                tblStockReturn.Rows[i].Cells[5].Value ="Stock Return (-)";
                else if (item.adjusted == 1)
                    tblStockReturn.Rows[i].Cells[5].Value = "Stock Adjusted (+)";
                

                tblStockReturn.Rows[i].Cells[6].Value = item.quantity.ToString();
                tblStockReturn.Rows[i].Cells[7].Value = item.Date_.ToString();
                tblStockReturn.Rows[i].Cells[8].Value = "View";
                tblStockReturn.Rows[i].Cells[9].Value = item.descrip.ToString();

                i++;
            }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        void increaseWidth()
        {
            tblStockReturn.Columns[0].Width = 90;

            tblStockReturn.Columns[1].Width = 200;
            tblStockReturn.Columns[2].Width = 120;
            tblStockReturn.Columns[3].Width = 140;
            tblStockReturn.Columns[4].Width = 140;
            tblStockReturn.Columns[5].Width = 160;
            tblStockReturn.Columns[6].Width = 110;
            tblStockReturn.Columns[7].Width = 180;
            tblStockReturn.Columns[8].Width = 120;

        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel3.Width >= 260)
            {
                this.timer1.Enabled = false;

            }
            else
            {
                panel3.Width += 12;
                lnkBack.Visible = true;
                lnkBtnShow.Visible = false;
            }

        }

        private void lnkBack_Click(object sender, EventArgs e)
        {

            if (panel3.Width >= 260)
            {
                this.timer1.Enabled = false;
                panel3.Width = 0;
                lnkBtnShow.Visible = true;
                lnkBack.Visible = false;

            }
            else
                this.timer1.Enabled = true;
        }

        private void lnkBtnShow_Click(object sender, EventArgs e)
        {
            if (panel3.Width >= 260)
            {
                this.timer1.Enabled = false;
                panel3.Width = 0;
                lnkBtnShow.Visible =false;
                lnkBack.Visible = true;

            }
            else
                this.timer1.Enabled = true;

        }

        private void lnkHome_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void tblStockReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int rw = e.RowIndex;
                int cl = e.ColumnIndex;
                if (Convert.ToString(tblStockReturn.Rows[rw].Cells[0].Value) == string.Empty)
                {
                    return;
                }
                int stockID = Convert.ToInt32(tblStockReturn.Rows[rw].Cells[0].Value.ToString());


                if (cl == 8)
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.GetType().Name == "ViewSotckReturnDescription")
                        {
                            MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return;
                        }
                    }


                    if (Convert.ToString(tblStockReturn.Rows[rw].Cells[9].Value) == string.Empty)
                    {
                        MessageBox.Show("Can't Find Description");
                        return;
                    }
                    string descrip= tblStockReturn.Rows[rw].Cells[9].Value.ToString();
                    ViewSotckReturnDescription vsd = new ViewSotckReturnDescription(stockID, descrip);

                    vsd.Show();

                }

              

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show(); 
        }
    }
}
