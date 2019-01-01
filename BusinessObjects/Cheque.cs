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
   public class Cheque
    {

//       cheque_id int primary key identity(1,1),
//cheque_no int not  null,
//cheque_date datetime not null,
//amount decimal not null,
//bank varchar(50) not null,
//branch varchar(50) not null,
//customer_name varchar(50) not null,
//details varchar(100)

        public int cheque_id { set; get; }
        public string cheque_no { set; get; }
        public DateTime cheque_date { set; get; }
        public decimal amount { get; set; }
        public int salesId { get; set; }
        public string bank { set; get; }
        public string branch { set; get; }
        public string customer_name { set; get; }
        public string details { set; get; }


        public bool Add(string connString)
        {
            try
            {

                string query = @"insert cheque (cheque_no, amount,cheque_date,bank,branch,customer_name,details, salesId) 
                Values('" + cheque_no + "'," + amount + ",'" + cheque_date.ToString("dd-MMM-yyyy") + "','" + bank
                          + "','" + branch + "','" + customer_name + "','" + details + "',"+salesId+")";


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



       

        public List<BusinessObjects.Cheque> getAll(string connString)
        {

            try
            {

                string query = @"select cheque_no, amount, cheque_date, bank, branch, customer_name,details,salesId from cheque";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();
                List<Cheque> cList = new List<Cheque>();  
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                     BusinessObjects.Cheque cObj = new BusinessObjects.Cheque();

                     cObj.cheque_no = reader[0].ToString();
                     cObj.amount = Convert.ToDecimal(reader[1].ToString());
                     cObj.cheque_date = Convert.ToDateTime(reader[2].ToString());
                     cObj.bank = reader[3].ToString();
                     cObj.branch = reader[4].ToString();
                     cObj.customer_name =reader[5].ToString();
                     cObj.details = reader[6].ToString();
                     cObj.salesId =Convert.ToInt32( reader[7].ToString());
                     cList.Add(cObj);

                }
                conn.Close();


                return cList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<BusinessObjects.Cheque> getAllByDate(string connString, DateTime sdate , DateTime eDate)
        {

            try
            {

                string query = @"select cheque_no, amount, cheque_date, bank, branch, customer_name, details, salesId from cheque where 
                                    cheque_date between '" + sdate.ToString("dd-MMM-yyyy") + "' AND '" + eDate.ToString("dd-MMM-yyyy") + "'";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();
                List<Cheque> cList = new List<Cheque>();
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.Cheque cObj = new BusinessObjects.Cheque();

                    cObj.cheque_no = reader[0].ToString();
                    cObj.amount = Convert.ToDecimal(reader[1].ToString());
                    cObj.cheque_date = Convert.ToDateTime(reader[2].ToString());
                    cObj.bank = reader[3].ToString();
                    cObj.branch = reader[4].ToString();
                    cObj.customer_name = reader[5].ToString();
                    cObj.details = reader[6].ToString();
                    cObj.salesId = Convert.ToInt32(reader[7].ToString());
                    cList.Add(cObj);

                }
                conn.Close();


                return cList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<BusinessObjects.Cheque> getAllByName(string connString, string C_Name)
        {

            try
            {

                string query = @"select cheque_no, amount, cheque_date, bank, branch, customer_name, details,salesId from cheque where 
                                    customer_name= '" +C_Name+"'";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();
                List<Cheque> cList = new List<Cheque>();
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.Cheque cObj = new BusinessObjects.Cheque();

                    cObj.cheque_no = reader[0].ToString();
                    cObj.amount = Convert.ToDecimal(reader[1].ToString());
                    cObj.cheque_date = Convert.ToDateTime(reader[2].ToString());
                    cObj.bank = reader[3].ToString();
                    cObj.branch = reader[4].ToString();
                    cObj.customer_name = reader[5].ToString();
                    cObj.details = reader[6].ToString();

                    cObj.salesId = Convert.ToInt32(reader[7].ToString());
                    cList.Add(cObj);

                }
                conn.Close();


                return cList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public BusinessObjects.Cheque getAllByChequeNo(string connString, string C_No)
        {

            try
            {

                string query = @"select cheque_no, amount, cheque_date, bank, branch, customer_name, details, salesId from cheque where 
                                    cheque_no= '" + C_No + "'";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();
                BusinessObjects.Cheque cObj = new BusinessObjects.Cheque();
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    

                    cObj.cheque_no = reader[0].ToString();
                    cObj.amount = Convert.ToDecimal(reader[1].ToString());
                    cObj.cheque_date = Convert.ToDateTime(reader[2].ToString());
                    cObj.bank = reader[3].ToString();
                    cObj.branch = reader[4].ToString();
                    cObj.customer_name = reader[5].ToString();
                    cObj.details = reader[6].ToString();

                    cObj.salesId = Convert.ToInt32(reader[7].ToString());
                   

                }
                conn.Close();


                return cObj;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
