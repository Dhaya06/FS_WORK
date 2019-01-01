using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessCommon;
using System.Data.SqlClient;

namespace BusinessObjects
{
  public  class sales_product
    {
     public int  p_id {set;get;}
     public int sales_id {set;get;}
     public int quantity {set;get;}
     public decimal price { set; get; }
     public decimal total { set; get; }
     public string pname { set; get; }
      public string warranty {set;get;}
      public DateTime dateTime { set; get; }

      public string[] getWarranty(string connString, int pid)
      {

          try
          {



              string query = @"select warranty,name from _Product where  ID=" + pid + "";

              SqlConnection conn = DBHelper.GetConnection(connString);

              conn.Open();
              string[] result=new string[2] ;
              SqlDataReader reader = DBHelper.ReadData(query, conn);
              while (reader.Read())
              {
                  BusinessObjects.M_Product_BS pObj = new BusinessObjects.M_Product_BS();

                  result[0]= reader[0].ToString();
                  result[1]=reader[1].ToString() ;




              }
              conn.Close();


              return result;
          }
          catch (Exception ex)
          {

              throw ex;
          }

      }


      public bool Add(string connString)
     {
         try
         {
             string query = @"insert sales_product (p_id, sales_id,quantity,price,total,pname,warranty) 
                                Values(" + p_id + "," + sales_id + "," + quantity 
                                         + ","+price+","+total+",'"+pname+"','"+warranty+"')";

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




     public bool Update(string connString)
     {
         try
         {

             string query = @"Update sales_product set quantity=" + quantity
                             + ",price="+price+",total="+total+" where p_id=" + p_id + " AND sales_id=" + sales_id + " ";

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




     public List<BusinessObjects.sales_product> getSales_Product(string connString)
     {

         try
         {

             List<BusinessObjects.sales_product> ProductList = new List<BusinessObjects.sales_product>();
             string query = @"select p_id,sales_id,quantity,price,total,pname,warranty from sales_product";

             SqlConnection conn = DBHelper.GetConnection(connString);

             conn.Open();

             SqlDataReader reader = DBHelper.ReadData(query, conn);
             while (reader.Read())
             {
                 BusinessObjects.sales_product pObj = new BusinessObjects.sales_product();

                 pObj.p_id = Convert.ToInt32(reader[0].ToString());
                 pObj.sales_id =  Convert.ToInt32(reader[1].ToString());
                 pObj.quantity = Convert.ToInt32(reader[2].ToString());
                 pObj.price = Convert.ToDecimal(reader[3].ToString());
                 pObj.total = Convert.ToDecimal(reader[4].ToString());
                 pObj.pname = reader[5].ToString();
                 pObj.warranty = reader[6].ToString();

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


     public List<BusinessObjects.sales_product> getSales_Product_BySID(string connString, int SID)
     {

         try
         {

             List<BusinessObjects.sales_product> ProductList = new List<BusinessObjects.sales_product>();
             string query = @"select p_id,sales_id,quantity,price,total,pname,warranty from sales_product where sales_id= "+SID+"";

             SqlConnection conn = DBHelper.GetConnection(connString);

             conn.Open();

             SqlDataReader reader = DBHelper.ReadData(query, conn);
             while (reader.Read())
             {
                 BusinessObjects.sales_product pObj = new BusinessObjects.sales_product();

                 pObj.p_id = Convert.ToInt32(reader[0].ToString());
                 pObj.sales_id = Convert.ToInt32(reader[1].ToString());
                 pObj.quantity = Convert.ToInt32(reader[2].ToString());
                 pObj.price = Convert.ToDecimal(reader[3].ToString());
                 pObj.total = Convert.ToDecimal(reader[4].ToString());
                 pObj.pname = reader[5].ToString();
                 pObj.warranty = reader[6].ToString();


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


     public BusinessObjects.sales_product getSales_Product_BySID_for_SalesReturn(string connString, int SID, int pid)
     {

         try
         {

           //  List<BusinessObjects.sales_product> ProductList = new List<BusinessObjects.sales_product>();
             string query = @"select p_id,sales_id,quantity,price,total,pname,warranty,date_ from sales_product where sales_id= " + SID + " AND p_id="+pid+" ";

             SqlConnection conn = DBHelper.GetConnection(connString);

             conn.Open();
            BusinessObjects.sales_product pObj = new BusinessObjects.sales_product();
             SqlDataReader reader = DBHelper.ReadData(query, conn);
             while (reader.Read())
             {
                 

                 pObj.p_id = Convert.ToInt32(reader[0].ToString());
                 pObj.sales_id = Convert.ToInt32(reader[1].ToString());
                 pObj.quantity = Convert.ToInt32(reader[2].ToString());
                 pObj.price = Convert.ToDecimal(reader[3].ToString());
                 pObj.total = Convert.ToDecimal(reader[4].ToString());
                 pObj.pname = reader[5].ToString();
                 pObj.warranty = reader[6].ToString();
                 pObj.dateTime = Convert.ToDateTime(reader[7].ToString());


                 //ProductList.Add(pObj);
             }
             conn.Close();


             return pObj;
         }
         catch (Exception ex)
         {

             throw ex;
         }

     }
     public List<sales_product> getSales_ProductByCatID(string con, int catID)
     {

         try
         {

             List<BusinessObjects.sales_product> ProductList = new List<BusinessObjects.sales_product>();
             string query = @"exec getSalesByCatID " + catID + "";

             SqlConnection conn = DBHelper.GetConnection(con);

             conn.Open();

             SqlDataReader reader = DBHelper.ReadData(query, conn);
             while (reader.Read())
             {
                 BusinessObjects.sales_product pObj = new BusinessObjects.sales_product();

                 pObj.p_id = Convert.ToInt32(reader[0].ToString());
                 pObj.sales_id = Convert.ToInt32(reader[1].ToString());
                 pObj.quantity = Convert.ToInt32(reader[2].ToString());
                 pObj.price = Convert.ToDecimal(reader[3].ToString());
                 pObj.total = Convert.ToDecimal(reader[4].ToString());




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




     public bool UpdateSalesReturn(string connString, int SID, int pid, int quantity, decimal totalcc)
     {
         try
         {
             string query = @"Update sales_product set quantity= " + quantity + ", total =" + totalcc + " where sales_id= " + SID + " AND p_id=" + pid + " ";
             

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

     public bool DeleteSalesReturn(string connString, int SID, int pid)
     {
         try
         {
             string query = "Delete from sales_product where sales_id= " + SID + " AND p_id=" + pid + "";
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


    }
}
