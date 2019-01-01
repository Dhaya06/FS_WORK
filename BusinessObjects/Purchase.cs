using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCommon;
using System.Data.SqlClient;
namespace BusinessObjects
{
   public class Purchase
    {

       public int stock_id  {set;get;}
       public string sup_name { get; set; }
       public DateTime s_date {get;set;}
       public string invoice_no {get;set;}
       public List<purchase_product> StockProductList { get; set; }
       public decimal grandTotal { get; set; }

       public bool AddPurchase(string connString, int sid)
       {
           try
           {

               string query = @"exec dbo.insertDuplicatStock " + sid + " ";
               
                       

               if (DBHelper.ExecuteNonQuery(query, connString) > 0)
                   return true;
               else
                   return false;


           }
           catch (Exception ex)
           {

               throw ex;
           }
       }


       public bool AddPurchaseProduct(string connString, int sid)
       {
           try
           {

               string query = @"exec dbo.insertDuplicatStockProduct " + sid + " ";



               if (DBHelper.ExecuteNonQuery(query, connString) > 0)
                   return true;
               else
                   return false;


           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

       public static object getScalar(string connString, string query)
       {
           try
           {

               return DBHelper.GetScaler(query, connString);
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public bool Update(string connString)
       {
           try
           {

               string query = @"Update Purchase set sup_name='" + sup_name
                               + "',s_date='" + s_date.ToString("dd-MMM-yyyy")
                               + "',invoice_no='" + invoice_no
                               + "'  where stock_id=" + stock_id + "";

               if (DBHelper.ExecuteNonQuery(query, connString) > 0)
                   return true;
               else
                   return false;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public bool Delete(string connString)
       {
           try
           {
               string query = "Delete from Purchase where stock_id=" + stock_id + "";
               if (DBHelper.ExecuteNonQuery(query, connString) > 0)
                   return true;
               else
                   return false;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public List<BusinessObjects.Purchase> GetStockList(string connString)
       {

           try
           {
               List<BusinessObjects.Purchase> ProductList = new List<BusinessObjects.Purchase>();
               string query = "select stock_id,sup_name, s_date,invoice_no from Purchase";

               SqlConnection conn = DBHelper.GetConnection(connString);

               conn.Open();

               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {
                   BusinessObjects.Purchase pObj = new BusinessObjects.Purchase();
                   pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                   pObj.sup_name = reader[1].ToString();
                   pObj.s_date = Convert.ToDateTime(reader[2].ToString());
                   pObj.invoice_no = reader[3].ToString();
                  // pObj.grandTotal = getGrandTotal(pObj.stock_id, connString);
                   pObj.grandTotal = getGrandTotal_New(pObj.stock_id, connString);
                   //retreiving relevant stock_product detail based on stock id
                   BusinessObjects.purchase_product sp = new purchase_product();
                   sp.stock_id = pObj.stock_id;
                   pObj.StockProductList= sp.Get_stock_by_sid(connString);
                   ProductList.Add(pObj);
               }
               conn.Close();


               return ProductList;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public BusinessObjects.Purchase GetOneStockbyInvoiceID(string connString, string invoice)
       {

           try
           {

               string query = @"select stock_id,sup_name, s_date,invoice_no from Purchase where invoice_no='" + invoice + "'";
               ;
               SqlConnection conn = DBHelper.GetConnection(connString);
               conn.Open();
               BusinessObjects.Purchase pObj = new BusinessObjects.Purchase();
               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {

                   pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                   pObj.sup_name = reader[1].ToString();
                   pObj.s_date = Convert.ToDateTime(reader[2].ToString());
                   pObj.invoice_no = reader[3].ToString();

                   pObj.grandTotal = getGrandTotal_New(pObj.stock_id, connString);
                 
               }
               conn.Close();
               return pObj;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public decimal getGrandTotal(int stockID, string connString)
       {


           decimal Gprice = 0;
                 string query = @"exec getProdIDbyPurchaseID  " + stockID + "";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    Gprice+= Convert.ToDecimal(reader[4].ToString());
                }
                conn.Close();


                return Gprice;
       }

       public decimal getGrandTotal_New(int stockID, string connString)//This is after stock routing update... (Getting stock product price from table it self instead of getting price from product table to calculate total )
       {


           decimal Gprice = 0;
           string query = @"exec getPurcahseProduct_ByPurchaseID  " + stockID + "";
           SqlConnection conn = DBHelper.GetConnection(connString);

           conn.Open();

           SqlDataReader reader = DBHelper.ReadData(query, conn);
           while (reader.Read())
           {
               Gprice += Convert.ToDecimal(reader[4].ToString());
           }
           conn.Close();


           return Gprice;
       }


       public List<BusinessObjects.Purchase> GetOneStockbySupName(string connString, string supName)
       {

           try
           {

               string query = @"select stock_id,sup_name, s_date,invoice_no from Purchase where sup_name='" + supName + "'";
               ;
               SqlConnection conn = DBHelper.GetConnection(connString);
               conn.Open();
               
               List<BusinessObjects.Purchase> ObjList = new List<Purchase>();
               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {
                    BusinessObjects.Purchase pObj = new BusinessObjects.Purchase();
                   pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                   pObj.sup_name = reader[1].ToString();
                   pObj.s_date = Convert.ToDateTime(reader[2].ToString());
                   pObj.invoice_no = reader[3].ToString();
                   pObj.grandTotal = getGrandTotal_New(pObj.stock_id, connString);
                   ObjList.Add(pObj);

               }
               conn.Close();
               return ObjList;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public List<BusinessObjects.Purchase> GetPurchaseByCatID(string connString, int catID)
       {

           try
           {
               string query = @"exec dbo.getPurchaseByCatID " + catID + " ";
           //    string query = @"select stock_id,sup_name, s_date,invoice_no from _Stokc where stock_id=" + stock_id + "";
               ;
               SqlConnection conn = DBHelper.GetConnection(connString);
               conn.Open();
               List<BusinessObjects.Purchase> sList = new List<Purchase>();
               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {
                   BusinessObjects.Purchase pObj = new BusinessObjects.Purchase();

                   pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                   pObj.sup_name = reader[1].ToString();
                   pObj.s_date = Convert.ToDateTime(reader[2].ToString());
                   pObj.invoice_no = reader[3].ToString();
                   pObj.grandTotal = getGrandTotal_New(pObj.stock_id, connString);

                   sList.Add(pObj);
               }
               conn.Close();
               return sList;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public List<BusinessObjects.Purchase> GetPurchaseByPname(string connString, string pName)
       {

           try
           {
               
    
               string query = @"exec dbo.getPurchaseByProdName '" + pName + "' ";
           //    string query = @"select stock_id,sup_name, s_date,invoice_no from _Stokc where stock_id=" + stock_id + "";
               ;
               SqlConnection conn = DBHelper.GetConnection(connString);
               conn.Open();
               List<BusinessObjects.Purchase> sList = new List<Purchase>();
               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {
                   BusinessObjects.Purchase pObj = new BusinessObjects.Purchase();

                   pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                   pObj.sup_name = reader[1].ToString();
                   pObj.s_date = Convert.ToDateTime(reader[2].ToString());
                   pObj.invoice_no = reader[3].ToString();
                   pObj.grandTotal = getGrandTotal_New(pObj.stock_id, connString);

                   sList.Add(pObj);
               }
               conn.Close();
               return sList;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }



       public BusinessObjects.Purchase GetPurchaseAndPProdBySID(string connString, int StokcID)
       {

           try
           {
               string query = "select stock_id,sup_name, s_date,invoice_no from Purchase where stock_id="+StokcID+"";

               SqlConnection conn = DBHelper.GetConnection(connString);

               conn.Open();
               BusinessObjects.Purchase pObj = new BusinessObjects.Purchase();
               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {
                   
                   pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                   pObj.sup_name = reader[1].ToString();
                   pObj.s_date = Convert.ToDateTime(reader[2].ToString());
                   pObj.invoice_no = reader[3].ToString();
                   // pObj.grandTotal = getGrandTotal(pObj.stock_id, connString);
                   pObj.grandTotal = getGrandTotal_New(pObj.stock_id, connString);
                   //retreiving relevant stock_product detail based on stock id
                   BusinessObjects.purchase_product sp = new purchase_product();
                   sp.stock_id = pObj.stock_id;
                   pObj.StockProductList = sp.Get_stock_by_sid(connString);
                   
               }
               conn.Close();
               return pObj;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public BusinessObjects.Purchase GetPurchaseByStockID(string connString, int StokcID)
       {

           try
           {
               string query = "select stock_id,sup_name, s_date,invoice_no from Purchase where stock_id=" + StokcID + "";

               SqlConnection conn = DBHelper.GetConnection(connString);

               conn.Open();
               BusinessObjects.Purchase pObj = new BusinessObjects.Purchase();
               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {

                   pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                   pObj.sup_name = reader[1].ToString();
                   pObj.s_date = Convert.ToDateTime(reader[2].ToString());
                   pObj.invoice_no = reader[3].ToString();
                   // pObj.grandTotal = getGrandTotal(pObj.stock_id, connString);
                   pObj.grandTotal = getGrandTotal_New(pObj.stock_id, connString);
               }
               conn.Close();
               return pObj;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }
   
   }
}
