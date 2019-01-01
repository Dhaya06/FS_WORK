using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework;
using BusinessObjects;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using MetroFramework;

namespace POS.AddToCart
{
    public partial class Dashboard : Form
    {
  
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
       
        public List<Sales_BM> SalesList_Public = new List<Sales_BM>();
       

        public List<sales_product> Sales_product_list_public;
        public Dashboard()
        {
            InitializeComponent();
           
            this.ControlBox = false;
            this.ControlBox = false;
            this.CenterToScreen();
            notifyIcon1.Visible = false;
            btnViewSales.selected = true;
            loadFirstControl();
            
        }

        void createBitIcon()
        {
            Bitmap tBmp = new Bitmap(POS.AddToCart.Properties.Resources.POS_icon22);

            Icon tIco;

            tIco = Icon.FromHandle(tBmp.GetHicon());
            notifyIcon1.Icon = tIco;
            // notifyIcon1.Visible = true;


        }
        void loadFirstControl()
        {
            try 
	        {	        
	    	
	    if (!panelMainContent.Controls.Contains(UserControlDashBoard.Instance()))
            {
                panelMainContent.Controls.Add(UserControlDashBoard.Instance());
                UserControlDashBoard.Instance().Dock = DockStyle.Fill;
                UserControlDashBoard.Instance().BringToFront();
            }
            else
                UserControlDashBoard.Instance().BringToFront();
         }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        
        private void btnDashboard_Click(object sender, EventArgs e)
        {

            loadFirstControl();
        }
        void toggle(object sender)
        {
            try 
	    {	        
	
            btnViewSales.selected = false;
            btnDashboard.selected = false;
            btnViewAvalible.selected = false;
            btnViewStock.selected = false;

            ((ns1.BunifuFlatButton)sender).selected = true;
         }
        catch (Exception ex)
        {

            MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        }

      

        private void btnViewStock_Click(object sender, EventArgs e)
        {
            try
            {

            
            if (!panelMainContent.Controls.Contains(D_Summary.Instance()))
            {
                panelMainContent.Controls.Add(D_Summary.Instance());
                D_Summary.Instance().Dock = DockStyle.Fill;
                D_Summary.Instance().BringToFront();
            }
            else
                D_Summary.Instance().BringToFront();
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void btnViewSales_Click(object sender, EventArgs e)
        {
            try
            {

            
            if (!panelMainContent.Controls.Contains(OutOfStoclIC.Instance()))
            {
                panelMainContent.Controls.Add(OutOfStoclIC.Instance());
                OutOfStoclIC.Instance().Dock = DockStyle.Fill;
                OutOfStoclIC.Instance().BringToFront();
            }
            else
                OutOfStoclIC.Instance().BringToFront();
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnViewAvalible_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();

        }

        private void Dashboard_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Dashboard_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Dashboard_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PBMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Dashboard_SizeChanged(object sender, EventArgs e)
        {
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
                notifyIcon1.Icon = null;

            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                
                OutOfStoclIC.refresh();
                D_Summary.Refresh();
                
                panelMainContent.Controls.Remove(UserControlDashBoard.Refresh());
                panelMainContent.Controls.Remove(D_Summary.Instance());
                panelMainContent.Controls.Remove(OutOfStoclIC.Instance());

                    panelMainContent.Controls.Add(UserControlDashBoard.Refresh());
                    UserControlDashBoard.Refresh().Dock = DockStyle.Fill;
                    UserControlDashBoard.Refresh().BringToFront();
                
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void panelTopMain_Paint(object sender, PaintEventArgs e)
        {

        }

     
  



       
    }
}
