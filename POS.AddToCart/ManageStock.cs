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

using System.Configuration;
using BusinessObjects;
using MetroFramework;
using Tulpep.NotificationWindow;
using POS.AddToCart.Properties;
namespace POS.AddToCart
{
    public partial class ManageStock : MetroFramework.Forms.MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        List<Stock> StockList = new List<Stock>();
        public List<BusinessObjects.stock_product> stock_product_list = new List<stock_product>();
        public List<BusinessObjects.M_Product_BS> ProductList = new List<M_Product_BS>();
        List<BusinessObjects.Category_BS> CategoryList = new List<Category_BS>();

        bool checkSelectedIndexChange;//to check whether cmb is droped by user or not
        //for auto sugges
        DataTable dataTable = new DataTable();
        DataTable filteredTable;
        bool checkAutoSuggestCMBClick;
        public ManageStock()
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();

            panelSideMenu.Width = 0;
            
            increaseWidth();
            this.CenterToScreen();
            //this.WindowState = FormWindowState.Maximized;
            this.Resizable = false;
            this.Movable = false;
            this.MaximizeBox = false;
            this.TopLevel = true;
            autoComplete();
            lnkBack.Visible = false;
            lnkshow.Visible = true;
            disableContent();
            loadGridStock();
            txtStockID.Enabled = false;
            
            SetMyCustomFormat();
           // t.Abort();
           // notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Visible = false;
            createAutoSuggest();
        }


        void createBitIcon()
        {
            Bitmap tBmp = new Bitmap(POS.AddToCart.Properties.Resources.POS_icon22);

            Icon tIco;

            tIco = Icon.FromHandle(tBmp.GetHicon());
            notifyIcon1.Icon = tIco;
            // notifyIcon1.Visible = true;


        }
        void increaseWidth()
        {

            tblProduct.Columns[0].Width = 80;
            tblProduct.Columns[1].Width =140;
            tblProduct.Columns[2].Width = 190;
            tblProduct.Columns[3].Width = 160;
            tblProduct.Columns[4].Width = 110;

        }


        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            cmbDate.Format = DateTimePickerFormat.Custom;
            cmbDate.CustomFormat = "MM/dd/yyyy";
           
        }

        public void GifLoading()
        {
            Application.Run(new loading());
        }


        private void autoComplete()
        {

            try
            {

                txtInvoiceSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtInvoiceSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtSNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtSNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPNameSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtPNameSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtSupName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtSupName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection stringColl = new AutoCompleteStringCollection();
                AutoCompleteStringCollection stringColl2 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection stringColl3 = new AutoCompleteStringCollection();

                M_Product_BS product = new M_Product_BS();
                ProductList = product.GetProducts(con);

                foreach (BusinessObjects.M_Product_BS item in ProductList)
                {
                    stringColl.Add(item.name);
                    
                }

                //retreive stock data 
                Stock sc = new Stock();
              
                StockList = sc.GetStockList(con);
                

                foreach (BusinessObjects.Stock item in StockList)
                {
                    stringColl2.Add(item.sup_name);
                    stringColl3.Add(item.invoice_no.ToString());

                }
                txtPNameSearch.AutoCompleteCustomSource = stringColl;
                txtSNameSearch.AutoCompleteCustomSource = stringColl2;
                txtInvoiceSearch.AutoCompleteCustomSource = stringColl3;

                txtSupName.AutoCompleteCustomSource = stringColl2;

                BusinessObjects.Category_BS catObj = new BusinessObjects.Category_BS();
                CategoryList = catObj.GetCategory(con);

                cmbECategory.DataSource = null;
                cmbECategory.DataSource = CategoryList;
               
                cmbECategory.DisplayMember = "name";
                cmbECategory.ValueMember = "ID";
               

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }




        private void loadGridStock()
        {

            try
            {
                 int i = 0;
                tblProduct.Rows.Clear();

                //MessageBox.Show(cObjList.Count.ToString());
                foreach (BusinessObjects.Stock item in StockList)
                {
                    tblProduct.Rows.Add();
                    tblProduct.Rows[i].Cells[0].Value = item.stock_id.ToString();
                    tblProduct.Rows[i].Cells[1].Value = item.invoice_no.ToString();

                    tblProduct.Rows[i].Cells[2].Value = item.sup_name.ToString();
                    tblProduct.Rows[i].Cells[3].Value = item.s_date.ToString();
                    tblProduct.Rows[i].Cells[4].Value = item.StockProductList.Count.ToString();

                    tblProduct.Rows[i].Cells[5].Value = "Edit";
                    tblProduct.Rows[i].Cells[6].Value = "View";




                    i++;
                }
             //   autoComplete();

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        //donno y i have  created this function
        private void loadGrid()
        {

            try
            {
                List<Category_BS> catList = new List<Category_BS>();
                List<BusinessObjects.M_Product_BS> cObjList= new List<M_Product_BS>();
                BusinessObjects.M_Product_BS cObj = new BusinessObjects.M_Product_BS();
                cObjList = cObj.GetProducts(con);
                //MessageBox.Show(cObjList.Count.ToString());
                BusinessObjects.Category_BS catObj = new BusinessObjects.Category_BS();
                catList = catObj.GetCategory(con);
                foreach (BusinessObjects.Category_BS itemCat in catList)
                {
                    foreach (BusinessObjects.M_Product_BS itemProd in cObjList)
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
                foreach (BusinessObjects.M_Product_BS item in cObjList)
                {
                    tblProduct.Rows.Add();
                    tblProduct.Rows[i].Cells[0].Value = item.ID;
                    tblProduct.Rows[i].Cells[1].Value = item.name;

                    tblProduct.Rows[i].Cells[3].Value = item.cost;
                    tblProduct.Rows[i].Cells[2].Value = item.unitPrice;


                    tblProduct.Rows[i].Cells[5].Value = "VIEW";
                    tblProduct.Rows[i].Cells[6].Value = "ADD";




                    i++;
                }
                autoComplete();

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtPNameSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtPNameSearch.Text.Length > 0)
                {
                    string pname = txtPNameSearch.Text;
                    int pid = 0;
                    int i = 0;
                    tblProduct.Rows.Clear();

                    foreach (M_Product_BS item in ProductList)
                    {
                        if (item.name == pname)
                        {
                            pid = item.ID;
                        }
                    }

                    


                    foreach (Stock item in StockList)
                    {
                        
                        foreach (stock_product prod_stock in item.StockProductList)
                        {
                           
		                 if (prod_stock.pid  == pid)
                         {

                             tblProduct.Rows.Add();
                                tblProduct.Rows[i].Cells[0].Value = item.stock_id;
                                tblProduct.Rows[i].Cells[1].Value = item.invoice_no;

                                tblProduct.Rows[i].Cells[2].Value = item.sup_name;

                                tblProduct.Rows[i].Cells[3].Value = item.s_date.ToString();

                                tblProduct.Rows[i].Cells[4].Value = item.StockProductList.Count;
                                tblProduct.Rows[i].Cells[5].Value = "Edit";

                                tblProduct.Rows[i].Cells[6].Value = "View";                               



                                i++;
                            }
	                    }

                    }


                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtInvoiceSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtInvoiceSearch.Text.Length > 0)
                {
                    string invoice = txtInvoiceSearch.Text;
                    

                    int i = 0;
                    tblProduct.Rows.Clear();

                    foreach (Stock item in StockList)
                    {

                        if (item.invoice_no == invoice)
                            {

                                tblProduct.Rows.Add();
                                tblProduct.Rows[i].Cells[0].Value = item.stock_id;
                                tblProduct.Rows[i].Cells[1].Value = item.invoice_no;

                                tblProduct.Rows[i].Cells[2].Value = item.sup_name;

                                tblProduct.Rows[i].Cells[3].Value = item.s_date.ToString();

                                tblProduct.Rows[i].Cells[4].Value = item.StockProductList.Count;
                                tblProduct.Rows[i].Cells[5].Value = "Edit";

                                tblProduct.Rows[i].Cells[6].Value = "View";                               



                                i++;
                            }
                        

                    }


                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtSNameSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtSNameSearch.Text.Length > 0)
                {
                    string supName = txtSNameSearch.Text;


                    int i = 0;
                    tblProduct.Rows.Clear();

                    foreach (Stock item in StockList)
                    {

                        if (item.sup_name == supName)
                        {
                           
                            tblProduct.Rows.Add();
                            tblProduct.Rows[i].Cells[0].Value = item.stock_id;
                            tblProduct.Rows[i].Cells[1].Value = item.invoice_no;

                            tblProduct.Rows[i].Cells[2].Value = item.sup_name;

                            tblProduct.Rows[i].Cells[3].Value = item.s_date.ToString();

                            tblProduct.Rows[i].Cells[4].Value = item.StockProductList.Count;
                            tblProduct.Rows[i].Cells[5].Value = "Edit";

                            tblProduct.Rows[i].Cells[6].Value = "View";                               



                            i++;
                        }


                    }
                }

                }

             catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cmbECategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkSelectedIndexChange)
                {
                    Category_BS cat = (Category_BS)cmbECategory.SelectedItem;
                    Stock stock = new Stock();
                    List<Stock> stockList2 = new List<Stock>();
                    stockList2 = stock.GetOneStockByCatID(con, cat.ID);
                   

                    int i = 0;
                    tblProduct.Rows.Clear();
                   
                    foreach (Stock item in stockList2)
                    {
                        

                         tblProduct.Rows.Add();
                        tblProduct.Rows[i].Cells[0].Value = item.stock_id;
                        tblProduct.Rows[i].Cells[1].Value = item.invoice_no;

                        tblProduct.Rows[i].Cells[2].Value = item.sup_name;

                        tblProduct.Rows[i].Cells[3].Value = item.s_date.ToString();


                        foreach (Stock stock2 in StockList)
                        {
                            
                            if (item.stock_id == stock2.stock_id)
                            {
                               tblProduct.Rows[i].Cells[4].Value = stock2.StockProductList.Count;
                                
                            }
                        }

                        tblProduct.Rows[i].Cells[5].Value = "Edit";

                        tblProduct.Rows[i].Cells[6].Value = "View";                               


                        i++;


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
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void cmbECategory_DropDown(object sender, EventArgs e)
        {
            checkSelectedIndexChange= true;

        }

        private void tblProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rw = e.RowIndex;
                int cl = e.ColumnIndex;

                if (cl == 6)
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.GetType().Name == "StockReturn")
                        {
                            MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (Convert.ToString(tblProduct.Rows[rw].Cells[0].Value) == string.Empty)
                    {
                        MessageBox.Show("No Stock data found");
                        return;
                    }

                    int sid = Convert.ToInt32(tblProduct.Rows[rw].Cells[0].Value.ToString());

                    //getting relevant product list of the selected stock
                    stock_product stpr = new stock_product();

                    stpr.stock_id = sid;
                    stock_product_list = stpr.Get_stock_by_sid(con);


                    if (stock_product_list.Count == 0)
                    {
                        MetroMessageBox.Show(this, "No products were found for this purchase data ", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }


                    foreach (var productlist in ProductList)
                    {
                        foreach (var PSlist in stock_product_list)
                        {
                            if (productlist.ID == PSlist.pid)
                            {
                                PSlist.p_name = productlist.name;
                            }
                        }
                    }



                    //MessageBox.Show(sid.ToString());
                    using (StockReturn sr = new StockReturn(this, sid))
                    {
                        sr.ShowDialog();
                    }
                }
                else if (cl == 5)
                {
                    if (Convert.ToString(tblProduct.Rows[rw].Cells[0].Value) == string.Empty)
                    {
                        MessageBox.Show("No Stock data found");
                        return;
                    }

                    if(Convert.ToString(tblProduct.Rows[rw].Cells[0].Value) != string.Empty)
                    txtStockID.Text = tblProduct.Rows[rw].Cells[0].Value.ToString();

                    if (Convert.ToString(tblProduct.Rows[rw].Cells[2].Value) != string.Empty)
                    
                    txtSupName.Text=tblProduct.Rows[rw].Cells[2].Value.ToString();


                    if (Convert.ToString(tblProduct.Rows[rw].Cells[1].Value) != string.Empty)
                    txtInvoiceNo.Text=tblProduct.Rows[rw].Cells[1].Value.ToString();


                    if (Convert.ToString(tblProduct.Rows[rw].Cells[3].Value) != string.Empty)
                    cmbDate.Text = tblProduct.Rows[rw].Cells[3].Value.ToString();

                    enableContent();
                }
                else if (cl == 2)
                {
                    if (Convert.ToString(tblProduct.Rows[rw].Cells[0].Value) == string.Empty)
                    {
                        MessageBox.Show("No Stock data found");
                        return;
                    }
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.GetType().Name == "V_Supplier")
                        {
                            MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    int stid =Convert.ToInt32( tblProduct.Rows[rw].Cells[0].Value.ToString());
                    using (V_Supplier ms = new V_Supplier(stid))
                    {
                        ms.ShowDialog();
                    }
                
                }


            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

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

        private void lnkBack_Click(object sender, EventArgs e)
        {
            if (panelSideMenu.Width >= 250)
            {
                // this.panelSideMenu.Enabled = false;
                panelSideMenu.Width = 0;


            }
            else
                this.timer1.Enabled = true;
        }

        private void btnViewCart_Click(object sender, EventArgs e)
        {

        }

        private bool nonNumberEntered2 = false;
        private void txtInvoiceSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered2 = false;
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
                        nonNumberEntered2 = true;
                    }
                }
            }
        }

        private void txtInvoiceSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered2 == true)
            {
                MessageBox.Show("Please enter number only");
                e.Handled = true;

            }
        }


        void enableContent()
        {
            btnAdd.Enabled = true;
            txtSupName.Enabled = true;
            cmbDate.Enabled = true;
            txtInvoiceNo.Enabled = true;
        }

        void disableContent()
        {
            btnAdd.Enabled = false;
            txtSupName.Enabled = false;
            cmbDate.Enabled = false;
            txtInvoiceNo.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

            if (txtInvoiceNo.Text == string.Empty || txtSupName.Text == string.Empty || cmbDate.Text == string.Empty||txtStockID.Text==string.Empty)
            {
                MessageBox.Show("Invalid Data! Please enter valid data to the text area");
                return;
            }

            /*Code for get the Supplier ID using supplier Name*/
            Supplier Sup_obj = new Supplier();
            int sup_id = Sup_obj.GetIdByName(con, txtSupName.Text);
            if (sup_id < 1)
            {
                MessageBox.Show("Supplier Name Invalid");

                PopupNotifier pop = new PopupNotifier();
                pop.ContentText = "Please enter Supplier name with Auto Suggest";
                pop.TitleText = "Information";
                pop.Image = Resources.warning_sign_48;
                // pop.Image = Resources.Button_Icon_Orange_svg; // or Image.FromFile(--Path--)
                pop.IsRightToLeft = false;
                pop.ContentHoverColor = Color.Blue;
                pop.Popup();
                return;
            }
        
            /* Sup ID Retreive function end here  */
            string supName = txtSupName.Text;
            string invoice = txtInvoiceNo.Text;
            DateTime dateS =Convert.ToDateTime( cmbDate.Text);
            int stockid=Convert.ToInt32( txtStockID.Text);


            Stock st = new Stock();
            st.stock_id = stockid;
            st.invoice_no = invoice;
            st.sup_name = supName;
            st.s_date = dateS;
            st.Sup_id=sup_id;    
            if (st.Update(con))
            {
                MetroMessageBox.Show(this, "Successfully Updated ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopupNotifier pop = new PopupNotifier();
                pop.ContentText = "Data Has been Modified Successfully";
                pop.TitleText = "Success";
                pop.Image = Resources.success_48;
                // pop.Image = Resources.Button_Icon_Orange_svg; // or Image.FromFile(--Path--)
                pop.IsRightToLeft = false;
                pop.BodyColor = Color.LawnGreen;
                pop.ContentHoverColor = Color.OrangeRed;
                pop.Popup();
               
            }
            else
            {
                MetroMessageBox.Show(this, "Encountered an error ", "Disclaimed!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //at last
            disableContent();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new Form3();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                autoComplete();
            disableContent();
            loadGridStock();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new FormBilling();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
             BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void ManageStock_SizeChanged(object sender, EventArgs e)
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

        private void ManageStock_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void txtSupName_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSupName.Text))
                return;

            string text = txtSupName.Text;
            string not = "SalesReturnStock";
            if (text == not || text.CompareTo(not) == 0 || text.Equals(not))
            {
                MessageBox.Show("This is reserved keyword. Do not use this string");
                txtSupName.Clear();
                return;
            }
        }

        private void createAutoSuggest()
        {
            try
            {
                dataTable.Columns.Add("PName");
                //cmbAutoSuggest.Enabled = false;
                foreach (M_Product_BS item in ProductList)
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
                cmbAutoSuggest.DroppedDown = true;
                //Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmbAutoSuggest_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                        int pid = 0;
                        int i = 0;
                        tblProduct.Rows.Clear();

                        foreach (M_Product_BS item in ProductList)
                        {
                            if (item.name == pname)
                            {
                                pid = item.ID;
                            }
                        }




                        foreach (Stock item in StockList)
                        {

                            foreach (stock_product prod_stock in item.StockProductList)
                            {

                                if (prod_stock.pid == pid)
                                {

                                    tblProduct.Rows.Add();
                                    tblProduct.Rows[i].Cells[0].Value = item.stock_id;
                                    tblProduct.Rows[i].Cells[1].Value = item.invoice_no;

                                    tblProduct.Rows[i].Cells[2].Value = item.sup_name;

                                    tblProduct.Rows[i].Cells[3].Value = item.s_date.ToString();

                                    tblProduct.Rows[i].Cells[4].Value = item.StockProductList.Count;
                                    tblProduct.Rows[i].Cells[5].Value = "Edit";

                                    tblProduct.Rows[i].Cells[6].Value = "View";



                                    i++;
                                }
                            }

                        }


                    


                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }



        private void cmbAutoSuggest_DropDownClosed(object sender, EventArgs e)
        {
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


    }
}
