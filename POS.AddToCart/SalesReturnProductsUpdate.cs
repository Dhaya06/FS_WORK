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
using System.Transactions;
using System.Globalization;
using MetroFramework;
namespace POS.AddToCart
{
    public partial class SalesReturnProductsUpdate : MetroFramework.Forms.MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;

        ViewSalesProductCancelSale gForm;
        int ProdID;
        int quantity=0;
        int sales_id;
        decimal soldPrice = 0;
        int stockIDGlobal = 0;
        List<BusinessObjects.Stock> stockList = new List<BusinessObjects.Stock>();
        public SalesReturnProductsUpdate(ViewSalesProductCancelSale form, int pid, int sid)
        {
            InitializeComponent();
            this.Resizable = false;
         //   this.Movable = false;
            this.TopMost= true; ;
            this.MaximizeBox = false;
            this.ControlBox = false;
            sales_id = sid;
            gForm = form;
            ProdID = pid;

            inititalis2();
            txtAvalQuantity.Enabled = false;
        }

        void inititalis()
        {

            BusinessObjects.sales_product SPObj = new BusinessObjects.sales_product();
            SPObj= SPObj.getSales_Product_BySID_for_SalesReturn(con, sales_id, ProdID);
            txtPName.Text = SPObj.pname;
            txtAvalQuantity.Text = SPObj.quantity.ToString();
            quantity = SPObj.quantity;
            soldPrice = SPObj.price;
            
            Stock stock = new Stock();
            stockList= stock.GetStockListByPIDSalesReturn(con, ProdID);

            cmbSupplier.DataSource = null;
            cmbSupplier.DataSource = stockList;
            cmbSupplier.DisplayMember = "sup_name";
            cmbSupplier.ValueMember = "stock_id";
        }


        List<CartSaleProductList> cspList;
        List<Purchase> puchaseList;
        void inititalis2()
        {
            BusinessObjects.sales_product SPObj = new BusinessObjects.sales_product();
            SPObj = SPObj.getSales_Product_BySID_for_SalesReturn(con, sales_id, ProdID);
            txtPName.Text = SPObj.pname;
            txtAvalQuantity.Text = SPObj.quantity.ToString();
            quantity = SPObj.quantity;
            soldPrice = SPObj.price;


            cspList = new List<CartSaleProductList>();
            CartSaleProductList csp = new CartSaleProductList();

            cspList = csp.getProduct(con, sales_id, ProdID);
           // cspList.SingleOrDefault(d => d.product_id == 3);
            Purchase pcr = new Purchase();
            puchaseList = new List<Purchase>();
            foreach (var item in cspList)
            {
                puchaseList.Add(pcr.GetPurchaseByStockID(con, item.stock_id));
            }
          
            cmbSupplier.DataSource = null;
            cmbSupplier.DataSource = puchaseList;
            cmbSupplier.DisplayMember = "sup_name";
            cmbSupplier.ValueMember = "stock_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
           
            try
            {

                if (txtPName.Text == "" || txtPName.Text == string.Empty || txtDesc.Text == string.Empty
                   || txtQuantity.Text == string.Empty)
                {
                    MessageBox.Show("Incomplete Data!");
                    return;

                }
                if (!tglTempStockRecord.Checked)
                {
                    if (cmbSupplier.SelectedIndex == -1 || txtStockDate.Text == string.Empty)
                    {
                        MessageBox.Show("Incomplete Data!");
                        return;
                    }
                }
                

                int typed = Convert.ToInt32(txtQuantity.Text);
                if (typed == 0 || typed > quantity)
                {
                    txtQuantity.Text = quantity.ToString();

                    MessageBox.Show("Please enter valid data!");
                    return;
                }

                using (TransactionScope txScope = new TransactionScope())
                {
                    //firstly update the sales product table
                    int returnQuantity = Convert.ToInt32(txtQuantity.Text);
                    string desc = txtDesc.Text;
                    sales_product SalePro = new sales_product();
                    Sales_BM saleObject = new Sales_BM();
                    int stepOneCount = 0;
                    BusinessObjects.SalesReturn salesReturnObject = new BusinessObjects.SalesReturn();
                    if (quantity == returnQuantity)
                    {
                        //delete record from sales_product 
                        SalePro.DeleteSalesReturn(con, sales_id, ProdID);//this will delete the relevant product from sales product data 


                        //calculating new amount
                        decimal deletedAMount = quantity * soldPrice;
                        saleObject = saleObject.getSalesByIDSalesReturn(con, sales_id);//getting the relevant sales data
                        decimal newTotal = saleObject.total - deletedAMount;
                        decimal newCredit = newTotal - saleObject.paid;

                        //update the sales table
                        saleObject.UpdateSalesReturn(con, newTotal, newCredit);//updating amount and the credit of that sales 

                        //insert to sales return table
                        int salesReturnTableCount = 0;
                        salesReturnTableCount = salesReturnObject.GetCountSalesReturn(con, sales_id);

                        if (salesReturnTableCount > 0)
                        {
                            int salesReturnProductTableCount = 0;
                            salesReturnProductTableCount = salesReturnObject.GetCountSalesProduct(con, sales_id, ProdID);

                            decimal ReturnAMount = returnQuantity * soldPrice;
                            if (salesReturnProductTableCount > 0)
                            {
                                string salesReturnProductsQuery = @"update sales_return_products set quantity= quantity + " + returnQuantity
                                    + "  where product_id=" + ProdID + " AND sales_id=" + sales_id + "";

                                salesReturnObject.ExecuteNonQuery(salesReturnProductsQuery, con);

                            }
                            else
                            {
                                string salesReturnProductsQuery = @"insert sales_return_products (product_id, sales_id, quantity, product_sold_price)
                        values (" + ProdID + "," + sales_id + "," + returnQuantity + "," + soldPrice + ")";
                                salesReturnObject.ExecuteNonQuery(salesReturnProductsQuery, con);

                            }

                        }
                        else
                        {
                            string salesReturnQuery = @"insert sales_return (sales_id, Total, _date, customer,paid)
                    values (" + saleObject.sales_id + "," + saleObject.total
                            + ",'" + saleObject.date_time.ToString("G", DateTimeFormatInfo.InvariantInfo)
                                + "','" + saleObject.customer_name + "'," + saleObject.paid + ")";
                            salesReturnObject.ExecuteNonQuery(salesReturnQuery, con);


                            string salesReturnProductsQuery = @"insert sales_return_products (product_id, sales_id, quantity, product_sold_price)
                        values (" + ProdID + "," + sales_id + "," + returnQuantity + "," + soldPrice + ")";
                            salesReturnObject.ExecuteNonQuery(salesReturnProductsQuery, con);

                        }
                    }

                    else
                    {
                        //updating sale_product table
                        int newQuantity = quantity - returnQuantity;
                        decimal newTotalSalesProductPrice = newQuantity * soldPrice;
                        SalePro.UpdateSalesReturn(con, sales_id, ProdID, newQuantity, newTotalSalesProductPrice);


                        // //update the sales table
                        decimal deletedAMount = returnQuantity * soldPrice;
                        saleObject = saleObject.getSalesByIDSalesReturn(con, sales_id);

                        decimal newTotal = saleObject.total - deletedAMount;
                        decimal newCredit = newTotal - saleObject.paid;
                        saleObject.UpdateSalesReturn(con, newTotal, newCredit);

                        //insert to sales return table
                        int salesReturnTableCount = 0;
                        salesReturnTableCount = salesReturnObject.GetCountSalesReturn(con, sales_id);

                        if (salesReturnTableCount > 0)
                        {
                            int salesReturnProductTableCount = 0;
                            salesReturnProductTableCount = salesReturnObject.GetCountSalesProduct(con, sales_id, ProdID);

                            decimal ReturnAMount = returnQuantity * soldPrice;
                            if (salesReturnProductTableCount > 0)
                            {
                               //int countAvalQun= salesReturnProductTableCount = salesReturnObject.GetQuantitySalesProduct(con, sales_id, ProdID);
                               //int newQuanttt = returnQuantity + countAvalQun;
                                string salesReturnProductsQuery = @"update sales_return_products set quantity=quantity+" + returnQuantity
                                    + "  where product_id=" + ProdID + " AND sales_id=" + sales_id + "";

                                salesReturnObject.ExecuteNonQuery(salesReturnProductsQuery, con);

                            }
                            else
                            {
                                string salesReturnProductsQuery = @"insert sales_return_products (product_id, sales_id, quantity, product_sold_price)
                        values (" + ProdID + "," + sales_id + "," + returnQuantity + "," + soldPrice + ")";
                                salesReturnObject.ExecuteNonQuery(salesReturnProductsQuery, con);

                            }

                        }
                        else
                        {
                            string salesReturnQuery = @"insert sales_return (sales_id, Total, _date, customer,paid)
                    values (" + saleObject.sales_id + "," + saleObject.total
                            + ",'" + saleObject.date_time.ToString("G", DateTimeFormatInfo.InvariantInfo)
                                + "','" + saleObject.customer_name + "',"+saleObject.paid+")";
                            salesReturnObject.ExecuteNonQuery(salesReturnQuery, con);


                            string salesReturnProductsQuery = @"insert sales_return_products (product_id, sales_id, quantity, product_sold_price)
                        values (" + ProdID + "," + sales_id + "," + returnQuantity + "," + soldPrice + ")";
                            salesReturnObject.ExecuteNonQuery(salesReturnProductsQuery, con);

                        }

                    }

                    int SalesTableProductCount = salesReturnObject.GetCountSalesProductTable(con, sales_id);
                    if (SalesTableProductCount == 0)
                    {
                        string salesDeleteQueru = @"Delete from _Sales where sales_id=" + sales_id + "";
                        salesReturnObject.ExecuteNonQuery(salesDeleteQueru, con);

                    }




                    //update the stock data here*********************************************************************
                    // returnQuantity  ProdID  cmbSupplier.SelectedIndex txtStockInvoice.text;

 #region removed_by_new_code
                    /*
                    
 #region if
                    if (tglTempStockRecord.Checked)
                    {
                        //string invoiceNum = txtStockInvoice.Text;
                        string custStockName = "SalesReturnStock";
                        string getTemStockRecordExistece = @"select stock_id from  _Stokc where sup_name='" + custStockName + "'";
                        int existence= 0;
                        if (BusinessObjects.SalesReturn.getScalar(con, getTemStockRecordExistece) != DBNull.Value)
                        {
                            object temPonj=BusinessObjects.SalesReturn.getScalar(con, getTemStockRecordExistece);
                            if (temPonj != null)
                                existence = (int)temPonj;
                        }
                        if (existence > 0)//this means the temp sales return data is in stock table
                        {
                            string getCountOfstokcreturn = @"select quantity from  _stock_product where pid=" + ProdID + " AND stock_id='" + existence + "'";
                            int AllreadyAvaliableQuant = 0;
                            if (BusinessObjects.SalesReturn.getScalar(con, getCountOfstokcreturn) != DBNull.Value)
                            {
                                object temPobj = BusinessObjects.SalesReturn.getScalar(con, getCountOfstokcreturn);
                                if (temPobj != null)
                                    AllreadyAvaliableQuant = (int)temPobj;
                            }
                            if (AllreadyAvaliableQuant > 0)
                            {
                                int newQuan = AllreadyAvaliableQuant + returnQuantity;

                                string stockProductUpdateQuery = @"update _stock_product set quantity=" + newQuan + " where pid=" + ProdID + " and stock_id =" + existence + "";

                                salesReturnObject.ExecuteNonQuery(stockProductUpdateQuery, con);
                            }
                            else
                            {

                                string stockProductInsertQuery = @"insert _stock_product  (pid,quantity,stock_id) values(" + ProdID + "," + returnQuantity + "," + existence + ") ";
                                salesReturnObject.ExecuteNonQuery(stockProductInsertQuery, con);

                            }
                        }
                        else //this means the temp stock return data is not availeble in stock table. 
                        {
                            //addign data to stock table first (SalesReturn Temp Record)
                            string addTempStockData = @"insert _Stokc  (sup_name,s_date,invoice_no) values('SalesReturnStock','" + DateTime.Now.ToString("G", DateTimeFormatInfo.InvariantInfo) + "','00000') ";
                            salesReturnObject.ExecuteNonQuery(addTempStockData, con);

                            //getting last inserted ID
                            string querySI = @"select IDENT_CURRENT('_Stokc')";
                            int lastInsertedID = Convert.ToInt32(Sales_BM.getScalar(con, querySI));
                            
                            //now we add data the the stock product table 
                            string AfterInsertSPQuery = @"insert _stock_product  (pid,quantity,stock_id) values(" + ProdID + "," + returnQuantity + "," + lastInsertedID + ") ";
                            salesReturnObject.ExecuteNonQuery(AfterInsertSPQuery, con);
                        }
                    }
                    #endregion 
                    #region else
                    else 
                    { 
                        //string invoiceNum = txtStockInvoice.Text;
                        int stockIDRt=Convert.ToInt32(txtStokIDRetrieved.Text);
                        string getCountOfstokcreturn = @"select quantity from  _stock_product where pid=" + ProdID + " AND stock_id='" + stockIDRt + "'";
                        int AllreadyAvaliableQuant=0;
                        if (BusinessObjects.SalesReturn.getScalar(con, getCountOfstokcreturn) != DBNull.Value)
                        {
                            object objTemp=BusinessObjects.SalesReturn.getScalar(con, getCountOfstokcreturn);
                            if (objTemp != null)
                                AllreadyAvaliableQuant = (int)objTemp;
                        }
                        if (AllreadyAvaliableQuant > 0)
                        {
                            int newQuan=AllreadyAvaliableQuant+returnQuantity;

                            string stockProductUpdateQuery = @"update _stock_product set quantity=" + newQuan + " where pid=" + ProdID + " and stock_id =" + stockIDRt + "";
                        
                            salesReturnObject.ExecuteNonQuery(stockProductUpdateQuery, con);
                        }
                        else
                        {
                            string stockProductInsertQuery = @"insert _stock_product  (pid,quantity,stock_id) values(" + ProdID + "," + returnQuantity + "," + stockIDRt + ") ";
                            salesReturnObject.ExecuteNonQuery(stockProductInsertQuery, con);
                        }
                        //returnQuantity;ProdID
                         // cmbSupplier.SelectedIndex 
                    }
#endregion

                    */
                    #endregion

                    int stockIDD=Convert.ToInt32(cmbSupplier.SelectedValue.ToString());
                    updateStock(ProdID, stockIDD, returnQuantity);

                    txScope.Complete();//transaction commit
                    MetroMessageBox.Show(this, "Transaction Complete ", "Process completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void updateStock(int productID, int StockID, int Quanityt)
        {
            int existenceStockTable = 0;
            int existenceStockProductTable = 0;
            BusinessObjects.SalesReturn salesReturnObject = new BusinessObjects.SalesReturn();
            string queryExistenseStockTable="select count (*) from _Stokc where stock_id="+StockID+" ";
            object objTemp = BusinessObjects.SalesReturn.getScalar(con, queryExistenseStockTable);
            if (objTemp != null)
                existenceStockTable = (int)objTemp;
            if (existenceStockTable > 0)
            {
                string queryExistenseStockProductTable = @"select count (*) from _stock_product where stock_id=" +                       StockID + " and pid=" + productID + " ";
                object objTemp2 = BusinessObjects.SalesReturn.getScalar(con, queryExistenseStockProductTable);
                if (objTemp2 != null)
                    existenceStockProductTable = (int)objTemp;

                if (existenceStockProductTable > 0)
                {
                    //update the stoc_product table
                    string updateQuerySP1 = @"update _stock_product set quantity=quantity+" + Quanityt + " where pid=" +
                        ProdID + " and stock_id =" + StockID + "";
                    salesReturnObject.ExecuteNonQuery(updateQuerySP1, con);
                }
                else
                {
                    //add to the stockProduct table
                    decimal cost=0;
                    string selectQuerySotkcProductDetails = @"select cost from purchase_product where stock_id=" +
                        StockID + " and pid=" + productID + " ";
                    object objTemp3 = BusinessObjects.SalesReturn.getScalar(con, selectQuerySotkcProductDetails);
                    if (objTemp3 != null)
                        cost = (decimal)objTemp3;

                    string stockProductInsert = @"insert _stock_product  (pid,quantity,stock_id,price) values(" + ProdID 
                        + "," + Quanityt + "," + StockID + ",'"+cost+"') ";
                    salesReturnObject.ExecuteNonQuery(stockProductInsert, con);
                }
            }
            else
            { 
                //add to stock
                Purchase pm = new Purchase();
                pm = pm.GetPurchaseAndPProdBySID(con, StockID);

                string queryGetSupID = @"select Id from Supplier where Name='" +pm.sup_name+ "'";
                int supID = 1;
                object objTemp4 = BusinessObjects.SalesReturn.getScalar(con, queryGetSupID);
                if (objTemp4 != null)
                    supID = (int)objTemp4;
                string o = "(return)";
                string insertStock = @"insert _Stokc  (sup_name,s_date,invoice_no,Sup_id) values('" + pm.sup_name + o
                       + "','" + pm.s_date.ToString("G", DateTimeFormatInfo.InvariantInfo) + "','" + pm.invoice_no 
                       + "',"+supID + ") ";
                salesReturnObject.ExecuteNonQuery(insertStock, con);
                //getting last inserted ID
                string queryx = @"select IDENT_CURRENT('_Stokc')";
                int lastInsertedID = Convert.ToInt32(Sales_BM.getScalar(con, queryx));
                //adding stock product
                stock_product sp = new stock_product();
                sp.price = pm.StockProductList.Find(prod => prod.pid == productID).cost;
                sp.quantity = Quanityt;
                sp.stock_id = lastInsertedID;
                sp.pid = ProdID;
                sp.Add(con);
            }
        }



        private bool combochangedByUser = false;

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combochangedByUser)
            {
                int stockSelectedID = Convert.ToInt32(cmbSupplier.SelectedValue.ToString());
                // MessageBox.Show(cmbSupplier.SelectedValue.ToString());

                foreach (Purchase item in puchaseList)
                {
                    if (item.stock_id == stockSelectedID)
                    {
                        stockIDGlobal = item.stock_id;
                        txtStockDate.Text = item.s_date.ToString();
                        txtStockInvoice.Text = item.invoice_no;
                        txtStokIDRetrieved.Text = item.stock_id.ToString();
                    }
                }
                combochangedByUser = false;
            }
        }
        private void cmbSupplier_SelectedIndexChanged_Old(object sender, EventArgs e)
        {
            if (combochangedByUser)
            {
                int stockSelectedID = Convert.ToInt32(cmbSupplier.SelectedValue.ToString());
               // MessageBox.Show(cmbSupplier.SelectedValue.ToString());

                foreach (Stock item in stockList)
                {
                    if (item.stock_id == stockSelectedID)
                    {
                        stockIDGlobal = item.stock_id;
                        txtStockDate.Text = item.s_date.ToString();
                        txtStockInvoice.Text = item.invoice_no;
                        txtStokIDRetrieved.Text = item.stock_id.ToString();
                    }
                }
                combochangedByUser = false;
            }
        }

        private void cmbSupplier_DropDown(object sender, EventArgs e)
        {
            combochangedByUser = true;
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (txtQuantity.Text == string.Empty)
            {
                txtQuantity.Text = quantity.ToString();
                return;
            }
            if (Convert.ToInt32(txtQuantity.Text) == 0)
            {
                txtQuantity.Text = quantity.ToString();
                return;
            }
        }
        private bool nonNumberEntered = false;
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                MessageBox.Show("Please enter numbers only");
                txtQuantity.Text = quantity.ToString();
                e.Handled = true;
            }
        }

        private void tglTempStockRecord_CheckedChanged(object sender, EventArgs e)
        {
            if (tglTempStockRecord.Checked)
            {
                cmbSupplier.Enabled = false;
                txtStockDate.Enabled = false;
                txtStockInvoice.Enabled = false;
            }
            else {
                cmbSupplier.Enabled = true;
                txtStockDate.Enabled = true;
                txtStockInvoice.Enabled = true;
            }
        }

     
    }
}
