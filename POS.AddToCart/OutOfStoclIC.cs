using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using BusinessObjects;
using MetroFramework;

namespace POS.AddToCart
{
    public partial class OutOfStoclIC : UserControl
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        List<BusinessObjects.M_Product_BS> cObjList = new List<M_Product_BS>();
        List<BusinessObjects.Category_BS> catList = new List<Category_BS>();
        private static OutOfStoclIC _instance;
        public OutOfStoclIC()
        {
            InitializeComponent();
            loadGrid();
            increaseWidth();
        }
        void increaseWidth()
        {
            tblProduct.Columns[0].Width = 60;
            tblProduct.Columns[1].Width = 200;
            tblProduct.Columns[2].Width = 140;
            tblProduct.Columns[3].Width = 140;
            tblProduct.Columns[4].Width = 140;
            tblProduct.Columns[5].Width = 120;
            tblProduct.EnableHeadersVisualStyles = false;
            tblProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            tblProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);

        }
        public static OutOfStoclIC Instance()
        {
            if (_instance == null)
                _instance = new OutOfStoclIC();
            return _instance;


        }

        public static void refresh()
        {
            _instance = null;
                _instance = new OutOfStoclIC();

            
           // return _instance;
        }


        void loadGrid()
        {

            try
            {

                BusinessObjects.M_Product_BS cObj = new M_Product_BS();
                cObjList = cObj.GetOutOfStockProducts(con);
               
              
                //MessageBox.Show(cObjList.Count.ToString());
                Category_BS catObj = new Category_BS();
                catList = catObj.GetCategory(con);
                foreach (Category_BS itemCat in catList)
                {
                    foreach (M_Product_BS itemProd in cObjList)
                    {
                        if (itemProd.category == itemCat.ID)
                        {
                            itemProd.catObj = itemCat;
                        }
                    }
                }

                int i = 0;
                tblProduct.Rows.Clear();

                //MessageBox.Show(cObjList.Count.ToString());
                foreach (M_Product_BS item in cObjList)
                {
                    tblProduct.Rows.Add();
                    tblProduct.Rows[i].Cells[0].Value = item.ID;
                    tblProduct.Rows[i].Cells[1].Value = item.name;
                    tblProduct.Rows[i].Cells[2].Value = item.catObj.name;
                    tblProduct.Rows[i].Cells[3].Value = item.cost;
                    tblProduct.Rows[i].Cells[4].Value = item.unitPrice;

                    tblProduct.Rows[i].Cells[5].Value = item.warranty;
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
