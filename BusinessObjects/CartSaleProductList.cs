using DataAccessCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BusinessObjects
{
   public class CartSaleProductList
    {

       //this class is for store product id, price and the quantity of cart item when clicking add button in form billing
       public int product_id { get; set; }
       public int stock_id { get; set; }
       public int quantity { get; set; }
       public decimal cost { get; set; }
       public int salesID { get; set; }
       public string pname { get; set; }

       public bool Add(string connString, int sid)
        {
            try
            {
                //     int,   int , stock_id int,   DECIMAL(15,2) ,  int

                string query = @"insert sales_product_price (sales_id, product_id,cost, quantity, stock_id) 
                                                Values(" + sid + "," + product_id + ",'" + cost + "',"
                                                          + quantity + ","+stock_id+" )";

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

       public List<BusinessObjects.CartSaleProductList> getProduct(string connString, int sid,int pid)
       {

           try
           {
               List<BusinessObjects.CartSaleProductList> ProductList = new List<BusinessObjects.CartSaleProductList>();
               string query = @"select sp.sales_id, sp.product_id,sp.cost, sp.quantity, sp.stock_id, p.name from sales_product_price sp
inner join _Product p  on sp.product_id=p.ID where  sales_id=" + sid + " and product_id=" + pid + "";
               
               SqlConnection conn = DBHelper.GetConnection(connString);

               conn.Open();

               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {
                   BusinessObjects.CartSaleProductList pObj = new BusinessObjects.CartSaleProductList();

                   pObj.salesID = Convert.ToInt32(reader[0].ToString());
                   pObj.product_id =Convert.ToInt32( reader[1].ToString());
                   pObj.cost = Convert.ToDecimal(reader[2].ToString());

                   pObj.quantity = Convert.ToInt32(reader[3].ToString());
                   pObj.stock_id = Convert.ToInt32(reader[4].ToString());
                   pObj.pname = reader[5].ToString();
                  



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
