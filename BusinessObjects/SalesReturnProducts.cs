using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessCommon;
using System.Data.SqlClient;

namespace BusinessObjects
{
    public class SalesReturnProducts
    {
        public int p_id { set; get; }
        public int sales_id { set; get; }
        public int quantity { set; get; }
        public decimal price { set; get; }
        public decimal total { set; get; }
        public string pname { set; get; }

        public DateTime dateTime { set; get; }

        public string[] getWarranty(string connString, int pid)
        {

            try
            {



                string query = @"select warranty,name from _Product where  ID=" + pid + "";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();
                string[] result = new string[2];
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.M_Product_BS pObj = new BusinessObjects.M_Product_BS();

                    result[0] = reader[0].ToString();
                    result[1] = reader[1].ToString();




                }
                conn.Close();


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




        public List<BusinessObjects.SalesReturnProducts> getSalesRetunrProductsBySID(string connString, int sid)
        {

            try
            {

                List<BusinessObjects.SalesReturnProducts> ProductList = new List<BusinessObjects.SalesReturnProducts>();
                string query = @"select srp.product_id, srp.sales_id, srp.quantity, srp.product_sold_price,srp._date, p.name
                                from _Product as p inner join sales_return_products srp on p.ID= srp.product_id
                                where srp.sales_id="+sid+"";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.SalesReturnProducts pObj = new BusinessObjects.SalesReturnProducts();
                    pObj.p_id = Convert.ToInt32(reader[0].ToString());
                    pObj.sales_id = Convert.ToInt32(reader[1].ToString());
                    pObj.quantity = Convert.ToInt32(reader[2].ToString());
                    pObj.price = Convert.ToDecimal(reader[3].ToString());
                    pObj.dateTime = Convert.ToDateTime(reader[4].ToString());
                    pObj.pname = reader[5].ToString();
                    pObj.total = pObj.quantity * pObj.price;

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
