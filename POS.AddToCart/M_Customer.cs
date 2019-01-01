using BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using System.Resources;
using POS.AddToCart.Properties;
using MetroFramework;
namespace POS.AddToCart
{
    public partial class M_Customer : Form
    {

        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        private string[] editGridData;
        private List<Customer> publicList;

        public M_Customer()
        {
            InitializeComponent();
            CenterToScreen();
            this.TopMost = true;
            publicList = new List<Customer>();
            editGridData = new string[6];
            LoadCartInitial();
        }

        private void LoadCartInitial()
        {
            try
            {
                Customer sup = new Customer();
                publicList.Clear();
                publicList = sup.GetLList(con);
                LoadCart(publicList);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //BusinessObjects.MemoryManagement.FlushMemory();

            //this.Hide();
            //var form2 = new MainMenu_Form();
            //form2.Closed += (s, args) => this.Close();
            //form2.Show(); 
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Close();
        }
        private void LoadCart(List<Customer> sList)
        {
            try
            {
                int count = 0;
                dgvSupplier.Rows.Clear();
                if (sList == null)
                {
                    return;
                }
                foreach (var item in sList)
	            {
                    dgvSupplier.Rows.Add();
                    dgvSupplier.Rows[count].Cells[0].Value = item.Id;
                    dgvSupplier.Rows[count].Cells[1].Value = item.Name;
                    dgvSupplier.Rows[count].Cells[2].Value = item.Contact;
                    dgvSupplier.Rows[count].Cells[3].Value = item.Address;
                    dgvSupplier.Rows[count].Cells[4].Value = item.NIC;
                    count++;

                }
             }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddress.Text == null || txtAddress.Text == "" || txtSupName.Text == null || txtSupName.Text == "" || txtContactNo.Text == null || txtContactNo.Text == "" || txtCompany.Text == "" || txtCompany.Text == null)
            {
                MessageBox.Show("Please enter valid data");
                return;
            }
            string NIC = txtSupName.Text;
            Customer supObj = new Customer(); ;
            bool isExist = supObj.checkNameExit(NIC, con);

            if (isExist)
            {
                PopupNotifier pop = new PopupNotifier();
                pop.ContentText = "Customer Name already exist ";
                pop.TitleText = "Redundancy Error";
                pop.Image = Resources.warning_sign_48; // or Image.FromFile(--Path--)
                pop.IsRightToLeft = false;
                pop.ContentHoverColor = Color.OrangeRed;
                pop.BodyColor = Color.White;
                pop.HeaderColor = Color.Teal;
                pop.Popup();
                return;
            }
           
            supObj.Name = txtSupName.Text;
            supObj.Address = txtAddress.Text;
            supObj.Contact = txtContactNo.Text;
            supObj.NIC = txtCompany.Text;

                if (supObj.Add(con))
                {
                    MetroMessageBox.Show(this, "Customer Data Stored Successfully", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    PopupNotifier pop = new PopupNotifier();
                    pop.ContentText = "Customer Data Added Successfully";
                    pop.TitleText = "Saved";
                    pop.Image = Resources.success_48; // or Image.FromFile(--Path--)
                    pop.IsRightToLeft = false;
                    pop.ContentHoverColor = Color.OrangeRed;
                    pop.BodyColor = Color.White;
                    pop.HeaderColor = Color.Teal;
                    pop.Popup();
                    LoadCartInitial();
                }
            }

            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool nonNumberEntered = false;
        private void txtContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                MessageBox.Show("Please enter numbers only");
                e.Handled = true;
            }
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rw = e.RowIndex;
                int cl = e.ColumnIndex;

                if (cl == 5)
                {
                    if (editGridData[0] == null || string.IsNullOrEmpty(editGridData[0]))
                    {
                        PopupNotifier pop = new PopupNotifier();
                        pop.ContentText = "Content Never been Edited";
                        pop.TitleText = "Aborted";
                        pop.Image = Resources.warning_sign_48; // or Image.FromFile(--Path--)
                        pop.IsRightToLeft = false;
                        pop.ContentHoverColor = Color.OrangeRed;
                        pop.BodyColor = Color.White;
                        pop.HeaderColor = Color.Teal;
                        pop.Popup();
                       
                        return; 
                    }
                    int edited = 0;
                    if (rw != Convert.ToInt32(editGridData[5]))
                    {
                        MessageBox.Show("Please edit the current row and click update");
                      
                        return; 
                    }
                    if (dgvSupplier.Rows[rw].Cells[1].Value != editGridData[1])
                    {
                        edited++;
                    }
                    if (dgvSupplier.Rows[rw].Cells[2].Value != editGridData[2])
                    {
                        edited++;
                    }
                    if (dgvSupplier.Rows[rw].Cells[3].Value != editGridData[3])
                    {
                        edited++;
                    }
                    if (dgvSupplier.Rows[rw].Cells[4].Value != editGridData[4])
                    {
                        edited++;
                    }

                    if (edited > 0)
                    {
                        Customer sp = new Customer();
                        sp.Id =Convert.ToInt32(dgvSupplier.Rows[rw].Cells[0].Value.ToString());
                        sp.Name = dgvSupplier.Rows[rw].Cells[1].Value.ToString();
                        sp.Contact = dgvSupplier.Rows[rw].Cells[2].Value.ToString();
                        sp.Address = dgvSupplier.Rows[rw].Cells[3].Value.ToString();
                        sp.NIC = dgvSupplier.Rows[rw].Cells[4].Value.ToString();

                        if (sp.Update(con))
                        {
                            MetroMessageBox.Show(this, "Customer Data Updated Successfully", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            PopupNotifier pop = new PopupNotifier();
                            pop.ContentText = "Customer Data Updated Successfully";
                            pop.TitleText = "Saved";
                            pop.Image = Resources.success_48; // or Image.FromFile(--Path--)
                            pop.IsRightToLeft = false;
                            pop.ContentHoverColor = Color.OrangeRed;
                            pop.BodyColor = Color.White;
                            pop.HeaderColor = Color.Teal;
                            pop.Popup();
                            LoadCartInitial();
                        }

                    }
                    else {
                        PopupNotifier pop = new PopupNotifier();
                        pop.ContentText = "Content Never been Edited";
                        pop.TitleText = "Aborted";
                        pop.Image = Resources.warning_sign_48; // or Image.FromFile(--Path--)
                        pop.IsRightToLeft = false;
                        pop.ContentHoverColor = Color.OrangeRed;
                        pop.BodyColor = Color.White;
                        pop.HeaderColor = Color.Teal;
                        pop.Popup();
                     
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void dgvSupplier_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                int rw = e.RowIndex;
                int cl = e.ColumnIndex;
                if (dgvSupplier.Rows[rw].Cells[0].Value == null || dgvSupplier.Rows[rw].Cells[0].Value == string.Empty || string.IsNullOrWhiteSpace(dgvSupplier.Rows[rw].Cells[0].Value.ToString()))
                {
                    return;
                }

                string id = dgvSupplier.Rows[rw].Cells[0].Value.ToString();
                string Name = dgvSupplier.Rows[rw].Cells[1].Value.ToString();
                string Contact = dgvSupplier.Rows[rw].Cells[2].Value.ToString();
                string Address = dgvSupplier.Rows[rw].Cells[3].Value.ToString();
                string Company = dgvSupplier.Rows[rw].Cells[4].Value.ToString();

                editGridData[0]=id;
                editGridData[1] = Name;
                editGridData[2] = Contact;
                editGridData[3] = Address;
                editGridData[4] = Company;
                editGridData[5] = rw.ToString();

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void dgvSupplier_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rw = e.RowIndex;
                int cl = e.ColumnIndex;
                if (dgvSupplier.Rows[rw].Cells[0].Value == null || string.IsNullOrWhiteSpace(dgvSupplier.Rows[rw].Cells[0].Value.ToString()))
                {
                    return;
                }
                if (dgvSupplier.Rows[rw].Cells[0].Value == null)
                {
                  dgvSupplier.Rows[rw].Cells[0].Value=  editGridData[0].ToString();
                }
                if (dgvSupplier.Rows[rw].Cells[1].Value == null||dgvSupplier.Rows[rw].Cells[1].Value==string.Empty||string.IsNullOrWhiteSpace(dgvSupplier.Rows[rw].Cells[1].Value.ToString()))
                {
                    dgvSupplier.Rows[rw].Cells[1].Value = editGridData[1].ToString();
                }
                if (dgvSupplier.Rows[rw].Cells[2].Value == null || dgvSupplier.Rows[rw].Cells[2].Value == string.Empty || string.IsNullOrWhiteSpace(dgvSupplier.Rows[rw].Cells[2].Value.ToString()))
                {
                    dgvSupplier.Rows[rw].Cells[2].Value = editGridData[2].ToString();
                }
                if (dgvSupplier.Rows[rw].Cells[3].Value == null || dgvSupplier.Rows[rw].Cells[3].Value == string.Empty || string.IsNullOrWhiteSpace(dgvSupplier.Rows[rw].Cells[3].Value.ToString()))
                {
                    dgvSupplier.Rows[rw].Cells[3].Value = editGridData[3].ToString();
                }
                if (dgvSupplier.Rows[rw].Cells[4].Value == null || dgvSupplier.Rows[rw].Cells[4].Value == string.Empty || string.IsNullOrWhiteSpace(dgvSupplier.Rows[rw].Cells[4].Value.ToString()))
                {
                    dgvSupplier.Rows[rw].Cells[4].Value = editGridData[4].ToString();
                }
                if (IsDigitsOnly(dgvSupplier.Rows[rw].Cells[2].Value.ToString()))
                {
                }
                else
                {
                    dgvSupplier.Rows[rw].Cells[2].Value = editGridData[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "System Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
        }
        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                LoadCart(publicList);
            }
        }

        private void PBMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}