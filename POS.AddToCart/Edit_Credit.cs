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
namespace POS.AddToCart
{
    public partial class Edit_Credit : MetroFramework.Forms.MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
       
        Manage_Creditors globalForm;
        public Edit_Credit(Manage_Creditors form)
        {
            InitializeComponent();
            this.Resizable = false;
            this.Movable = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.TopMost = true;
            globalForm = form;
            initi();
        }

        void initi()
        {
            txtCredit.Text = globalForm.publicSales.credit.ToString();
            txtCName.Text = globalForm.publicSales.customer_name;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemoryManagement.FlushMemory();
            this.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {

            if (txtCName.Text == string.Empty || txtCredit.Text == string.Empty || txtAmount.Text == string.Empty)
            {
                MessageBox.Show("Please enter valid data");
                return;
            }

            decimal paid=Convert.ToDecimal( txtAmount.Text);

            if (globalForm.publicSales.UpdateCredit(con, paid))
            {
                MemoryManagement.FlushMemory();
             //   this.Close();
                MessageBox.Show("Credit amount has been deducted");
                txtAmount.Clear();
                txtCredit.Text =Convert.ToString( Convert.ToDecimal(txtCredit.Text) - paid);

            }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }




        }
        private bool nonNumberEntered = false;
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            


            if (nonNumberEntered == true)
            {
                MessageBox.Show("Please enter numbers only");
                e.Handled = true;
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
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

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text == string.Empty)
                return;

            decimal credit = Convert.ToDecimal(txtCredit.Text);
            decimal paid = Convert.ToDecimal(txtAmount.Text);

            if (paid > credit)
            {

                MessageBox.Show("Invalid Input Found. Process Terminated");
                txtAmount.Text = string.Empty;
                return;
            }





        }
    }
}
