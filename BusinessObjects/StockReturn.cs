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
  public  class StockReturn_BS
    {

    public int table_id {get;set;}
	public int prd_id {get;set;}
	public int stock_id {get;set;}
	public string descrip {get;set;}
    public int adjusted { get; set; }
    public DateTime Date_ { get; set; }
    public int quantity { get; set; }
    public string product_name { get; set; }
    public string  sup_name { get; set; }
    public DateTime stock_date { get; set; }
    public string invoice_no { get; set; }
      public bool Add(string connString)
    {
        try
        {
            string query = @"insert stock_return (prd_id,stock_id,descrip,adjusted,quantity) 
                                Values(" +prd_id+","+stock_id+",'"+descrip+"', " + adjusted + ","+quantity+")";

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



    public List<BusinessObjects.StockReturn_BS> GetAllProcInnjerJoin(string connString)
    {

        try
        {

            string query = @"exec get_stock_return";

            //get_stock_return
            List<BusinessObjects.StockReturn_BS> CatetList = new List<BusinessObjects.StockReturn_BS>();
           
            SqlConnection conn = DBHelper.GetConnection(connString);

            conn.Open();

            SqlDataReader reader = DBHelper.ReadData(query, conn);
            while (reader.Read())
            {
                BusinessObjects.StockReturn_BS pObj = new BusinessObjects.StockReturn_BS();
                pObj.table_id = Convert.ToInt32(reader[0].ToString());
                pObj.prd_id = Convert.ToInt32(reader[1].ToString());
                pObj.product_name= reader[2].ToString();
              
                pObj.stock_id = Convert.ToInt32(reader[4].ToString());

                pObj.descrip = reader[5].ToString();
                pObj.adjusted = Convert.ToInt32(reader[6].ToString());
                pObj.quantity = Convert.ToInt32(reader[7].ToString());
                pObj.sup_name = reader[8].ToString();

                pObj.Date_ = Convert.ToDateTime(reader[9].ToString());
                    
                pObj.stock_date = Convert.ToDateTime(reader[10].ToString());
                
                pObj.invoice_no= reader[10].ToString();
                CatetList.Add(pObj);
            }
            conn.Close();
            return CatetList;

;
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }


    public List<BusinessObjects.StockReturn_BS> GetAll(string connString)
    {

        try
        {
            //get_stock_return
            List<BusinessObjects.StockReturn_BS> CatetList = new List<BusinessObjects.StockReturn_BS>();
            string query = "select table_id,prd_id,stock_id,descrip,adjusted,quantity,Date_ from stock_return";

            SqlConnection conn = DBHelper.GetConnection(connString);

            conn.Open();

            SqlDataReader reader = DBHelper.ReadData(query, conn);
            while (reader.Read())
            {
                BusinessObjects.StockReturn_BS pObj = new BusinessObjects.StockReturn_BS();
                pObj.table_id = Convert.ToInt32(reader[0].ToString());
                pObj.prd_id = Convert.ToInt32(reader[1].ToString());
                pObj.stock_id = Convert.ToInt32(reader[2].ToString());
               
                pObj.descrip = reader[3].ToString();
                pObj.adjusted = Convert.ToInt32(reader[4].ToString());
                pObj.quantity = Convert.ToInt32(reader[5].ToString());
               
                pObj.Date_ = Convert.ToDateTime(reader[6].ToString());
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
