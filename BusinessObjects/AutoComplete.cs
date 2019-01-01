using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DataAccessCommon;
using System.Data;
using System.Data.SqlClient;

namespace BusinessObjects
{
      
    public class AutoComplete
    {
        string connString = ConfigurationManager.ConnectionStrings["gster"].ConnectionString;
        public string BranchId { set; get; }
        public string Location { set; get; }
        public string Type { set; get; }
        public string userID { set; get; }

        public List<AutoComplete> GetBranch()
        {

            try
            {
                List<AutoComplete> BranchList = new List<AutoComplete>();
                string query = "select BranchId, Location, BranchType from BRANCH";

                SqlConnection conn = DBHelper.GetConnection(connString);//PAssing that connection to the conn

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn); //passing the query and connection details
                //The purpose of not creating the while loop in the DL is.. it reduces the reusesability it directly connected to the UI layer so.. in the next project it will be diff
                //Reader returns the first roww and we are assigning that first row to the reader.. the Reader will return values in an array ..that why we are using [] to get from the array and pass it to text field
                while (reader.Read()) //The reader starts to get the fisrt row to end..
                {
                    AutoComplete bObj = new AutoComplete();
                    bObj.BranchId = reader[0].ToString(); //in the reader array oth position has the details of product code and we are passign that values to the object
                    bObj.Location = reader[1].ToString();
                    bObj.Type = reader[2].ToString();


                    BranchList.Add(bObj); //adding the project object to the list
                }
                conn.Close();
                return BranchList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



    }



}
