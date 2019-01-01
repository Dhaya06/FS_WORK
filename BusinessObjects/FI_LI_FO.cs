using DataAccessCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{ 
    public class FI_LI_FO
    {
        public int stockTyp { get; set; }
        public int value { get; set; }


        public bool Add(string connString, string type)
        {
            try
            {
                
                string queryDelete = "delete from Stock_Routing";
                if (DBHelper.ExecuteNonQuery(queryDelete, connString) > 0)
                {
                    string query = "";
                    if (type == "FIFO")
                    {
                        query = @"insert Stock_Routing (name, value) 
                         Values('FIFO',1),('LIFO',0);";
                    }
                    else if (type == "LIFO")
                    {
                        query = @"insert Stock_Routing (name, value) 
                        Values('FIFO',0),('LIFO',1);";
                    }

                    if (DBHelper.ExecuteNonQuery(query, connString) > 0)
                        return true;
                    else
                        return false;
                }
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
