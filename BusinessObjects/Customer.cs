using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCommon;
using System.Data.SqlClient;
using System.Data;
namespace BusinessObjects
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string NIC { get; set; }
        public string Contact { get; set; }
        public int Id { get; set; }

        public object getScalar(string connString, string query)
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

        public bool checkNameExit(string nic, string con)
        {
            try
            {

                bool result = false;
                string query = @"select count(*) from Customer where Name ='" + nic + "'";
                object ob = getScalar(con, query);
                if (ob == DBNull.Value)
                {
                    result = false;
                }
                else
                {
                    int count = Convert.ToInt32(ob);
                    if (count > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


         public int getIdByName(string name, string con)
        {
            try
            {

                int result = 0;
                string query = @"select Id from Customer where Name ='" + name + "'";
                object ob = getScalar(con, query);
                if (ob == DBNull.Value)
                {
                    result = 0;
                }
                else
                {
                    result=Convert.ToInt32(ob);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Add(string connString)
        {
            try
            {
                string query = @"insert Customer (Name, Address,NIC, Contact) 
                                                Values('" + Name + "','" + Address + "','" + NIC + "','"
                                                          + Contact + "')";

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
                string query = @"Update Customer set Name='" + Name
                                + "',Address='" + Address
                                + "',NIC='" + NIC
                                + "', Contact='" + Contact + "'  where Id=" + Id + "";

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


        public List<BusinessObjects.Customer> GetLList(string connString)
        {

            try
            {
                List<BusinessObjects.Customer> ProductList = new List<BusinessObjects.Customer>();
                string query = "select Id, Name, Address,NIC, Contact from Customer";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.Customer pObj = new BusinessObjects.Customer();
                    pObj.Id = Convert.ToInt32(reader[0].ToString());
                    pObj.Name = reader[1].ToString();
                    pObj.Address = reader[2].ToString();
                    pObj.NIC = reader[3].ToString();
                    pObj.Contact = reader[4].ToString();
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


        public DataTable ForAutoSearch(string connString)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = "select Id, Name, Address,NIC, Contact from Customer";
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer GetCustomerBySID(string connString, int sid)
        {
            try
            {
                string query = @"select Id, Name, Address,NIC, Contact from Customer 
                                where Id =(select customerID from _Sales where sales_id="+sid+")";

                SqlConnection conn = DBHelper.GetConnection(connString);
                conn.Open();
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                BusinessObjects.Customer pObj = new BusinessObjects.Customer();
                while (reader.Read())
                {
                    pObj.Id = Convert.ToInt32(reader[0].ToString());
                    pObj.Name = reader[1].ToString();
                    pObj.Address = reader[2].ToString();
                    pObj.NIC = reader[3].ToString();
                    pObj.Contact = reader[4].ToString();
                }
                conn.Close();
                return pObj;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
