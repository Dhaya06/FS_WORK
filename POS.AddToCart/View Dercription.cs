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
    public partial class View_Dercription : MetroFramework.Forms.MetroForm
    {
        public View_Dercription(string desc)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Resizable = false;
            this.Movable = false;
            this.MaximizeBox = false;
            this.TopMost = true;
            richTextBox1.Text = desc;
        }

        private void button1_Click(object sender, EventArgs e)
        { BusinessObjects.MemoryManagement.FlushMemory();
            this.Close();
           
        }
    }
}
