using System;
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
using System.Drawing.Printing;
using MetroFramework.Controls;
using MetroFramework;
using System.Threading;
using System.Globalization;
using System.Transactions;

namespace POS.AddToCart
{
    public partial class FormBilling : MetroFramework.Forms.MetroForm

        //forVat object is defined unusuall. line 326
    {  
        string connString2 = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        bool isKeyPressProductCode;
        List<CartList> Cartlist = new List<CartList>();
        //List<List<CartList>> RunningOrders=new List<List<CartList>>();

        //List<BusinessObjects.RunningOrder_BS> RunningOrderList = new List<RunningOrder_BS>();
       
        BusinessObjects.M_Product_BS ForVAT = new M_Product_BS();
        List<M_Product_BS> toggleList = new List<M_Product_BS>();
       public  Cheque chequeTemp = new Cheque();
        int i = 0;
        int TileCountZ;
        decimal total_text = 0;
        int quantity_text = 0;
        decimal GlobalCost=0;
        bool checkAdd = false;
        public bool  checkCheque=false;
        //bool changeQuantityType = false;

        //for autosuggest
        DataTable dataTable = new DataTable();
        DataTable filteredTable;


       // private CustomToolTip customToolTip;
        private string tooltipMessage;
        public FormBilling()
        {
            
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();

            TileCountZ = 0;

            isKeyPressProductCode = false;
            this.Resizable = false;
          //  t.Abort();

            btnPrint.Enabled = false;
            increaseWidth();
           // WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.Movable = false;
            
            panel4.Location = new Point(this.ClientSize.Width / 2 - panel4.Size.Width / 2, this.ClientSize.Height / 2 - panel4.Size.Height / 2);
            panel4.Anchor = AnchorStyles.None;

            panel1.Width = 0;

            this.TopLevel = true;
            
            this.StyleManager = FrmBillingStyle;
            DateTime todayDate = DateTime.Now;
             
            autoComplete();

           //  dtpPaymentDate.Format = DateTimePickerFormat.Custom;
         //    dtpPaymentDate.CustomFormat = "MM/dd/yyyy";
             dtpPaymentDate.Enabled = true;
            dtpPaymentDate.Value = todayDate;
            

            BusinessObjects.RunningOrder_BS so = new RunningOrder_BS();
            
            so.Delete_Company(connString2);
          
            cmbPaymentMode.SelectedIndex = 0;

            SetMyCustomFormat();
         //   notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Visible = false;

            
            //create pname autosuggest control
            createPNameSuggest();

            //this.customToolTip = new CustomToolTip();
            tooltipMessage = "";

            //for customer auto complete
            loadCustDropDown();
            SoftCustomertoList();


            //vista edit 
            txtAmount.Visible = false;
            lblQuanPrice.Visible = false;

            onFlyCustName.Visible = false;
            onFlyCustName.Enabled = false;
            
        }
        void createBitIcon()
        {
            Bitmap tBmp = new Bitmap(POS.AddToCart.Properties.Resources.POS_icon22);

            Icon tIco;

            tIco = Icon.FromHandle(tBmp.GetHicon());
            notifyIcon1.Icon = tIco;
            // notifyIcon1.Visible = true;


        }
        private void createPNameSuggest()
        {
            try
            {


                dataTable.Columns.Add("PName");

                cmbAutoSuggest.Enabled = false;
                foreach (M_Product_BS item in toggleList)
                {
                    dataTable.Rows.Add(new string[] { item.name });
                }


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 106. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        
            
        }
       
        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            dtpPaymentDate.Format = DateTimePickerFormat.Custom;
            dtpPaymentDate.CustomFormat = "MM/dd/yyyy";
        }

        void increaseWidth()
        {
            GridCart.Columns[0].Width = 150;
            GridCart.Columns[1].Width =330;
            GridCart.Columns[2].Width = 160;
            GridCart.Columns[3].Width = 120;
            GridCart.Columns[4].Width = 230;
        }

        public void GifLoading()
        {
            Application.Run(new loading());
        }

        public void GifLoadingSaveSales()
        {
            Application.Run(new LoadingSave());
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {

           
            bool result=Cartlist.Any();
            
            if (!result)
            {
                MetroMessageBox.Show(this, "Cart it empty!", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            else
            {
                int c = 0;
                foreach (Control item in flpLayout.Controls)
                {

                    if (item is MetroTile)
                    {
                        //item.Text = String.Empty;
                        c++;

                    }
            }

                if (c > 2)
                {
                    MetroMessageBox.Show(this, "Cannot create a new order. Maximum count Reached", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                BusinessObjects.RunningOrder_BS ROObj = new RunningOrder_BS();
                foreach (CartList item in Cartlist)
                {
                    ROObj.id = TileCountZ;
                    ROObj.name = item.name;
                    ROObj.productID=item.productID;
                    ROObj.quantity=item.quantity;
                    ROObj.discount=item.discount;
                    ROObj.amount=item.amount;
                    ROObj.varAmount=item.varAMount;
                    ROObj.totalAmount=item.totalAmount;
                    ROObj.price=item.price;
                    ROObj._type = item.type;
                    ROObj.Add(connString2);    
                    
                }
                


                i = i + 1;
                MetroTile _tile = new MetroTile();
                _tile.Size = new Size(40, 40);

                _tile.Tag = TileCountZ.ToString();
               // _tile.Name = TileCountZ.ToString();
                _tile.Width = 100;
                _tile.Height = 50;
                
                _tile.Text = i.ToString()+" Order";
               _tile.Name= flpLayout.Controls.Count.ToString();
                _tile.Style = (MetroFramework.MetroColorStyle)4;

                flpLayout.Controls.Add(_tile);
                TileCountZ++;
                GridCart.DataSource = null;
                GridCart.Rows.Clear();
                GridCart.Refresh();
                Cartlist.Clear();
                //toggleList.Clear();
                ForVAT = null;
                foreach (Control item in GroupBox5.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = String.Empty;


                    }
                }
                foreach (Control item in GroupBox2Payment.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = String.Empty;


                    }
                }
                foreach (Control item in Panel4Total.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = String.Empty;


                    }
                }




                _tile.Click += _tile_Click;

           
              
            }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error "+ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


       private void CreateRunningOrders()
        {
            try
            {


                bool result = Cartlist.Any();

                if (!result)
                {
                    MetroMessageBox.Show(this, "Cart it empty!", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                else
                {
                    int c = 0;
                    foreach (Control item in flpLayout.Controls)
                    {

                        if (item is MetroTile)
                        {
                            //item.Text = String.Empty;
                            c++;

                        }
                    }

                    if (c > 2)
                    {
                        MetroMessageBox.Show(this, "Cannot create a new order. Maximum count Reached", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    BusinessObjects.RunningOrder_BS ROObj = new RunningOrder_BS();
                    foreach (CartList item in Cartlist)
                    {
                        ROObj.id = TileCountZ;
                        ROObj.name = item.name;
                        ROObj.productID = item.productID;
                        ROObj.quantity = item.quantity;
                        ROObj.discount = item.discount;
                        ROObj.amount = item.amount;
                        ROObj.varAmount = item.varAMount;
                        ROObj.totalAmount = item.totalAmount;
                        ROObj.price = item.price;
                        ROObj._type = item.type;
                        ROObj.Add(connString2);

                    }



                    i = i + 1;
                    MetroTile _tile = new MetroTile();
                    _tile.Size = new Size(40, 40);

                    _tile.Tag = TileCountZ.ToString();
                    // _tile.Name = TileCountZ.ToString();
                    _tile.Width = 100;
                    _tile.Height = 50;

                    _tile.Text = i.ToString() + " Order";
                    _tile.Name = flpLayout.Controls.Count.ToString();
                    _tile.Style = (MetroFramework.MetroColorStyle)4;

                    flpLayout.Controls.Add(_tile);
                    TileCountZ++;
                    GridCart.DataSource = null;
                    GridCart.Rows.Clear();
                    GridCart.Refresh();
                    Cartlist.Clear();
                    //toggleList.Clear();
                    ForVAT = null;
                    foreach (Control item in GroupBox5.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = String.Empty;


                        }
                    }
                    foreach (Control item in GroupBox2Payment.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = String.Empty;


                        }
                    }
                    foreach (Control item in Panel4Total.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = String.Empty;


                        }
                    }




                    _tile.Click += _tile_Click;



                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


        void _tile_Click(object sender, EventArgs e)
        {
            try
            {

            int tag = Convert.ToInt32(((MetroTile)sender).Tag);

            BusinessObjects.RunningOrder_BS Robj = new RunningOrder_BS();
            Robj.id = tag;
            Cartlist.Clear();
            GridCart.DataSource = null;
            Cartlist = Robj.GetOrderAsCartList(connString2);
            if (Cartlist.Count < 0)
            {

                MetroMessageBox.Show(this, "Data Crashed !", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cartlist.Clear();
            }
            else
            {

                LoadCart();
                foreach (Control item in flpLayout.Controls)
	            {
                    int itemTag= Convert.ToInt32(item.Tag);
                    if (itemTag==tag)
                    {
                        flpLayout.Controls.Remove(item);
                    }
                    
		 
	            }
               
            }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error. " + ex.Message, "System message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

         void autoComplete()
        {

            try
            {
                txtProductCode.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtProductCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
             //   txtProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
              //  txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCustomerName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection stringColl = new AutoCompleteStringCollection();
                AutoCompleteStringCollection stringColl2 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection stringColCustName = new AutoCompleteStringCollection();


                BusinessObjects.Sales_BM s = new Sales_BM();
                List<Sales_BM> SalesLst = new List<Sales_BM>();
                SalesLst = s.getSales(connString2);
                foreach (Sales_BM item in SalesLst)
                {
                    stringColCustName.Add(item.customer_name);
                    
                }



                BusinessObjects.M_Product_BS p = new M_Product_BS();
                List<M_Product_BS> PList = new List<M_Product_BS>();
                PList = p.GetProducts(connString2);
                toggleList = PList;
                foreach (M_Product_BS item in PList)
                {
                    stringColl.Add(item.ID.ToString());
                    stringColl2.Add(item.name);
                }


               txtProductCode.AutoCompleteCustomSource = stringColl;
               txtCustomerName.AutoCompleteCustomSource = stringColCustName;
            //   txtProductName.AutoCompleteCustomSource = stringColl2;

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "! System Error . Code 104. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
       }

         DataTable temp;
         DataTable bank;
         private void loadCustDropDown()
         {
             try
             {


                 Customer prodObj = new Customer();

                 txtCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                 txtCustomerName.AutoCompleteSource = AutoCompleteSource.ListItems;

                 temp = prodObj.ForAutoSearch(connString2);

                 DataView dtview = new DataView(temp);
                 dtview.Sort = "Name DESC";
                 bank = dtview.ToTable();


                 txtCustomerName.DataSource = bank;
                 txtCustomerName.ValueMember = "Id";
                 txtCustomerName.DisplayMember = "Name";
             }
             catch (Exception ex)
             {

                 MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

             }
         }

         private void clearTextQuanPrice()
         {
             lblQuanPrice.Text = string.Empty;
             lblQuanPrice.Visible = false;  
         }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            clearTextQuanPrice();
            tglWholesale.Checked = false;
            
            try
            {
                if (isKeyPressProductCode)
                {

                    if (string.IsNullOrWhiteSpace(txtProductCode.Text))
                    {
                        foreach (Control item in GroupBox5.Controls)
                        {
                            if (item is TextBox)
                            {
                                item.Text = String.Empty;
                                lblAvaliable.Text = string.Empty;

                            }
                        }

                        return;
                    }

                    
                    int Code = Convert.ToInt32(txtProductCode.Text);
                    BusinessObjects.M_Product_BS pObj = new M_Product_BS();
                   
                    pObj.ID = Code;


                    pObj = pObj.GetOneProduct(connString2);
                    getAvaliability(Code);
                    //ForVAT = pObj;

                    txtProductName.Text = pObj.name;
                    
                   
                    if (tglWholesale.Checked == true)
                    {
                        string price = pObj.boundlePrice.ToString();
                        lblCost.Text = pObj.boundleCost.ToString();
                        txtSellingPrice.Text = price;
                        txtCustom.Text = price;
                         }
                    else
                    {
                     string price = pObj.unitPrice.ToString();
                    lblCost.Text = pObj.cost.ToString();
                    txtSellingPrice.Text = price;
                    txtCustom.Text = price;
                    }

                    isKeyPressProductCode = false;
                }
                else
                {
                    isKeyPressProductCode = false;
                    return;
                }

                


            }
            catch (Exception ex)
            {

    MetroMessageBox.Show(this, "Warning !!! " + ex.Message, "System Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error); 
            }
            
        }


        private void getAvaliability(int productID)
        {

            string query = @"select sum(quantity)as qty from _stock_product where pid=" + productID + "";
            int quantityAvalible = 0;
            Object o = stock_product.getScalar(connString2, query);
            if (o.Equals(DBNull.Value))
            {
            }
            else
            {
                quantityAvalible = (int)o;
            }
            lblAvaliable.Text = "Available Quantity = " + quantityAvalible.ToString();     
        }


        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
          //  changeQuantityType = false;

            clearTextQuanPrice();
            tglWholesale.Checked = false;
            try
            {

                if (string.IsNullOrWhiteSpace(txtProductName.Text))
                {
                    foreach (Control item in GroupBox5.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = String.Empty;
                            lblAvaliable.Text = string.Empty;
                        }
                    }

                    return;
                }

               



                string Name = txtProductName.Text;

                BusinessObjects.M_Product_BS pObj = new M_Product_BS();
                pObj.name = Name;
                pObj = pObj.Get1Product(connString2);

                ForVAT = pObj;
                txtProductCode.Text = pObj.ID.ToString();

                txtSellingPrice.Text = pObj.unitPrice.ToString();
                /*********Changes here********/

                getAvaliability(pObj.ID);

                if (tglWholesale.Checked == true)
                {
                    string price = pObj.boundlePrice.ToString();
                    txtCustom.Text = price;
                    txtSellingPrice.Text = price;
                    lblCost.Text = pObj.boundleCost.ToString();
                }
                else
                {
                    string price = pObj.unitPrice.ToString();
                    txtCustom.Text = price;
                    txtSellingPrice.Text = price;
                    lblCost.Text = pObj.cost.ToString();
                }


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error Code :243" + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnListReset_Click(object sender, EventArgs e)
        {
            
           txtProductName.Clear();
            txtProductCode.Clear();
            txtQty.Clear();
            txtTotalAmount.Clear();
            txtSellingPrice.Clear();
            txtTotalAmount.Clear();
            txtAmount.Clear();
            txtGrandTotal.Clear();
            txtTotalPayment.Clear();
            Cartlist.Clear();
            LoadCart();
            clearAddProductPanel();
            txtPaymentBalance.Clear();
           // txtCustomerName.Clear();
            if (txtCustomerName.SelectedIndex>1)
            txtCustomerName.SelectedIndex = 1;
            txtStaffName.Clear();
            txtPayment.Clear();
            lblQuanPrice.Text = "";  
          
            
           

        }

        void refresh()
        {
            txtProductName.Clear();
            txtProductCode.Clear();
            txtQty.Clear();
            txtTotalAmount.Clear();
            txtSellingPrice.Clear();
            txtTotalAmount.Clear();
            txtAmount.Clear();
            txtGrandTotal.Clear();
            txtTotalPayment.Clear();
            Cartlist.Clear();
            LoadCart();
            clearAddProductPanel();
            txtPaymentBalance.Clear();
           // txtCustomerName.Clear();
            if(txtCustomerName.SelectedIndex>1)
            txtCustomerName.SelectedIndex = 1;
            txtStaffName.Clear();
            txtPayment.Clear();
            lblQuanPrice.Text = ""; 
        }

        void cleanFOrm()
        {
            txtProductName.Clear();
            txtProductCode.Clear();
            txtQty.Clear();
            txtTotalAmount.Clear();
            txtSellingPrice.Clear();
            txtTotalAmount.Clear();
            txtAmount.Clear();
            txtGrandTotal.Clear();
            txtTotalPayment.Clear();
            Cartlist.Clear();
            LoadCart();
            clearAddProductPanel();
            txtPaymentBalance.Clear();
           // txtCustomerName.Clear();
            if(txtCustomerName.SelectedIndex > 1)
            txtCustomerName.SelectedIndex = 1;
            txtStaffName.Clear();
            txtPayment.Clear();
            lblQuanPrice.Text = ""; 
        }


        void clearAddProductPanel()
        {
            foreach (Control item in GroupBox5.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = String.Empty;
                }
                
            }
            lblQuanPrice.Text = ""; 
        }

        private void btnAdd_ClickOLDDD(object sender, EventArgs e)
        {
            

            decimal GrandTotal = 0;

            if (txtQty.Text == "" || txtQty.Text == null||txtProductName.Text ==""||txtProductName.Text == null||
                txtTotalAmount.Text == "" || txtTotalAmount.Text == null || txtProductCode.Text == "" ||  txtProductCode.Text == null||
                txtCustom.Text==null||txtCustom.Text=="" )
            {
                MessageBox.Show("Product details incomplete!");
                return;

            }
            int cartCount = 0;
            cartCount = Cartlist.Count;
           
                if (cartCount > 25) //Cart Limit
                {
                    MetroMessageBox.Show(this, "Maximum Product Limit Reached", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                /*********************** Newly Added************/
            decimal checkCustomPrice=0;
            decimal checkActualPrice=0;
            decimal checkCostPrirce=0;
                checkCustomPrice=Convert.ToDecimal(txtCustom.Text);
                checkActualPrice=Convert.ToDecimal(txtSellingPrice.Text);
                checkCostPrirce = Convert.ToDecimal(lblCost.Text);
                if (tglWholesale.Checked)
                {
                    if (checkCustomPrice > checkActualPrice)
                    {
                        MessageBox.Show("Warning!. Custom Price You Entered is Greater Than Actual Selling Price !!!");
                        
                    }

                }
                else 
                {
                    if (checkCostPrirce > checkCustomPrice || checkCustomPrice > checkActualPrice)
                    {
                        MessageBox.Show("Customer Price should not lower than Cost! ");
                        return;
                    }

                }


                /*********************** Newly Added************/


            CartList CartObj = new CartList();
            CartObj.productID = txtProductCode.Text;
            bool result = Cartlist.Any();
            int count = 0;

            bool tglStatus = false;
            if (tglWholesale.Checked)
            {
                tglStatus = true;
            }

            //Checking for similar product in filled cart
            if (result)
            {
                btnRemove.Enabled = true;
                CartList indexCart = new CartList();
                

                //looping through cart list
                foreach (CartList item in Cartlist)
                {
                    if (item.productID == CartObj.productID)
                    {
                        //the product is whole sale
                        if (item.type == "yes" && tglStatus)
                        { //Product is matching if so
                            CartObj.quantity = Convert.ToString(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(item.quantity));
                            indexCart = item;
                            count = 1;
                            Cartlist.Remove(indexCart);//removing the  item from the list
                        }
                        else if (item.type == "no" && !tglStatus)
                        {
                            CartObj.quantity = Convert.ToString(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(item.quantity));
                            indexCart = item;
                            count = 1;
                            Cartlist.Remove(indexCart);//removing the  item from the list
                        }
                    }
                }
            }

            if (count == 0)
            {
                CartObj.name = txtProductName.Text;
                CartObj.quantity = txtQty.Text;
                CartObj.totalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                CartObj.price = Convert.ToDecimal(txtCustom.Text);
                CartObj.amount = Convert.ToDecimal(txtAmount.Text);
            
            }
            else 
            {

                CartObj.name = txtProductName.Text;
                CartObj.price = Convert.ToDecimal(txtCustom.Text);
                CartObj.totalAmount = CartObj.price * Convert.ToInt32(CartObj.quantity);
                CartObj.amount = Convert.ToDecimal(txtAmount.Text);
               
                
                
            }

            if (tglWholesale.Checked)
            {
                CartObj.type = "yes";
            }
            else
            {
                CartObj.type = "no";
            }

            CartObj.name = txtProductName.Text;

            CartObj.tileID = TileCountZ;

            Cartlist.Add(CartObj);

            LoadCart();

            if (Cartlist != null)
            {
                btnPrint.Enabled = true;
                foreach (CartList item in Cartlist)
                {
                    total_text = total_text + item.totalAmount;

                    // quantity_text = quantity_text + item.quantity;
                    GrandTotal = GrandTotal + item.totalAmount;//value for the Grand total text box

                }


                txtGrandTotal.Clear();
                txtGrandTotal.Text = GrandTotal.ToString();


            }
            else if (Cartlist == null)
            {
                btnPrint.Enabled = false;

                txtTotalAmount.Clear();


            }
            clearAddProductPanel();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try 
	{	        
		
	            decimal GrandTotal = 0;

            if (txtQty.Text == "" || txtQty.Text == null || txtProductName.Text == "" || txtProductName.Text == null ||
                txtTotalAmount.Text == "" || txtTotalAmount.Text == null || txtProductCode.Text == "" || txtProductCode.Text == null ||
                txtCustom.Text == null || txtCustom.Text == "")
            {
                MessageBox.Show("Product details incomplete!");
                return;

            }
            int cartCount = 0;
            cartCount = Cartlist.Count;

            if (cartCount > 25) //Cart Limit
            {
                MetroMessageBox.Show(this, "Maximum Product Limit Reached", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            /*********************** Newly Added************/
            decimal checkCustomPrice = 0;
            decimal checkActualPrice = 0;
            decimal checkCostPrirce = 0;
            checkCustomPrice = Convert.ToDecimal(txtCustom.Text);
            checkActualPrice = Convert.ToDecimal(txtSellingPrice.Text);
            checkCostPrirce = Convert.ToDecimal(lblCost.Text);
            if (tglWholesale.Checked)
            {
                if (checkCustomPrice > checkActualPrice)
                {
                    //MessageBox.Show("Warning!. Custom Price You Entered is Greater Than Actual Selling Price !!!");

                }

            }
            //else
            //{
            //    //if (checkCostPrirce > checkCustomPrice || checkCustomPrice > checkActualPrice)
            //    //{
            //    //    MessageBox.Show("Customer Price should not lower than Cost! ");
            //    //    return;
            //    //}

            //}


            /*********************** Newly Added************/


            CartList CartObj = new CartList();
            CartObj.productID = txtProductCode.Text;
            bool result = Cartlist.Any();
            int count = 0;

            bool tglStatus = false;
            if (tglWholesale.Checked)
            {
                tglStatus = true;
            }

            //if (result)
            //{
            //    foreach (var item in Cartlist)
            //    {
            //        MessageBox.Show(item.name);
            //    }
            //}



            //Checking for similar product in filled cart
            if (result)
            {
                btnRemove.Enabled = true;
                CartList indexCart = new CartList();


                //looping through cart list
                foreach (CartList item in Cartlist)
                {

                    if (item.productID == CartObj.productID)
                    {
                        //CartObj.quantity = Convert.ToString(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(item.quantity));
                        //indexCart = item;
                        //count = 1;
                        //Cartlist.Remove(indexCart);

                        //the product is whole sale
                        if (item.type == "yes" && tglStatus)
                        { //Product is matching if so
                            CartObj.quantity = Convert.ToString(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(item.quantity));
                            indexCart = item;
                            count = 1;
                            //Cartlist.Remove(indexCart);//removing the  item from the list
                        }
                        else if (item.type == "no" && !tglStatus)
                        {
                            CartObj.quantity = Convert.ToString(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(item.quantity));
                            indexCart = item;
                            count = 1;
                            //Cartlist.Remove(indexCart);//removing the  item from the list
                        }
                    }
                }

                if (count > 0)
                {
                    Cartlist.Remove(indexCart);

                }
            }

            if (count == 0)
            {
                CartObj.name = txtProductName.Text;
                CartObj.quantity = txtQty.Text;
                CartObj.totalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                CartObj.price = Convert.ToDecimal(txtCustom.Text);
                CartObj.amount = Convert.ToDecimal(txtAmount.Text);

            }
            else
            {

                CartObj.name = txtProductName.Text;
                CartObj.price = Convert.ToDecimal(txtCustom.Text);
                CartObj.totalAmount = CartObj.price * Convert.ToInt32(CartObj.quantity);
                CartObj.amount = Convert.ToDecimal(txtAmount.Text);



            }

            if (tglWholesale.Checked)
            {
                CartObj.type = "yes";
            }
            else
            {
                CartObj.type = "no";
            }

            CartObj.name = txtProductName.Text;
            CartObj.tileID = TileCountZ;

            

            /*This code is to check the quantiyty///////////////////////////////////////*/

            string query = @"select sum(quantity)as qty from _stock_product where pid=" + CartObj.productID + "";

            int quantityAvalible = 0;
            Object o = stock_product.getScalar(connString2, query);
            if (o.Equals(DBNull.Value))
            {
            }
            else
            {
                quantityAvalible = (int)o;
            }

            // int quantityAvalible = (int)stock_product.getScalar(connString2, query);
            int requiredQuantity = Convert.ToInt32(CartObj.quantity);
            //MessageBox.Show(quantityAvalible.ToString());
            if (requiredQuantity > quantityAvalible)
            {
                MetroMessageBox.Show(this, "Such amount of quantity is not available in stock", "! System Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error); ;

            }
            else
            {

                /*THIS IS FOR FIFO LIFO*/
                //accordingly get the cound of different stock and the price.

                int requiredQuan = Convert.ToInt32(CartObj.quantity);
                List<CartStockRoutingList> stList = getStockListOflist(Convert.ToInt32(txtProductCode.Text), requiredQuan);
                    if (stList == null)
                    {
                        MessageBox.Show("Somethign Went Really Bad. Transaction Terminated");
                    }
                    tooltipMessage = string.Empty;

                    List<CartSaleProductList> saleItemList = new List<CartSaleProductList>();
                
                    int requiredqty = Convert.ToInt32(CartObj.quantity);
                    foreach (var item in stList)
                    {
                        CartSaleProductList cartSaleObj = new CartSaleProductList();
                        cartSaleObj.stock_id = item.sid;
                        cartSaleObj.product_id = item.pid;
                        cartSaleObj.cost = item.price;

                        if (requiredqty - item.qty < 0)
                        {
                            cartSaleObj.quantity = requiredqty;
                            //tooltipMessage += "Qty = " + requiredqty.ToString() + "        " + "RS = " + item.sid.ToString();
                        }
                        else if (requiredqty - item.qty == 0)
                        {
                            cartSaleObj.quantity = item.qty;
                            //tooltipMessage += "Qty = " + item.qty.ToString() + "        " + "RS = " + item.sid.ToString();
                        }
                        else
                        {
                            cartSaleObj.quantity = item.qty;
                            //tooltipMessage += "Qty = " + item.qty.ToString() + "        " + "RS = " + item.sid.ToString() + Environment.NewLine;
                            requiredqty = requiredqty - item.qty;
                        }

                        saleItemList.Add(cartSaleObj);

                    }

                /*FIFO LIFO END HERE*/
                CartObj.StockOrderList = saleItemList;
                Cartlist.Add(CartObj);
              //  CartObj.quanText = lblQuanPrice.Text;
                //i have added the cartAdd function inside this else
            }

            /* This coe end here*/

            LoadCart();

            if (Cartlist != null)
            {
                btnPrint.Enabled = true;
                foreach (CartList item in Cartlist)
                {
                    total_text = total_text + item.totalAmount;

                    // quantity_text = quantity_text + item.quantity;
                    GrandTotal = GrandTotal + item.totalAmount;//value for the Grand total text box

                }

                txtGrandTotal.Clear();
                txtGrandTotal.Text = GrandTotal.ToString();

            }
            else if (Cartlist == null)
            {
                btnPrint.Enabled = false;

                txtTotalAmount.Clear();
                lblAvaliable.Text = "";

            }
            clearAddProductPanel();
            txtProductCode.Focus();
            lblAvaliable.Text = "";
            clearTextQuanPrice();

            }catch (Exception ex)
            {
MetroMessageBox.Show(this, ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void AddTOCartFunction()
        {
            try
            {

              decimal GrandTotal = 0;

            if (txtQty.Text == "" || txtQty.Text == null || txtProductName.Text == "" || txtProductName.Text == null ||
                txtTotalAmount.Text == "" || txtTotalAmount.Text == null || txtProductCode.Text == "" || txtProductCode.Text == null ||
                txtCustom.Text == null || txtCustom.Text == "")
            {
                MessageBox.Show("Product details incomplete!");
                return;

            }
            int cartCount = 0;
            cartCount = Cartlist.Count;

            if (cartCount > 25) //Cart Limit
            {
                MetroMessageBox.Show(this, "Maximum Product Limit Reached", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            /*********************** Newly Added************/
            decimal checkCustomPrice = 0;
            decimal checkActualPrice = 0;
            decimal checkCostPrirce = 0;
            checkCustomPrice = Convert.ToDecimal(txtCustom.Text);
            checkActualPrice = Convert.ToDecimal(txtSellingPrice.Text);
            checkCostPrirce = Convert.ToDecimal(lblCost.Text);
            if (tglWholesale.Checked)
            {
                if (checkCustomPrice > checkActualPrice)
                {
                    //MessageBox.Show("Warning!. Custom Price You Entered is Greater Than Actual Selling Price !!!");

                }

            }
            //else
            //{
            //    //if (checkCostPrirce > checkCustomPrice || checkCustomPrice > checkActualPrice)
            //    //{
            //    //    MessageBox.Show("Customer Price should not lower than Cost! ");
            //    //    return;
            //    //}

            //}


            /*********************** Newly Added************/


            CartList CartObj = new CartList();
            CartObj.productID = txtProductCode.Text;
            bool result = Cartlist.Any();
            int count = 0;

            bool tglStatus = false;
            if (tglWholesale.Checked)
            {
                tglStatus = true;
            }

            //if (result)
            //{
            //    foreach (var item in Cartlist)
            //    {
            //        MessageBox.Show(item.name);
            //    }
            //}



            //Checking for similar product in filled cart
            if (result)
            {
                btnRemove.Enabled = true;
                CartList indexCart = new CartList();


                //looping through cart list
                foreach (CartList item in Cartlist)
                {

                    if (item.productID == CartObj.productID)
                    {
                        //CartObj.quantity = Convert.ToString(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(item.quantity));
                        //indexCart = item;
                        //count = 1;
                        //Cartlist.Remove(indexCart);

                        //the product is whole sale
                        if (item.type == "yes" && tglStatus)
                        { //Product is matching if so
                            CartObj.quantity = Convert.ToString(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(item.quantity));
                            indexCart = item;
                            count = 1;
                            //Cartlist.Remove(indexCart);//removing the  item from the list
                        }
                        else if (item.type == "no" && !tglStatus)
                        {
                            CartObj.quantity = Convert.ToString(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(item.quantity));
                            indexCart = item;
                            count = 1;
                            //Cartlist.Remove(indexCart);//removing the  item from the list
                        }
                    }
                }

                if (count > 0)
                {
                    Cartlist.Remove(indexCart);

                }
            }

            if (count == 0)
            {
                CartObj.name = txtProductName.Text;
                CartObj.quantity = txtQty.Text;
                CartObj.totalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                CartObj.price = Convert.ToDecimal(txtCustom.Text);
                CartObj.amount = Convert.ToDecimal(txtAmount.Text);

            }
            else
            {

                CartObj.name = txtProductName.Text;
                CartObj.price = Convert.ToDecimal(txtCustom.Text);
                CartObj.totalAmount = CartObj.price * Convert.ToInt32(CartObj.quantity);
                CartObj.amount = Convert.ToDecimal(txtAmount.Text);



            }

            if (tglWholesale.Checked)
            {
                CartObj.type = "yes";
            }
            else
            {
                CartObj.type = "no";
            }

            CartObj.name = txtProductName.Text;
            CartObj.tileID = TileCountZ;



            /*This code is to check the quantiyty///////////////////////////////////////*/

            string query = @"select sum(quantity)as qty from _stock_product where pid=" + CartObj.productID + "";

            int quantityAvalible = 0;
            Object o = stock_product.getScalar(connString2, query);
            if (o.Equals(DBNull.Value))
            {
            }
            else
            {
                quantityAvalible = (int)o;
            }

            // int quantityAvalible = (int)stock_product.getScalar(connString2, query);
            int requiredQuantity = Convert.ToInt32(CartObj.quantity);
            //MessageBox.Show(quantityAvalible.ToString());
            if (requiredQuantity > quantityAvalible)
            {
                MetroMessageBox.Show(this, "Such amount of quantity is not available in stock", "! System Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error); ;

            }
            else
            {

                /*THIS IS FOR FIFO LIFO*/
                //accordingly get the cound of different stock and the price.

                int requiredQuan = Convert.ToInt32(CartObj.quantity);
                List<CartStockRoutingList> stList = getStockListOflist(Convert.ToInt32(txtProductCode.Text), requiredQuan);
                if (stList == null)
                {
                    MessageBox.Show("Somethign Went Really Bad. Transaction Terminated");
                }
                tooltipMessage = string.Empty;

                List<CartSaleProductList> saleItemList = new List<CartSaleProductList>();

                int requiredqty = Convert.ToInt32(CartObj.quantity);
                foreach (var item in stList)
                {
                    CartSaleProductList cartSaleObj = new CartSaleProductList();
                    cartSaleObj.stock_id = item.sid;
                    cartSaleObj.product_id = item.pid;
                    cartSaleObj.cost = item.price;

                    if (requiredqty - item.qty < 0)
                    {
                        cartSaleObj.quantity = requiredqty;
                        //tooltipMessage += "Qty = " + requiredqty.ToString() + "        " + "RS = " + item.sid.ToString();
                    }
                    else if (requiredqty - item.qty == 0)
                    {
                        cartSaleObj.quantity = item.qty;
                        //tooltipMessage += "Qty = " + item.qty.ToString() + "        " + "RS = " + item.sid.ToString();
                    }
                    else
                    {
                        cartSaleObj.quantity = item.qty;
                        //tooltipMessage += "Qty = " + item.qty.ToString() + "        " + "RS = " + item.sid.ToString() + Environment.NewLine;
                        requiredqty = requiredqty - item.qty;
                    }

                    saleItemList.Add(cartSaleObj);

                }

                /*FIFO LIFO END HERE*/
                CartObj.StockOrderList = saleItemList;
                Cartlist.Add(CartObj);
                //  CartObj.quanText = lblQuanPrice.Text;
                //i have added the cartAdd function inside this else
            }

            /* This coe end here*/

            LoadCart();

            if (Cartlist != null)
            {
                btnPrint.Enabled = true;
                foreach (CartList item in Cartlist)
                {
                    total_text = total_text + item.totalAmount;

                    // quantity_text = quantity_text + item.quantity;
                    GrandTotal = GrandTotal + item.totalAmount;//value for the Grand total text box

                }

                txtGrandTotal.Clear();
                txtGrandTotal.Text = GrandTotal.ToString();

            }
            else if (Cartlist == null)
            {
                btnPrint.Enabled = false;

                txtTotalAmount.Clear();
                lblAvaliable.Text = "";

            }
            clearAddProductPanel();
            txtProductCode.Focus();
            lblAvaliable.Text = "";
            clearTextQuanPrice();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        private void AddTOCartFunctionOld()
        {



            decimal GrandTotal = 0;

            if (txtQty.Text == "" || txtQty.Text == null || txtProductName.Text == "" || txtProductName.Text == null ||
                txtTotalAmount.Text == "" || txtTotalAmount.Text == null || txtProductCode.Text == "" || txtProductCode.Text == null ||
                txtCustom.Text == null || txtCustom.Text == "")
            {
                MessageBox.Show("Product details incomplete!");
                return;

            }
            int cartCount = 0;
            cartCount = Cartlist.Count;

            if (cartCount > 25) //Cart Limit
            {
                MetroMessageBox.Show(this, "Maximum Product Limit Reached", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            /*********************** Newly Added************/
            decimal checkCustomPrice = 0;
            decimal checkActualPrice = 0;
            decimal checkCostPrirce = 0;
            checkCustomPrice = Convert.ToDecimal(txtCustom.Text);
            checkActualPrice = Convert.ToDecimal(txtSellingPrice.Text);
            checkCostPrirce = Convert.ToDecimal(lblCost.Text);
            if (tglWholesale.Checked)
            {
                if (checkCustomPrice > checkActualPrice)
                {
                    //MessageBox.Show("Warning!. Custom Price You Entered is Greater Than Actual Selling Price !!!");

                }

            }
            //else
            //{
            //    //if (checkCostPrirce > checkCustomPrice || checkCustomPrice > checkActualPrice)
            //    //{
            //    //    MessageBox.Show("Customer Price should not lower than Cost! ");
            //    //    return;
            //    //}

            //}


            /*********************** Newly Added************/


            CartList CartObj = new CartList();
            CartObj.productID = txtProductCode.Text;
            bool result = Cartlist.Any();
            int count = 0;

            bool tglStatus = false;
            if (tglWholesale.Checked)
            {
                tglStatus = true;
            }

            //if (result)
            //{
            //    foreach (var item in Cartlist)
            //    {
            //        MessageBox.Show(item.name);
            //    }
            //}



            //Checking for similar product in filled cart
            if (result)
            {
                btnRemove.Enabled = true;
                CartList indexCart = new CartList();


                //looping through cart list
                foreach (CartList item in Cartlist)
                {

                    if (item.productID == CartObj.productID)
                    {
                        //CartObj.quantity = Convert.ToString(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(item.quantity));
                        //indexCart = item;
                        //count = 1;
                        //Cartlist.Remove(indexCart);

                        //the product is whole sale
                        if (item.type == "yes" && tglStatus)
                        { //Product is matching if so
                            CartObj.quantity = Convert.ToString(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(item.quantity));
                            indexCart = item;
                            count = 1;
                            //Cartlist.Remove(indexCart);//removing the  item from the list
                        }
                        else if (item.type == "no" && !tglStatus)
                        {
                            CartObj.quantity = Convert.ToString(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(item.quantity));
                            indexCart = item;
                            count = 1;
                            //Cartlist.Remove(indexCart);//removing the  item from the list
                        }
                    }
                }

                if (count > 0)
                {
                    Cartlist.Remove(indexCart);

                }
            }

            if (count == 0)
            {
                CartObj.name = txtProductName.Text;
                CartObj.quantity = txtQty.Text;
                CartObj.totalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                CartObj.price = Convert.ToDecimal(txtCustom.Text);
                CartObj.amount = Convert.ToDecimal(txtAmount.Text);

            }
            else
            {

                CartObj.name = txtProductName.Text;
                CartObj.price = Convert.ToDecimal(txtCustom.Text);
                CartObj.totalAmount = CartObj.price * Convert.ToInt32(CartObj.quantity);
                CartObj.amount = Convert.ToDecimal(txtAmount.Text);



            }

            if (tglWholesale.Checked)
            {
                CartObj.type = "yes";
            }
            else
            {
                CartObj.type = "no";
            }

            CartObj.name = txtProductName.Text;

            CartObj.tileID = TileCountZ;







            /*This code is to check the quantiyty///////////////////////////////////////*/

            string query = @"select sum(quantity)as qty from _stock_product where pid=" + CartObj.productID + "";

            int quantityAvalible = 0;
            Object o = stock_product.getScalar(connString2, query);
            if (o.Equals(DBNull.Value))
            {
            }
            else
            {
                quantityAvalible = (int)o;
            }

            // int quantityAvalible = (int)stock_product.getScalar(connString2, query);
            int requiredQuantity = Convert.ToInt32(CartObj.quantity);
            //MessageBox.Show(quantityAvalible.ToString());
            if (requiredQuantity > quantityAvalible)
            {
                MetroMessageBox.Show(this, "Such amount of quantity is not available in stock", "! System Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error); ;

            }
            else
            {

                Cartlist.Add(CartObj);
                //i have added the cartAdd function inside this else
            }



            /* This coe end here*/


            LoadCart();

            if (Cartlist != null)
            {
                btnPrint.Enabled = true;
                foreach (CartList item in Cartlist)
                {
                    total_text = total_text + item.totalAmount;

                    // quantity_text = quantity_text + item.quantity;
                    GrandTotal = GrandTotal + item.totalAmount;//value for the Grand total text box

                }


                txtGrandTotal.Clear();
                txtGrandTotal.Text = GrandTotal.ToString();


            }
            else if (Cartlist == null)
            {
                btnPrint.Enabled = false;

                txtTotalAmount.Clear();


            }
            clearAddProductPanel();
            txtProductCode.Focus();
        }


        private void LoadCart()
        {
            
            //decimal weight=0;
            decimal totalPP = 0;
            int i = 0;
            GridCart.Rows.Clear();
            foreach (CartList  item in Cartlist)
            {
                int cc = Convert.ToInt32(item.productID);
                GridCart.Rows.Add();
                GridCart.Rows[i].Cells[0].Value = item.productID;
                GridCart.Rows[i].Cells[1].Value = item.name;
                GridCart.Rows[i].Cells[2].Value = item.price.ToString();

                if (item.type == "yes")
                { GridCart.Rows[i].Cells[3].Value = item.quantity.ToString() + " (P)";
              
                }
                else
                { GridCart.Rows[i].Cells[3].Value = item.quantity.ToString();
               
                              
                }

               
                GridCart.Rows[i].Cells[4].Value = item.totalAmount.ToString();


                totalPP = totalPP + item.totalAmount;
                  
               
                i++;
            }
                     
            txtGrandTotal.Text = totalPP.ToString();
           
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {


            if (txtQty.Text.Length == 0)
            {
                txtAmount.Clear();
                txtTotalAmount.Clear();
                
            }
            else if (txtProductName.Text == "" || txtProductName.Text == null || txtProductCode.Text == "" || txtProductCode.Text == null || txtSellingPrice.Text == null || txtSellingPrice.Text == "")
            {
                MessageBox.Show("Product details not found");
                txtAmount.Clear();
                txtQty.Clear();
                return;
            }
            else
            {
                decimal customPrice = Convert.ToDecimal(txtCustom.Text);
                decimal actualPrice = Convert.ToDecimal(txtSellingPrice.Text);
                decimal Amount = 0;
                
                if (customPrice != actualPrice)
                    {
                        Amount = Convert.ToDecimal(txtCustom.Text) * Convert.ToInt32(txtQty.Text);
                    }
                    else
                    {

                        Amount = Convert.ToDecimal(txtSellingPrice.Text) * Convert.ToInt32(txtQty.Text);
                    }
                    /************************new code here*****************/

                    txtAmount.Text = Amount.ToString();

                    txtTotalAmount.Text = Amount.ToString();

                }
            
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "! System Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error); ;
            }

        }
      
        private void PrintReceipt()
        {
            
            try{
                if (!string.IsNullOrWhiteSpace(txtGrandTotal.Text))
                {
                    decimal t = 0;

                    t = Convert.ToDecimal(txtGrandTotal.Text);
                    RunningOrder_BS ro = new RunningOrder_BS();
                    ro.ToA = t;
                    ro.AddTotal(connString2);

                }
                    
            BusinessObjects.Print print = new Print();

            print = print.GetP(connString2);
            PrintDialog printDialog = new PrintDialog();
              PrintDocument printDocument = new PrintDocument();
            printDialog.Document = printDocument;
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printDocument.PrinterSettings.PrinterName = print.PrinterName;
            printDocument.DefaultPageSettings.PaperSize = printDocument.PrinterSettings.PaperSizes[print.PaperSize];
            printDocument.DefaultPageSettings.PaperSource = printDocument.PrinterSettings.PaperSources[print.Source];
            printDocument.DefaultPageSettings.PrinterResolution = printDocument.PrinterSettings.PrinterResolutions[print.Resolution];

            if (!printDocument.PrinterSettings.IsValid)
            {

                MetroMessageBox.Show(this, "Printer settings not valid. Process terminated", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            printDocument.Print();
            GridCart.DataSource = null;
            GridCart.Rows.Clear();
            GridCart.Refresh();
            Cartlist.Clear();
           // toggleList.Clear();
            ForVAT = null;
            foreach (Control item in GroupBox5.Controls)
            {
                if (item is TextBox)
                {
                    item.Text=String.Empty;


                }
            }
            foreach (Control item in GroupBox2Payment.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = String.Empty;


                }
            }


            MetroMessageBox.Show(this, "Transaction Successful", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
           // txtTotalWeight.Text = String.Empty;
            txtTotalAmount.Text = String.Empty;
            txtGrandTotal.Clear();
            txtTotalPayment.Text = String.Empty;
            txtPaymentBalance.Text = String.Empty;
            
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

           
        }

        public  int GetDecimalPlaces(decimal n)
        {
            n = Math.Abs(n); //make sure it is positive.
            n -= Convert.ToInt64(n);     //remove the integer part of the number.
            var decimalPlaces = 0;
            while (n > 0)
            {
                decimalPlaces++;
                n *= 10;
                n -= (int)n;
            }
            return decimalPlaces;
        }

        public int getDecimalPlacesTwo(decimal d)
        {

            decimal integral = Math.Truncate(d);
            decimal frac = d - integral;

            return frac.ToString().Length;
        }
        
        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                StringFormat stringFormat = new StringFormat();

                stringFormat.LineAlignment = StringAlignment.Near;
                
                Graphics graphics = e.Graphics;
                
                Font font = new Font("Courier New", 10);
                float FontHeight = font.GetHeight();
                int startX = 10;
                int startY = 200;
                int count = 0;
                int offset = 100;
                int middle = (e.PageSettings.PaperSize.Width / 2);

                string a ="Time: "+ DateTime.Now.ToString("h:mm:ss tt");
                string dd = dtpPaymentDate.Text;

                graphics.DrawString("DATE :" + dd.PadRight(40) + a, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + 10 + (int)FontHeight + 5);
                graphics.DrawString("CUSTOMER :" + txtCustomerName.Text, new Font("Courier New", 11), new SolidBrush(Color.Black), startX, startY + 20 + (int)FontHeight + 5 + 15);
                
                offset = offset + 10;

                graphics.DrawString("Product".PadRight(24) + "Qty".PadRight(20) + "Amount".PadRight(20) + "Total",  
                    new Font("Courier New",12),new SolidBrush(Color.Black), startX, startY + offset+10);

                graphics.DrawString("__________________________________________________________________________________________________________",
                        new Font("Courier New", 9), new SolidBrush(Color.Black), startX, startY + offset + 20);
                offset = offset + (int)FontHeight + 10;

                foreach (CartList cart in Cartlist)
                {
                    string ProductName = cart.name.PadRight(20);
                    string quantity = "";

                    

                    quantity = cart.quantity.ToString() + cart.measuringUnit;

                    string Price = "";
                    if (2 == getDecimalPlacesTwo(cart.totalAmount))
                    {
                        
                          Price = String.Format("{0,15}.00", cart.totalAmount.ToString());
                    }
                    else if (3 == getDecimalPlacesTwo(cart.totalAmount))
                    {
                        Price = String.Format("{0,17}0", cart.totalAmount.ToString());
                    }
                    else if (4 == getDecimalPlacesTwo(cart.totalAmount))
                    {
                         Price = String.Format("{0,18}", cart.totalAmount.ToString());
                    }
                    else if (4 < getDecimalPlacesTwo(cart.totalAmount))
                    {
                        cart.totalAmount = Math.Round(cart.totalAmount, 2);
                        Price = String.Format("{0,18}", cart.totalAmount.ToString());
                    }
                    else {
                        Price = String.Format("{0,15}.00", cart.totalAmount.ToString());
                      
                    
                    }



                    string tPrice ="";
                    if (2 == getDecimalPlacesTwo(cart.price))
                    {
                        
                        tPrice = String.Format("{0,17}.00", cart.price.ToString());;
                    }
                    else if (3 == getDecimalPlacesTwo(cart.price))
                    {
                         tPrice = String.Format("{0,19}0", cart.price.ToString());
                    }
                    else if (4 == getDecimalPlacesTwo(cart.price))
                    {
                        tPrice = String.Format("{0,19}",cart.price.ToString());
                    }
                    else if (4 < getDecimalPlacesTwo(cart.price))
                    {
                         tPrice = Math.Round(cart.price, 2).ToString();
                        tPrice = String.Format("{0,19}", tPrice);
                    }
                    else
                    {
                        tPrice = String.Format("{0,17}.00", cart.price.ToString());
                        

                    }
                    

                    //tPrice= tPrice;
                    string line1 = ProductName + quantity;
                    string line2 = tPrice + Price;
                    
                    graphics.DrawString(line1, new Font("Courier New", 15), new SolidBrush(Color.Black), startX, startY + offset+10);
                    graphics.DrawString(line2, new Font("Courier New", 15), new SolidBrush(Color.Black), startX + 270, startY + offset+10, stringFormat);

                    offset = offset + (int)FontHeight + 5;
                    //Price2 += (int)cart.totalAmount;
                    count++;
                }
                offset = offset + 20;

                graphics.DrawString("Total Amount(Rs) ", new Font("Courier New", 15), new SolidBrush(Color.Black), startX, 800);
                graphics.DrawString(":", font, new SolidBrush(Color.Black), startX + 400, startY + offset);
                decimal x = Math.Round(GlobalCost, 2);
                decimal GT = Convert.ToDecimal(txtGrandTotal.Text);

                string GRANDtOTAL= "";
                if (2 == getDecimalPlacesTwo(GT))
                {
                    GRANDtOTAL = String.Format("{0,4}.00", GT.ToString()); 
                }
                else if (3 == getDecimalPlacesTwo(GT))
                {
                    GRANDtOTAL = String.Format("{0,6}0", GT.ToString());
                }
                else if (4 == getDecimalPlacesTwo(GT))
                {
                    GRANDtOTAL =String.Format("{0,6}", GT.ToString());
                }
                else if (4 < getDecimalPlacesTwo(GT))
                {
                    GRANDtOTAL = Math.Round(GT, 2).ToString();
                    GRANDtOTAL = String.Format("{0,6}", GRANDtOTAL);
                }
                else
                {
                    GRANDtOTAL = String.Format("{0,4}.00", GT.ToString());
                }



                graphics.DrawString( String.Format ( "{0,15}",GRANDtOTAL.ToString()), new Font("Courier New", 10), new SolidBrush(Color.Black), startX + 400, startY + offset);

                offset = offset + 20;
                //graphics.DrawString("Labour Cost(Rs) ", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
                //graphics.DrawString(":", font, new SolidBrush(Color.Black), startX + 200, startY + offset);



                string LCost = "";
                if (2 == getDecimalPlacesTwo(x))
                {
                    LCost = String.Format("{0,4}.00", x.ToString());
                }
                else if (3 == getDecimalPlacesTwo(GT))
                {
                    LCost = String.Format("{0,6}0", x.ToString());
                }
                else if (4 == getDecimalPlacesTwo(GT))
                {
                    LCost = String.Format("{0,6}", x.ToString());
                }
                else if (4 < getDecimalPlacesTwo(GT))
                {
                    LCost = Math.Round(x, 2).ToString();
                    LCost = String.Format("{0,6}",LCost);
                }
                else
                {
                    LCost = String.Format("{0,4}.00", x.ToString());
                }


                //graphics.DrawString(String.Format("{0,15}", LCost.ToString()), new Font("Courier New", 10), new SolidBrush(Color.Black), startX + 285, startY + offset);

                //offset = offset + 20;


                graphics.DrawString("Total Payment(Rs) ", new Font("Courier New", 15), new SolidBrush(Color.Black), startX, startY + offset);
                graphics.DrawString(":", font, new SolidBrush(Color.Black), startX + 200, startY + offset);
                
                decimal pay = Convert.ToDecimal(txtTotalPayment.Text);
                string editedpay = "";
                if (2 == getDecimalPlacesTwo(pay))
                {
                   
                    editedpay = String.Format("{0,4}.00", pay.ToString());
                }
                else if (3 == getDecimalPlacesTwo(pay))
                {
                   
                    editedpay = String.Format("{0,6}0", pay.ToString());
                }
                else if (4 == getDecimalPlacesTwo(pay))
                {
                   
                    editedpay = String.Format("{0,6}", pay.ToString());
                }
                else if (4 < getDecimalPlacesTwo(pay))
                {
                   
                    editedpay = Math.Round(pay, 2).ToString();
                    editedpay = String.Format("{0,6}", editedpay);
                }
                else
                {
                   
                    editedpay = String.Format("{0,4}.00", pay.ToString());

                }


                graphics.DrawString(String.Format("{0,15}", editedpay.ToString()), new Font("Courier New", 15), new SolidBrush(Color.Black), startX + 285, startY + offset);

                offset = offset + 10;
                graphics.DrawString("---------".PadRight(20), new Font("Courier New", 15), new SolidBrush(Color.Black), startX + 340, startY + offset);



                offset = offset + 10;
                GT = GT + x;

                decimal balance = pay - GT;
                if (balance > 0)
                {
                    string editedBalance = "";
                    if (2 == getDecimalPlacesTwo(balance))
                    {
                        
                        editedBalance = String.Format("{0,4}.00", balance.ToString());
                    }
                    else if (3 == getDecimalPlacesTwo(balance))
                    {
                        
                        editedBalance = String.Format("{0,6}0", balance.ToString());
                    }
                    else if (4 == getDecimalPlacesTwo(balance))
                    {
                        
                        editedBalance = String.Format("{0,6}", balance.ToString());
                    }
                    else if (4 < getDecimalPlacesTwo(balance))
                    {
                        
                        editedBalance = Math.Round(balance, 2).ToString();
                        editedBalance = String.Format("{0,6}", editedBalance);
                    }
                    else
                    {
                        
                        editedBalance = String.Format("{0,4}.00", balance.ToString());
                        
                    }


                    graphics.DrawString("Balance (Rs) ", new Font("Courier New", 15), new SolidBrush(Color.Black), startX, startY + offset);
                    graphics.DrawString(":", font, new SolidBrush(Color.Black), startX + 200, startY + offset);

                    editedBalance = Convert.ToString(Math.Round(Convert.ToDecimal(editedBalance),2));
                    
                    graphics.DrawString(String.Format("{0,15}", editedBalance.ToString()), new Font("Courier New", 15), new SolidBrush(Color.Black), startX + 285, startY + offset);
                }
                else
                {
                    balance = Math.Abs(balance);
                    string editedBalance = "";
                    if (2 == getDecimalPlacesTwo(balance))
                    {

                        editedBalance = String.Format("{0,4}.00", balance.ToString());
                    }
                    else if (3 == getDecimalPlacesTwo(balance))
                    {
                        editedBalance = String.Format("{0,6}0", balance.ToString());
                    }
                    else if (4 == getDecimalPlacesTwo(balance))
                    {
                        editedBalance = String.Format("{0,6}", balance.ToString());
                    }
                    else if (4 < getDecimalPlacesTwo(balance))
                    {
                        editedBalance = Math.Round(balance, 2).ToString();
                        editedBalance = String.Format("{0,6}", balance);
                    }
                    else
                    {
                        editedBalance = String.Format("{0,4}.00", balance.ToString());

                    }
                    graphics.DrawString("Credit (Rs) ", new Font("Courier New", 15), new SolidBrush(Color.Black), startX, startY + offset);
                    graphics.DrawString(":", font, new SolidBrush(Color.Black), startX + 200, startY + offset);

                    editedBalance = Convert.ToString(Math.Round(Convert.ToDecimal(editedBalance), 2));
                    
                    
                    graphics.DrawString(String.Format("{0,15}", editedBalance.ToString()), new Font("Courier New", 15), new SolidBrush(Color.Black), startX + 285, startY + offset);
                }
                offset = offset + 10;
                graphics.DrawString("---------".PadRight(20), new Font("Courier New", 15), new SolidBrush(Color.Black), startX + 340, startY + offset);


                //offset = offset + 30;
                //graphics.DrawString("Total Weight(Kg) ", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
                //graphics.DrawString(":", font, new SolidBrush(Color.Black), startX + 200, startY + offset);
                //decimal tw = 0; // Convert.ToDecimal(txtTotalWeight.Text);
                //tw = Math.Round(tw, 2);
                //graphics.DrawString(String.Format("{0,17}", tw.ToString()), new Font("Courier New", 10), new SolidBrush(Color.Black), startX + 250, startY + offset);

                //offset = offset + 20;
                //graphics.DrawString("Total No. Product ", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
                //graphics.DrawString(":", font, new SolidBrush(Color.Black), startX + 200, startY + offset);
                //graphics.DrawString(String.Format("{0,17}", count.ToString()), new Font("Courier New", 10), new SolidBrush(Color.Black), startX + 250, startY + offset);



                offset = offset + 40;
                graphics.DrawString("Thank You! Come Again.".PadRight(5), new Font("Courier New", 14), new SolidBrush(Color.Black), startX + 75, startY + offset);

                offset = offset + 20;
                graphics.DrawString("FutureSoft Solution".PadRight(5), new Font("Courier New", 11), new SolidBrush(Color.Black), startX + 110, startY + offset);

                offset = offset + 20;
                graphics.DrawString("Tel: 0750290689 ".PadRight(5), new Font("Courier New", 11), new SolidBrush(Color.Black), startX + 120, startY + offset);

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        void PrintingProcess()
        {

            try
            {
               
                //bool result = Cartlist.Any();
                //if (result)
                //{
                //    MetroMessageBox.Show(this, "Cart is empty", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    checkAdd = false;
                //    return;
                //}
                //if (checkAdd)
                //{


                string custName = "guest";
                int customerID = 0;
                string adres = "Not Applicable";

                //newly added for customer update*****************************************
                if (chkCNameAsPName.Checked)
                {
                    custName = string.IsNullOrEmpty(onFlyCustName.Text) ? "Guest" : onFlyCustName.Text;
                }
                else
                {
                    if (txtCustomerName.SelectedIndex == -1)
                    {
                        //  t.Abort();
                        MessageBox.Show("Please Select an Customer or Add a New Customer");
                        return;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtCustomerName.Text))
                        {
                            // t.Abort();
                            MessageBox.Show("Customer Name Not Valid");
                            return;
                        }
                        else
                        {
                            custName = txtCustomerName.Text;
                            customerID = Convert.ToInt32(txtCustomerName.SelectedValue.ToString());
                            if (!string.IsNullOrEmpty(txtStaffName.Text))
                            adres = txtStaffName.Text;
                        }
                    }
                }
                //decimal printTotal = 0;
                //decimal printPayment = 0;

                BillPrint bl = new BillPrint(sid, custName, adres);
                bl.Show();
                // PrintReceipt();
                //PrintReceipt();
                //    checkAdd = false;
                //}
                //else
                //{
                //    MetroMessageBox.Show(this, "Please enter the payment details before print", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope txScope = new TransactionScope())
                {

                    bool result = Cartlist.Any();
                    if (!result)
                    {
                        MetroMessageBox.Show(this, "Cart is empty", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkAdd = false;
                        return;
                    }
                    if (checkAdd)
                    {
                        string custName = "guest";
                        if (string.IsNullOrEmpty(txtCustomerName.Text))
                        {


                        }
                        else
                        {
                            custName = txtCustomerName.Text;
                        }


                        /*insert into sales tables*/
                        Sales_BM sale = new Sales_BM();
                        sale.customer_name = custName;
                        //  sale.date_time = Convert.ToDateTime(dtpPaymentDate.Text);

                        sale.date_time = DateTime.Now;
                        sale.total = Convert.ToDecimal(txtGrandTotal.Text);
                        sale.paid = Convert.ToDecimal(txtTotalPayment.Text);
                        sale.credit = sale.total - sale.paid;


                        //if (sale.credit > 0)
                        //{
                        //    //sale.credit = System.Math.Abs(sale.credit);
                        //    sale.credit = sale.credit;
                        //}


                        printTotal = sale.total;
                        printPayment = Convert.ToDecimal(txtTotalPayment.Text);




                        /*JJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJNEWYLY ADDED*/
                        stock_product stoPro = new stock_product();
                        List<stock_product> stoProList = new List<stock_product>();
                        List<DeductFromProduct_Quantit> deductionList = new List<DeductFromProduct_Quantit>();

                        stoProList = stoPro.Get_all_List(connString2);


                        foreach (var item2 in Cartlist)
                        {
                            int requiredQty = Convert.ToInt32(item2.quantity);
                            int idofprod = Convert.ToInt32(item2.productID);

                            foreach (stock_product item in stoProList)
                            {

                                if (idofprod == item.pid)
                                {
                                    if (requiredQty > 0)
                                    {
                                        if (item.quantity > 0)
                                        {
                                            DeductFromProduct_Quantit deductObj = new DeductFromProduct_Quantit();
                                            deductObj.pid = item.pid;
                                            deductObj.sid = item.stock_id;


                                            //MessageBox.Show(requiredQty.ToString()+" This is required ");
                                            //MessageBox.Show(item.quantity.ToString() + " This is avalible" +item.stock_id.ToString());

                                            requiredQty = requiredQty - item.quantity;
                                            if (requiredQty > 0)
                                            {
                                                deductObj.quantity = item.quantity;
                                            }
                                            else
                                            {
                                                deductObj.quantity = item.quantity + requiredQty;
                                            }

                                            //MessageBox.Show(requiredQty.ToString() + " This is required after deduct");
                                            //MessageBox.Show( " Next Round");
                                            deductionList.Add(deductObj);
                                        }

                                    }
                                }

                            }
                            //MessageBox.Show(" Loop out start big loop");
                        }

                        /*aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa*/


                        foreach (DeductFromProduct_Quantit itemtobereduct in deductionList)
                        {
                            ////  MessageBox.Show(itemtobereduct.pid.ToString());
                            //MessageBox.Show(itemtobereduct.sid.ToString());
                            //MessageBox.Show(itemtobereduct.quantity.ToString());

                            itemtobereduct.Update(connString2);
                        }

                        if (sale.Add(connString2))
                        {

                            // string query = "SELECT SCOPE_IDENTITY() as inserted";

                            string query = @"select IDENT_CURRENT('_Sales')";
                            sid = Convert.ToInt32(Sales_BM.getScalar(connString2, query));


                            string[] waranty = new string[2];
                            foreach (var item in Cartlist)
                            {
                                sales_product sp = new sales_product();

                                sp.p_id = Convert.ToInt32(item.productID);
                                sp.quantity = Convert.ToInt32(item.quantity);
                                sp.sales_id = sid;

                                waranty = sp.getWarranty(connString2, sp.p_id);

                                sp.warranty = waranty[0];
                                sp.pname = waranty[1];
                                sp.price = item.price;
                                sp.total = item.totalAmount;
                                sp.Add(connString2);
                                btnPrint.Enabled = true;
                            }
                            if (chequeTemp.bank != null && chequeTemp.cheque_no != null)
                            {
                                chequeTemp.salesId = sid;
                                chequeTemp.Add(connString2);
                            }
                            MetroMessageBox.Show(this, "Transaction successfully completed", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        }
                        else
                        {

                            MetroMessageBox.Show(this, "Transaction Failed !. Please restart the system for reinitialize the services", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }


                        /*Lastly ask do u want to print receipt*/
                        DialogResult drs = MetroMessageBox.Show(this, "Do you want to print the receipt", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (drs == DialogResult.Yes)
                        {
                            PrintingProcess();

                        }
                        else if (drs == DialogResult.No)
                        {
                            MetroMessageBox.Show(this, "Transaction Successfully Saved", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }

                        txScope.Complete();//transaction commit
                        checkAdd = false;
                        cleanFOrm();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Please enter the payment details before print", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }//end of using

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
 
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private bool nonNumberEntered = false;

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {          
                    if (nonNumberEntered == true)
                    {
                        MessageBox.Show("Please enter numbers only");
                        e.Handled = true;
                    }
                
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;
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
                        nonNumberEntered = true;
                    }
                }
            }

        }

        private void lnkBack_Click(object sender, EventArgs e)
        {

            if (panel1.Width >= 260)
            {
                this.timer.Enabled = false;
                panel1.Width = 0;
                lnkBtnShow.Visible = true;
                lnkBack.Visible = false;

            }
            else
            this.timer.Enabled = true;

            
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Cartlist == null )
            {
                MessageBox.Show("Cart list is Empty");
                return;
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string pid = "";
                CartList RemoveIndex = new CartList();
                foreach (DataGridViewRow item in this.GridCart.SelectedRows)
                {
                    //GridCart.Rows.RemoveAt(item.Index);
                    pid = item.Cells[0].Value.ToString();

                }

                foreach (CartList item in Cartlist)
                {
                    if (item.productID == pid)
                    {
                        RemoveIndex = item;

                    }
                }

                Cartlist.Remove(RemoveIndex);
                LoadCart();

                if (Cartlist != null)
                {
                    btnPrint.Enabled = true;
                    foreach (CartList item in Cartlist)
                    {
                        total_text = total_text + item.totalAmount;

                        //quantity_text = quantity_text + item.quantity;

                    }
                    /*txtRemarks.Text = "Total      :" + total_text.ToString() + System.Environment.NewLine
                                      + "Vat        :" + vat_text.ToString() + System.Environment.NewLine
                                      + "Quantity :" + quantity_text.ToString();*/

                }
                else if (Cartlist == null)
                {
                    btnPrint.Enabled = false;
                    // txtRemarks.Clear();
                } 
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            
        }

        private void DeleteItemFromCart()
        {

            try
            {
                string pid = "";
                CartList RemoveIndex = new CartList();
                foreach (DataGridViewRow item in this.GridCart.SelectedRows)
                {
                    //GridCart.Rows.RemoveAt(item.Index);
                    pid = item.Cells[0].Value.ToString();

                }

                foreach (CartList item in Cartlist)
                {
                    if (item.productID == pid)
                    {
                        RemoveIndex = item;

                    }
                }

                Cartlist.Remove(RemoveIndex);
                LoadCart();

                if (Cartlist != null)
                {
                    btnPrint.Enabled = true;
                    foreach (CartList item in Cartlist)
                    {
                        total_text = total_text + item.totalAmount;

                        //quantity_text = quantity_text + item.quantity;

                    }
                    /*txtRemarks.Text = "Total      :" + total_text.ToString() + System.Environment.NewLine
                                      + "Vat        :" + vat_text.ToString() + System.Environment.NewLine
                                      + "Quantity :" + quantity_text.ToString();*/

                }
                else if (Cartlist == null)
                {
                    btnPrint.Enabled = false;
                    // txtRemarks.Clear();
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            
            try
            {

                if (txtPayment.Text == "" || txtPayment.Text == null )
                {
                    MetroMessageBox.Show(this, "Information incomplete. Enter Valid Information.", "! System Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkAdd = false;
                    return;
                }
                bool result = Cartlist.Any();
                if (!result)
                {
                    MetroMessageBox.Show(this, "Cart is empty", "! System Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkAdd = false;
                    return;
                }


                string paymetnMode = cmbPaymentMode.SelectedItem.ToString();
                decimal Amountsss = Convert.ToDecimal(txtPayment.Text);
                string Date = dtpPaymentDate.Text;
                txtTotalPayment.Text = Amountsss.ToString();
                checkAdd = true;

//                txtGrandTotal.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtGrandTotal.Text) + GlobalCost, 2));
                txtPaymentBalance.Text =Convert.ToString( Amountsss- Convert.ToDecimal(txtGrandTotal.Text));

               
                
                /*Here inovke cheque invoice form */
                
                if(paymetnMode=="By Cheque"||paymetnMode=="By Cash & Cheque")
                {
                    //if he adds a cheque data. then keep some global vairable and decide he added cheque data or not. if not process it as normal data.
                    //otherwise process it with cheque data. 
                   // checkCheque
                    string query = "select max(sales_id) from _Sales";

                   int sidx = Convert.ToInt32(Sales_BM.getScalar(connString2, query));
                    sidx++;



                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.GetType().Name == "ChequePay")
                        {
                            MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    ChequePay v = new ChequePay(this, sidx);
                    v.Show();
                    
                    
                } 

                /*END HERE*/


            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
       
        private void btnListReset1_Click(object sender, EventArgs e)
        {
            foreach (Control item in GroupBox2Payment.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = String.Empty;
                }
                
            }
          

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (panel1.Width >= 260)
            {
                this.timer.Enabled = false;

            }
            else
            {
                panel1.Width += 12;
                lnkBack.Visible = true;
                lnkBtnShow.Visible = false;
            }


        }

        private void txtTotalPayment_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGrandTotal.Text))
            {
                return;
            }
            

            decimal grandTotal = Convert.ToDecimal(txtGrandTotal.Text);
            decimal Payment = Convert.ToDecimal(txtTotalPayment.Text);

            txtPaymentBalance.Text = Convert.ToString(Payment-grandTotal);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                toolTipCustom.Dispose();
        /*    if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                return;
            }
            string name = txtProductName.Text;
            BusinessObjects.M_Product_BS pObj = new M_Product_BS();
            pObj.name = name;
            pObj = pObj.Get1Product(connString2);
            if ( pObj.name==null||pObj.name=="")
            {
                MetroMessageBox.Show(this, "Product Name does not match", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductCode.Clear();
                txtProductName.Clear();


            }

                */

            }
            catch (Exception ez)
            {

                MetroMessageBox.Show(this, "System Error " + ez.Message, "System Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
               
            }
        }

        private bool nonNumberEntered2 = false;
        
        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
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

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            isKeyPressProductCode = true;
            tglWholesale.Checked = false;
            
            if (nonNumberEntered2 == true)
            {
                MessageBox.Show("Please enter number only");
                e.Handled = true;

            }
            else 
            {

                try
                {
                    if (isKeyPressProductCode)
                    {

                        if (string.IsNullOrWhiteSpace(txtProductCode.Text))
                        {
                            foreach (Control item in GroupBox5.Controls)
                            {
                                if (item is TextBox)
                                {
                                    item.Text = String.Empty;
                                    lblAvaliable.Text = string.Empty;

                                }
                            }

                            return;
                        }
                       
                        int Code = Convert.ToInt32(txtProductCode.Text);
                        BusinessObjects.M_Product_BS pObj = new M_Product_BS();
                        pObj.ID = Code;

                        getAvaliability(Code);

                        pObj = pObj.GetOneProduct(connString2);
                        ForVAT = pObj;
                        txtProductName.Text = pObj.name;


                        txtSellingPrice.Text = pObj.unitPrice.ToString();


                        /*********Changes here********/
                        lblCost.Text = pObj.cost.ToString();

            
                        if (tglWholesale.Checked == true)
                        {
                            string price = pObj.boundlePrice.ToString();
                            //txtSellingPrice.Text = pObj.boundlePrice.ToString();
                            txtSellingPrice.Text = price;
                            txtCustom.Text = price;
                        
                        }
                        else
                        {
                            string price = pObj.unitPrice.ToString();
                            txtCustom.Text = price;
                           // txtSellingPrice.Text = pObj.unitPrice.ToString();
                            txtSellingPrice.Text = price;
                        }

                    }
                    else
                    {
                        isKeyPressProductCode = false;
                        return;
                    }
                }
                catch (Exception ex)
                {

                    MetroMessageBox.Show(this, "Warning !!! " + ex.Message, "System Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error); ;
                }
            }



        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void tglWholesale_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void tglWholesale_Click(object sender, EventArgs e)
        {

            try
            {
                txtQty.Clear();
                if (txtProductName.Text == "" || txtProductName.Text == null || txtProductCode.Text == "" || txtProductCode.Text == null || txtSellingPrice.Text == null || txtSellingPrice.Text == "")
                {

                    tglWholesale.Checked = false;
                  
                    MessageBox.Show("Product details not found");
                    return;
                }

                else
                {
                    int pid = Convert.ToInt32(txtProductCode.Text);
                    M_Product_BS prodObj = new M_Product_BS();
                    foreach (M_Product_BS item in toggleList)
                    {
                        if (pid == item.ID)
                        {
                            prodObj = item;
                        }
                    }
                    if (tglWholesale.Checked)
                    {
                        txtSellingPrice.Text = prodObj.boundlePrice.ToString();
                        /****************************Newly Added**********************/
                        txtCustom.Text = txtSellingPrice.Text;
                        /**********************************************/
                        //

                        if (txtQty.Text.Length == 0)
                        {
                            txtAmount.Clear();
                            txtTotalAmount.Clear();
                        }
                        else if (txtProductName.Text == "" || txtProductName.Text == null || txtProductCode.Text == "" || txtProductCode.Text == null || txtSellingPrice.Text == null || txtSellingPrice.Text == "")
                        {
                            MessageBox.Show("Product details not found");
                            txtAmount.Clear();
                            txtTotalAmount.Clear();
                            txtQty.Clear();
                            return;
                        }
                        

                    }
                    else
                    {

                        txtSellingPrice.Text = prodObj.unitPrice.ToString();
                        /****************************Newly Added**********************/
                        txtCustom.Text = txtSellingPrice.Text;
                        /**********************************************/
                        if (txtQty.Text.Length == 0)
                        {
                            txtAmount.Clear();

                        }
                        else if (txtProductName.Text == "" || txtProductName.Text == null || txtProductCode.Text == "" || txtProductCode.Text == null || txtSellingPrice.Text == null || txtSellingPrice.Text == "")
                        {
                            MessageBox.Show("Product details not found");
                            txtAmount.Clear();
                            txtQty.Clear();
                            return;
                        }               
                        //end
                    }
            }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        private void FormBilling_Load(object sender, EventArgs e)
        {
            txtProductCode.Focus();
            this.WindowState = FormWindowState.Maximized;
           
        }

        private void FormBilling_Click(object sender, EventArgs e)
        {
            if (panel1.Width >= 350)
            {
                this.timer.Enabled = false;
                panel1.Width = 0;
                lnkBtnShow.Visible = true;
                lnkBack.Visible = false;

            }
            else
                this.panel1.Enabled = true;
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {

        }

        private void lnkHome_Click(object sender, EventArgs e)
        {
           MemoryManagement.FlushMemory();
            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Dispose();
            form2.Show();
                       
        }

        private void txtCustom_Leave(object sender, EventArgs e)
        {

            try
            {

                /*********************** Newly Added************/

                if (txtProductName.Text == "" || txtProductName.Text == null || txtProductCode.Text == "" || txtProductCode.Text == null || txtSellingPrice.Text == null || txtSellingPrice.Text == "")
                {
                    txtCustom.Text = String.Empty;
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCustom.Text))
                {
                    txtCustom.Text = txtSellingPrice.Text;
                    return;
                }


                decimal checkCustomPrice = 0;
                decimal checkActualPrice = 0;
                decimal checkCostPrirce = 0;
                checkCustomPrice = Convert.ToDecimal(txtCustom.Text);
                checkActualPrice = Convert.ToDecimal(txtSellingPrice.Text);
                checkCostPrirce = Convert.ToDecimal(lblCost.Text);
                if (tglWholesale.Checked)
                {
                    if (checkCustomPrice > checkActualPrice)
                    {
                        //MessageBox.Show("Custom Price You Entered Is Greater Than Actual Selling Price !!!");
                        //txtCustom.Text = txtSellingPrice.Text; ;
                        //return;


                        MetroMessageBox.Show(this, "Custom Price You Entered Is Greater Than Actual Selling Price !!!", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    //if (checkCostPrirce > checkCustomPrice || checkCustomPrice > checkActualPrice)  commented because they dont want any restrictions
                    if ( checkCustomPrice > checkActualPrice)
                    {
                        //MessageBox.Show("Custom price is greater than selling price. Wear your Eye Glass. I will hanlde this.( Your price greater than Selling Price  !!!)");
                        //txtCustom.Text = txtSellingPrice.Text;
                        //return;
                        MetroMessageBox.Show(this, "Custom Price You Entered is Greater Than Actual Selling Price !!! I'm not gona handle this. Keep your sh*t", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    if (checkCostPrirce > checkCustomPrice) //this is only warning. can proceed somehow. 
                    {
                       // MessageBox.Show("Your price is lower than cost. Huhhh . Are you drunk. I'm not gona handle this. ( Your Price lesser than Cost  !!!)");
                        MetroMessageBox.Show(this, "Your price is lower than cost. Huhhh . Are you drunk. I'm not gona handle this. ( Your Price lesser than Cost  !!!).", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GroupBox5_Enter(object sender, EventArgs e)
        {
        }

        private void txtCustom_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtQty.Text.Length > 0)
                {
                    /************************new code here*****************/
                    decimal customPrice = Convert.ToDecimal(txtCustom.Text);
                    decimal actualPrice = Convert.ToDecimal(txtSellingPrice.Text);

                    decimal Amount = 0;


                    if (customPrice != actualPrice)
                    {
                        Amount = Convert.ToDecimal(txtCustom.Text) * Convert.ToInt32(txtQty.Text);

                    }
                    else
                    {

                        Amount = Convert.ToDecimal(txtSellingPrice.Text) * Convert.ToInt32(txtQty.Text);
                    }
                    /************************new code here*****************/

                    txtAmount.Text = Amount.ToString();

                    txtTotalAmount.Text = Amount.ToString();
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
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

        private void txtCustom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, txtCustom.Text))
                e.Handled = true;
        }

        private void txtLabourCost_KeyPress(object sender, KeyPressEventArgs e)
        {         
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }
        int sid;
        decimal printTotal = 0;
        decimal printPayment = 0;
        private void btnDelete_Click_1_Oldddd(object sender, EventArgs e)
        {

            try
            {

                bool result = Cartlist.Any();
                if (!result)
                {
                    MetroMessageBox.Show(this, "Cart is empty", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkAdd = false;
                    return;
                }
                if (checkAdd)
                {
                    string custName = "guest";
                    if (string.IsNullOrEmpty(txtCustomerName.Text))
                    {
                    }
                    else
                    {
                        custName = txtCustomerName.Text;
                    }


                    /*insert into sales tables*/
                    Sales_BM sale = new Sales_BM();
                    sale.customer_name = custName;
                    sale.date_time = Convert.ToDateTime(dtpPaymentDate.Text);
                    sale.total = Convert.ToDecimal(txtGrandTotal.Text);
                    sale.paid = Convert.ToDecimal(txtTotalPayment.Text);
                    sale.credit = sale.paid - sale.total;

                    printTotal = sale.total;
                    printPayment = Convert.ToDecimal(txtTotalPayment.Text);


                    if (sale.Add(connString2))
                    {
                        string query = "select max(sales_id) from _Sales";

                        sid = Convert.ToInt32(Sales_BM.getScalar(connString2, query));
                        string[] waranty = new string[2];
                        foreach (var item in Cartlist)
                        {
                            sales_product sp = new sales_product();
                            sp.p_id = Convert.ToInt32(item.productID);
                            sp.quantity = Convert.ToInt32(item.quantity);
                            sp.sales_id = sid;

                            waranty = sp.getWarranty(connString2, sp.p_id);

                            sp.warranty = waranty[0];
                            sp.pname = waranty[1];
                            sp.price = item.price;
                            sp.total = item.totalAmount;
                            sp.Add(connString2);
                            btnPrint.Enabled = true;
                        }

                        MetroMessageBox.Show(this, "Transaction successfully completed", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {

                        MetroMessageBox.Show(this, "Transaction Failed !. Please restart the system for reinitialize the services", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }

                    /*Lastly ask do u want to print receipt*/
                    DialogResult drs = MetroMessageBox.Show(this, "Do you want to print the receipt", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drs == DialogResult.Yes)
                    {
                        PrintingProcess();

                    }
                    else if (drs == DialogResult.No)
                    {
                        MessageBox.Show("Transaction Successfully Saved");
                        return;
                    }


                    checkAdd = false;
                }
                else
                {
                    MetroMessageBox.Show(this, "Please enter the payment details before print", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            }



        private void SaveTransactionSales()
        {
            try
            {
                using (TransactionScope txScope = new TransactionScope())
                {

                    bool result = Cartlist.Any();
                    if (!result)
                    {
                        // t.Abort();
                        MetroMessageBox.Show(this, "Cart is empty", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkAdd = false;
                        return;
                    }
                    if (checkAdd)
                    {
                        string custName = "guest";
                        int customerID = 0;


                        //newly added for customer update*****************************************
                        if (chkCNameAsPName.Checked)
                        {
                            custName = string.IsNullOrEmpty(onFlyCustName.Text) ? "Guest" : onFlyCustName.Text;
                        }
                        else
                        {
                            if (txtCustomerName.SelectedIndex == -1)
                            {
                                //  t.Abort();
                                MessageBox.Show("Please Select an Customer or Add a New Customer");
                                return;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(txtCustomerName.Text))
                                {
                                    // t.Abort();
                                    MessageBox.Show("Customer Name Not Valid");
                                    return;
                                }
                                else
                                {
                                    custName = txtCustomerName.Text;
                                    customerID = Convert.ToInt32(txtCustomerName.SelectedValue.ToString());
                                }
                            }
                        }
                        //***************************************************************************

                        Sales_BM sale = new Sales_BM();
                        sale.customer_name = custName;
                        sale.customerID = customerID;
                        DateTime dtime = Convert.ToDateTime(dtpPaymentDate.Text);
                        if (dtime == DateTime.Now.Date)
                            sale.date_time = DateTime.Now;
                        else
                            sale.date_time = Convert.ToDateTime(dtpPaymentDate.Text);

                        sale.total = Convert.ToDecimal(txtGrandTotal.Text);
                        sale.paid = Convert.ToDecimal(txtTotalPayment.Text);
                        sale.credit = sale.total - sale.paid;

                        printTotal = sale.total;
                        printPayment = Convert.ToDecimal(txtTotalPayment.Text);

                        List<DeductFromProduct_Quantit> deductionList = new List<DeductFromProduct_Quantit>();

                        foreach (var item in Cartlist)
                        {
                            foreach (var item2 in item.StockOrderList)
                            {
                                DeductFromProduct_Quantit deductObj = new DeductFromProduct_Quantit();
                                deductObj.pid = item2.product_id;
                                deductObj.sid = item2.stock_id;
                                deductObj.quantity = item2.quantity;
                                deductionList.Add(deductObj);

                            }
                        }

                        foreach (DeductFromProduct_Quantit itemtobereduct in deductionList)
                        {
                            itemtobereduct.Update(connString2);
                        }

                        if (sale.Add(connString2))
                        {

                            // string query = "SELECT SCOPE_IDENTITY() as inserted";

                            string query = @"select IDENT_CURRENT('_Sales')";
                            sid = Convert.ToInt32(Sales_BM.getScalar(connString2, query));


                            string[] waranty = new string[2];
                            foreach (var item in Cartlist)
                            {
                                sales_product sp = new sales_product();

                                sp.p_id = Convert.ToInt32(item.productID);
                                sp.quantity = Convert.ToInt32(item.quantity);
                                sp.sales_id = sid;

                                waranty = sp.getWarranty(connString2, sp.p_id);

                                sp.warranty = waranty[0];
                                sp.pname = waranty[1];
                                sp.price = item.price;
                                sp.total = item.totalAmount;
                                sp.Add(connString2);
                                btnPrint.Enabled = true;
                            }
                            if (chequeTemp.bank != null && chequeTemp.cheque_no != null)
                            {
                                chequeTemp.salesId = sid;
                                chequeTemp.Add(connString2);
                            }

                            //gona add sales product different price details
                            foreach (var item in Cartlist)
                            {
                                foreach (var item2 in item.StockOrderList)
                                {
                                    item2.Add(connString2, sid);
                                }
                            }

                            //t.Abort();
                            MetroMessageBox.Show(this, "Transaction successfully completed", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        }
                        else
                        {
                            //t.Abort();
                            MetroMessageBox.Show(this, "Transaction Failed !. Please restart the system for reinitialize the services", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }
                        /*Lastly ask do u want to print receipt*/
                        DialogResult drs = MetroMessageBox.Show(this, "Do you want to print the receipt", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (drs == DialogResult.Yes)
                        {
                            PrintingProcess();
                        }
                        else if (drs == DialogResult.No)
                        {
                            MetroMessageBox.Show(this, "Transaction Successfully Saved", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        txScope.Complete();//transaction commit
                        checkAdd = false;
                        cleanFOrm();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Please enter the payment details before print", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }//end of using

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        //this is save_click event
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
                //Thread t = new Thread(new ThreadStart(GifLoadingSaveSales));
                //t.Start();
            try
            {
                
                using (TransactionScope txScope = new TransactionScope())
                {

                    bool result = Cartlist.Any();
                    if (!result)
                    {
                       // t.Abort();
                        MetroMessageBox.Show(this, "Cart is empty", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkAdd = false;
                        return;
                    }
                    if (checkAdd)
                    {
                        string custName = "guest";
                        int customerID = 0;
                        
                        
                        //newly added for customer update*****************************************
                        if (chkCNameAsPName.Checked)
                        {
                           custName= string.IsNullOrEmpty(onFlyCustName.Text) ? "Guest" : onFlyCustName.Text;
                        }
                        else 
                        {
                            if (txtCustomerName.SelectedIndex == -1)
                            {
                              //  t.Abort();
                                MessageBox.Show("Please Select an Customer or Add a New Customer");
                                return;
                            }
                            else
                            { 
                                if (string.IsNullOrEmpty(txtCustomerName.Text))
                                {
                                   // t.Abort();
                                    MessageBox.Show("Customer Name Not Valid");
                                    return;
                                }
                                else
                                {
                                    custName = txtCustomerName.Text; 
                                    customerID = Convert.ToInt32(txtCustomerName.SelectedValue.ToString());
                                }
                            }
                        }
                        //***************************************************************************



                        /*insert into sales tables*/
                        Sales_BM sale = new Sales_BM();
                        sale.customer_name = custName;
                        //sale.customerID = Convert.ToInt32(txtCustomerName.SelectedValue.ToString());
                        sale.customerID = customerID;



                        //  sale.date_time = Convert.ToDateTime(dtpPaymentDate.Text);

                        // sale.date_time = DateTime.Now;*************
                        DateTime dtime = Convert.ToDateTime(dtpPaymentDate.Text);
                        if (dtime == DateTime.Now.Date)
                            sale.date_time = DateTime.Now;
                        else
                            sale.date_time = Convert.ToDateTime(dtpPaymentDate.Text);

                        sale.total = Convert.ToDecimal(txtGrandTotal.Text);
                        sale.paid = Convert.ToDecimal(txtTotalPayment.Text);
                        sale.credit = sale.total - sale.paid;


                        //if (sale.credit > 0)
                        //{
                        //    //sale.credit = System.Math.Abs(sale.credit);
                        //    sale.credit = sale.credit;
                        //}


                        printTotal = sale.total;
                        printPayment = Convert.ToDecimal(txtTotalPayment.Text);



                        /*//COMMETING BECOZ OF NEW STOCK ROUTING ADDED FIFO AND LIFO
                    
                                            stock_product stoPro = new stock_product();
                                            List<stock_product> stoProList = new List<stock_product>();
                                            List<DeductFromProduct_Quantit> deductionList = new List<DeductFromProduct_Quantit>();

                                            stoProList = stoPro.Get_all_List(connString2);
                                            foreach (var item2 in Cartlist)
                                            {
                                                int requiredQty = Convert.ToInt32(item2.quantity);
                                                int idofprod = Convert.ToInt32(item2.productID);

                                                foreach (stock_product item in stoProList)
                                                {

                                                    if (idofprod == item.pid)
                                                    {
                                                        if (requiredQty > 0)
                                                        {
                                                            if (item.quantity > 0)
                                                            {
                                                                DeductFromProduct_Quantit deductObj = new DeductFromProduct_Quantit();
                                                                deductObj.pid = item.pid;
                                                                deductObj.sid = item.stock_id;


                                                                //MessageBox.Show(requiredQty.ToString()+" This is required ");
                                                                //MessageBox.Show(item.quantity.ToString() + " This is avalible" +item.stock_id.ToString());

                                                                requiredQty = requiredQty - item.quantity;
                                                                if (requiredQty > 0)
                                                                {
                                                                    deductObj.quantity = item.quantity;
                                                                }
                                                                else
                                                                {
                                                                    deductObj.quantity = item.quantity + requiredQty;
                                                                }

                                                                //MessageBox.Show(requiredQty.ToString() + " This is required after deduct");
                                                                //MessageBox.Show( " Next Round");
                                                                deductionList.Add(deductObj);
                                                            }

                                                        }
                                                    }

                                                }
                                                //MessageBox.Show(" Loop out start big loop");
                                            }

                    
                        */
                        List<DeductFromProduct_Quantit> deductionList = new List<DeductFromProduct_Quantit>();

                        foreach (var item in Cartlist)
                        {
                            foreach (var item2 in item.StockOrderList)
                            {
                                DeductFromProduct_Quantit deductObj = new DeductFromProduct_Quantit();
                                deductObj.pid = item2.product_id;
                                deductObj.sid = item2.stock_id;
                                deductObj.quantity = item2.quantity;
                                deductionList.Add(deductObj);

                            }
                        }

                        //deducting from stock 
                        foreach (DeductFromProduct_Quantit itemtobereduct in deductionList)
                        {
                            itemtobereduct.Update(connString2);
                        }

                        if (sale.Add(connString2))
                        {

                            // string query = "SELECT SCOPE_IDENTITY() as inserted";

                            string query = @"select IDENT_CURRENT('_Sales')";
                            sid = Convert.ToInt32(Sales_BM.getScalar(connString2, query));


                            string[] waranty = new string[2];
                            foreach (var item in Cartlist)
                            {
                                sales_product sp = new sales_product();

                                sp.p_id = Convert.ToInt32(item.productID);
                                sp.quantity = Convert.ToInt32(item.quantity);
                                sp.sales_id = sid;

                                waranty = sp.getWarranty(connString2, sp.p_id);

                                sp.warranty = waranty[0];
                                sp.pname = waranty[1];
                                sp.price = item.price;
                                sp.total = item.totalAmount;
                                sp.Add(connString2);
                                btnPrint.Enabled = true;
                            }
                            if (chequeTemp.bank != null && chequeTemp.cheque_no != null)
                            {
                                chequeTemp.salesId = sid;
                                chequeTemp.Add(connString2);
                            }

                            //gona add sales product different price details
                            foreach (var item in Cartlist)
                            {
                                foreach (var item2 in item.StockOrderList)
                                {
                                    item2.Add(connString2, sid);
                                }
                            }

                            //t.Abort();
                            MetroMessageBox.Show(this, "Transaction successfully completed", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        }
                        else
                        {
                            //t.Abort();
                            MetroMessageBox.Show(this, "Transaction Failed !. Please restart the system for reinitialize the services", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }

                        /*Lastly ask do u want to print receipt*/
                        DialogResult drs = MetroMessageBox.Show(this, "Do you want to print the receipt", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (drs == DialogResult.Yes)
                        {
                            
                            PrintingProcess();

                        }
                        else if (drs == DialogResult.No)
                        {
                         
                            MetroMessageBox.Show(this, "Transaction Successfully Saved", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }

                        txScope.Complete();//transaction commit
                        checkAdd = false;
                        cleanFOrm();
                    }
                    else
                    {
                       // t.Abort();
                        MetroMessageBox.Show(this, "Please enter the payment details before print", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }//end of using

            }
            catch (Exception ex)
            {
               // t.Abort();
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            
        }

        private string nameListp;
        ToolTip toolTipCustom;
        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkAutoSuggestCMBClick = false;

            try
            {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                foreach (Control item in GroupBox5.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = String.Empty;
                        lblAvaliable.Text = string.Empty;
                    }
                }

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
            nameListp ="";
            foreach (DataRow row in filteredTable.Rows)
            {
                string fname = row["PName"].ToString();
                //MessageBox.Show(fname);
                namelist.Add(fname);
                nameListp = nameListp + Environment.NewLine + fname;
            }

            //comboBoxAdv1.DataSource = filteredTable.DefaultView;
            //comboBoxAdv1.DisplayMember = "FirstName";
            cmbAutoSuggest.DataSource = null;
            BindingSource bs = new BindingSource();
            bs.DataSource = namelist;

            cmbAutoSuggest.DataSource = bs;
            if (nameListp != null)
                // ttProdNameSuggest.Show("Hai",this.panel8);
                toolTipCustom.Dispose();
                toolTipCustom = new ToolTip();
                toolTipCustom.Show(nameListp, this.cmbAutoSuggest);

            //cmbAutoSuggest.DroppedDown = true;
                Cursor.Current = Cursors.Default;
             }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error Code 232 " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormBilling_SizeChanged(object sender, EventArgs e)
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

        private void cmbAutoSuggest_SelectedIndexChanged(object sender, EventArgs e)
        {          

        }


        bool checkAutoSuggestCMBClick = false;
        private void cmbAutoSuggest_MouseClick(object sender, MouseEventArgs e)
        {  
        }

        private void cmbAutoSuggest_ValueMemberChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbAutoSuggest_TextChanged(object sender, EventArgs e)
        {
            try
            {
            cmbAutoSuggest.Enabled = true;
    //        MessageBox.Show("Came to test");
            if (cmbAutoSuggest.Items.Count < 1)
            {
      //          MessageBox.Show("Item count is 0");
                cmbAutoSuggest.Enabled = false;
            }
            else
            {
                cmbAutoSuggest.Enabled = true;
            }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbAutoSuggest_Click(object sender, EventArgs e)
        {
            checkAutoSuggestCMBClick = false;
            if (cmbAutoSuggest.SelectedIndex == -1)
                return;
            checkAutoSuggestCMBClick = true;
        }

        private void txtProductName_MouseEnter(object sender, EventArgs e)
        {
            toolTipCustom = new ToolTip();
            toolTipCustom.AutoPopDelay = 5000;
            toolTipCustom.InitialDelay = 1000;
        }

        private void txtProductName_MouseClick(object sender, MouseEventArgs e)
        {
            txtProductName.Text = string.Empty;
        }
      
        private void cmbAutoSuggest_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbAutoSuggest.Items.Count<1)
            { return; }
            checkAutoSuggestCMBClick = false;
            if (cmbAutoSuggest.SelectedIndex == -1)
                return;
            checkAutoSuggestCMBClick = true;

            string name = cmbAutoSuggest.SelectedItem.ToString();
            txtProductName.Text = name;
        }

        private void cmbAutoSuggest_DropDown(object sender, EventArgs e)
        {
            txtProductName.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F10)
            {
                txtProductName.Clear();
                txtProductCode.Clear();
                txtQty.Clear();
                txtTotalAmount.Clear();
                txtSellingPrice.Clear();
                txtTotalAmount.Clear();
                txtAmount.Clear();
                txtGrandTotal.Clear();
                txtTotalPayment.Clear();
                Cartlist.Clear();
                LoadCart();
                clearAddProductPanel();
                txtPaymentBalance.Clear();

                return true;
            }
            else if (keyData == Keys.F5)
            {

                SaveTransactionSales();

                return true;
            }
            else if (keyData == Keys.Enter)
            {
                AddTOCartFunction();

                return true;
            }
            else if (keyData == Keys.Escape)
            {
                MemoryManagement.FlushMemory();


                this.Hide();
                var form2 = new MainMenu_Form();
                form2.Closed += (s, args) => this.Dispose();
                form2.Show();

                return true;
            }
            else if (keyData == Keys.F2)
            {

                CreateRunningOrders();

                return true;
            }
            else if (keyData == Keys.Delete)
            {
                DeleteItemFromCart();

                return true;
            }
            else if (keyData == Keys.F1)
            {
                txtCustomerName.Focus();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cmbAutoSuggest_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void cmbAutoSuggest_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtCustomerName_Enter(object sender, EventArgs e)
        {
            if (txtCustomerName.Items.Count == 0)
            {
                MessageBox.Show("No Customer Data Found");
            }
            //else
            //txtCustomerName.SelectedIndex=0;
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == String.Empty)
            {
                txtCustomerName.Text = "customer";
            }
        }

        private void txtStaffName_Click(object sender, EventArgs e)
        {
            
        }

        
        private void bunifuImageButton1_MouseHover(object sender, EventArgs e)
        {
            if (txtProductName.Text == "" || txtProductName.Text == null || txtProductCode.Text == "" || txtProductCode.Text == null || txtSellingPrice.Text == null || txtSellingPrice.Text == "")
            {
                tooltipMessage = "Data Not Found";
            }

            this.toolTip1.SetToolTip(this.bunifuImageButton1, tooltipMessage);
          /*  toolTip1.OwnerDraw = true;
            this.toolTip1.Draw+=toolTip1_Draw;
            this.toolTip1.Popup+=toolTip1_Popup;*/
          
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
        

            if (txtProductName.Text == "" || txtProductName.Text == null || txtProductCode.Text == "" || txtProductCode.Text == null || txtSellingPrice.Text == null || txtSellingPrice.Text == ""||txtQty.Text==null||txtQty.Text=="")
            {
                tooltipMessage = string.Empty;
                tooltipMessage = "Data Not Found";
                this.toolTip1.SetToolTip(this.bunifuImageButton1, tooltipMessage);
                return;
            }
            
            //accordingly get the cound of different stock and the price.
            List<CartStockRoutingList> stList = getStockListOflist(Convert.ToInt32(txtProductCode.Text), Convert.ToInt32(txtQty.Text));
            if (stList == null)
            {
                tooltipMessage = string.Empty;
                tooltipMessage = "Data Not Found";
            }
            tooltipMessage = string.Empty;

            int requiredqty = Convert.ToInt32(txtQty.Text);
            foreach(var item in stList)
            {
                if (requiredqty - item.qty < 0)
                {
                    tooltipMessage += "Qty = " + requiredqty.ToString() + "        " + "RS = " + item.price.ToString();
                }
                else if (requiredqty -item.qty == 0)
                {
                    tooltipMessage += "Qty = " + item.qty.ToString() + "        " + "RS = " + item.price.ToString();
                }
                else
                {
                    tooltipMessage += "Qty = " + item.qty.ToString() + "        " + "RS = " + item.price.ToString() + Environment.NewLine;
                    requiredqty=requiredqty-item.qty;
                }
                
            }
             
            this.toolTip1.SetToolTip(this.bunifuImageButton1, tooltipMessage);

        }

        private List<CartStockRoutingList> getStockListOflist(int pro_id, int qty)
        {
            try
            {
                //check the stock routing
                CartStockRoutingList DataModel = new CartStockRoutingList();
                string routing = DataModel.Get_Stock_Routing(connString2);
                List<CartStockRoutingList> sList = new List<CartStockRoutingList>();
                sList = DataModel.GetStockList(connString2, pro_id, routing);
                
                //gona remove unncessary stock from stock list. 
                int sumQty = 0;
                int count = 0;
                if (sList != null)
                {
                    foreach (CartStockRoutingList item in sList)
                    {
                        sumQty += item.qty;
                        count++;
                        if (sumQty >= qty)
                        {
                            break;
                        }
                    }

                  if(count!=sList.Count)
                  sList.RemoveRange(count, sList.Count - count);
                }

                return sList;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using (M_Customer ms = new M_Customer())
            {

                ms.ShowDialog();
            }
        }

        private void btnSupRefresh_Click(object sender, EventArgs e)
        {
            loadCustDropDown();
            SoftCustomertoList();
        }


       private  List<Customer> custList;
        private void SoftCustomertoList()
        {
            custList = new List<Customer>();
            DataView dv = new DataView(temp);
             custList = dv.Cast<DataRowView>().Select(t => new Customer() { Id = (int)t["Id"], Name = (string)t["Name"], Contact = (string)t["Contact"], NIC = (string)t["NIC"], Address = (string)t["Address"] }).ToList();

        
        }

        private void txtCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            

           if (string.IsNullOrEmpty(txtCustomerName.Text))
           {
               txtStaffName.Text = "address";
               return;
           }
           int selected = Convert.ToInt32(txtCustomerName.SelectedValue.ToString());
           
           foreach (var item in custList)
           {
               if (selected == item.Id)
               { txtStaffName.Text = item.Address;
               return;
               }
               
           }
              
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            
            if (txtQty.Text.Length == 0)
            {
                txtAmount.Clear();
                txtTotalAmount.Clear();
                return;
            }
            //accordingly get the cound of different stock and the price.
            List<CartStockRoutingList> stList = new List<CartStockRoutingList>();
            stList = getStockListOflist(Convert.ToInt32(txtProductCode.Text), Convert.ToInt32(txtQty.Text));
            if (stList == null)
            {
                tooltipMessage = string.Empty;
                tooltipMessage = "Data Not Found";
            }
            tooltipMessage = string.Empty;

            int requiredqty = Convert.ToInt32(txtQty.Text);
            if (stList != null || stList.Count > 0)
            {
                foreach (var item in stList)
                {
                    if (requiredqty - item.qty < 0)
                    {
                        tooltipMessage += "Qty = " + requiredqty.ToString() + "        " + "RS = " + item.price.ToString();
                    }
                    else if (requiredqty - item.qty == 0)
                    {
                        tooltipMessage += "Qty = " + item.qty.ToString() + "        " + "RS = " + item.price.ToString();
                    }
                    else
                    {
                        tooltipMessage += "Qty = " + item.qty.ToString() + "        " + "RS = " + item.price.ToString() + Environment.NewLine;
                        requiredqty = requiredqty - item.qty;
                    }

                }
            }

            this.toolTip1.SetToolTip(this.bunifuImageButton1, tooltipMessage);
            lblQuanPrice.Text = tooltipMessage;
            lblQuanPrice.Visible = true;
        }

        private void chkCNameAsPName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCNameAsPName.Checked)
            {
                txtCustomerName.Enabled = false;
                txtStaffName.Enabled = false;
                txtCustomerName.Visible = false;
                txtStaffName.Visible = false;

                onFlyCustName.Visible = true;
                onFlyCustName.Enabled = true;
            }
            else
            {
                txtCustomerName.Enabled = true;
                txtStaffName.Enabled = true;
                txtCustomerName.Visible = true;
                txtStaffName.Visible = true;

                onFlyCustName.Visible = false;
                onFlyCustName.Enabled = false;
            }
        }

        private void chkCNameAsPName_MouseHover(object sender, EventArgs e)
        {
             string mgs="Use Product Name as Customer Name";
             this.ttCustomerNameTick.SetToolTip(this.chkCNameAsPName, mgs);
             
        }

        private void onFlyCustName_TextChanged(object sender, EventArgs e)
        {

        }





        
       /* string temptooltiptext = "Quick Info";
        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {

            Font f = new Font("Arial", 16.0f);
            e.DrawBackground();
            e.DrawBorder();
            temptooltiptext = e.ToolTipText;
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, new PointF(2, 2));   
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText(temptooltiptext, new Font("Arial", 16.0f));
        }
        */
       

   }
}
