using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCommon;
using System.Data;
using System.Data.SqlClient;

namespace BusinessObjects
{
    public class Supplier
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public string Contact { get; set; }
        public int Id { get; set; }

        public  object getScalar(string connString, string query)
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

        public bool checkNameExit(string name, string con)
        {
            try
            {

                bool result = false;
                string query = @"select count(*) from Supplier where Name ='" + name+ "'";
                object ob=getScalar(con, query);
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
                    else {
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

        public bool Add(string connString)
        {
            try
            {
                string query = @"insert Supplier (Name, Address,Company, Contact) 
                                                Values('" + Name + "','" +Address+ "','" + Company + "','"
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
                string query = @"Update Supplier set Name='" + Name
                                + "',Address='" + Address
                                + "',Company='" + Company
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


        public List<BusinessObjects.Supplier> GetLList(string connString)
        {
            try
            {
                List<BusinessObjects.Supplier> ProductList = new List<BusinessObjects.Supplier>();
                string query = "select Id, Name, Address,Company, Contact from Supplier";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.Supplier pObj = new BusinessObjects.Supplier();
                    pObj.Id = Convert.ToInt32(reader[0].ToString());
                    pObj.Name = reader[1].ToString();
                    pObj.Address = reader[2].ToString();
                    pObj.Company = reader[3].ToString();
                    pObj.Contact =reader[4].ToString();                  
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

        public Supplier GetLListByStockID(string connString, int stockID)
        {
            try
            {
            
                string query = "select Id, Name, Address,Company, Contact from Supplier where Id=(select Sup_id from _Stokc where stock_id=" + stockID + " )";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();
                BusinessObjects.Supplier pObj = new BusinessObjects.Supplier();
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                   
                    pObj.Id = Convert.ToInt32(reader[0].ToString());
                    pObj.Name = reader[1].ToString();
                    pObj.Address = reader[2].ToString();
                    pObj.Company = reader[3].ToString();
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


        public int GetIdByName(string connString, string sup_name)
        {
            try
            {
                int result = 0;
                string query = "select Id from Supplier where Name='"+sup_name+"'";
                object obj = getScalar(connString, query);
                if (obj == null || obj == DBNull.Value)
                {
                    result = 0;
                }
                else
                {
                    result = Convert.ToInt32(obj.ToString());
                }
                return result;
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
                string query = @"select Id, Name, Address,Company, Contact from Supplier";
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

    }
}
