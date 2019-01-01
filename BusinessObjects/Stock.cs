using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCommon;
using System.Data.SqlClient;
using System.Globalization;
namespace BusinessObjects
{
   public class Stock
    {

       public int stock_id  {set;get;}
       public string sup_name { get; set; }
       public DateTime s_date {get;set;}
       public string invoice_no {get;set;}
       public List<stock_product> StockProductList { get; set; }
       public int Sup_id { get; set; }

       public bool Add(string connString)
       {
           try
           {
                
//               string query = @"insert _Stokc (sup_name, s_date,invoice_no) 
//                                Values('" + sup_name + "','" + s_date.ToString("dd-MMM-yyyy") + "','" + invoice_no + "' )";
               string query = @"insert _Stokc (sup_name, s_date,invoice_no, Sup_id) 
                                Values('" + sup_name + "','" + s_date.ToString("G", DateTimeFormatInfo.InvariantInfo) + "','" + invoice_no + "', "+Sup_id+" )";


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
               
               string query = @"Update _Stokc set sup_name='" + sup_name
                               + "',s_date='" + s_date.ToString("G", DateTimeFormatInfo.InvariantInfo)
                               + "',invoice_no='" + invoice_no
                               + "', Sup_id=" + Sup_id + "  where stock_id=" + stock_id + "";

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
               string query = "Delete from _Stokc where stock_id=" + stock_id + "";
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

       public List<BusinessObjects.Stock> GetStockList(string connString)
       {
           try
           {
              List<BusinessObjects.Stock> ProductList = new List<BusinessObjects.Stock>();
              string query = "select stock_id,sup_name, s_date,invoice_no,Sup_id from _Stokc";

               SqlConnection conn = DBHelper.GetConnection(connString);

               conn.Open();

               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {
                   BusinessObjects.Stock pObj = new BusinessObjects.Stock();
                   pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                   pObj.sup_name = reader[1].ToString();
                   pObj.s_date = Convert.ToDateTime(reader[2].ToString());
                   pObj.invoice_no = reader[3].ToString();
                   pObj.Sup_id = Convert.ToInt32(reader[4].ToString()); 

                   //retreiving relevant stock_product detail based on stock id
                   BusinessObjects.stock_product sp = new stock_product();
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


       public List<BusinessObjects.Stock> GetStockListByPIDSalesReturn(string connString, int pids)
       {

           try
           {



               List<BusinessObjects.Stock> ProductList = new List<BusinessObjects.Stock>();
               //string query = "select stock_id,sup_name, s_date,invoice_no from _Stokc";
               string query = @"select stock_id, sup_name, s_date,invoice_no, Sup_id from _Stokc where stock_id in(select distinct(stock_id) from _stock_product where pid=" + pids + ")";
               SqlConnection conn = DBHelper.GetConnection(connString);

               conn.Open();

               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {
                   BusinessObjects.Stock pObj = new BusinessObjects.Stock();
                   pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                   pObj.sup_name = reader[1].ToString();
                   pObj.s_date = Convert.ToDateTime(reader[2].ToString());
                   pObj.invoice_no = reader[3].ToString();
                   pObj.Sup_id = Convert.ToInt32(reader[4].ToString());

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


       public BusinessObjects.Stock GetOneStock(string connString)
       {

           try
           {

               string query = @"select stock_id,sup_name, s_date,invoice_no, Sup_id from _Stokc where stock_id=" + stock_id + "";
               ;
               SqlConnection conn = DBHelper.GetConnection(connString);
               conn.Open();
               BusinessObjects.Stock pObj = new BusinessObjects.Stock();
               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {

                   pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                   pObj.sup_name = reader[1].ToString();
                   pObj.s_date = Convert.ToDateTime(reader[2].ToString());
                   pObj.invoice_no = reader[3].ToString();
                   pObj.Sup_id = Convert.ToInt32(reader[4].ToString());
               }
               conn.Close();
               return pObj;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public List<BusinessObjects.Stock> GetOneStockByCatID(string connString, int catID)
       {

           try
           {
               string query = @"exec dbo.getProdIDByCatID " + catID + " ";
           //    string query = @"select stock_id,sup_name, s_date,invoice_no from _Stokc where stock_id=" + stock_id + "";
               ;
               SqlConnection conn = DBHelper.GetConnection(connString);
               conn.Open();
               List<BusinessObjects.Stock> sList = new List<Stock>();
               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {BusinessObjects.Stock pObj = new BusinessObjects.Stock();

                   pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                   pObj.sup_name = reader[1].ToString();
                   pObj.s_date = Convert.ToDateTime(reader[2].ToString());
                   pObj.invoice_no = reader[3].ToString();
                   pObj.Sup_id = Convert.ToInt32(reader[4].ToString());
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
   
   
   }
}
