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
    public class SalesReturn
    {
        public int p_id { set; get; }
        public int sales_id { set; get; }
        public int quantity { set; get; }
        public decimal price { set; get; }
        public decimal total { set; get; }
        public string pname { set; get; }
        public string warranty { set; get; }
        public DateTime dateTime { set; get; }


        public int stock_id { set; get; }
        public string sup_name { get; set; }
        public DateTime stock_date { get; set; }
        public string invoice_no { get; set; }
        public List<stock_product> StockProductListSR { get; set; }


        public List<BusinessObjects.SalesReturn> getOneSalesReturn(string connString)
        {

            try
            {



                List<BusinessObjects.SalesReturn> ProductList = new List<BusinessObjects.SalesReturn>();
                string query = "select stock_id,sup_name, s_date,invoice_no from _Stokc";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.SalesReturn pObj = new BusinessObjects.SalesReturn();
                    pObj.stock_id = Convert.ToInt32(reader[0].ToString());
                    pObj.sup_name = reader[1].ToString();
                    pObj.stock_date = Convert.ToDateTime(reader[2].ToString());
                    pObj.invoice_no = reader[3].ToString();


                    //retreiving relevant stock_product detail based on stock id
                    BusinessObjects.stock_product sp = new stock_product();
                    sp.stock_id = pObj.stock_id;
                    pObj.StockProductListSR = sp.Get_stock_by_sid(connString);
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

        public int GetCountSalesReturn(string connString, int saleID)
        {
            try
            {
                List<BusinessObjects.SalesReturn> ProductList = new List<BusinessObjects.SalesReturn>();
                string query = "select count(*) from sales_return where sales_id = " + saleID + "";
                SqlConnection conn = DBHelper.GetConnection(connString);
                conn.Open();
                int count = 0;
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    count = Convert.ToInt32(reader[0].ToString());
                }
                conn.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int GetCountSalesProduct(string connString, int saleID, int prodID)
        {
            try
            {
                List<BusinessObjects.SalesReturn> ProductList = new List<BusinessObjects.SalesReturn>();
                string query = "select count(*) from sales_return_products where sales_id = " + saleID + " and product_id =" + prodID + "";
                SqlConnection conn = DBHelper.GetConnection(connString);
                conn.Open();
                int count = 0;
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    count = Convert.ToInt32(reader[0].ToString());
                }
                conn.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetQuantitySalesProduct(string connString, int saleID, int prodID)
        {
            try
            {
                List<BusinessObjects.SalesReturn> ProductList = new List<BusinessObjects.SalesReturn>();
                string query = "select quantity from sales_return_products where sales_id = " + saleID + " and product_id =" + prodID + "";
                SqlConnection conn = DBHelper.GetConnection(connString);
                conn.Open();
                int count = 0;
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    count = Convert.ToInt32(reader[0].ToString());
                }
                conn.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int GetCountSalesProductTable(string connString, int saleID)
        {
            try
            {
                List<BusinessObjects.SalesReturn> ProductList = new List<BusinessObjects.SalesReturn>();
                string query = @"select COUNT(*) from sales_product where sales_id=" + saleID + "";
                /*SqlConnection conn = DBHelper.GetConnection(connString);
                conn.Open();
                int count = 0;
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    count = Convert.ToInt32(reader[0].ToString());
                }
                conn.Close();
                return count;*/
                int result = 0;
                object retreived=getScalar(connString, query);
                if (retreived != DBNull.Value)
                {
                    result = (int)retreived;

                }
                return result;

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


        public bool ExecuteNonQuery(string query, string con)
        {
            if (DBHelper.ExecuteNonQuery(query, con) > 0)
                return true;
            else
                return false;
        
        }

    }
}
