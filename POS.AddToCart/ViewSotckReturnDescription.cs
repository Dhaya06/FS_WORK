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

namespace POS.AddToCart
{
    public partial class ViewSotckReturnDescription : Form
    {
        int stockID = 0;
        string description="";
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        public ViewSotckReturnDescription(int sid, string description)
        {
            InitializeComponent();
            stockID = sid;
            this.description = description;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.rtbDescription.Text = this.description;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
