using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using BusinessObjects;
using System.Configuration;
using Tulpep.NotificationWindow;
using POS.AddToCart.Properties;
namespace POS.AddToCart
{
    public partial class FIFO_LIFO : Form
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        public FIFO_LIFO()
        {
            InitializeComponent();

            this.TopMost = true;
            this.ControlBox = false;
            this.CenterToScreen();
            LoadCurrentRouting();
        }

        private void LoadCurrentRouting()
        {
            try
            {
                CartStockRoutingList DataModel = new CartStockRoutingList();
             string routing = DataModel.Get_Stock_Routing(con);
             lblCurrent.Text ="( "+ routing.ToString()+" )";
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try{
            if (!rdoFIFO.Checked && !rdoLIFO.Checked)
            {
                MessageBox.Show("Please select an option before proceeding");
                return;
            }

            DialogResult drs = MetroMessageBox.Show(this, "Do You Want to Change the System Settings", "System Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drs == DialogResult.Yes)
            {
                using (TransactionScope txScope = new TransactionScope())
                {
                    string type="";
                    if(rdoFIFO.Checked)
                    {type = "FIFO";}
                    else if (rdoLIFO.Checked)
                    { type = "LIFO"; }
                    else
                    {
                        MetroMessageBox.Show(this, "Something went wrong", "System Misconfugartion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    FI_LI_FO fili = new FI_LI_FO();
                    if (fili.Add(con, type)){

                        lblCurrent.Text = "( " + type.ToString() + " )";
                        MetroMessageBox.Show(this, "System Stock routing Has been changed", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        PopupNotifier pop = new PopupNotifier();
                        pop.ContentText = "System Funtionality has been updated";
                        pop.TitleText = "System Process Changed";
                        pop.Image = Resources.success_48; // or Image.FromFile(--Path--)
                        pop.IsRightToLeft = false;
                        pop.BodyColor = Color.Teal;
                        pop.BorderColor = Color.OrangeRed;
                        pop.ButtonHoverColor = Color.Purple;
                        pop.ContentColor = Color.OrangeRed;


                        pop.ContentHoverColor = Color.Blue;
                        pop.Popup();
                    }
                    else {
                        MetroMessageBox.Show(this, "Something went wrong", "System Misconfugartion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txScope.Complete();
                }
            }
            else if (drs == DialogResult.No)
            {
                MetroMessageBox.Show(this, "Transaction Has been Cancelled", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //close the forn
            this.Close();
        }
    }
}
