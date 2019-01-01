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
using MetroFramework;
using System.Threading;
namespace POS.AddToCart
{
    public partial class M_Category : MetroFramework.Forms.MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        public M_Category()
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();

            this.TopMost = true;
            this.Resizable = false;
            this.Movable = false;
            this.ControlBox = false;

            //t.Abort();
            metroTabControl1.SelectedTab = metroTabPage1;
        }

        public void GifLoading()
        {
            Application.Run(new loading());
        }
        private void lnkOK_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(txtCategory.Text))
                {
                    MetroMessageBox.Show(this, "Please enter valid data to the text fields", "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                Category_BS CBS = new Category_BS();
                string name = txtCategory.Text;

                CBS.name = name;


                if (CBS.Add(con))
                {
                    MetroMessageBox.Show(this, "Successfully Saved", "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                 
                }
                else
                    MetroMessageBox.Show(this, "System error", "MetroMessageBox", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System error  " + ex.Message, "MetroMessageBox", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }


        }

        private void lnkCancel_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Close();
        }


        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedIndex == 1)
            {
             loadGrid();
            }


        }

        private void loadGrid()
        {
            try
            {
                BusinessObjects.Category_BS cObj = new Category_BS();
                List<BusinessObjects.Category_BS> cObjList = new List<Category_BS>();
                cObjList = cObj.GetCategory(con);
                int i = 0;
                grdCategory.Rows.Clear();
                foreach (Category_BS item in cObjList)
                {
                    grdCategory.Rows.Add();
                    grdCategory.Rows[i].Cells[0].Value = item.ID;
                    grdCategory.Rows[i].Cells[1].Value = item.name;
                    i++;
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
