using DataAccessCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class DeductFromProduct_Quantit
    {

        public int pid { set; get; }
        public int sid { get; set; }
        public int quantity { set; get; }


        public bool Update(string connString)
        {
            try
            {

                string query = @"Update _stock_product set quantity= quantity-" + quantity
                                + " where stock_id=" + sid + " AND pid=" + pid + " ";

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
