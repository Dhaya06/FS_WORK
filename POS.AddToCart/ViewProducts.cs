using System;
using MetroFramework.Forms;
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
using System.Globalization;

namespace POS.AddToCart
{
    public partial class ViewProducts : MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        List<BusinessObjects.M_Product_BS> cObjList = new List<M_Product_BS>();
        List<BusinessObjects.Category_BS> catList = new List<Category_BS>();
        private bool nonNumberEnteredss = false;
        bool checkSelectedIndexChange;

        public ViewProducts()
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();
          //  t.Abort();
            this.MaximizeBox = false;
          //  WindowState = FormWindowState.Maximized;
            //metroPanel1.Location = new Point(this.ClientSize.Width / 2 - metroPanel1.Size.Width / 2, this.ClientSize.Height / 2 - metroPanel1.Size.Height / 2);
            //metroPanel1.Anchor = AnchorStyles.None;

         this.TopLevel = true;
            autoComplete();
            lnkSearch.Enabled = false;
            loadGrid();
            panelSideMenu.Width = 0;
           // notifyIcon1.Icon = SystemIcons.Application;
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

        private void autoComplete()
        {

            try
            {

                txtPID.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtPID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtPName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection stringColl = new AutoCompleteStringCollection();
                AutoCompleteStringCollection stringColl2 = new AutoCompleteStringCollection();




                foreach (M_Product_BS item in cObjList)
                {
                    stringColl.Add(item.ID.ToString());
                    stringColl2.Add(item.name);
                }


                txtPID.AutoCompleteCustomSource = stringColl;
                txtPName.AutoCompleteCustomSource = stringColl2;
                cmbPCat.DataSource = null;
                cmbPCat.DataSource = catList;
                cmbECategory.DataSource = null;
                cmbECategory.DataSource = catList;
                cmbECategory.DisplayMember = "name";
                cmbECategory.ValueMember = "ID";
                cmbPCat.DisplayMember = "name";
                cmbPCat.ValueMember = "ID";

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void loadGrid()
        {

            try
            {

                BusinessObjects.M_Product_BS cObj = new M_Product_BS();
                cObjList = cObj.GetProducts(con);
                //MessageBox.Show(cObjList.Count.ToString());
                Category_BS catObj = new Category_BS();
                catList = catObj.GetCategory(con);
                foreach (Category_BS itemCat in catList)
                {
                    foreach (M_Product_BS itemProd in cObjList)
                    {
                        if (itemProd.category == itemCat.ID)
                        {
                            itemProd.catObj = itemCat;
                        }
                    }
                }

                int i = 0;
                tblProduct.Rows.Clear();

                //MessageBox.Show(cObjList.Count.ToString());
                foreach (M_Product_BS item in cObjList)
                {
                    tblProduct.Rows.Add();
                    tblProduct.Rows[i].Cells[0].Value = item.ID;
                    tblProduct.Rows[i].Cells[1].Value = item.name;
                    tblProduct.Rows[i].Cells[2].Value = item.catObj.name;
                    tblProduct.Rows[i].Cells[3].Value = item.cost;
                    tblProduct.Rows[i].Cells[4].Value = item.unitPrice;

                    tblProduct.Rows[i].Cells[5].Value = item.warranty;
                    tblProduct.Rows[i].Cells[6].Value = "Edit";




                    i++;
                }
                autoComplete();

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ClearText()
        {
            txtEPid.Text = "";
            txtEPname.Text = "";
            txtEPrice.Text = "";
            txtECost.Text = "";
            cmbECategory.Text = "";
            //txtEBoundlePrice.Text = "";
            lnkSearch.Text = "";
            //txtPackagecost.Text = "";
            numericUpDown1.Value = 0;
            txtDes.Text = "Description";
           
        }

        private void txtPID_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEnteredss = false;
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
                        nonNumberEnteredss = true;
                    }
                }
            }
        }

        private void txtPID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEnteredss == true)
            {
                MessageBox.Show("Please enter number only");
                e.Handled = true;
            }
        }

        private void txtPID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPID.Text.Length > 0)
                {
                    int pid = Convert.ToInt32(txtPID.Text);
                    int i = 0;
                    tblProduct.Rows.Clear();

                    foreach (M_Product_BS item in cObjList)
                    {
                        if (item.ID == pid)
                        {
                            tblProduct.Rows.Add();
                            tblProduct.Rows[i].Cells[0].Value = item.ID;
                            tblProduct.Rows[i].Cells[1].Value = item.name;
                            tblProduct.Rows[i].Cells[2].Value = item.catObj.name;
                            tblProduct.Rows[i].Cells[3].Value = item.cost;
                            tblProduct.Rows[i].Cells[4].Value = item.unitPrice;

                            tblProduct.Rows[i].Cells[5].Value = item.warranty;
                            tblProduct.Rows[i].Cells[6].Value = "Edit";


                            i++;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtPName_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtPName.Text.Length > 0)
                {
                    string pname = txtPName.Text;
                    int i = 0;
                    tblProduct.Rows.Clear();


                    foreach (M_Product_BS item in cObjList)
                    {
                        if (item.name == pname)
                        {
                            tblProduct.Rows.Add();
                            tblProduct.Rows[i].Cells[0].Value = item.ID;
                            tblProduct.Rows[i].Cells[1].Value = item.name;
                            tblProduct.Rows[i].Cells[2].Value = item.catObj.name;
                            tblProduct.Rows[i].Cells[3].Value = item.cost;
                            tblProduct.Rows[i].Cells[4].Value = item.unitPrice;

                            tblProduct.Rows[i].Cells[5].Value = item.warranty;
                            tblProduct.Rows[i].Cells[6].Value = "Edit";


                            i++;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cmbPCat_DropDown(object sender, EventArgs e)
        {
            checkSelectedIndexChange = true;
        }

        private void cmbPCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkSelectedIndexChange)
                {
                    Category_BS cat = (Category_BS)cmbPCat.SelectedItem;
                    int i = 0;
                    tblProduct.Rows.Clear();


                    foreach (M_Product_BS item in cObjList)
                    {
                        if (item.catObj == cat)
                        {
                            tblProduct.Rows.Add();
                            tblProduct.Rows[i].Cells[0].Value = item.ID;
                            tblProduct.Rows[i].Cells[1].Value = item.name;
                            tblProduct.Rows[i].Cells[2].Value = item.catObj.name;
                            tblProduct.Rows[i].Cells[3].Value = item.cost;
                            tblProduct.Rows[i].Cells[4].Value = item.unitPrice;
                           
                            tblProduct.Rows[i].Cells[5].Value = item.warranty;
                            tblProduct.Rows[i].Cells[6].Value = "Edit";


                            i++;
                        }

                    }
                    checkSelectedIndexChange = false;
                }
                else
                {
                    checkSelectedIndexChange = false;
                }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        string editedName = "";
        private void tblProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rw = e.RowIndex;
                int cl = e.ColumnIndex;
                int pid = 0;

                if (cl == 6)
                {
                    pid = Convert.ToInt32(tblProduct.Rows[rw].Cells[0].Value.ToString());
                    foreach (M_Product_BS item in cObjList)
                    {
                        if (item.ID == pid)
                        {

                            txtEPid.Enabled = true;
                            txtEPname.Enabled = true;
                            txtEPrice.Enabled = true;
                            txtECost.Enabled = true;
                            cmbECategory.Enabled = true;
                            //txtEBoundlePrice.Enabled = true;
                            lnkSearch.Enabled = true;
                            numericUpDown1.Enabled = true;
                            //txtPackagecost.Enabled = true;

                            txtEPid.Text = item.ID.ToString();
                            txtEPname.Text = item.name;
                            editedName = item.name;
                            txtEPrice.Text = item.unitPrice.ToString();
                            txtECost.Text = item.cost.ToString();
                            cmbECategory.SelectedIndex = cmbECategory.FindString(item.catObj.name);
                            numericUpDown1.Value = 1;
                            //txtEBoundlePrice.Text = item.boundlePrice.ToString();
                            //txtPackagecost.Text = item.boundleCost.ToString();
                            txtDes.Clear();
                            txtDes.Text = item.description.ToString();

                        }

                    }
                }
                else
                {
                    txtEPid.Enabled = false;
                    txtEPname.Enabled = false;
                    txtEPrice.Enabled = false;
                    txtECost.Enabled = false;
                    cmbECategory.Enabled = false;
                    //txtEBoundlePrice.Enabled = false;
                    lnkSearch.Enabled = false;
                    //txtPackagecost.Enabled = false;
                    numericUpDown1.Enabled = false;
                    

                    return;
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lnkSearch_Click(object sender, EventArgs e)
        {
            try
            {

                
                if (string.IsNullOrEmpty(txtECost.Text) || string.IsNullOrEmpty(txtEPname.Text) || string.IsNullOrEmpty(txtEPrice.Text) ||
                  cmbECategory.SelectedIndex == -1 )
                {
                    MetroMessageBox.Show(this, "Please enter valid data to the text fields", "System Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToDecimal(txtEPrice.Text) < Convert.ToDecimal(txtECost.Text))
                {
                    MetroMessageBox.Show(this, "Unit Price should be higher than or equal to Unit Cost ", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
               
                else
                {
                    int pid = 0;
                    M_Product_BS IndexObj = new M_Product_BS();
                    pid = Convert.ToInt32(txtEPid.Text);

                    string waran = "";
                    if (cmbMonth.Checked)
                    { waran = " /Month"; }
                    else
                    {
                        waran = " /Week";
                    }


                    bool result = cObjList.Any();
                    if (result)
                    {
                        foreach (M_Product_BS item in cObjList)
                        {
                            if (item.ID == pid)
                            {
                                IndexObj.ID = pid;
                                IndexObj.name = txtEPname.Text;
                                IndexObj.unitPrice = Convert.ToDecimal(txtEPrice.Text);
                                //IndexObj.boundlePrice = Convert.ToDecimal(txtEBoundlePrice.Text);
                                IndexObj.cost = Convert.ToDecimal(txtECost.Text);
                                IndexObj.catObj = (BusinessObjects.Category_BS)cmbECategory.SelectedItem;
                                IndexObj.category = IndexObj.catObj.ID;
                                //IndexObj.boundleCost = Convert.ToDecimal(txtPackagecost.Text);
                                IndexObj.warranty = numericUpDown1.Value.ToString() + waran;

                                if (string.IsNullOrEmpty(txtDes.Text))
                                { IndexObj.description = ""; }
                                else
                                {
                                    IndexObj.description = txtDes.Text;
                                }
                                

                            }
                        }

                        if (IndexObj.Update(con))
                        {
                            MetroMessageBox.Show(this, "Product data Successfully updated", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearText();
                            loadGrid();

                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Process encountered an error. Please try again", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        txtEPid.Enabled = false;
                        txtEPname.Enabled = false;
                        txtEPrice.Enabled = false;
                        txtECost.Enabled = false;
                        cmbECategory.Enabled = false;
                        //txtEBoundlePrice.Enabled = false;
                        lnkSearch.Enabled = false;
                        //txtPackagecost.Enabled = false;
                        txtDes.Enabled = false;
                        numericUpDown1.Enabled = false;
                        txtDes.Text = "Description";
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Table is empty ", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

                
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            try
            {

                int pid = 0;
                M_Product_BS IndexObj = new M_Product_BS();
                foreach (DataGridViewRow item in this.tblProduct.SelectedRows)
                {
                    pid = Convert.ToInt32(item.Cells[0].Value.ToString());

                }


                bool result = cObjList.Any();
                if (result)
                {
                    if (tblProduct.RowCount > 0)
                    {
                        foreach (M_Product_BS item in cObjList)
                        {
                            if (item.ID == pid)
                            {
                                IndexObj = item;
                            }
                        }

                        if (IndexObj.Delete(con))
                        {
                            MetroMessageBox.Show(this, "Product data Successfully deleted", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadGrid();
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Product was not deleted", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        txtEPid.Enabled = false;
                        txtEPname.Enabled = false;
                        txtEPrice.Enabled = false;
                        txtECost.Enabled = false;
                        cmbECategory.Enabled = false;
                        //txtEBoundlePrice.Enabled = false;
                        lnkSearch.Enabled = false;
                        numericUpDown1.Enabled = false;
                        //txtPackagecost.Enabled = false;
                        

                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Table data is empty ", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Table list is empty ", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void lnkHome_Click(object sender, EventArgs e)
        {

            BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
        }


        private void lnkShowAll_Click(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void txtEPname_Leave(object sender, EventArgs e)
        {
            try
            {
            if (string.IsNullOrWhiteSpace(txtEPname.Text))
                {

                    return;
                }
                else
                {

                    string name = txtEPname.Text;
                    string query = "select COUNT(*) from _Product where name='" + name + "' ";
                    int count = (int)BusinessObjects.M_Product_BS.getScalar(con, query);
                    if (count > 0)
                    {
                        string query2 = "select ID from _Product where name='" + name + "' ";
                        int piad = (int)BusinessObjects.M_Product_BS.getScalar(con, query2);
                      
                        //MessageBox.Show(piad.ToString());
                        int textBoxPID =Convert.ToInt32( txtEPid.Text);
                        if (piad != textBoxPID)
                        {
                            MessageBox.Show("The Product Name Already Exist");
                            txtEPname.Text = editedName;
                        
                        }

                        
                    }

                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            autoComplete(); ClearText();
            lnkSearch.Enabled = false;
            loadGrid();
        }

        private void txtECost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, txtECost.Text))
                e.Handled = true;
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

        private void txtEPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, txtEPrice.Text))
                e.Handled = true;
        }

        private void txtEBoundlePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!isNumber(e.KeyChar, txtEBoundlePrice.Text))
            //    e.Handled = true;
        }

        private void txtPackagecost_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!isNumber(e.KeyChar, txtPackagecost.Text))
            //    e.Handled = true;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

            MemoryManagement.FlushMemory();


            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {

            MemoryManagement.FlushMemory();


            this.Hide();
            var form2 = new AddProduct();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            
            MemoryManagement.FlushMemory();


            this.Hide();
            var form2 = new ManageStock();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
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

        private void ViewProducts_SizeChanged(object sender, EventArgs e)
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

        private void panel1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void ViewProducts_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

    }
}
