using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DataAccessCommon;
using System.Data.SqlClient;

namespace BusinessObject
{
    public class DatabaseMangement
    {

        #region Methods

        public bool Backup(string connString, string location)
        {
            try
            {
                string cmd = "BACKUP DATABASE POS_DB TO DISK='" + location + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";

                SqlConnection conn = DBHelper.GetConnection(connString);
                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(cmd, conn);
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
