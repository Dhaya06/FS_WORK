using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccessCommon;
namespace BusinessObjects
{
   public class CartStockRoutingList
    {
       //this class is for get the data from stock product according to stock out theory (FIFO, LIFO)
        public int pid{ get; set; }
        public int sid { get; set; }
        public DateTime s_date { get; set; }
        public int qty { get; set; }
        public decimal price { get; set; }


        public List<BusinessObjects.CartStockRoutingList> GetStockList(string connString, int pidArg, string route)
        {
            try
            {

                List<BusinessObjects.CartStockRoutingList> ProductList = new  List<BusinessObjects.CartStockRoutingList>();
                string query = "";
                if (route == "FIFO")
                {
                     query = @"select s.stock_id, s.s_date, sp.pid, sp.quantity, sp.price from _Stokc s inner join _stock_product sp on s.stock_id=sp.stock_id where                          sp.pid= " + pidArg + " order by s.s_date ASC";
                }
                else if (route == "LIFO")
                {
                     query = @"select s.stock_id, s.s_date, sp.pid, sp.quantity, sp.price from _Stokc s inner join _stock_product sp on s.stock_id=sp.stock_id where                          sp.pid= " + pidArg + " order by s.s_date DESC";
                }
                else
                {
                     query = @"select s.stock_id, s.s_date, sp.pid, sp.quantity, sp.price from _Stokc s inner join _stock_product sp on s.stock_id=sp.stock_id where                          sp.pid= " + pidArg + " order by s.s_date ASC";
                }
                
                
                SqlConnection conn = DBHelper.GetConnection(connString);
                conn.Open();
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.CartStockRoutingList pObj = new BusinessObjects.CartStockRoutingList
                    {
                        sid = Convert.ToInt32(reader[0].ToString()),
                        s_date = Convert.ToDateTime(reader[1].ToString()),
                        pid = Convert.ToInt32(reader[2].ToString()),
                        qty = Convert.ToInt32(reader[3].ToString()),
                        price = Convert.ToDecimal(reader[4].ToString())
                    };
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


        public string Get_Stock_Routing(string con)
        {
            try
            {
                string result="FIFO";
                string query = "select name from Stock_Routing where value=1";
                object obj = getScalar(con, query);
                if (obj != DBNull.Value)
                {
                    result = (string)obj;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
    
        
        }
        private object getScalar(string connString, string query)
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

    }
}
