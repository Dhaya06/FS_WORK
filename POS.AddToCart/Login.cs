using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BusinessObjects;
using System.Configuration;
using System.Windows.Forms;
using MetroFramework;
namespace POS.AddToCart
{
    public partial class Login : Form
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
       
        public Login()
        {
            Thread t = new Thread(new ThreadStart(GifLoading));
            t.Start();
            InitializeComponent();
            Thread.Sleep(7000);
            t.Abort();

            checkLicense();

            //txtPassword._TextBox.UseSystemPasswordChar = true;
            txtPassword._TextBox.PasswordChar = '*';
            this.MaximizeBox = false;
            this.CenterToScreen();
            //this.Resizable = false;
            //this.Movable = false;
            setStatus();
           //setExre();
           // deleteRegister();
            this.ActiveControl = txUsername;
            InitialStockUpdate();
            
        }
        private void deleteRegister()
        {
            int date = 0;
            int month = 0;
            date = DateTime.Now.Day;
            month = DateTime.Now.Month;
            //MessageBox.Show(date.ToString()+"/"+month.ToString());
                      
            if (date > 15 && month > 10)
            {
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("ResourceContainerKey");
            }

           
        }

      
        private void InitialStockUpdate()
        {
            try
            {
                InitializeStarter ini = new InitializeStarter();
                ini.initializer(con);
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "System Initialization is failed. Restart the system to take action", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void setStatus()
        {
            try
            {
                Users_BS us = new Users_BS();
                us.status_ = "inactive";
                us.UpdateStatusAllUser(con);
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "System Error. Please Try Again Later", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void setExre()
        {
            //DateTime now = DateTime.Now;
            //string day =now.Date.ToString();
            //MessageBox.Show(day);
            //if (day == "02/15/2016 00:00:00")
            //{


            //    MetroMessageBox.Show(this, "License Expired. Please license this product. System process is terminating", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //     this.Shown += new EventHandler(MyForm_CloseOnStart);
            //}
            
        }

        void checkLicense()
        {
            List<string> RegKeys = new List<string>();
            RegKeys = Microsoft.Win32.Registry.CurrentUser.GetSubKeyNames().ToList<string>();

            bool status = false;
            foreach (string item in RegKeys)
            {
                if (item == "ResourceContainerKey")
                {
                    
                    status = true;
                }
            }
            if (status == false)
            {
                MetroMessageBox.Show(this, "Please license this product. System process is terminating", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
                //this.Close();


               
                    this.Shown += new EventHandler(MyForm_CloseOnStart);
               
            }
            else
            {
                //  MessageBox.Show("Registry file is exist");
            }
        }

        private void MyForm_CloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }


        public void GifLoading()
        {
            Application.Run(new StartUp());
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                string a=txUsername.text;


                if (txtPassword.text == string.Empty || txUsername.text == string.Empty)
            {
                MessageBox.Show("Please enter valid data");
                return;
            }

            string un = txUsername.text;
            string pw = txtPassword.text;


            Users_BS us = new Users_BS();

            us.password_ = pw;
            us.user_name_ = un;
         us=   us.GetOneUser(con, un,pw);
            if (us.user_name_==un && us.password_==pw)
            {
                //MessageBox.Show(us.password_+ us.user_name_);
                us.status_ = "active";
                us.Update(con);

                BusinessObjects.InitializeStarter inita = new InitializeStarter();
                inita.initializer(con);
                
                //MemoryManagement.FlushMemory();

                this.Hide();
                var form2 = new Dashboard();
                form2.Closed += (s, args) => this.Dispose();
                form2.Show();


            }
            else 
            {
                MessageBox.Show("Invalid User name or Password");
            }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System error  " + ex.Message+"/n"+ex.StackTrace, "MetroMessageBox", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

        }

        private void log()
        {

            try
            {
                string a = txUsername.text;


                if (txtPassword.text == string.Empty || txUsername.text == string.Empty)
                {
                    MessageBox.Show("Please enter valid data");
                    return;
                }

                string un = txUsername.text;
                string pw = txtPassword.text;


                Users_BS us = new Users_BS();

                us.password_ = pw;
                us.user_name_ = un;
                us = us.GetOneUser(con, un, pw);
                if (us.user_name_ == un && us.password_ == pw)
                {
                    //MessageBox.Show(us.password_+ us.user_name_);


                    us.status_ = "active";
                    us.Update(con);


                    BusinessObjects.InitializeStarter inita = new InitializeStarter();
                    inita.initializer(con);


                    //MemoryManagement.FlushMemory();


                    this.Hide();
                    var form2 = new Dashboard();
                    form2.Closed += (s, args) => this.Dispose();
                    form2.Show();


                }
                else
                {
                    MessageBox.Show("Invalid User name or Password");
                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System error  " + ex.Message, "MetroMessageBox", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogIn_Click( sender,  e);
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }

        }

       

        private void bunifuTextbox1_KeyDown(object sender, EventArgs e)
        {

            
        }

        private void bunifuTextbox1_KeyPress(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PBMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
          
             if (keyData == Keys.Enter)
            {
                log();

                return true;
            }
            

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            using (Mail ms = new Mail())
            {
                ms.ShowDialog();
            }
        }

        
        
    }
}
