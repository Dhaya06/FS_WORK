using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCommon;
using System.Data.SqlClient;

namespace BusinessObjects
{
   public class stock_product
    {
        public int pid {set;get;} 
        public int stock_id {set;get;}
        public int quantity {get;set;}
        public string p_name { get; set; }
       //this is not price. actually this is cost
        public decimal price { get; set; }


       public bool Add(string connString)
       {
           try
           {

               string query = @"insert _stock_product (pid, stock_id,quantity,price) 
                                Values(" + pid + "," + stock_id + "," + quantity + "," + price + ")";


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


       public int GetOutOfStock(string connString)
       {
            try
           {
           string query = @"select count(*) from _Product where ID not in (select distinct(pid) from _stock_product)";
           int count = 0;
           if (getScalar(connString, query) != DBNull.Value)
           {
               count = Convert.ToInt32(getScalar(connString, query));
           }
           return count;
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

               string query = @"Update _stock_product set quantity=" + quantity
                               + " where stock_id=" + stock_id + " AND pid=" + pid + " ";

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

       public bool Delete_stock_by_sid_pid(string connString)
       {
           try
           {
               string query = "Delete from _stock_product where stock_id=" + stock_id + "  AND pid=" + pid + " ";
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

       public bool Deletestock_by_stockID(string connString)
       {
           try
           {
               string query = "Delete from _stock_product where stock_id=" + stock_id + "  ";
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

       public List<BusinessObjects.stock_product> Get_stock_by_pid(string connString)
       {

           try
           {


              
               List<BusinessObjects.stock_product> ProductList = new List<BusinessObjects.stock_product>();
               string query = "select pid,stock_id, quantity, price from _stock_product WHERE pid= "+pid+"";

               SqlConnection conn = DBHelper.GetConnection(connString);

               conn.Open();

               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {
                   BusinessObjects.stock_product pObj = new BusinessObjects.stock_product();
                   pObj.pid = Convert.ToInt32(reader[0].ToString());
                   pObj.stock_id = Convert.ToInt32(reader[1].ToString());
                   pObj.quantity = Convert.ToInt32(reader[2].ToString());
                   pObj.price = Convert.ToDecimal(reader[3].ToString());


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


 

       public List<BusinessObjects.stock_product> Get_stock_by_sid(string connString)
       {

           try
           {



               List<BusinessObjects.stock_product> ProductList = new List<BusinessObjects.stock_product>();
               string query = "select pid,stock_id, quantity, price from _stock_product WHERE stock_id= " + stock_id + "";

               SqlConnection conn = DBHelper.GetConnection(connString);

               conn.Open();

               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {
                   BusinessObjects.stock_product pObj = new BusinessObjects.stock_product();
                   pObj.pid = Convert.ToInt32(reader[0].ToString());
                   pObj.stock_id = Convert.ToInt32(reader[1].ToString());
                   pObj.quantity = Convert.ToInt32(reader[2].ToString());
                   pObj.price = Convert.ToDecimal(reader[3].ToString());


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

       public List<BusinessObjects.stock_product> Get_all_List(string connString)
       {

           try
           {



               List<BusinessObjects.stock_product> ProductList = new List<BusinessObjects.stock_product>();
               string query = "select pid,stock_id, quantity,price from _stock_product ";

               SqlConnection conn = DBHelper.GetConnection(connString);

               conn.Open();

               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {
                   BusinessObjects.stock_product pObj = new BusinessObjects.stock_product();
                   pObj.pid = Convert.ToInt32(reader[0].ToString());
                   pObj.stock_id = Convert.ToInt32(reader[1].ToString());
                   pObj.quantity = Convert.ToInt32(reader[2].ToString());
                   pObj.price = Convert.ToDecimal(reader[3].ToString());



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

       }
}
