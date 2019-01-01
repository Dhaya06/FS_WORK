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
    public partial class UserManage : MetroFramework.Forms.MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;

        public UserManage()
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();
            this.ControlBox = false;
            this.Resizable = false;
            this.Movable = false;
            this.TopMost = true; ;
            txUsername.Enabled = false;
           // t.Abort();
        }
        public void GifLoading()
        {
            Application.Run(new loading());
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try 
	    {


            if (string.IsNullOrEmpty(txtRetype.Text) || string.IsNullOrEmpty(txtNewPassword.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txUsername.Text))
            {
                MessageBox.Show("Invalid Data");
                return;
            }


            string userNae = txUsername.Text;
            string pasword = txtPassword.Text;
            string newPaass = txtNewPassword.Text;
            string rety = txtRetype.Text;

            if (rety != newPaass)
            {
                MessageBox.Show("Password does not matching");
            }
    

            Users_BS ubs = new Users_BS();
            ubs = ubs.GetOneUser(con, userNae, pasword);
            MessageBox.Show(ubs.password_);
            if (ubs.password_ == pasword && ubs.user_name_ == userNae)
            {
                
            }
            else
            { 
            MessageBox.Show("Invalid username or password");
                return;
            }

            ubs.user_name_ = userNae;
            ubs.password_ = newPaass;
            ubs.status_ = "active";

            if (ubs.Update(con))
            {
                MetroMessageBox.Show(this, "Successfully Updated" , "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
                
}
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void txtRetype_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRetype.Text))
            {
                return;
            }
            if (txtRetype.Text != txtNewPassword.Text)
            {
                MessageBox.Show("Password does not match");
                txtRetype.Clear();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            try
            {


                Users_BS ubs = new Users_BS();
                ubs = ubs.GetActiveUser(con);
                txUsername.Text = ubs.user_name_;
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
