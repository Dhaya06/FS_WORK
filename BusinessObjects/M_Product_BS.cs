using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCommon;
using System.Data.SqlClient;
using System.Data;
namespace BusinessObjects
{
    public class M_Product_BS
    {
        public int ID { set; get; }
        public  string name {set;get;}  
        public  int category {set;get;}
        public decimal unitPrice  { get; set; }
        public decimal boundlePrice  { get; set; }
        public decimal cost { get; set; }
        public decimal boundleCost { get; set; }
        public string description { set; get; }
        public string warranty { set; get; }

        public BusinessObjects.Category_BS catObj { set; get; }
      

        public bool Add(string connString)
        {
            try
            {
//                string query = @"insert _Product (name, category,unitPrice, boundlePrice, cost, boundleCost, description,warranty) 
//                                Values('" + name + "'," + category + "," + unitPrice + "," + boundlePrice + "," + cost + "," + boundleCost + ", '" + description + "','"+warranty+"' )";

                string query = @"insert _Product (name, category,unitPrice, cost, description,warranty) 
                                                Values('" + name + "'," + category + ",'" + unitPrice + "','"
                                                          + cost + "', '" + description + "','" + warranty + "' )";


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

        public bool Update(string connString)
        {
            try
            {

                //string query = @"Update _Product set name='" + name
                //                + "',unitPrice=" + unitPrice
                //                + ",category=" + category
                //                + ", cost=" + cost + ", boundlePrice=" + boundlePrice
                //                + ", boundleCost=" + boundleCost 
                //                + ", description='" + description
                //                + "', warranty='" + warranty + "'   where ID=" + ID + "";

                string query = @"Update _Product set name='" + name
                                + "',unitPrice=" + unitPrice
                                + ",category=" + category
                                + ", cost=" + cost + ", description='" + description
                                + "', warranty='" + warranty + "'   where ID=" + ID + "";

                                   
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

        public bool Delete(string connString)
        {
            try
            {
                string query = "Delete from _Product where ID=" + ID + "";
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




        public List<BusinessObjects.M_Product_BS> getProductByVat_ID(string connString, int catID)
        {

            try
            {



                List<BusinessObjects.M_Product_BS> ProductList = new List<BusinessObjects.M_Product_BS>();
                string query = @"select ID,name,unitPrice,cost,category,warranty from _Product where  category=" + catID + "";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.M_Product_BS pObj = new BusinessObjects.M_Product_BS();

                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[2].ToString());
                   
                    pObj.cost = Convert.ToDecimal(reader[3].ToString());
                    pObj.category = Convert.ToInt32(reader[4].ToString());
                   
                    pObj.warranty = reader[5].ToString();



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




        public List<BusinessObjects.M_Product_BS> GetProductsWithLikeQuery(string connString, string TypingText)
        {

            try
            {
                TypingText = "%" + TypingText + "%";


                List<BusinessObjects.M_Product_BS> ProductList = new List<BusinessObjects.M_Product_BS>();


                string query = "select ID,name,unitPrice,cost,category,description,warranty from _Product WHERE name LIKE '"+TypingText+"'";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();








                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.M_Product_BS pObj = new BusinessObjects.M_Product_BS();

                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[2].ToString());

                    pObj.cost = Convert.ToDecimal(reader[3].ToString());
                    pObj.category = Convert.ToInt32(reader[4].ToString());

                    pObj.description = reader[5].ToString();
                    pObj.warranty = reader[6].ToString();
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

        

        



        //this is cleared
        public List<BusinessObjects.M_Product_BS> GetProducts(string connString)
        {

            try
            {



                List<BusinessObjects.M_Product_BS> ProductList = new List<BusinessObjects.M_Product_BS>();

                string query = "select ID,name,unitPrice,cost,category,description,warranty from _Product";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.M_Product_BS pObj = new BusinessObjects.M_Product_BS();

                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[2].ToString());
                  
                    pObj.cost = Convert.ToDecimal(reader[3].ToString());
                    pObj.category = Convert.ToInt32(reader[4].ToString());
                   
                    pObj.description = reader[5].ToString();
                    pObj.warranty = reader[6].ToString();
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

        public List<M_Product_BS> GetOutOfStockProducts(string connString)
        {
         try
            {



                List<BusinessObjects.M_Product_BS> ProductList = new List<BusinessObjects.M_Product_BS>();

                string query = @"select ID,name,unitPrice,cost,category,description,warranty from _Product where ID not in (select distinct(pid) from _stock_product)";
           

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {
                    BusinessObjects.M_Product_BS pObj = new BusinessObjects.M_Product_BS();

                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[2].ToString());

                    pObj.cost = Convert.ToDecimal(reader[3].ToString());
                    pObj.category = Convert.ToInt32(reader[4].ToString());

                    pObj.description = reader[5].ToString();
                    pObj.warranty = reader[6].ToString();
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

        //this is cleared
        public BusinessObjects.M_Product_BS GetOneProduct(string connString)
        {

            try
            {

                string query = @"select ID,name,unitPrice,cost,category,description,warranty from _Product where ID=" + ID + "";
                ;
                SqlConnection conn = DBHelper.GetConnection(connString);
                conn.Open();
                BusinessObjects.M_Product_BS pObj = new BusinessObjects.M_Product_BS();
                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[2].ToString());
                    pObj.cost = Convert.ToDecimal(reader[3].ToString());
                    pObj.category = Convert.ToInt32(reader[4].ToString());
                    pObj.description = reader[5].ToString();
                    pObj.warranty = reader[6].ToString();
                   
                }
                conn.Close();
                return pObj;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public BusinessObjects.M_Product_BS Get1Product(string connString)
        {

            try
            {

                string query = @"select ID,name,unitPrice,cost,category,description,warranty from _Product where  name='" + name + "'";

                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();
                BusinessObjects.M_Product_BS pObj = new BusinessObjects.M_Product_BS();
                SqlDataReader reader = DBHelper.ReadData(query, conn);

                while (reader.Read())
                {


                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[2].ToString());
                    pObj.cost = Convert.ToDecimal(reader[3].ToString());
                    pObj.category = Convert.ToInt32(reader[4].ToString());
                     pObj.description= reader[5].ToString();
                    pObj.warranty=reader[6].ToString();
                   

                }
                conn.Close();
                return pObj;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public DataTable ForTestAutoSearch(string connString)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = @"select ID,name,unitPrice,cost,category,description,warranty from _Product where ID not in (select distinct(pid) from _stock_product)";
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
