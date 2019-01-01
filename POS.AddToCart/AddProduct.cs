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
using System.Globalization;
using System.Configuration;
using System.Threading;

namespace POS.AddToCart
{
    public partial class AddProduct : MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;



        public AddProduct()
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();
            //t.Abort();
            this.TopLevel = true;
          
           this.MaximizeBox=false;
           this.ControlBox = false;
            tglWeight.Location = new Point(this.ClientSize.Width / 2 - tglWeight.Size.Width / 2, this.ClientSize.Height / 2 - tglWeight.Size.Height / 2);
            tglWeight.Anchor = AnchorStyles.None;
            panelSideMenu.Width = 0;
            getMaxId();
            loadCombo();

        //    notifyIcon1.Icon = SystemIcons.Application;
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

        private void ClearText()
        {
            txtProductID.Text = String.Empty;
            txtProName.Text = String.Empty;
            txtPCost.Text = String.Empty;
            txtPMPrice.Text = String.Empty;
            txtBundlePrice.Text = String.Empty;
            txtpackagecost.Text = String.Empty;
            txtDescp.Text = String.Empty;
            numericUpDown1.Value = 0;
            
        }

        private void loadCombo()
        {
            try
            {
                cmbCategory.DataSource = null;
                BusinessObjects.Category_BS CBS = new BusinessObjects.Category_BS();
                List<BusinessObjects.Category_BS> CList = new List<BusinessObjects.Category_BS>();
                CList = CBS.GetCategory(con);
                cmbCategory.DataSource = CList;
                cmbCategory.DisplayMember = "name";
                cmbCategory.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void getMaxId()
        {
            try
            {

                if (BusinessObjects.M_Product_BS.getScalar(con, "Select max(ID) from _Product").Equals(System.DBNull.Value))
                {
                    txtProductID.Text = 1.ToString();

                }
                else
                {
                    int a = 0;
                    a = (int)BusinessObjects.M_Product_BS.getScalar(con, "Select max(ID) from _Product");
                    a++;
                    txtProductID.Text = a.ToString();
                }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        public bool isNumber(char ch, string text)
        {
            bool res = true;

            try
            {

                
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
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return res;
            }

        }

        private void txtPCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, txtPCost.Text))
                e.Handled = true;
        }

        private void txtPMPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, txtPMPrice.Text))
                e.Handled = true;
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBundlePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, txtBundlePrice.Text))
                e.Handled = true;
        }

        private void txtVat_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtUnitWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtBundleWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void lnkMCategory_Click(object sender, EventArgs e)
        {

            

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Name == "M_Category")
                {   
                    MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
            }

            M_Category m = new M_Category();
            m.Show(this);
        }

        private void lnkAdd_Click(object sender, EventArgs e)
        {

            try
            {


                //if (string.IsNullOrEmpty(txtPCost.Text) || string.IsNullOrEmpty(txtProName.Text) || string.IsNullOrEmpty(txtPMPrice.Text) ||
                // cmbCategory.SelectedIndex == -1 ||string.IsNullOrEmpty(txtBundlePrice.Text) ||string.IsNullOrEmpty(txtpackagecost.Text)||string.IsNullOrEmpty(txtDescp.Text))

                if (string.IsNullOrEmpty(txtPCost.Text) || string.IsNullOrEmpty(txtProName.Text) || string.IsNullOrEmpty(txtPMPrice.Text) ||
                 cmbCategory.SelectedIndex == -1 )
              
                
                {
                    MetroMessageBox.Show(this, "Please enter valid data to the text fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    if (Convert.ToDecimal(txtPMPrice.Text) < Convert.ToDecimal(txtPCost.Text))
                    {
                        MetroMessageBox.Show(this, "Unit Price should be higher than Unit Cost", "System Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                    }
                    //else if (Convert.ToDecimal(txtBundlePrice.Text) <= Convert.ToDecimal(txtpackagecost.Text))
                    //{
                    //    MetroMessageBox.Show(this, "Package Price should be higher than Package Cost", "System Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                    //}
                    else
                    {


                        string name, description;

                        //decimal price, boundlePrice, cost, boundlecost;
                       
                        decimal price, cost;
                        int category;

                            name = txtProName.Text;
                            category = Convert.ToInt32(cmbCategory.SelectedValue);
                            price = Convert.ToDecimal(txtPMPrice.Text);
                            //boundlePrice = Convert.ToDecimal(txtBundlePrice.Text);
                            cost = Convert.ToDecimal(txtPCost.Text);
                            //boundlecost = Convert.ToDecimal(txtpackagecost.Text);

                            if (string.IsNullOrEmpty(txtDescp.Text))
                            { description = ""; }
                            else
                            {
                                description = txtDescp.Text;
                            }
                        
                        BusinessObjects.M_Product_BS BP = new BusinessObjects.M_Product_BS();
                            //BP.boundlePrice = boundlePrice;
                            BP.name = name;
                            BP.category = category;
                            BP.cost = cost;
                            BP.unitPrice = price;
                            //BP.boundleCost = boundlecost;
                            BP.description = description;

                            if (cmbMonth.Checked)
                            { BP.warranty = numericUpDown1.Value.ToString() + " /Month"; }
                            else
                            { BP.warranty = numericUpDown1.Value.ToString() + " /Week"; }
                            
                            if (BP.Add(con))
                            {

                                MetroMessageBox.Show(this, "Product data added Successfully", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearText();
                                getMaxId();
                            }
                            else
                            {
                                MetroMessageBox.Show(this, "! Process encountered an error", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                            }
                        
                    }
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, " !System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void lnkShowAll_Click(object sender, EventArgs e)
        {
            loadCombo();
        }

        private void lnkHome_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
        }

        private void lnkCancel_Click(object sender, EventArgs e)
        {
            try
            {

                ClearText();
                getMaxId();
        
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void txtProName_Leave(object sender, EventArgs e)
        {
            try
	        {
                if (string.IsNullOrWhiteSpace(txtProName.Text))
                {

                    return;
                }
                else
                {

                    string name = txtProName.Text;
                    string query = "select COUNT(*) from _Product where name='" + name + "' ";
                    int count = (int)BusinessObjects.M_Product_BS.getScalar(con, query);
                    if (count > 0)
                    {
                        MessageBox.Show("The Product Name Already Exist");
                        txtProName.Text = String.Empty;
                    }

                }
	        }
	        catch (Exception ex)
	        {

                MetroMessageBox.Show(this, "System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
	        }
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
        }

        private void txtpackagecost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, txtpackagecost.Text))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panelSideMenu.Width >= 250)
            {
                // this.panelSideMenu.Enabled = false;
                panelSideMenu.Width = 0;


            }
            else
                this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panelSideMenu.Width >= 250)
            {
                this.timer1.Enabled = false;

            }
            else
            {
                panelSideMenu.Width += 12;

            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new ViewProducts();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new ManageStock();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            
            ClearText();
            panelSideMenu.Width = 0;
            getMaxId();
            loadCombo();


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void AddProduct_SizeChanged(object sender, EventArgs e)
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
                //notifyIcon1.Visible = true;
                //notifyIcon1.Icon = SystemIcons.Application;
                //notifyIcon1.BalloonTipText = "System Process Started";
                //notifyIcon1.ShowBalloonTip(3000);
                notifyIcon1.Icon = null;

            }
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
