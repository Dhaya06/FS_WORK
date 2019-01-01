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
    public class GetProductStock
    {
        public int ID { set; get; }
        public string name { set; get; }
        public int category { set; get; }
        public decimal unitPrice { get; set; }
        //public decimal boundlePrice  { get; set; }
        public decimal cost { get; set; }
        //public decimal boundleCost { get; set; }
        public string description { set; get; }
        public string warranty { set; get; }
        public int TotalQuantity { set; get; }
        public DateTime date_ { set; get; }

        public BusinessObjects.Category_BS catObj { set; get; }


        public List<BusinessObjects.GetProductStock> getProdAlongWithSalesQuantity_ByCatID(string connString, int catID, DateTime sDate, DateTime eDate)
        {

            try
            {

                //s.ID,s.name,s.description, s.unitPrice, s.cost, s.category, s.warranty,sp.TotalQuantity,sp.date_

                List<BusinessObjects.GetProductStock> ProductList = new List<BusinessObjects.GetProductStock>();
                string query = @"exec getProdAlongWithSalesQuantity_ByCatID " + catID + ", '" + sDate.ToString("dd-MMM-yyyy") + "', '" + eDate.ToString("dd-MMM-yyyy") + "' ";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.GetProductStock pObj = new BusinessObjects.GetProductStock();
                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.description = reader[2].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[3].ToString());
                    pObj.cost = Convert.ToDecimal(reader[4].ToString());
                    pObj.category = Convert.ToInt32(reader[5].ToString());
                    pObj.warranty = reader[6].ToString();
                    pObj.TotalQuantity = Convert.ToInt32(reader[7].ToString());
                    pObj.date_ = Convert.ToDateTime(reader[8].ToString());
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


        public List<BusinessObjects.GetProductStock> getProdAlongWithSalesQuantity_ByDate(string connString, DateTime sDate, DateTime eDate)
        {

            try
            {

                //s.ID,s.name,s.description, s.unitPrice, s.cost, s.category, s.warranty,sp.TotalQuantity,sp.date_

                List<BusinessObjects.GetProductStock> ProductList = new List<BusinessObjects.GetProductStock>();
                string query = @"exec getProdAlongWithSalesQuantity_ByDate '" + sDate.ToString("dd-MMM-yyyy") + "', '" + eDate.ToString("dd-MMM-yyyy") + "' ";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.GetProductStock pObj = new BusinessObjects.GetProductStock();
                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.description = reader[2].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[3].ToString());
                    pObj.cost = Convert.ToDecimal(reader[4].ToString());
                    pObj.category = Convert.ToInt32(reader[5].ToString());
                    pObj.warranty = reader[6].ToString();
                    pObj.TotalQuantity = Convert.ToInt32(reader[7].ToString());
                    pObj.date_ = Convert.ToDateTime(reader[8].ToString());
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



        public List<BusinessObjects.GetProductStock> getProdAlongWithSalesQuantity_ByAll(string connString)
        {

            try
            {

                //s.ID,s.name,s.description, s.unitPrice, s.cost, s.category, s.warranty,sp.TotalQuantity,sp.date_

                List<BusinessObjects.GetProductStock> ProductList = new List<BusinessObjects.GetProductStock>();
                string query = @"exec getProdAlongWithSalesQuantity_ByAll ";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.GetProductStock pObj = new BusinessObjects.GetProductStock();
                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.description = reader[2].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[3].ToString());
                    pObj.cost = Convert.ToDecimal(reader[4].ToString());
                    pObj.category = Convert.ToInt32(reader[5].ToString());
                    pObj.warranty = reader[6].ToString();
                    pObj.TotalQuantity = Convert.ToInt32(reader[7].ToString());
                    //pObj.date_ = Convert.ToDateTime(reader[8].ToString());

                    //reader[8].Equals(DBNull.Value)

                    //pObj.date_ = DateTime.ParseExact(reader[8].ToString(), "yyyy/MM/dd", null);
                    pObj.date_ = Convert.ToDateTime(reader[8].ToString());
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




        public List<BusinessObjects.GetProductStock> getProdAlongWithSalesQuantity_ByProdName(string connString, string pname, DateTime sDate, DateTime eDate)
        {

            try
            {

                //s.ID,s.name,s.description, s.unitPrice, s.cost, s.category, s.warranty,sp.TotalQuantity,sp.date_

                List<BusinessObjects.GetProductStock> ProductList = new List<BusinessObjects.GetProductStock>();
                string query = @"exec getProdAlongWithSalesQuantity_ByProdName '" + pname + "', '" + sDate.ToString("dd-MMM-yyyy") + "', '" + eDate.ToString("dd-MMM-yyyy") + "' ";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.GetProductStock pObj = new BusinessObjects.GetProductStock();
                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.description = reader[2].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[3].ToString());
                    pObj.cost = Convert.ToDecimal(reader[4].ToString());
                    pObj.category = Convert.ToInt32(reader[5].ToString());
                    pObj.warranty = reader[6].ToString();
                    pObj.TotalQuantity = Convert.ToInt32(reader[7].ToString());
                    pObj.date_ = Convert.ToDateTime(reader[8].ToString());
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

        public List<BusinessObjects.GetProductStock> getProdAlongWithSalesQuantity_ByProdID(string connString, int pid, DateTime sDate, DateTime eDate)
        {

            try
            {

                //s.ID,s.name,s.description, s.unitPrice, s.cost, s.category, s.warranty,sp.TotalQuantity,sp.date_

                List<BusinessObjects.GetProductStock> ProductList = new List<BusinessObjects.GetProductStock>();
                string query = @"exec getProdAlongWithSalesQuantity_ByProdID " + pid + ", '" + sDate.ToString("dd-MMM-yyyy") + "', '" + eDate.ToString("dd-MMM-yyyy") + "' ";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.GetProductStock pObj = new BusinessObjects.GetProductStock();
                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.description = reader[2].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[3].ToString());
                    pObj.cost = Convert.ToDecimal(reader[4].ToString());
                    pObj.category = Convert.ToInt32(reader[5].ToString());
                    pObj.warranty = reader[6].ToString();
                    pObj.TotalQuantity = Convert.ToInt32(reader[7].ToString());
                    pObj.date_ = Convert.ToDateTime(reader[8].ToString());
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

        public List<BusinessObjects.GetProductStock> getProdAlongWithStockQuantity_ByCatID(string connString, int cat_id)
        {

            try
            {

                //s.ID,s.name,s.description, s.unitPrice, s.cost, s.category, s.warranty,sp.TotalQuantity,sp.date_
                List<BusinessObjects.GetProductStock> ProductList = new List<BusinessObjects.GetProductStock>();
                string query = @"exec getProdAlongWithStockQuantity_ByCatID " + cat_id + " ";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.GetProductStock pObj = new BusinessObjects.GetProductStock();
                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.description = reader[2].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[3].ToString());
                    pObj.cost = Convert.ToDecimal(reader[4].ToString());
                    pObj.category = Convert.ToInt32(reader[5].ToString());
                    pObj.warranty = reader[6].ToString();
                    pObj.TotalQuantity = Convert.ToInt32(reader[7].ToString());

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

        public List<BusinessObjects.GetProductStock> getProdAlongWithStockQuantity_ByProdName(string connString, string pName)
        {

            try
            {

                //s.ID,s.name,s.description, s.unitPrice, s.cost, s.category, s.warranty,sp.TotalQuantity,sp.date_
                List<BusinessObjects.GetProductStock> ProductList = new List<BusinessObjects.GetProductStock>();
                string query = @"exec getProdAlongWithStockQuantity_ByProdName '" + pName + "' ";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.GetProductStock pObj = new BusinessObjects.GetProductStock();
                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.description = reader[2].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[3].ToString());
                    pObj.cost = Convert.ToDecimal(reader[4].ToString());
                    pObj.category = Convert.ToInt32(reader[5].ToString());
                    pObj.warranty = reader[6].ToString();
                    pObj.TotalQuantity = Convert.ToInt32(reader[7].ToString());

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


        public List<BusinessObjects.GetProductStock> getProdAlongWithStockQuantity_ByProdID(string connString, int pID)
        {

            try
            {

                //s.ID,s.name,s.description, s.unitPrice, s.cost, s.category, s.warranty,sp.TotalQuantity,sp.date_
                List<BusinessObjects.GetProductStock> ProductList = new List<BusinessObjects.GetProductStock>();
                string query = @"exec getProdAlongWithStockQuantity_ByProdID " + pID + " ";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.GetProductStock pObj = new BusinessObjects.GetProductStock();
                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.description = reader[2].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[3].ToString());
                    pObj.cost = Convert.ToDecimal(reader[4].ToString());
                    pObj.category = Convert.ToInt32(reader[5].ToString());
                    pObj.warranty = reader[6].ToString();
                    pObj.TotalQuantity = Convert.ToInt32(reader[7].ToString());

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

        public List<BusinessObjects.GetProductStock> getProdAlongWithStockQuantity_All(string connString)
        {

            try
            {

                //s.ID,s.name,s.description, s.unitPrice, s.cost, s.category, s.warranty,sp.TotalQuantity,sp.date_
                List<BusinessObjects.GetProductStock> ProductList = new List<BusinessObjects.GetProductStock>();
                string query = @"exec getProdAlongWithStockQuantity_ByAll ";
                SqlConnection conn = DBHelper.GetConnection(connString);

                conn.Open();

                SqlDataReader reader = DBHelper.ReadData(query, conn);
                while (reader.Read())
                {

                    BusinessObjects.GetProductStock pObj = new BusinessObjects.GetProductStock();
                    pObj.ID = Convert.ToInt32(reader[0].ToString());
                    pObj.name = reader[1].ToString();
                    pObj.description = reader[2].ToString();
                    pObj.unitPrice = Convert.ToDecimal(reader[3].ToString());
                    pObj.cost = Convert.ToDecimal(reader[4].ToString());
                    pObj.category = Convert.ToInt32(reader[5].ToString());
                    pObj.warranty = reader[6].ToString();
                    pObj.TotalQuantity = Convert.ToInt32(reader[7].ToString());

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

    }
}
