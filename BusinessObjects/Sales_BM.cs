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
   public class Sales_BM
    {
        public int sales_id {set;get;}
        public string customer_name {set;get;}
        public decimal total {set;get;}
        public DateTime date_time {set;get;}
       public decimal credit {set;get;}
       public decimal paid { get; set; }
       public int customerID { set; get; }
        

        public bool Add(string connString)
        {
            try
            {
//                date_time.ToString("G",DateTimeFormatInfo.InvariantInfo)
//                string query = @"insert _Sales (customer_name, total,date_time,paid,credit) 
//                Values('" + customer_name + "'," + total + ",'" + date_time.ToString("dd-MMM-yyyy") + "'," + paid
//                          +","+credit+")";


                string query = @"insert _Sales (customer_name, total,date_time,paid,credit,customerID) 
                   Values('" + customer_name + "'," + total + ",'" + date_time.ToString("G", DateTimeFormatInfo.InvariantInfo) + "'," + paid
                          + "," + credit + "," + customerID + ")";

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
                string query = @"Update _Sales set customer_name='" + customer_name
                                + "',total=" + total
                                + ",date_time='" + date_time.ToString("G", DateTimeFormatInfo.InvariantInfo) + "' where sales_id=" + sales_id + "";
                                   
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
       public bool UpdateCredit(string connString, decimal cred)
       {
           try
           {
               string query = @"Update _Sales set credit= credit-"+cred+"   where sales_id=" + sales_id + "";

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
                string query = "Delete from _Sales where sales_id=" + sales_id + " ";
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

      

        public BusinessObjects.Sales_BM getSalesByID(string connString)
        {

            try
            {



                string query = "select customer_name,total, date_time,sales_id,credit,paid,customerID from _Sales WHERE sales_id= " + sales_id + "";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();
                BusinessObjects.Sales_BM pObj = new BusinessObjects.Sales_BM();
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                   
                    pObj.sales_id = Convert.ToInt32(reader[3].ToString());
                    pObj.total = Convert.ToDecimal(reader[1].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[2].ToString());
                    pObj.customer_name = reader[0].ToString();
                    pObj.credit = Convert.ToDecimal(reader[4].ToString());
                    pObj.paid = Convert.ToDecimal(reader[5].ToString());
                    pObj.customerID = Convert.ToInt32(reader[6].ToString());

                    
                }
                conn.Close();


                return pObj;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public int ScopeIdentity(string connString)
        {

            try
            {


                int identity = 0;
                string query = @"SELECT SCOPE_IDENTITY() as inserted";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    identity = Convert.ToInt32(reader[0].ToString());


                }
                conn.Close();


                return identity;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public List<BusinessObjects.Sales_BM> getSalesByCatID(string connString, int catID)
        {

            try
            {



                List<BusinessObjects.Sales_BM> ProductList = new List<BusinessObjects.Sales_BM>();
                string query = @"exec getSalesByCatID " + catID + "";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.Sales_BM pObj = new BusinessObjects.Sales_BM();
                    pObj.sales_id = Convert.ToInt32(reader[0].ToString());
                    pObj.total = Convert.ToDecimal(reader[2].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[4].ToString());
                    pObj.customer_name = reader[1].ToString();
                    pObj.credit = Convert.ToDecimal(reader[3].ToString());
                    pObj.paid = Convert.ToDecimal(reader[5].ToString());


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


         public List<BusinessObjects.Sales_BM> getSalesByP_Name(string connString, string p_nameS)
        {

            try
            {



                List<BusinessObjects.Sales_BM> ProductList = new List<BusinessObjects.Sales_BM>();
                string query = @"exec getSalesByProductName '" + p_nameS + "' ";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.Sales_BM pObj = new BusinessObjects.Sales_BM();
                    pObj.sales_id = Convert.ToInt32(reader[0].ToString());
                    pObj.total = Convert.ToDecimal(reader[2].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[4].ToString());
                    pObj.customer_name = reader[1].ToString();
                    pObj.credit = Convert.ToDecimal(reader[3].ToString());
                    pObj.paid = Convert.ToDecimal(reader[5].ToString());


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

         public List<BusinessObjects.Sales_BM> getSalesByC_Name(string connString, string c_nameS)
         {

             try
             {



                 List<BusinessObjects.Sales_BM> ProductList = new List<BusinessObjects.Sales_BM>();
                 string query = @"select customer_name,total, date_time,sales_id,credit,paid from _Sales WHERE customer_name= '" + c_nameS + "'";

                 SqlConnection conn = DBHelper.GetConnection(connString);

                 conn.Open();
                 
                 SqlDataReader reader = DBHelper.ReadData(query, conn);
                 while (reader.Read())
                 {BusinessObjects.Sales_BM pObj = new BusinessObjects.Sales_BM();

                     pObj.sales_id = Convert.ToInt32(reader[3].ToString());
                     pObj.total = Convert.ToDecimal(reader[1].ToString());
                     pObj.date_time = Convert.ToDateTime(reader[2].ToString());
                     pObj.customer_name = reader[0].ToString();
                     pObj.credit = Convert.ToDecimal(reader[4].ToString());
                     pObj.paid = Convert.ToDecimal(reader[5].ToString());
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

        public List<BusinessObjects.Sales_BM> getSales(string connString)
        {

            try
            {



                List<BusinessObjects.Sales_BM> ProductList = new List<BusinessObjects.Sales_BM>();
                string query = "select customer_name,total, date_time,sales_id,credit,paid from _Sales ";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.Sales_BM pObj = new BusinessObjects.Sales_BM();
                    pObj.sales_id = Convert.ToInt32(reader[3].ToString());
                    pObj.total = Convert.ToDecimal(reader[1].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[2].ToString());
                    pObj.customer_name = reader[0].ToString();
                    pObj.credit = Convert.ToDecimal(reader[4].ToString());
                    pObj.paid = Convert.ToDecimal(reader[5].ToString());


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


        public List<BusinessObjects.Sales_BM> getSalesForChart(string connString, DateTime sDate, DateTime eDate)
        {

            try
            {



                List<BusinessObjects.Sales_BM> ProductList = new List<BusinessObjects.Sales_BM>();
                string query = "select customer_name,total, date_time,sales_id,credit,paid from _Sales ";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.Sales_BM pObj = new BusinessObjects.Sales_BM();
                    pObj.sales_id = Convert.ToInt32(reader[3].ToString());
                    pObj.total = Convert.ToDecimal(reader[1].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[2].ToString());
                    pObj.customer_name = reader[0].ToString();
                    pObj.credit = Convert.ToDecimal(reader[4].ToString());
                    pObj.paid = Convert.ToDecimal(reader[5].ToString());


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


        public List<BusinessObjects.Sales_BM> getSalesCreditors(string connString)
        {

            try
            {



                List<BusinessObjects.Sales_BM> ProductList = new List<BusinessObjects.Sales_BM>();

                int ia = 0;
                string query = "select customer_name,total, date_time,sales_id,credit,paid from _Sales where credit > "+ia+" ";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.Sales_BM pObj = new BusinessObjects.Sales_BM();
                    pObj.sales_id = Convert.ToInt32(reader[3].ToString());
                    pObj.total = Convert.ToDecimal(reader[1].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[2].ToString());
                    pObj.customer_name = reader[0].ToString();
                    pObj.credit = Convert.ToDecimal(reader[4].ToString());
                    pObj.paid = Convert.ToDecimal(reader[5].ToString());


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


        public List<BusinessObjects.Sales_BM> getSalesByDateCredit(string connString, DateTime sdate, DateTime eDate)
        {

            try
            {
                //  toString("dd-MMM-yyyy"), 

               
                List<BusinessObjects.Sales_BM> ProductList = new List<BusinessObjects.Sales_BM>();
                string query = @"select customer_name,total, date_time,sales_id,credit,paid from _Sales
                where credit > 0 and  date_time between '" + sdate.ToString("dd-MMM-yyyy") + "' AND '" + eDate.ToString("dd-MMM-yyyy") + "' ";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.Sales_BM pObj = new BusinessObjects.Sales_BM();
                    pObj.sales_id = Convert.ToInt32(reader[3].ToString());
                    pObj.total = Convert.ToDecimal(reader[1].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[2].ToString());
                    pObj.customer_name = reader[0].ToString();
                    pObj.credit = Convert.ToDecimal(reader[4].ToString());
                    pObj.paid = Convert.ToDecimal(reader[5].ToString());


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




        public List<BusinessObjects.Sales_BM> getSalesByDate(string connString, DateTime sdate, DateTime eDate)
        {

            try
            {
              //  toString("dd-MMM-yyyy"), 


                List<BusinessObjects.Sales_BM> ProductList = new List<BusinessObjects.Sales_BM>();
                string query = @"select customer_name,total, date_time,sales_id,credit,paid from _Sales
                where date_time between '"+sdate.ToString("dd-MMM-yyyy")+"' AND '"+eDate.ToString("dd-MMM-yyyy")+"' ";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.Sales_BM pObj = new BusinessObjects.Sales_BM();
                    pObj.sales_id = Convert.ToInt32(reader[3].ToString());
                    pObj.total = Convert.ToDecimal(reader[1].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[2].ToString());
                    pObj.customer_name = reader[0].ToString();
                    pObj.credit = Convert.ToDecimal(reader[4].ToString());
                    pObj.paid = Convert.ToDecimal(reader[5].ToString());


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

        public BusinessObjects.Sales_BM getSalesByIDSalesReturn(string connString, int salesID)
        {

            try
            {



                string query = "select customer_name,total, date_time,sales_id,credit,paid from _Sales WHERE sales_id= " + salesID + "";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();
                BusinessObjects.Sales_BM pObj = new BusinessObjects.Sales_BM();
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    pObj.sales_id = Convert.ToInt32(reader[3].ToString());
                    pObj.total = Convert.ToDecimal(reader[1].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[2].ToString());
                    pObj.customer_name = reader[0].ToString();
                    pObj.credit = Convert.ToDecimal(reader[4].ToString());
                    pObj.paid = Convert.ToDecimal(reader[5].ToString());


                }
                conn.Close();


                return pObj;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool UpdateSalesReturn(string connString,decimal totalSR, decimal creditSR)
        {
            try
            {
                string query = @"Update _Sales set total=" + totalSR
                                + ",credit=" + creditSR + " where sales_id=" + sales_id + "";

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
