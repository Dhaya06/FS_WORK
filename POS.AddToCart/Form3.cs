using BusinessObjects;
using MetroFramework;
using POS.AddToCart.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace POS.AddToCart
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
      
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        List<BusinessObjects.M_Product_BS> cObjList = new List<M_Product_BS>();
        List<BusinessObjects.Category_BS> catList = new List<Category_BS>();
        private bool nonNumberEnteredss = false;
        bool checkSelectedIndexChange;
      public  List<BusinessObjects.stock_product> stock_product_list=new List<stock_product>();
       
        

        public Form3()
        {
          //Thread t = new Thread(new ThreadStart(GifLoading));
          //t.Start();

          //   Thread.Sleep(400);
            InitializeComponent();
         //   t.Abort();
            //this.WindowState = FormWindowState.Maximized;
            increaseWidth();
            panelSideMenu.Width = 0;
            autoComplete();
            loadCombo();
            loadGrid();
            SetMyCustomFormat();
            getMaxStockID();
            this.Resizable = false;
            this.ControlBox = false;
            this.ControlBox = false;
         
            notifyIcon1.Visible = false;

            loadCombow();
        }


        void createBitIcon()
        {
            Bitmap tBmp = new Bitmap(POS.AddToCart.Properties.Resources.POS_icon22);

            Icon tIco;

            tIco = Icon.FromHandle(tBmp.GetHicon());
            notifyIcon1.Icon = tIco;
            // notifyIcon1.Visible = true;


        }


        public void GifLoadingSaveSales()
        {
            Application.Run(new LoadingSave());
        }
        private void GifLoading()
        {
            Application.Run(new loading());
        }



        DataTable temp;
        DataTable bank;
       private void loadCombow()
        {
            try
            {

            
            Supplier prodObj = new Supplier();

            txtSupName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSupName.AutoCompleteSource = AutoCompleteSource.ListItems;

            temp = prodObj.ForAutoSearch(con);

            DataView dtview = new DataView(temp);
            dtview.Sort = "Company DESC";
            bank = dtview.ToTable();


            txtSupName.DataSource = bank;
            txtSupName.ValueMember = "Id";
            txtSupName.DisplayMember = "Company";
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void getMaxStockID()
        {
            try
            {

                if (BusinessObjects.Stock.getScalar(con, "Select max(stock_id) from _Stokc").Equals(System.DBNull.Value))
                {
                    txtStockID.Text = 1.ToString();

                }
                else
                {
                    int a = 0;
                    a = (int)BusinessObjects.M_Product_BS.getScalar(con, "Select max(stock_id) from _Stokc");
                    a++;
                    txtStockID.Text = a.ToString();
                }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            cmbDate.Format = DateTimePickerFormat.Custom;
            cmbDate.CustomFormat = "MM/dd/yyyy";
        }

        void increaseWidth()
        {
            tblProduct.Columns[1].Width = 180;
            tblProduct.Columns[2].Width = 120;
            tblProduct.Columns[3].Width = 120;
            tblProduct.Columns[4].Width = 120;

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

        private void loadCombo()
        {
            try
            {
                cmbECategory.DataSource = null;
                BusinessObjects.Category_BS CBS = new BusinessObjects.Category_BS();
                List<BusinessObjects.Category_BS> CList = new List<BusinessObjects.Category_BS>();
                CList = CBS.GetCategory(con);
                cmbECategory.DataSource = CList;
                cmbECategory.DisplayMember = "name";
                cmbECategory.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                            tblProduct.Rows[i].Cells[3].Value = item.cost;
                            tblProduct.Rows[i].Cells[2].Value = item.unitPrice;

                            tblProduct.Rows[i].Cells[5].Value = "VIEW";
                            tblProduct.Rows[i].Cells[6].Value = "ADD";


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


        private void autoComplete()
        {

            try
            {

                txtPID.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtPID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtPName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    txtSupName.AutoCompleteMode = AutoCompleteMode.Suggest;
             //   txtSupName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection stringColl = new AutoCompleteStringCollection();
                AutoCompleteStringCollection stringColl2 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection stringColl3 = new AutoCompleteStringCollection();



                foreach (BusinessObjects.M_Product_BS item in cObjList)
                {
                    stringColl.Add(item.ID.ToString());
                    stringColl2.Add(item.name);
                }
                
                //retreve stock data 
                Stock sc = new Stock();
                List<Stock> stList = new List<Stock>();
                stList = sc.GetStockList(con);

                //foreach (BusinessObjects.Stock item in stList)
                //{
                //    stringColl3.Add(item.sup_name);
                    
                //}
               // txtSupName.AutoCompleteCustomSource = stringColl3;

                txtPID.AutoCompleteCustomSource = stringColl;
                txtPName.AutoCompleteCustomSource = stringColl2;
                cmbECategory.DataSource = null;
                cmbECategory.DataSource = catList;
                cmbECategory.DataSource = null;
                cmbECategory.DataSource = catList;
                cmbECategory.DisplayMember = "name";
                cmbECategory.ValueMember = "ID";
                cmbECategory.DisplayMember = "name";
                cmbECategory.ValueMember = "ID";

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

                            tblProduct.Rows[i].Cells[3].Value = item.cost;
                            tblProduct.Rows[i].Cells[2].Value = item.unitPrice;


                            tblProduct.Rows[i].Cells[5].Value = "VIEW";
                            tblProduct.Rows[i].Cells[6].Value = "ADD";


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

        private void cmbECategory_DropDown(object sender, EventArgs e)
        {
            checkSelectedIndexChange = true;
        }

        private void cmbECategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkSelectedIndexChange)
                {
                    Category_BS cat = (Category_BS)cmbECategory.SelectedItem;
                    int i = 0;
                    tblProduct.Rows.Clear();


                    foreach (M_Product_BS item in cObjList)
                    {
                        if (item.catObj == cat)
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

        private void tblProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rw = e.RowIndex;
                int cl = e.ColumnIndex;
                int pid = 0;


                if (cl == 5)
                {
                   

                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.GetType().Name == "View_Dercription")
                        {
                            MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    pid = Convert.ToInt32(tblProduct.Rows[rw].Cells[0].Value.ToString());
                    string desc = "";
                    foreach (M_Product_BS item in cObjList)
                    {
                        if (item.ID == pid)
                        {
                            desc = item.description;

                        }

                    }
                    using ( View_Dercription m = new View_Dercription(desc))
                    {
                        m.Show(this);
                        
                    }

                    return;
                    
                
                }

                else if (cl == 6)
                {
                    pid = Convert.ToInt32(tblProduct.Rows[rw].Cells[0].Value.ToString());

                    if (tblProduct.Rows[rw].Cells[4].Value==null)
                    {

                        MessageBox.Show("Please enter quanity");
                        return;
                    }
                    if (tblProduct.Rows[rw].Cells[3].Value==null)
                    {
                        MessageBox.Show("Cost should not be null");
                        return;
                    }

                    
                    int check = 0;
                    bool result=stock_product_list.Any();
                  
                    if (result)
                    {
                        foreach (stock_product item in stock_product_list)
                        {
                            if (item.pid == pid)
                            {
                                item.price =Convert.ToDecimal(tblProduct.Rows[rw].Cells[3].Value.ToString());
                                item.quantity = item.quantity + Convert.ToInt32(tblProduct.Rows[rw].Cells[4].Value.ToString());
                                check = 1;
                            }
                            
                        }
                        
                    }


                    if (check == 0)
                    {


                        foreach (M_Product_BS item in cObjList)
                        {
                            if (item.ID == pid)
                            {
                                stock_product Stock_product = new BusinessObjects.stock_product();

                                Stock_product.pid = item.ID;
                                Stock_product.p_name = item.name;
                                
                                Stock_product.price = Convert.ToDecimal(tblProduct.Rows[rw].Cells[3].Value.ToString());
                                Stock_product.quantity = Convert.ToInt32(tblProduct.Rows[rw].Cells[4].Value.ToString());

                                Stock_product.stock_id = Convert.ToInt32(txtStockID.Text.ToString());

                                stock_product_list.Add(Stock_product);
                                MessageBox.Show("Product Added");
                                
                            }

                        }

                    }
                    else 
                    {
                        check = 0;
                    }
                    
                    
                    ////this is to testing purpose
                    //foreach (stock_product item in stock_product_list)
                    //    {

                    //        MessageBox.Show(item.p_name + " "+ item.quantity.ToString());
                    //    }

                }
                else
                {
                    return;
                }


            }

            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
        
        
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(new ThreadStart(GifLoadingSaveSales));
            try
            {

                if (txtSupName.SelectedValue == null)
                {
                    MessageBox.Show("Invalid Supplier Name");
                    txtSupName.ResetText();
                    txtSupName.DataSource = null;
                    txtSupName.DataSource = bank;
                    txtSupName.ValueMember = "Id";
                    txtSupName.DisplayMember = "Company";

                    return;
                }
                if (txtSupName.Text == "SalesReturnStock")
                {

                    MetroMessageBox.Show(this, "Selected suppilier name is system reserved keyword. You can't use this record, Please try another suppilier name or add a new name", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                //MessageBox.Show(txtSupName.SelectedValue.ToString());
                //MessageBox.Show(txtSupName.Text.ToString());

                if (string.IsNullOrEmpty(txtSupName.Text) || string.IsNullOrEmpty(txtInvoiceNo.Text) || string.IsNullOrEmpty(txtStockID.Text) ||
                   string.IsNullOrEmpty(cmbDate.Text) || txtSupName.SelectedValue == null)
                {
                    MetroMessageBox.Show(this, "Please enter valid data to the text fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool resul = stock_product_list.Any();
                if (!resul)
                {
                    MessageBox.Show("No Product details were added to the stock");
                    return;
                }

                else
                {
                    
                 //   t.Start();

                    using (TransactionScope txScope = new TransactionScope())
                    {
                        DateTime d;
                        d = Convert.ToDateTime(cmbDate.Text);
                        int stockID = Convert.ToInt32(txtStockID.Text);
                        string supName = txtSupName.Text;
                        string invoiceNo = txtInvoiceNo.Text;

                        Stock stock = new Stock();
                        stock.invoice_no = invoiceNo;
                        stock.stock_id = stockID;
                        stock.sup_name = supName;
                        stock.s_date = d;
                        stock.Sup_id = Convert.ToInt32(txtSupName.SelectedValue.ToString());

                        if (stock.Add(con))
                        {
                            string query = @"select IDENT_CURRENT('_Stokc')";
                            int lastInsertedID = Convert.ToInt32(Sales_BM.getScalar(con, query));

                            stockID = lastInsertedID;
                            int count = 0;
                            foreach (var item in stock_product_list)
                            {
                                item.stock_id = lastInsertedID;
                                item.Add(con);
                                count++;
                            }


                            int cehckPurchase = 0;
                            Purchase pr = new Purchase();
                            if (pr.AddPurchase(con, lastInsertedID))
                            {
                                pr.AddPurchaseProduct(con, lastInsertedID);
                                cehckPurchase++;
                            }

                         //   t.Abort();
                            if (cehckPurchase > 0 && count > 0)
                            {
                                txScope.Complete();//transaction commit

                                //MessageBox.Show("Products were added");
                                PopupNotifier pop = new PopupNotifier();
                                pop.ContentText = "Products Stock data stored to the system";
                                pop.TitleText = "Notification";
                                pop.Image = Resources.success_48; // or Image.FromFile(--Path--)
                                pop.IsRightToLeft = false;
                                pop.ContentHoverColor = Color.Teal;
                                pop.Popup();

                                MetroMessageBox.Show(this, "Stock Details stored to the system. :-P ", "Successfull!", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                                refresh();
                            }
                            else
                            {
                                MetroMessageBox.Show(this, "Something Went Wrong. Please restrart the form and try again... ", "Unexpected Interuption!", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);

                            }
                        }
                        else
                        {
                          //  t.Abort();
                            MetroMessageBox.Show(this, "Something Went Wrong. Please restrart the form and try again... ", "Unexpected Interuption!", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                        }


                    }//end of using statement
                }

            }
            catch (Exception ex)
            {
                //t.Abort();
                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
               // t.Abort();
            }


        }

      
        private void tblProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void tblProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rw = e.RowIndex;
                int cl = e.ColumnIndex;

                if (Convert.ToString(tblProduct.Rows[rw].Cells[3].Value.ToString()) == string.Empty)
                {
                    tblProduct.Rows[rw].Cells[3].Value = costBeforeEdit.ToString();
                }

                //checking cost 
                decimal d;
                string costValue = tblProduct.Rows[rw].Cells[3].Value.ToString();
                if (!decimal.TryParse(costValue, out d))
                {
                    PopupNotifier pop = new PopupNotifier();
                    pop.ContentText = "Please enter valid Cost";
                    pop.TitleText = "Invalid Input";
                     pop.Image = Resources.warning_sign_48; // or Image.FromFile(--Path--)
                    pop.IsRightToLeft = false;
                    pop.ContentHoverColor = Color.OrangeRed;
                    pop.BodyColor = Color.Orange;
                    pop.Popup();
                    tblProduct.Rows[rw].Cells[3].Value = costBeforeEdit.ToString();
                }


                if (Convert.ToString(tblProduct.Rows[rw].Cells[4].Value) == string.Empty)
                {
                    return;
                }
               string theQuantity = tblProduct.Rows[rw].Cells[4].Value.ToString();

                if (IsDigitsOnly(theQuantity))
                {
                }
                else 
                {
                    MessageBox.Show("Please enter numbers in the quanity field");
                    tblProduct.Rows[rw].Cells[4].Value=string.Empty;
                }
                
            

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

      private  bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
       

    

        private void btnViewCart_Click(object sender, EventArgs e)
        {
            try
            {

                if (stock_product_list.Count==0)
                {
                    MessageBox.Show("Product Cart is Empty");
                    return;
                }


                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType().Name == "ViewCart")
                    {
                        MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }
                }
            ViewCart v = new ViewCart(this);
            v.Show();
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

       
        private void tblProduct_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show(); 
            
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

        private void metroTile3_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new ManageStock();
            form2.Closed += (s, args) => this.Close();
            form2.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearTextFIeld();
            panelSideMenu.Width = 0;
            autoComplete();
            loadCombo();
            loadGrid();
            SetMyCustomFormat();
            getMaxStockID();
            stock_product_list.Clear();
        }


        void refresh()
        {
            clearTextFIeld();
            panelSideMenu.Width = 0;
           // autoComplete();
           // loadCombo();
           // loadGrid();
            SetMyCustomFormat();
          //  getMaxStockID();
            stock_product_list.Clear();
        
        }
        void clearTextFIeld()
        {
            txtInvoiceNo.Text = String.Empty;
            txtSupName.Text = String.Empty;
            txtPID.Text = String.Empty;
            txtPName.Text = String.Empty;
            
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();

            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void btnAddStockItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            int checkloop = 0;
            int prodID = 0;
            int quntyToAddList = 0;
            string prName = "";
                
            string col1 = "";
            foreach (DataGridViewRow dr in tblProduct.Rows)
            {
                //if (dr.Cells[4].Value != null || dr.Cells[4].Value!=string.Empty && dr.Cells[3].Value != null || dr.Cells[3].Value != string.Empty)
                if (dr.Cells[4].Value != null  && dr.Cells[3].Value != null )
                {
                    checkloop++;
                    decimal priceTyped = 0;

                    col1 = dr.Cells[4].Value.ToString();


                    prodID = Convert.ToInt32(dr.Cells[0].Value.ToString());
                     priceTyped = Convert.ToDecimal(dr.Cells[3].Value.ToString());//getting teh price
                    quntyToAddList = Convert.ToInt32(dr.Cells[4].Value.ToString());
                    prName = dr.Cells[1].Value.ToString();

                    int check = 0;
                    bool result = stock_product_list.Any();

                    if (result)
                    {
                        foreach (stock_product item in stock_product_list)
                        {
                            if (item.pid == prodID)
                            {
                                item.quantity = item.quantity + quntyToAddList;
                                item.price = priceTyped;
                                check = 1;
                            }

                        }

                    }


                    if (check == 0)
                    {

                        stock_product Stock_product = new BusinessObjects.stock_product();

                        Stock_product.pid = prodID;
                        Stock_product.p_name = prName;
                        Stock_product.price = priceTyped;//adding the price
                        Stock_product.quantity = quntyToAddList;

                        Stock_product.stock_id = Convert.ToInt32(txtStockID.Text.ToString());

                        stock_product_list.Add(Stock_product);


                        //    }

                        //}

                    }
                    else
                    {
                        check = 0;
                    }


                }
            }


            if (checkloop > 0)
            {
                

                foreach (DataGridViewRow dr in tblProduct.Rows)
                {
                 //   dr.Cells[4].Value = string.Empty;

                    dr.Cells[4].Value = null; 
                    
                }
                  

                //MessageBox.Show("Products were added");
                PopupNotifier pop = new PopupNotifier();
                pop.ContentText = "Products were added";
                pop.TitleText = "Notification";
               // pop.Image = Resources.Button_Icon_Orange_svg; // or Image.FromFile(--Path--)
                pop.IsRightToLeft = false;
                pop.ContentHoverColor = Color.Blue;
                pop.Popup();


            }
            else
            {
                foreach (DataGridViewRow dr in tblProduct.Rows)
                {
                    //dr.Cells[4].Value = string.Empty;
                    dr.Cells[4].Value = null;


                }

                //MessageBox.Show("No Products were added");

                PopupNotifier pop = new PopupNotifier();
                pop.ContentText = "No products were added";
                pop.TitleText = "Notification";
               // pop.Image = Resources.Button_Icon_Orange_svg; // or Image.FromFile(--Path--)
                pop.IsRightToLeft = false;
                pop.ContentHoverColor = Color.Blue;
                pop.Popup();
            }

        //}
        //catch (Exception ex)
        //{

        //    MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //}

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
        }

        private void Form3_SizeChanged(object sender, EventArgs e)
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

        private void Form3_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void txtSupName_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSupName.Text))
                return;

            if (txtSupName.SelectedValue== null)
            {
                MessageBox.Show("Invalid Supplier Name");
                txtSupName.DataSource = null;
                txtSupName.DataSource = bank;
                txtSupName.ValueMember = "Id";
                txtSupName.DisplayMember = "Company";

                return;
            }

            string text = txtSupName.Text;
            string not="SalesReturnStock";
            if (text == not || text.CompareTo(not) == 0 || text.Equals(not))
            {
                txtSupName.ResetText();
                MessageBox.Show("This is reserved keyword. Do not use this string");
               
                txtSupName.DataSource = null;
                txtSupName.DataSource = bank;
                txtSupName.ValueMember = "Id";
                txtSupName.DisplayMember = "Company";
           
                return;
            }

           
        }



        private decimal costBeforeEdit;
        private void tblProduct_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int rw=e.RowIndex;
            int cl = e.ColumnIndex;

            decimal costy=Convert.ToDecimal(tblProduct.Rows[rw].Cells[3].Value.ToString());
            costBeforeEdit = costy;
        }



        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
         
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using (M_Suppilier ms = new M_Suppilier())
            {
             
                ms.ShowDialog();
            }
        }

        private void btnSupRefresh_Click(object sender, EventArgs e)
        {
            loadCombow();
        }
        
      

    }
}
