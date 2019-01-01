using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;
using System.Configuration;
using MetroFramework;

namespace POS.AddToCart
{
    public partial class Stock_Update : MetroFramework.Forms.MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        
        StockReturn gForm;
        int ProdID;
        int quantity;
        int stock_id;
        public Stock_Update(StockReturn form, int pid, int sid)
        {
            InitializeComponent();
            this.Resizable = false;
            this.Movable = false;
            this.TopMost = true; ;
            this.MaximizeBox = false;
            this.ControlBox = false;
            stock_id = sid;
            gForm = form;
            ProdID = pid;
            inititalis();
            txtAdjustedQuantity.Enabled = false;
        }


        void inititalis()
        { 
            foreach (var item in gForm.globalForm.stock_product_list)
	        {
                if(item.pid==ProdID)
                {
                    txtPName.Text=item.p_name;
                    txtAdjustedQuantity.Text=item.quantity.ToString();
                    quantity = item.quantity;
                }
	        }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        public bool isNumber(char ch, string text)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            //check if it´s a decimal separator and if doesn´t already have one in the text string
            if (ch == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            //check if it´s a digit, decimal separator and backspace
            if (!Char.IsDigit(ch) && ch != decimalChar && ch != (char)Keys.Back)
                res = false;

            return res;
        }



        private void btnupdate_Click(object sender, EventArgs e)
        {
           try
                { 
               
               if (txtPName.Text == "" || txtPName.Text == string.Empty || txtDesc.Text == string.Empty
                || txtQuantity.Text == string.Empty||txtAdjustedQuantity.Text==string.Empty)
            {
                MessageBox.Show("Please enter valid data!");
                return;
            
            }
            if (chkStockReturn.Checked)
            {
                

               
                if (Convert.ToInt32(txtQuantity.Text) <= quantity )
                {
                    //if so reduce from the current stock and enter data to the database to stockreturn table
                   
                    int amount=Convert.ToInt32(txtQuantity.Text);
                    stock_product stock = new stock_product();
                    stock.stock_id = stock_id;
                    stock.pid = ProdID;
                    stock.quantity = Convert.ToInt32(txtAdjustedQuantity.Text) - amount;
                    if (stock.Update(con))
                    {
                        StockReturn_BS sr = new StockReturn_BS();
                        sr.prd_id = ProdID;
                        sr.stock_id = stock_id;
                        sr.quantity = amount;
                        sr.descrip = txtDesc.Text;
                        sr.adjusted = 1;
                        if (sr.Add(con))
                        {
                            MessageBox.Show("Stock Updated Sucessfully");
                        }
                        else 
                        {
                            MetroMessageBox.Show(this, "System Error ", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "System Error ", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                   

                }
                else
                {
                    MessageBox.Show("Invalid Quantity!");
                    return;
                }

            }
            else
            {
                    //if so increase from the current stock and enter data to the database to stockreturn table
                int amount = Convert.ToInt32(txtQuantity.Text);
                stock_product stock = new stock_product();
                stock.stock_id = stock_id;
                stock.pid = ProdID;
                stock.quantity = Convert.ToInt32(txtAdjustedQuantity.Text) + amount;
                if (stock.Update(con))
                {
                    StockReturn_BS sr = new StockReturn_BS();
                    sr.prd_id = ProdID;
                    sr.stock_id = stock_id;
                    sr.quantity = amount;
                    sr.descrip = txtDesc.Text;
                    sr.adjusted = 0;
                    if (sr.Add(con))
                    {
                        MessageBox.Show("Stock Updated Sucessfully");
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "System Error, ! Please contact administrator for more information.  ", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "System Error ", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            
            }

           }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool nonNumberEntered = false;
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }

        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                MessageBox.Show("Please enter numbers only");
                txtQuantity.Text = quantity.ToString();
                e.Handled = true;
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            //if (txtQuantity.Text == string.Empty)
            //{
            //    txtQuantity.Text = quantity.ToString();
            // }
        }

        private void txtQuantity_TabStopChanged(object sender, EventArgs e)
        {
            
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (txtQuantity.Text == string.Empty)
            {
                txtQuantity.Text = quantity.ToString();
                return;
            }
            if(Convert.ToInt32(txtQuantity.Text)==0)
            {
                txtQuantity.Text = quantity.ToString();
                return;
            }

        }


    }
}
