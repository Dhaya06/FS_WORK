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
    public partial class ViewSalesProductCancelSale : MetroFramework.Forms.MetroForm
    {

        int salesID = 0;
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        public ViewSalesProductCancelSale(int sid)
        {
            // Thread t = new Thread(new ThreadStart(GifLoading));
            //      t.Start();
            // MessageBox.Show(sid.ToString());
            // Thread.Sleep(400);
            InitializeComponent();
            this.TopLevel = true;

            //MessageBox.Show(sid.ToString());
            salesID = sid;
            increaseWidth();
            loadGrid();
            this.MaximizeBox = false;
            this.Resizable = false;
            this.Movable = false;
            this.ControlBox = false;
            //       t.Abort();
        }
        private void GifLoading()
        {
            Application.Run(new loading());
        }

        void increaseWidth()
        {
            tblCart.Columns[0].Width = 90;
            tblCart.Columns[1].Width = 140;
            tblCart.Columns[2].Width = 140;
            tblCart.Columns[3].Width = 70;

            tblCart.Columns[4].Width = 160;
            tblCart.Columns[5].Width = 160;
        }


        void loadGrid()
        {
            try
            {


                sales_product sp = new sales_product();
                List<sales_product> spList = new List<sales_product>();
                //  MessageBox.Show("Function called");
                spList = sp.getSales_Product_BySID(con, salesID);

                tblCart.Rows.Clear();
                int i = 0;
                //MessageBox.Show(cObjList.Count.ToString());
                foreach (BusinessObjects.sales_product item in spList)
                {
                    // MessageBox.Show(item.pname);
                    tblCart.Rows.Add();
                    tblCart.Rows[i].Cells[0].Value = item.p_id.ToString();
                    tblCart.Rows[i].Cells[1].Value = item.pname;
                    tblCart.Rows[i].Cells[2].Value = item.price.ToString();
                    tblCart.Rows[i].Cells[3].Value = item.quantity.ToString();

                    tblCart.Rows[i].Cells[4].Value = item.total.ToString();
                    tblCart.Rows[i].Cells[5].Value = item.warranty.ToString();


                    i++;
                }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemoryManagement.FlushMemory();
            this.Close();
        }

        private void tblCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

           
            int rw = e.RowIndex;
            int cl = e.ColumnIndex;
            if (Convert.ToString(tblCart.Rows[rw].Cells[0].Value) == string.Empty)
            {
                return;
            }
            


            if (cl == 6)
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType().Name == "SalesReturnProductsUpdate")
                    {
                        MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }
                }


            }

            if (Convert.ToString(tblCart.Rows[rw].Cells[0].Value) == string.Empty)
            {
                MessageBox.Show("No Products were found");
                tblCart.Rows[rw].Cells[0].Value = string.Empty;
                return;
            }
            int P_Code = Convert.ToInt32(tblCart.Rows[rw].Cells[0].Value.ToString());

            SalesReturnProductsUpdate st = new SalesReturnProductsUpdate(this, P_Code, salesID);

            st.ShowDialog();

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

    }
}
