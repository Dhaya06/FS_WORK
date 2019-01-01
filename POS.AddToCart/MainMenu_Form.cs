using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Threading;

namespace POS.AddToCart
{
    public partial class MainMenu_Form : MetroForm
    {
       
        public MainMenu_Form()
        {

            
 //Thread t = new Thread(new ThreadStart(GifLoading));
 //           t.Start();
            InitializeComponent();
                 
           
            
            metroPanel1.Location = new Point(this.ClientSize.Width / 2 - metroPanel1.Size.Width / 2, this.ClientSize.Height / 2 - metroPanel1.Size.Height / 2);
            metroPanel1.Anchor = AnchorStyles.None;
            this.TopLevel= true;
            this.ControlBox = true;
            this.MaximizeBox = false;
            //t.Abort();

       // notifyIcon1.Icon = SystemIcons.Application;

           // createBitIcon();
            
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

        private void metroTileItem1_Click(object sender, EventArgs e)
        {

        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
           
    /*        FormBilling fb = new FormBilling();
            fb.Show();
            this.Close();
            */

            this.Hide();
            var form2 = new FormBilling();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();


        }

        private void metroTileItem1_Click_1(object sender, EventArgs e)
        {
          

            this.Hide();
            var form2 = new AddProduct();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTileItem3_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            var form2 = new ViewProducts();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
            
        }

        private void metroTileItem6_Click(object sender, EventArgs e)
        {

            this.Hide();
            var form2 = new DatabaseManagement_Form();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();

            
           
        }

        private void metroTileItem11_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new V_Stock ();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
          //  System.GC.Collect();
          ////  BusinessObjects.MemoryManagement.FlushMemory();
          //  this.Hide();
          //  var form2 = new VIewPrinters();
          //  form2.Closed += (s, args) => this.Close();
          //  form2.Show(); 
         //   MessageBox.Show("Function is disabled");
            
           
        }

        private void metroTileItem7_Click(object sender, EventArgs e)
        {

            //System.GC.Collect();
            ////BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new ManageStock();
            form2.Closed += (s, args) => this.Close();
            form2.Show(); 
           // MetroMessageBox.Show(this, "Function Disabled2", "MetroMessageBox", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }

        private void metroTileItem4_Click(object sender, EventArgs e)
        {
          //  System.GC.Collect();
           // BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new UserManage();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTileItem15_Click(object sender, EventArgs e)
        {
            
            System.GC.Collect();
            this.Hide();
            var form2 = new ViewChequePayment();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
           // MessageBox.Show("Function has been disabled");
        }

        private void metroTileItem16_Click(object sender, EventArgs e)
        {


           // System.GC.Collect();
            this.Hide();
            var form2 = new Form3();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTileItem5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroTileItem9_Click(object sender, EventArgs e)
        {
           // System.GC.Collect();
            this.Hide();
            var form2 = new ViewSales();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }



      

        private void MainMenu_Form_SizeChanged(object sender, EventArgs e)
        {
            //if (notifyIcon1 != null)
            //{
            //    notifyIcon1.Visible = false;
             
            //}
          
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
              // notifyIcon1.Icon = SystemIcons.Application;
                createBitIcon();
               

                notifyIcon1.BalloonTipText = "System Has Been Minimized. You Can Maximise here";
                notifyIcon1.ShowBalloonTip(3000);
            }
            else
            {
                //notifyIcon1.Visible = true;
                //notifyIcon1.Icon = SystemIcons.Application;
                //notifyIcon1.BalloonTipText = "System Process Started";
                //notifyIcon1.ShowBalloonTip(3000);
                notifyIcon1.Icon = null;

            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void metroTileItem12_Click(object sender, EventArgs e)
        {
           // System.GC.Collect();
           // BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new ViewSoldProduct();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
            //MessageBox.Show("Function has been diabled");

        }

        private void metroTileItem8_Click(object sender, EventArgs e)
        {
           // System.GC.Collect();
        //    BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new Manage_Creditors();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTileItem10_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Purchase_M();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void MainMenu_Form_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
          //  
       
            //this.ShowInTaskbar = false;
            //this.ShowInTaskbar = true;
            //this.ShowInTaskbar = true;
            //this.ShowInTaskbar = true;

            //this.ShowInTaskbar = true;




            //this.ShowInTaskbar = true;
            //this.ShowInTaskbar = true;
            //this.ShowInTaskbar = true;
            //this.Activate();
        }

        private void tileSalesReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new SalesReturn();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void tileDashBoard_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Dashboard();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void tltFIFOLIFO_Click(object sender, EventArgs e)
        {
            using (FIFO_LIFO fi = new FIFO_LIFO())
            {
                fi.ShowDialog();
            }
        }

        private void tileStackHolder_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Name == "StackHolder")
                {
                    MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
            }
            using (StackHolder ms = new StackHolder())
            {
                ms.ShowDialog();
            }
        }

        private void tileSotckAdjust_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new ViewStockUpdate();
            form2.Closed += (s, args) => this.Close();
            form2.Show();

            //MessageBox.Show("We are working on it [ to bring the light.]");
            //MetroMessageBox.Show(this, "This screen allows to view all the changes that are made to the stock and the 'stocl products' respectively with 'user_name' and the 'changed date'", "Feature Details!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //return;
        }
    }
}
