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
    public class Category_BS
    {

        public int ID { set; get; }
        public string name { set; get; }
     
        
        public bool Add(string connString)
        {
            try
            {
                string query = @"insert _Category (name) 
                                Values('" + name + "')";

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

        public List<BusinessObjects.Category_BS> GetCategory(string connString)
        {

            try
            {

                List<BusinessObjects.Category_BS> CatetList = new List<BusinessObjects.Category_BS>();
                string query = "select ID,name from _Category";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.Category_BS pObj = new BusinessObjects.Category_BS();
                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();

                    CatetList.Add(pObj);
                }
                conn.Close();
                return CatetList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
