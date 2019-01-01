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
using System.Configuration;
using POS.AddToCart.Properties;
using BusinessObjects;
using Tulpep.NotificationWindow;

namespace POS.AddToCart
{
    public partial class V_Supplier : Form
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        private int s_id;
        public V_Supplier(int stockID)
        {
            InitializeComponent();
            this.ControlBox = false;
            s_id = stockID;
            LoadCartInitial();
            this.CenterToScreen();
            increaseWidth();
        }
        void increaseWidth()
        {
            dgvSupplier.Columns[0].Width = 60;
            dgvSupplier.Columns[1].Width = 145;
            dgvSupplier.Columns[2].Width = 130;
            dgvSupplier.Columns[3].Width = 140;
            dgvSupplier.Columns[4].Width = 110;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCart(Supplier sList)
        {
            try
            {
                
                dgvSupplier.Rows.Clear();
                if (sList.Name == null && sList.Id < 1)
                {//MessageBox.Show("Products were added");
                    PopupNotifier pop = new PopupNotifier();
                    pop.ContentText = "Supplier Data Not Found";
                    pop.TitleText = "Notification";
                    pop.Image = Resources.error_48; // or Image.FromFile(--Path--)
                    pop.IsRightToLeft = false;

                    pop.ContentHoverColor = Color.Blue;
                    pop.Popup();
                    return;
                }
               
                    dgvSupplier.Rows.Add();
                    dgvSupplier.Rows[0].Cells[0].Value = sList.Id;
                    dgvSupplier.Rows[0].Cells[1].Value = sList.Name;
                    dgvSupplier.Rows[0].Cells[2].Value = sList.Contact;
                    dgvSupplier.Rows[0].Cells[3].Value = sList.Address;
                    dgvSupplier.Rows[0].Cells[4].Value = sList.Company;
                  

                
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void LoadCartInitial()
        {
            try
            {
                Supplier sup = new Supplier();
                Supplier publicList =new Supplier ();
                publicList = sup.GetLListByStockID(con, s_id);
                LoadCart(publicList);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
