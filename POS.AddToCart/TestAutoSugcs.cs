using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;
using System.Configuration;
namespace POS.AddToCart
{
    public partial class TestAutoSugcs : Form
    {

        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        List<BusinessObjects.M_Product_BS> cObjList = new List<M_Product_BS>();
        List<BusinessObjects.GetProductStock> GridList = new List<GetProductStock>();
        List<BusinessObjects.Category_BS> catList = new List<Category_BS>();
        List<BusinessObjects.stock_product> stock_pro_list = new List<stock_product>();
        DataTable dataTable = new DataTable();
        DataTable filteredTable;
        public TestAutoSugcs()
        {

            InitializeComponent();
            InitialloadGrid();
            createAutoSuggest();
        }

        private void InitialloadGrid()
        {
            try
            {
                BusinessObjects.GetProductStock spObj = new GetProductStock();
                BusinessObjects.M_Product_BS cObj = new M_Product_BS();
                cObjList = cObj.GetProducts(con);
                Category_BS catObj = new Category_BS();
                catList = catObj.GetCategory(con);
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void createAutoSuggest()
        {
            try
            {
                dataTable.Columns.Add("PName");
                //cmbAutoSuggest.Enabled = false;
                foreach (M_Product_BS item in cObjList)
                {
                    dataTable.Rows.Add(new string[] { item.name });
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "! System Error . Code 106. " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string nameListp ;
        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
           

                if (string.IsNullOrWhiteSpace(txtProductName.Text))
                {
                    return;
                }

                string name = string.Format("{0}{1}", txtProductName.Text, e.KeyChar.ToString()); //join previous text and new pressed char
                DataRow[] rows = dataTable.Select(string.Format("PName LIKE '%{0}%'", name));
                filteredTable = dataTable.Clone();

                foreach (DataRow r in rows)
                {
                    filteredTable.ImportRow(r);
                }
                List<string> namelist = new List<string>();
                nameListp = string.Empty;
                foreach (DataRow row in filteredTable.Rows)
                {
                    string fname = row["PName"].ToString();
                    //MessageBox.Show(fname);
                    namelist.Add(fname);
                    nameListp = nameListp + Environment.NewLine +fname;
                }
                
                //comboBoxAdv1.DataSource = filteredTable.DefaultView;
                //comboBoxAdv1.DisplayMember = "FirstName";
                cmbAutoSuggest.DataSource = null;

                BindingSource bs = new BindingSource();
                bs.DataSource = namelist;

                cmbAutoSuggest.DataSource = bs;
                toolTip1.Show(nameListp, this.cmbAutoSuggest);
            
           
        }

        private void txtProductName_Enter(object sender, EventArgs e)
        {
         
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {

           
        }

    }
}
