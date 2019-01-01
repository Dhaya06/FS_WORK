using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCommon;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BusinessObjects
{
   public class Print
    {
       public string PrinterName { set; get; }
       public int PaperSize { set; get; }
       public int Resolution { set; get; }
       public int Source { set; get; }

       public bool ADD_Print_Settings(string connString)
       {
           try
           {
               string query = @"insert PrinterSettings (PrinterName, PaperSize, Source,Resolution ) 
                                Values('" + PrinterName + "'," + PaperSize
                                          + "," + Source + "," + Resolution + ")";

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

       public Print GetP(string connString)
       {

           try
           {

               string query = "select PrinterName, PaperSize, Source,Resolution from PrinterSettings ";
               SqlConnection conn = DBHelper.GetConnection(connString);//PAssing that connection to the conn
               conn.Open();
               Print pObj = new Print();
               SqlDataReader reader = DBHelper.ReadData(query, conn);
               while (reader.Read())
               {

                   pObj.PrinterName = reader[0].ToString(); //in the reader array oth position has the details of product code and we are passign that values to the object
                   pObj.PaperSize =Convert.ToInt32( reader[1].ToString());
                   pObj.Source = Convert.ToInt32(reader[2].ToString());
                   pObj.Resolution = Convert.ToInt32(reader[3].ToString());
                  
               }
               conn.Close();
               return pObj;
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public bool Delete(string connString)
       {
           try
           {
               string query = "Delete FROM PrinterSettings";

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
