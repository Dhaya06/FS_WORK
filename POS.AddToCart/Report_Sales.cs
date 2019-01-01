using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.AddToCart
{
    public partial class Report_Sales : MetroFramework.Forms.MetroForm
    {
        public Report_Sales()
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();
              //  t.Abort();
                panelSideMenu.Width = 0;

            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            this.CenterToScreen();

            SetMyCustomFormat();              
        }

        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            dateStart.Format = DateTimePickerFormat.Custom;
            dateStart.CustomFormat = "dd/MM/yyyy";
            dateEnd.Format = DateTimePickerFormat.Custom;
            dateEnd.CustomFormat = "dd/MM/yyyy";
        }

        public void GifLoading()
        {
            Application.Run(new loading());
        }

        private void Report_Sales_Load(object sender, EventArgs e)
        {
                    DateTime date = DateTime.Now;
                    var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                    var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            
            // TODO: This line of code loads data into the 'Sale_Data_Set._Sales' table. You can move, or remove it, as needed.
            this._SalesTableAdapter.Fill(this.Sale_Data_Set._Sales, firstDayOfMonth, lastDayOfMonth);
            //Where date_time > @X AND date_time < @Y
                   // this._SalesTableAdapter.Fill(this.Sale_Data_Set._Sales);
            this.reportViewer1.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this._SalesTableAdapter.Fill(this.Sale_Data_Set._Sales, Convert.ToDateTime(dateStart.Text), Convert.ToDateTime(dateEnd.Text));

            this.reportViewer1.RefreshReport();
        }

        private void lnkBack_Click(object sender, EventArgs e)
        {

            if (panelSideMenu.Width >= 250)
            {
                // this.panelSideMenu.Enabled = false;
                panelSideMenu.Width = 0;


            }
            else
                this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panelSideMenu.Width >= 250)
            {
                this.timer1.Enabled = false;

            }
            else
            {
                panelSideMenu.Width += 12;


            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            System.GC.Collect();
            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            System.GC.Collect();
            this.Hide();
            var form2 = new FormBilling();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            System.GC.Collect();
            this.Hide();
            var form2 = new Form3();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            System.GC.Collect();
            this.Hide();
            var form2 = new MainMenu_Form();
            form2.Closed += (s, args) => this.Close();
            form2.Show();

        }

    }
}
