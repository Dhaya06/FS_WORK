using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;
using MetroFramework;

namespace POS.AddToCart
{
    public  partial class ViewCart : MetroFramework.Forms.MetroForm
    {
        Form3 GlobalForm;
        public ViewCart(Form3 form)
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
          //  t.Start();

            //Thread.Sleep(800);
            InitializeComponent();
          //  t.Abort();
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.Resizable = false;
            this.Movable = false;
            this.TopMost = true;

            GlobalForm = form;
            loadGrid();
            increaseWidth();
        }

        private void loadGrid()
        {
            try
            {

            
            bool result = GlobalForm.stock_product_list.Any();
            if (result)
            {
                tblCartGrid.Rows.Clear();
                int i = 0;
                foreach (stock_product item in GlobalForm.stock_product_list) 
                {
                   
                    tblCartGrid.Rows.Add();

                    tblCartGrid.Rows[i].Cells[0].Value = item.pid;
                    tblCartGrid.Rows[i].Cells[1].Value = item.p_name;
                    tblCartGrid.Rows[i].Cells[2].Value = item.quantity.ToString();

                    tblCartGrid.Rows[i].Cells[4].Value = "Update";
                    tblCartGrid.Rows[i].Cells[4].Value = "Remove";
                    i++;
                }
                

              
            }
            else
               
            { tblCartGrid.Rows.Clear();
                MessageBox.Show("Product list is empty");
            }


           }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        void increaseWidth()
        {
            tblCartGrid.Columns[0].Width = 80;
            tblCartGrid.Columns[1].Width = 170;
            tblCartGrid.Columns[2].Width = 120;
            tblCartGrid.Columns[3].Width = 120;

        }


        public void GifLoading()
        {
            Application.Run(new loading());
        }

        private void tblCartGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


            int rw = e.RowIndex;
            int cl = e.ColumnIndex;

            if (Convert.ToString(tblCartGrid.Rows[rw].Cells[0].Value) == string.Empty)
            {
                MessageBox.Show("No Products were found");
                return;
            }


            if (cl == 4)
            {
                bool result =GlobalForm. stock_product_list.Any();
                
                
                if (result)
                {
                    

                    GlobalForm.stock_product_list.RemoveAt(rw);

                        tblCartGrid.Rows.Clear();
                       
                    int i = 0;
                    //MessageBox.Show(rw.ToString());
                    foreach (stock_product item in GlobalForm.stock_product_list)
                   {
                         tblCartGrid.Rows.Add();
                        
                        tblCartGrid.Rows[i].Cells[0].Value = item.pid;
                        tblCartGrid.Rows[i].Cells[1].Value = item.p_name;
                        tblCartGrid.Rows[i].Cells[2].Value = item.quantity.ToString();

                        tblCartGrid.Rows[i].Cells[3].Value = "Update";
                        tblCartGrid.Rows[i].Cells[3].Value = "Remove";
                        i++;
                   }
              
                


                }

                else
                {
                    tblCartGrid.Rows.Clear();
                    MessageBox.Show("Product list is empty");

                }
            }
            else if (cl == 3)
            {

             
              int id=Convert.ToInt32( tblCartGrid.Rows[rw].Cells[0].Value) ;
              int quan = Convert.ToInt32(tblCartGrid.Rows[rw].Cells[2].Value);

              foreach (var item in  GlobalForm.stock_product_list)
              {
                  if (item.pid == id)
                  {
                      if (item.quantity == quan)
                      {

                          return;
                      }
                      else
                      { 
                        GlobalForm.stock_product_list.Where(d=>d.pid==id).First().quantity=quan;//updating a relevent porperty of a object in a list
                        MessageBox.Show("Quantity Updated");
                       // MessageBox.Show(item.quantity.ToString());
                      }
                  }
                  
              }
            
                
            }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Close();
        }


        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void tblCartGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

            int rw = e.RowIndex;
            int cl = e.ColumnIndex;
                if (Convert.ToString(tblCartGrid.Rows[rw].Cells[0].Value) == string.Empty)
                {
                    
                    return;
                }


            
            int ExactIDofProduct = Convert.ToInt32(tblCartGrid.Rows[rw].Cells[0].Value);
            int q = GlobalForm.stock_product_list.Where(d => d.pid == ExactIDofProduct).First().quantity;//updating a relevent porperty of a object in a list
                        
            if (Convert.ToString(tblCartGrid.Rows[rw].Cells[2].Value) == string.Empty)
            {
                tblCartGrid.Rows[rw].Cells[2].Value = q;
                return;
            }
                 
                string theQuantity = tblCartGrid.Rows[rw].Cells[2].Value.ToString();

            if (IsDigitsOnly(theQuantity))
            {



            }
            else
            {
                MessageBox.Show("Please enter numbers in the quanity field");
                tblCartGrid.Rows[rw].Cells[2].Value = q;
                return;
            }

                
                if (Convert.ToInt32(tblCartGrid.Rows[rw].Cells[2].Value) == 0)
            {
                tblCartGrid.Rows[rw].Cells[2].Value = q;
                return;
            }




            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            






        }
    }
}
