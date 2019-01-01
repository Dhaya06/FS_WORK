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
    public partial class purcahsed_products : MetroFramework.Forms.MetroForm
    {
       public Purchase_M globalForm;
        int stockID;
        public purcahsed_products(Purchase_M form, int sid)
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
            tblCartGrid.Columns[0].Width = 80;
            tblCartGrid.Columns[1].Width = 240;
            tblCartGrid.Columns[2].Width = 100;
            tblCartGrid.Columns[4].Width = 180;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MemoryManagement.FlushMemory();

            this.Close();
            //this.Hide();
            //var form2 = new ManageStock();
            //form2.Closed += (s, args) => this.Dispose();
            //form2.Show();


        }


        private void loadGrid() 
	    {	   
            try 
	    {
           // MessageBox.Show(globalForm.stock_product_list[1].p_name);
            bool result = globalForm.stock_product_list.Any();
            if (result)
            {
                tblCartGrid.Rows.Clear();
                int i = 0;
                foreach (BusinessObjects.purchase_product item in globalForm.stock_product_list)
                {

                    tblCartGrid.Rows.Add();

                    tblCartGrid.Rows[i].Cells[0].Value = item.pid;

                  
                    tblCartGrid.Rows[i].Cells[1].Value = item.p_name;
                    
                    

                    tblCartGrid.Rows[i].Cells[2].Value = item.quantity.ToString();

                    tblCartGrid.Rows[i].Cells[3].Value = item.cost.ToString();
                    tblCartGrid.Rows[i].Cells[4].Value = item.costTotal.ToString();
                 //   tblCartGrid.Rows[i].Cells[3].Value = "Update";
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
            

        }



        private void tblCartGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rw = e.RowIndex;
            int cl = e.ColumnIndex;   
            
           
        }
    }
}
