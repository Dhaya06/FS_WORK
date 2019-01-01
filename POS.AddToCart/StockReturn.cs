using BusinessObjects;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.AddToCart
{
    public partial class StockReturn : MetroFramework.Forms.MetroForm
    {
       public ManageStock globalForm;
        int stockID;
        public StockReturn(ManageStock form, int sid)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Movable = false;
            this.Resizable = false;
            this.MaximizeBox = false;
            this.TopMost = true;
            globalForm = form;
            
            stockID = sid;
            increaseWidth();
            loadGrid();
        }
        void increaseWidth()
        {
            tblCartGrid.Columns[1].Width = 190;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemoryManagement.FlushMemory();
            this.Close();
        }


        private void loadGrid() 
	    {	   
            try 
	    {
            bool result = globalForm.stock_product_list.Any();
            if (result)
            {
                tblCartGrid.Rows.Clear();
                int i = 0;
                foreach (stock_product item in globalForm.stock_product_list)
                {
                    tblCartGrid.Rows.Add();
                    tblCartGrid.Rows[i].Cells[0].Value = item.pid;
                    tblCartGrid.Rows[i].Cells[1].Value = item.p_name;
                    tblCartGrid.Rows[i].Cells[2].Value = item.quantity.ToString();
                    tblCartGrid.Rows[i].Cells[3].Value = item.price.ToString();
                    tblCartGrid.Rows[i].Cells[4].Value = "Update";
                    i++;
                }
            }
            else
            {
                tblCartGrid.Rows.Clear();
                MessageBox.Show("Product list is empty");
                this.Close();
            }
	}
    catch (Exception ex)
    {
        MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    }

        private void tblCartGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int rw = e.RowIndex;
            int cl = e.ColumnIndex;
            if (cl != 4)
                return;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Name == "Stock_Update")
                {
                    MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
            }
            
            if (Convert.ToString(tblCartGrid.Rows[rw].Cells[0].Value) == string.Empty)
            {
                MessageBox.Show("No Products were found");
                tblCartGrid.Rows[rw].Cells[0].Value = string.Empty;
                return;
            }
            int p=Convert.ToInt32(tblCartGrid.Rows[rw].Cells[0].Value);

            using (Stock_Update st = new Stock_Update(this, p, stockID))
            {
                st.ShowDialog();
            }
        }



        private void tblCartGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rw = e.RowIndex;
            int cl = e.ColumnIndex;   
            
            //if (Convert.ToString(tblCartGrid.Rows[rw].Cells[0].Value) == string.Empty)
            //        {
            //            MessageBox.Show("No Products were found");
            //            tblCartGrid.Rows[rw].Cells[0].Value = string.Empty;
            //            return;
            //        }

            //int pid =Convert.ToInt32( tblCartGrid.Rows[rw].Cells[0].Value);
            //int quan = Convert.ToInt32(tblCartGrid.Rows[rw].Cells[2].Value);
            //if (chkStockReturn.Checked)
            //{
            //    foreach (var item in globalForm.stock_product_list)
            //    {
            //        if (item.pid == pid)
            //        {
            //            if (item.quantity < quan)
            //            { 
                            
            //            }
                    
            //        }
                    
            //    }
                
            //}
        }
    }
}
