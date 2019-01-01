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
using Tulpep.NotificationWindow;
using POS.AddToCart.Properties;
namespace POS.AddToCart
{
    public partial class V_Customer : Form
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        private int sales_id;
        public V_Customer(int sid)
        {
            InitializeComponent();
            this.ControlBox = false;
            sales_id = sid;
            loadgrid();
            this.CenterToScreen();
                increaseWidth();
        }
        void increaseWidth()
        {
            dgvSupplier.Columns[0].Width = 60;
            dgvSupplier.Columns[1].Width = 145;
            dgvSupplier.Columns[2].Width = 120;
            dgvSupplier.Columns[3].Width = 140;
            dgvSupplier.Columns[4].Width = 120;
        }
        private void loadgrid()
        {
            dgvSupplier.Rows.Clear();
           //USING SID BRING TEH CUSTOMER DETAILS USING A PROCEDURE
            Customer cum = new Customer();
            cum = cum.GetCustomerBySID(con, sales_id);
            if (cum.Id == null|| string.IsNullOrEmpty(cum.Name))
            {
                //MessageBox.Show("Products were added");
                PopupNotifier pop = new PopupNotifier();
                pop.ContentText = "Cusrtomer Data Not Found";
                pop.TitleText = "Notification";
                 pop.Image = Resources.error_48; // or Image.FromFile(--Path--)
                pop.IsRightToLeft = false;
              
                pop.ContentHoverColor = Color.Blue;
                pop.Popup();
               
                return;
            }
            
                dgvSupplier.Rows.Add();
                dgvSupplier.Rows[0].Cells[0].Value = cum.Id;
                dgvSupplier.Rows[0].Cells[1].Value = cum.Name;
                dgvSupplier.Rows[0].Cells[2].Value = cum.Contact;
                dgvSupplier.Rows[0].Cells[3].Value = cum.Address;
                dgvSupplier.Rows[0].Cells[4].Value = cum.NIC;
             

            
        
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
