using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCommon;
using System.Data.SqlClient;
using BusinessObjects;
namespace BusinessObjects
{
   public class InitializeStarter
   {


       public void initializer(string conn)
       {
           try
           {

          
           delete0Quantity(conn);
           delete0Stock(conn);
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       private bool delete0Quantity(string connString)
       {
           try
           {


               string query = @"delete  from _stock_product where quantity <1";

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

       private void delete0Stock(string con)
       {
           try
           {



               List<BusinessObjects.Stock> stocklist = new List<Stock>();


               stocklist = Get0StockList(con);
           
               foreach (BusinessObjects.Stock item in stocklist)
               {
                   
                   string quer = @"select count(*) from _stock_product where stock_id="+item.stock_id+"";

                   int count= (int)DBHelper.GetScaler(quer, con);

                   if (count < 1)
                   {
                       string query = @"delete from _Stokc where stock_id= "+item.stock_id+"";
                       DBHelper.ExecuteNonQuery(query, con);
                   }
               }

               
           }
           catch (Exception ex)
           {

               throw ex;
           }
        
       }



       private List<BusinessObjects.Stock> Get0StockList(string connString)
       {

           try
           {



               List<BusinessObjects.Stock> ProductList = new List<BusinessObjects.Stock>();
               string query = "select stock_id,sup_name, s_date,invoice_no from _Stokc";

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


                   //retreiving relevant stock_product detail based on stock id
                   BusinessObjects.stock_product sp = new stock_product();
                   sp.stock_id = pObj.stock_id;
                   pObj.StockProductList = sp.Get_stock_by_sid(connString);
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
