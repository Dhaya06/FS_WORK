using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using System.Windows.Forms;
using System.Configuration;

namespace POS.AddToCart
{
    public partial class ChequePay : MetroFramework.Forms.MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        int slesId = 0;
        FormBilling privateForm;
        public ChequePay(FormBilling argForm,int sid)
        {
            
            InitializeComponent();
            this.Resizable = false;
            this.ControlBox = false;
            this.TopMost = true;
            SetMyCustomFormat();
            slesId = sid;
            privateForm = argForm;
        }

        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            dtpChequeDate.Format = DateTimePickerFormat.Custom;
            dtpChequeDate.CustomFormat = "MM/dd/yyyy";
            
        }
        public bool isNumber(char ch, string text)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            //check if it´s a decimal separator and if doesn´t already have one in the text string
            if (ch == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            //check if it´s a digit, decimal separator and backspace
            if (!Char.IsDigit(ch) && ch != decimalChar && ch != (char)Keys.Back)
                res = false;

            return res;
        }

        

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar, txtAmount.Text))
                e.Handled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {


            if (txtAmount.Text == "" || txtAmount.Text == null || txtBank.Text == "" || txtBank.Text == null || txtBranch.Text == "" || txtBranch.Text == null
                || txtChequeNo.Text == "" || txtChequeNo.Text == null || txtName.Text == "" || txtName.Text == null || rtbDetails.Text == "" || rtbDetails.Text == null)
            {
                MetroMessageBox.Show(this, "Information incomplete. Enter Valid Information.", "! System Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           // Cheque cheque = new Cheque();
            privateForm.chequeTemp.customer_name = txtName.Text;
            privateForm.chequeTemp.amount =Convert.ToDecimal( txtAmount.Text);
            privateForm.chequeTemp.bank = txtBank.Text;
            privateForm.chequeTemp.salesId = slesId;
            privateForm.chequeTemp.branch = txtBranch.Text;
            privateForm.chequeTemp.cheque_no = txtChequeNo.Text;
            privateForm.chequeTemp.cheque_date = Convert.ToDateTime(dtpChequeDate.Text);
            privateForm.chequeTemp.details = rtbDetails.Text;
            //if (cheque.Add(con))
           if(privateForm.chequeTemp!=null)
            {

                privateForm.checkCheque = true;
                MetroMessageBox.Show(this, "Transaction Successfully Stored. Hive Five ", "<(*) Success Hoe", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MetroMessageBox.Show(this, "Somethign went wrong buddy ", "<(*) Appologize Bae", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            
            
            
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "System Error " + ex.Message, "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {   
            txtName.Text=string.Empty;
            txtAmount.Text = string.Empty;
            txtBank.Text = string.Empty;
            txtBranch.Text = string.Empty;
            txtChequeNo.Text = string.Empty;
            dtpChequeDate.Text = string.Empty;
            rtbDetails.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            if (!privateForm.checkCheque)
            {
                MetroMessageBox.Show(this, "The cheque details were not processed properly. This transaction will considered under CASH Transation", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }



        
    }
}
