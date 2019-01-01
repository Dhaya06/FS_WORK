using MetroFramework;
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

namespace POS.AddToCart
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            
            InitializeComponent();
        //    checkLicense();
             this.TopLevel = true;
            CenterToScreen();
            metroProgressBar2.Visible = false;
            this.timer1.Start();
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.metroProgressBar2.Increment(1);
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
                MetroMessageBox.Show(this, "Please license this product", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // Application.Exit();
            }
            else
            {
              //  MessageBox.Show("Registry file is exist");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        

    }
}
