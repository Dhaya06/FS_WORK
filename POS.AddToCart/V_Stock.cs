using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;
using System.Threading;
using MetroFramework;
using DGVPrinterHelper;

namespace POS.AddToCart
{
    public partial class V_Stock : MetroFramework.Forms.MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        List<BusinessObjects.M_Product_BS> cObjList = new List<M_Product_BS>();
        List<BusinessObjects.GetProductStock> GridList = new List<GetProductStock>();
        List<BusinessObjects.Category_BS> catList = new List<Category_BS>();
        List<BusinessObjects.stock_product> stock_pro_list = new List<stock_product>();
        private bool nonNumberEnteredss = false;
        bool checkSelectedIndexChange;

        //for auto sugges
        DataTable dataTable = new DataTable();
        DataTable filteredTable;
        bool checkAutoSuggestCMBClick;
        public V_Stock()
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();
            //t.Abort();
            this.MaximizeBox = false;
           /// WindowState = FormWindowState.Maximized;

            InitialloadGrid();
            autoComplete();
            increaseWidth(); panelSideMenu.Width = 0;
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Visible = false;
            createAutoSuggest();
            

        }
        public void GifLoading()
        {
            Application.Run(new loading());
        }
    
        //public void SetMyCustomFormat()
        //{
        //    // Set the Format type and the CustomFormat string.
        //    dateStart.Format = DateTimePickerFormat.Custom;
        //    dateStart.CustomFormat = "MM/dd/yyyy";
        //    dateEnd.Format = DateTimePickerFormat.Custom;
        //    dateEnd.CustomFormat = "MM/dd/yyyy";
        //}

        void increaseWidth()
        {
            tblProduct.Columns[1].Width = 240;
            tblProduct.Columns[2].Width = 140;
            tblProduct.Columns[5].Width = 120;
            //tblProduct.Columns[4].Width = 120;

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
              
                cmbPCat.DisplayMember = "name";
                cmbPCat.ValueMember = "ID";

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void InitialloadGrid()
        {

            try
            {
                
                BusinessObjects.GetProductStock spObj = new GetProductStock();
                GridList = spObj.getProdAlongWithStockQuantity_All(con);

                BusinessObjects.M_Product_BS cObj = new M_Product_BS();
                cObjList = cObj.GetProducts(con);
                //MessageBox.Show(cObjList.Count.ToString());
               
                //this is to set the category name
                
                Category_BS catObj = new Category_BS();
                catList = catObj.GetCategory(con);
                foreach (Category_BS itemCat in catList)
                {
                    foreach (GetProductStock itemProd in GridList)
                    {
                        if (itemProd.category == itemCat.ID)
                        {
                            itemProd.catObj = itemCat;
                        }
                    }
                }

                int i = 0;
                tblProduct.Rows.Clear();


                foreach (GetProductStock item in GridList)
                {
                    tblProduct.Rows.Add();
                    tblProduct.Rows[i].Cells[0].Value = item.ID;
                    tblProduct.Rows[i].Cells[1].Value = item.name;
                    tblProduct.Rows[i].Cells[2].Value = item.catObj.name;
                    tblProduct.Rows[i].Cells[3].Value = item.cost;
                    tblProduct.Rows[i].Cells[4].Value = item.unitPrice;

                    tblProduct.Rows[i].Cells[5].Value = item.warranty;
                    tblProduct.Rows[i].Cells[6].Value = item.TotalQuantity;
                    i++;
                }
                autoComplete();

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }




        private void loadGrid(List<GetProductStock> List_)
        {

            try
            {


                GridList = List_;

                BusinessObjects.M_Product_BS cObj = new M_Product_BS();
                cObjList = cObj.GetProducts(con);
                //MessageBox.Show(cObjList.Count.ToString());

                //this is to set the category name

               // Category_BS catObj = new Category_BS();
               // catList = catObj.GetCategory(con);
                foreach (Category_BS itemCat in catList)
                {
                    foreach (GetProductStock itemProd in GridList)
                    {
                        if (itemProd.category == itemCat.ID)
                        {
                            itemProd.catObj = itemCat;
                        }
                    }
                }

                int i = 0;
                tblProduct.Rows.Clear();


                foreach (GetProductStock item in GridList)
                {
                    tblProduct.Rows.Add();
                    tblProduct.Rows[i].Cells[0].Value = item.ID;
                    tblProduct.Rows[i].Cells[1].Value = item.name;
                    tblProduct.Rows[i].Cells[2].Value = item.catObj.name;
                    tblProduct.Rows[i].Cells[3].Value = item.cost;
                    tblProduct.Rows[i].Cells[4].Value = item.unitPrice;

                    tblProduct.Rows[i].Cells[5].Value = item.warranty;
                    tblProduct.Rows[i].Cells[6].Value = item.TotalQuantity;
                    i++;
                }
               // autoComplete();

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }


        private void cmbPCat_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            try{

                if (checkSelectedIndexChange)
                {
                    Category_BS cat = new Category_BS();
                    cat = (Category_BS)cmbPCat.SelectedItem;
                   // MessageBox.Show(cat.ID.ToString());
                    List<GetProductStock> ListItem = new List<GetProductStock>();
                    GetProductStock lObj = new GetProductStock();
                    ListItem= lObj.getProdAlongWithStockQuantity_ByCatID(con, cat.ID);

                    loadGrid(ListItem);



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

        private void cmbPCat_DropDown(object sender, EventArgs e)
        {
            checkSelectedIndexChange = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            BusinessObjects.MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
        }

        private void txtPName_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtPName.Text.Length > 0)
                {
                    string pname = txtPName.Text;
                    List<GetProductStock> ListItem = new List<GetProductStock>();
                    GetProductStock lObj = new GetProductStock();
                    ListItem = lObj.getProdAlongWithStockQuantity_ByProdName(con, pname);
                    loadGrid(ListItem);
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
                    


                    List<GetProductStock> ListItem = new List<GetProductStock>();
                    GetProductStock lObj = new GetProductStock();
                    ListItem = lObj.getProdAlongWithStockQuantity_ByProdID(con, pid);

                    loadGrid(ListItem);
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            
            InitialloadGrid();
        }
        private void ClearText()
        {
            txtPID.Text = "";
            txtPName.Text = "";


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

        private void V_Stock_SizeChanged(object sender, EventArgs e)
        {

            //if (notifyIcon1 != null)
            //{
            //    notifyIcon1.Visible = false;

            //}

            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = SystemIcons.Application;



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

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblProduct.Rows.Count < 1)
                {
                    MetroMessageBox.Show(this, "No Data found. !!!", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DGVPrinter printer = new DGVPrinter();

                printer.Title = "Stock Report";

                printer.SubTitle = "Stock Summary: Date : " + DateTime.Now.Date;

                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                              StringFormatFlags.NoClip;

                printer.PageNumbers = true;

                printer.PageNumberInHeader = false;

                printer.PorportionalColumns = true;

                printer.HeaderCellAlignment = StringAlignment.Near;

                printer.Footer = "Vista Computers";

                printer.FooterSpacing = 15;
                printer.PrintDataGridView(tblProduct);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void V_Stock_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void createAutoSuggest()
        {
            try
            {
                dataTable.Columns.Add("PName");
                //cmbAutoSuggest.Enabled = false;
                foreach (M_Product_BS item in cObjList)
                {
                    dataTable.Rows.Add(new string[] { item.name });
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "! System Error . Code 106. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkAutoSuggestCMBClick = false;
            try
            {
                if (string.IsNullOrWhiteSpace(txtProductName.Text))
                {
                    return;
                }

                string name = string.Format("{0}{1}", txtProductName.Text, e.KeyChar.ToString()); //join previous text and new pressed char
                DataRow[] rows = dataTable.Select(string.Format("PName LIKE '%{0}%'", name));
                filteredTable = dataTable.Clone();

                foreach (DataRow r in rows)
                {
                    filteredTable.ImportRow(r);
                }
                List<string> namelist = new List<string>();
                foreach (DataRow row in filteredTable.Rows)
                {
                    string fname = row["PName"].ToString();
                    //MessageBox.Show(fname);
                    namelist.Add(fname);
                }

                //comboBoxAdv1.DataSource = filteredTable.DefaultView;
                //comboBoxAdv1.DisplayMember = "FirstName";
                cmbAutoSuggest.DataSource = null;
                

                BindingSource bs = new BindingSource();
                bs.DataSource = namelist;

                cmbAutoSuggest.DataSource = bs;
               // cmbAutoSuggest.DroppedDown = true;
                //Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void cmbAutoSuggest_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
            //MessageBox.Show("Comes selected index change");
            try
            {
            if (!checkAutoSuggestCMBClick)
            {
                checkAutoSuggestCMBClick = false;
                return;
            }
            
            checkAutoSuggestCMBClick = false;
            if (cmbAutoSuggest.Text.Length > 0)
                {
                    string pname = cmbAutoSuggest.SelectedItem.ToString();
                    List<GetProductStock> ListItem = new List<GetProductStock>();
                    GetProductStock lObj = new GetProductStock();
                    ListItem = lObj.getProdAlongWithStockQuantity_ByProdName(con, pname);
                    loadGrid(ListItem);
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void cmbAutoSuggest_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbAutoSuggest_DropDownClosed(object sender, EventArgs e)
        {
            return;
            checkAutoSuggestCMBClick = false;
            if (cmbAutoSuggest.SelectedIndex == -1)
                return;
            checkAutoSuggestCMBClick = true;
        
        }

        private void txtProductName_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show("This feature is still not implemented to this product");
            //txtProductName.Enabled = false;
            //cmbAutoSuggest.Enabled = false;
            //return;
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {
         
        }

        

             
    }
}
