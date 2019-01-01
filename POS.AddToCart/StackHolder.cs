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

namespace POS.AddToCart
{
    public partial class StackHolder : Form
    {
        public StackHolder()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.CenterToScreen();
            this.TopMost = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Name == "M_Customer")
                {
                    MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
            }
            using (M_Customer ms = new M_Customer())
            {
                ms.ShowDialog();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Name == "M_Suppilier")
                {
                    MetroMessageBox.Show(this, "Form is already opened", "System Message!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
            }
            using (M_Suppilier ms = new M_Suppilier())
            {

                ms.ShowDialog();
            }
        }
    }
}
