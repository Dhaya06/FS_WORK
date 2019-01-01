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
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
            this.TopLevel = true;
            CenterToScreen();
            this.MinimizeBox = false;
            this.ControlBox = false;
           
        }
    }
}
