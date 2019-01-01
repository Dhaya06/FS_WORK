using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCommon;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;



namespace BusinessObjects
{
   public class RunningOrder_BS
    {
       

       
        public int id {set;get;}
		public string productID {set;get;}
		 public string  name {set;get;}
		 public string quantity {set;get;}
		public decimal amount {set;get;}
        public decimal price { set; get; }
		public decimal discount {set;get;}
		public decimal  varAmount {set;get;}
		public decimal totalAmount {set;get;} 
		public string _type {set;get;}
		 public int titleCount {set;get;}

         public decimal ToA { set; get; }

         public bool Add(string connString)
        {
            try
            {
                string query = @"insert CartList (id,productID ,name,quantity,amount, price, discount,varAmount,totalAmount,_type ) 
                                Values(" + id+ "," + productID + ",'" + name
                                           + "','" + quantity + "','" + amount + "','" + price + "','" + discount + "','" + varAmount 
                                           + "','"+totalAmount+"','"+_type+"')";

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

            public List<BusinessObjects.RunningOrder_BS> GetRUnningOrders(string connString)
        {

            try
            {



                List<BusinessObjects.RunningOrder_BS> ProductList = new List<BusinessObjects.RunningOrder_BS>();
                string query = "select id,productID ,name,quantity,amount, price, discount,varAmount,totalAmount,_type from CartList";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn); 
                while (reader.Read()) 
                {
                    BusinessObjects.RunningOrder_BS pObj = new BusinessObjects.RunningOrder_BS();
                    pObj.id =Convert.ToInt32( reader[0].ToString()); 
                    pObj.productID = reader[1].ToString();
                    pObj.name = reader[2].ToString();
                    pObj.quantity = reader[3].ToString();
                    pObj.amount = Convert.ToDecimal(reader[4].ToString());
                    pObj.price = Convert.ToDecimal(reader[5].ToString());
                    pObj.discount = Convert.ToInt32(reader[6].ToString());
                    pObj.varAmount = Convert.ToInt32(reader[7].ToString());
                    pObj.totalAmount = Convert.ToInt32(reader[8].ToString());
                    pObj._type = reader[9].ToString();


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



            public List<BusinessObjects.CartList> GetOrderAsCartList(string connString)
            {

                try
                {



                    List<BusinessObjects.CartList> ProductList = new List<BusinessObjects.CartList>();
                    string query = "select id,productID ,name,quantity,amount, price, discount,varAmount,totalAmount,_type from CartList where id="+id+"";

                    SqlConnection conn = DBHelper.GetConnection(connString);

                    conn.Open();

                    SqlDataReader reader = DBHelper.ReadData(query, conn);
                    while (reader.Read())
                    {
                        BusinessObjects.CartList pObj = new BusinessObjects.CartList();
                        pObj.tileID = Convert.ToInt32(reader[0].ToString());
                        pObj.productID = reader[1].ToString();
                        pObj.name = reader[2].ToString();
                        pObj.quantity = reader[3].ToString();
                        pObj.amount = Convert.ToDecimal(reader[4].ToString());
                        pObj.price = Convert.ToDecimal(reader[5].ToString());
                        pObj.discount = Convert.ToInt32(reader[6].ToString());
                        pObj.varAMount = Convert.ToInt32(reader[7].ToString());
                        pObj.totalAmount = Convert.ToInt32(reader[8].ToString());
                        pObj.type = reader[9].ToString();

                   
                        

                        ProductList.Add(pObj);
                    }
                    if (ProductList.Count > 0)
                    {
                        Delete_Branch(connString);
                    }
                    conn.Close();


                    return ProductList;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

            public bool Delete_Branch(string connString)
            {
                try
                {
                    string query = "Delete from CartList where id=" + id + "";
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

            public bool Delete_Company(string connString)
            {
                try
                {
                    string query = "Delete from CartList";
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

            public bool AddTotal(string connString)
            {
                try
                {
                    string query = @"insert _XYZ (Total) 
                                Values('" +ToA+ "')";

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
