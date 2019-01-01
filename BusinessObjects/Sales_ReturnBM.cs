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
    public class Sales_ReturnBM
    {
        public int sales_id { set; get; }
        public string customer_name { set; get; }
        public decimal total { set; get; }
        public DateTime date_time { set; get; }
        public decimal sales_return_id { set; get; }
        public decimal paid { get; set; }



      
    

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



       
     


        public BusinessObjects.Sales_ReturnBM getSalesReturnsByID(string connString, int salesID)
        {

            try
            {



                string query = "select sales_return_id, sales_id, Total, _date, customer, paid from sales_return WHERE sales_id= " + salesID + "";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();
                BusinessObjects.Sales_ReturnBM pObj = new BusinessObjects.Sales_ReturnBM();
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    pObj.sales_return_id = Convert.ToInt32(reader[0].ToString());
                    pObj.sales_id = Convert.ToInt32(reader[1].ToString());
                    pObj.total = Convert.ToDecimal(reader[2].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[3].ToString());
                    pObj.customer_name = reader[4].ToString();
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

        public List<BusinessObjects.Sales_ReturnBM> getSalesReturns(string connString)
        {

            try
            {



                string query = "select sales_return_id, sales_id, Total, _date, customer, paid from sales_return";

                SqlConnection conn = DBHelper.GetConnection(connString);
                List<BusinessObjects.Sales_ReturnBM> pObjList = new List<Sales_ReturnBM>();
                conn.Open();
                
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.Sales_ReturnBM pObj = new BusinessObjects.Sales_ReturnBM();
                    pObj.sales_return_id = Convert.ToInt32(reader[0].ToString());
                    pObj.sales_id = Convert.ToInt32(reader[1].ToString());
                    pObj.total = Convert.ToDecimal(reader[2].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[3].ToString());
                    pObj.customer_name = reader[4].ToString();
                    pObj.paid = Convert.ToDecimal(reader[5].ToString());

                    pObjList.Add(pObj);
                }
                conn.Close();


                return pObjList;
                          
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<BusinessObjects.Sales_ReturnBM> getSalesReturnsByDate(string connString, DateTime startDate, DateTime endDate)
        {

            try
            {



                string query = @"select sales_return_id, sales_id, Total, _date, customer, paid from sales_return where sales_id in 
                                (select sales_id from sales_return_products where _date  between '" + startDate.ToString("dd-MMM-yyyy") + "' AND '" + endDate.ToString("dd-MMM-yyyy") + "')";

                SqlConnection conn = DBHelper.GetConnection(connString);
                List<BusinessObjects.Sales_ReturnBM> pObjList = new List<Sales_ReturnBM>();
                conn.Open();
                
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.Sales_ReturnBM pObj = new BusinessObjects.Sales_ReturnBM();
                    pObj.sales_return_id = Convert.ToInt32(reader[0].ToString());
                    pObj.sales_id = Convert.ToInt32(reader[1].ToString());
                    pObj.total = Convert.ToDecimal(reader[2].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[3].ToString());
                    pObj.customer_name = reader[4].ToString();
                    pObj.paid = Convert.ToDecimal(reader[5].ToString());

                    pObjList.Add(pObj);
                }
                conn.Close();


                return pObjList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public List<BusinessObjects.Sales_ReturnBM> getSalesReturnByCatID(string connString, int catID)
        {

            try
            {



                List<BusinessObjects.Sales_ReturnBM> ProductList = new List<BusinessObjects.Sales_ReturnBM>();
                string query = @"exec getSalesReturnByCarID " + catID + "";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.Sales_ReturnBM pObj = new BusinessObjects.Sales_ReturnBM();
                    pObj.sales_return_id = Convert.ToInt32(reader[3].ToString());
                    pObj.sales_id = Convert.ToInt32(reader[0].ToString());
                    pObj.total = Convert.ToDecimal(reader[2].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[4].ToString());
                    pObj.customer_name = reader[1].ToString();
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


        public List<BusinessObjects.Sales_ReturnBM> getSalesReturnByP_Name(string connString, string p_nameS)
        {
           
            try
            {



                List<BusinessObjects.Sales_ReturnBM> ProductList = new List<BusinessObjects.Sales_ReturnBM>();
                string query = @"exec getSalesReturnByProductName '" + p_nameS + "' ";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.Sales_ReturnBM pObj = new BusinessObjects.Sales_ReturnBM();
                    pObj.sales_return_id = Convert.ToInt32(reader[3].ToString());
                    pObj.sales_id = Convert.ToInt32(reader[0].ToString());
                    pObj.total = Convert.ToDecimal(reader[2].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[4].ToString());
                    pObj.customer_name = reader[1].ToString();
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

        public List<BusinessObjects.Sales_ReturnBM> getSalesReturnByCustName(string connString, string CustName)
        {

            try
            {



                List<BusinessObjects.Sales_ReturnBM> ProductList = new List<BusinessObjects.Sales_ReturnBM>();
                string query = "select sales_return_id, sales_id, Total, _date, customer, paid from sales_return where customer= '" + CustName + "'";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.Sales_ReturnBM pObj = new BusinessObjects.Sales_ReturnBM();
                    pObj.sales_return_id = Convert.ToInt32(reader[0].ToString());
                    pObj.sales_id = Convert.ToInt32(reader[1].ToString());
                    pObj.total = Convert.ToDecimal(reader[2].ToString());
                    pObj.date_time = Convert.ToDateTime(reader[3].ToString());
                    pObj.customer_name = reader[4].ToString();
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

        

        


    }
}
