using DataAccessCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
namespace BusinessObjects
{
   public class Users_BS
    {
          public string status_  {get; set;}
          public int user_id_ {get; set;}
          public string user_name_ {get; set;}
          public string password_ { get; set; }


          public bool Add(string connString)
          {
              try
              {
                  string query = @"insert users (password_,user_name_,status_) 
                                Values('" + password_ + "', '" + user_name_ + "','" + status_ + "')";

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

          public List<BusinessObjects.Users_BS> GetAll(string connString)
          {

              try
              {

                  List<BusinessObjects.Users_BS> CatetList = new List<BusinessObjects.Users_BS>();
                  string query = "select user_id_,password_,user_name_,status_ from users";

                  SqlConnection conn = DBHelper.GetConnection(connString);

                  conn.Open();

                  SqlDataReader reader = DBHelper.ReadData(query, conn);
                  while (reader.Read())
                  {
                      BusinessObjects.Users_BS pObj = new BusinessObjects.Users_BS();
                      pObj.user_id_ = Convert.ToInt32(reader[0].ToString());
                      pObj.password_ = reader[1].ToString();
                      pObj.user_name_ = reader[2].ToString();

                      pObj.status_ = reader[3].ToString();
                     
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

          public Users_BS GetOneUser(string connString, string UN, string PW)
          {

              try
              {

                  string query = @"select user_id_,password_,user_name_,status_ from users where user_name_=
                  '" + UN + "' and password_='"+PW+"' ";

                  SqlConnection conn = DBHelper.GetConnection(connString);

                  conn.Open();
                BusinessObjects.Users_BS pObj = new BusinessObjects.Users_BS();
                      
                  SqlDataReader reader = DBHelper.ReadData(query, conn);
                  while (reader.Read())
                  {
                      pObj.user_id_ = Convert.ToInt32(reader[0].ToString());
                      pObj.password_ = reader[1].ToString();
                      pObj.user_name_ = reader[2].ToString();

                      pObj.status_ = reader[3].ToString();

                      
                  }
                  conn.Close();
                  return pObj;
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
            //      user_id_,password_,user_name_,status_ 
                  string query = @" Update users set password_='"+password_+ "', status_='"+status_+"' where user_name_='"+user_name_+"'";
 



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



          public bool UpdateStatusAllUser(string connString)
          {
              try
              {
                  //      user_id_,password_,user_name_,status_ 
                  string query = @" Update users set status_='" + status_ + "' ";




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
       
       public Users_BS GetActiveUser(string connString)
          {

              try
              {

                  string query = @"select user_id_,password_,user_name_,status_ from users where status_='active' ";

                  SqlConnection conn = DBHelper.GetConnection(connString);

                  conn.Open();
                  BusinessObjects.Users_BS pObj = new BusinessObjects.Users_BS();

                  SqlDataReader reader = DBHelper.ReadData(query, conn);
                  while (reader.Read())
                  {
                      pObj.user_id_ = Convert.ToInt32(reader[0].ToString());
                      pObj.password_ = reader[1].ToString();
                      pObj.user_name_ = reader[2].ToString();

                      pObj.status_ = reader[3].ToString();


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
