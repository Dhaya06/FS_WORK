using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using BusinessObjects;
using POS.AddToCart.Properties;
using Tulpep.NotificationWindow;
namespace POS.AddToCart
{
    public partial class ViewSalesProductQuantity : Form
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        int prodID;
        int salesID;
        public ViewSalesProductQuantity(int sid, int pid)
        {
            InitializeComponent();
            this.ControlBox = false;
            prodID = pid;
            this.CenterToScreen();
            salesID = sid;
            this.TopMost = true;
            loadgrid();
        }

        void increaseWidth()
        {
            dgvSupplier.Columns[0].Width = 90;
            dgvSupplier.Columns[1].Width = 150;
            dgvSupplier.Columns[2].Width = 80;
            dgvSupplier.Columns[3].Width = 120;
        }

        private void loadgrid()
        {
            dgvSupplier.Rows.Clear();
           //USING SID BRING TEH CUSTOMER DETAILS USING A PROCEDURE
            CartSaleProductList cum = new CartSaleProductList();
            List<CartSaleProductList> csList = new List<CartSaleProductList>();
            csList = cum.getProduct(con, salesID, prodID);

            if (csList == null || csList.Count<1)
            {
                //MessageBox.Show("Products were added");
                PopupNotifier pop = new PopupNotifier();
                pop.ContentText = "Product Data Not Found";
                pop.TitleText = "Notification";
                 pop.Image = Resources.error_48; // or Image.FromFile(--Path--)
                pop.IsRightToLeft = false;
              
                pop.ContentHoverColor = Color.Blue;
                pop.Popup();
               
                return;
            }
            int count = 0;
            foreach (var item in csList)
            {
                dgvSupplier.Rows.Add();
                dgvSupplier.Rows[count].Cells[0].Value = item.stock_id;
                dgvSupplier.Rows[count].Cells[1].Value = item.pname;
                dgvSupplier.Rows[count].Cells[2].Value = item.quantity;
                dgvSupplier.Rows[count].Cells[3].Value = item.cost;
                count++;
            }
              
             

            
        
        }
     
        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    



}
