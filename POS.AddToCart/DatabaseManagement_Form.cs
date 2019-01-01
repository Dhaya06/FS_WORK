using System;
using MetroFramework.Forms;
using MetroFramework;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using BusinessObject;
using System.Threading;

namespace POS.AddToCart
{
    public partial class DatabaseManagement_Form : MetroForm
    {
        string conn = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;

        //SqlConnection con = new SqlConnection(UserInterface.Properties.Settings.Default.ConnectionString);


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["pos"].ConnectionString);

        DatabaseMangement db = new DatabaseMangement(); 

        public DatabaseManagement_Form()
        {
            Thread t = new Thread(new ThreadStart(GifLoading));
            t.Start();
            InitializeComponent();
            t.Abort();

            this.TopLevel = true;
            this.Resizable = false;
            this.Movable = false;
            this.ControlBox = false;
         //   notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Visible = false;
        }

        void createBitIcon()
        {
            Bitmap tBmp = new Bitmap(POS.AddToCart.Properties.Resources.POS_icon22);

            Icon tIco;

            tIco = Icon.FromHandle(tBmp.GetHicon());
            notifyIcon1.Icon = tIco;
            // notifyIcon1.Visible = true;


        }


        public void GifLoading()
        {
            Application.Run(new loading());
        }
        private void btnBackupBrowser_Click(object sender, EventArgs e)
        {

            try
            {

                FolderBrowserDialog dlg = new FolderBrowserDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtBackupLocation.Text = dlg.SelectedPath;
                    btnBackup.Enabled = true;
                }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            
            try
            {
                if (txtBackupLocation.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Database Backup Location");
                }
                else
                {
                    string cmd = "BACKUP DATABASE ["+database+"] TO DISK='" + txtBackupLocation.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        command.ExecuteNonQuery();
                        con.Close();

                    }

                    MessageBox.Show("Database Backup is done Sucessfully");
                    btnBackup.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRestoreLocation_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "SQL SERVER database backup files|*.bak";
                dlg.Title = "Database restore";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtRestoreLocation.Text = dlg.FileName;
                    btnRestore.Enabled = true;
                }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
               string sqlstmnt1 = string.Format("ALTER DATABASE ["+database+"] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
               SqlCommand bu1 = new SqlCommand(sqlstmnt1,con);
               bu1.ExecuteNonQuery();

               string sqlstmnt2 = "USE MASTER RESTORE DATABASE ["+database+"] FROM DISK='"+txtRestoreLocation.Text+"'WITH REPLACE;";
               SqlCommand bu2 = new SqlCommand(sqlstmnt2,con);
               bu2.ExecuteNonQuery();

               string sqlstmnt3 = string.Format("ALTER DATABASE ["+database+"] SET MULTI_USER");
               SqlCommand bu3 = new SqlCommand(sqlstmnt3,con);
               bu3.ExecuteNonQuery();

               MessageBox.Show("Database restoration done sucessfully");
               con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void lnkHome_Click(object sender, EventArgs e)
        {
            //BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void DatabaseManagement_Form_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
              
                createBitIcon();


                notifyIcon1.BalloonTipText = "System Has Been Minimized. You Can Maximise here";
                notifyIcon1.ShowBalloonTip(3000);
            }
            else
            {
              
                notifyIcon1.Icon = null;

            }
        }
    }
}
