using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using BusinessObjects;
using System.Configuration;

namespace POS.AddToCart
{
    public partial class D_Summary : UserControl
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        private static D_Summary _instance;
        public D_Summary()
        {
            InitializeComponent();
            InitialloadGrid();
            increaseWidth();
        }

        public static D_Summary Instance()
        {
            if (_instance == null)
                _instance = new D_Summary();
            return _instance;


        }

        public static void Refresh()
        {
                    _instance = null;
                _instance = new D_Summary();


        }
        void increaseWidth()
        {
            tblProduct.Columns[0].Width = 60;
            tblProduct.Columns[1].Width = 200;
            tblProduct.Columns[2].Width = 140;
            tblProduct.Columns[3].Width = 140;
            tblProduct.Columns[4].Width = 140;
            tblProduct.Columns[5].Width = 120;
            tblProduct.Columns[6].Width = 70;

        }
        private void InitialloadGrid()
        {

            try
            {
                List<GetProductStock> GridList = new List<GetProductStock>();
                BusinessObjects.GetProductStock spObj = new GetProductStock();
                GridList = spObj.getProdAlongWithStockQuantity_All(con);

                List<M_Product_BS> cObjList = new List<M_Product_BS>();
                BusinessObjects.M_Product_BS cObj = new M_Product_BS();
                cObjList = cObj.GetProducts(con);
                //MessageBox.Show(cObjList.Count.ToString());

                //this is to set the category name

                List<Category_BS> catList = new List<Category_BS>();
                Category_BS catObj = new Category_BS();
                catList = catObj.GetCategory(con);
                foreach (Category_BS itemCat in catList)
                {
                    foreach (GetProductStock itemProd in GridList)
                    {
                        if (itemProd.category == itemCat.ID)
                        {
                            itemProd.catObj = itemCat;
                        }
                    }
                }

                int i = 0;
                tblProduct.Rows.Clear();


                foreach (GetProductStock item in GridList)
                {
                    if (item.TotalQuantity > 3)
                    {
                        continue; 
                    }
                    tblProduct.Rows.Add();
                    tblProduct.Rows[i].Cells[0].Value = item.ID;
                    tblProduct.Rows[i].Cells[1].Value = item.name;
                    tblProduct.Rows[i].Cells[2].Value = item.catObj.name;
                    tblProduct.Rows[i].Cells[3].Value = item.cost;
                    tblProduct.Rows[i].Cells[4].Value = item.unitPrice;

                    tblProduct.Rows[i].Cells[5].Value = item.warranty;
                    tblProduct.Rows[i].Cells[6].Value = item.TotalQuantity;





                    i++;
                }
               

            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}
