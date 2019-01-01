using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POS.AddToCart
{
    public partial class VIewPrinters : MetroFramework.Forms.MetroForm
    {
        string con = ConfigurationManager.ConnectionStrings["pos"].ConnectionString;
        PrintDocument printDoc = new PrintDocument();

        public VIewPrinters()
        {
            //Thread t = new Thread(new ThreadStart(GifLoading));
            //t.Start();
            InitializeComponent();

            this.TopLevel = true;
            LoadPrinterName();
            LoadPaperSize();
            LoadPaperSource();
            LoadResolution();
              //t.Abort();

        }

        public void GifLoading()
        {
            Application.Run(new loading());
        }
        private void mlnkChoose_Click(object sender, EventArgs e)
        {
            try
            {

            if(cmbPrinterName.SelectedIndex==-1||cmbPrintResolution.SelectedIndex==-1||comboPaperSize.SelectedIndex==-1
                ||comboPaperSource.SelectedIndex==-1)
            {
                MetroMessageBox.Show(this, "Please Configure the Printer Settings", "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
             

                return;                  
            }

            BusinessObjects.Print ps = new BusinessObjects.Print();

            if (cmbPrinterName.SelectedIndex != -1)
            {
                ps.PrinterName = cmbPrinterName.SelectedItem.ToString();
            }
                    if (comboPaperSize.SelectedIndex != -1)
                    {    
                       /* printDoc.DefaultPageSettings.PaperSize =           
                        printDoc.PrinterSettings.PaperSizes[comboPaperSize.SelectedIndex];*/
                        ps.PaperSize = comboPaperSize.SelectedIndex;
                   
                    
                    } 

                    if (comboPaperSource.SelectedIndex != -1) 
                    {        /* printDoc.DefaultPageSettings.PaperSource =             
                        printDoc.PrinterSettings.PaperSources[comboPaperSource.SelectedIndex];*/
                        ps.Source = comboPaperSource.SelectedIndex;
                    
                    } 

                    if (cmbPrintResolution.SelectedIndex != -1)      
                    {      /*   printDoc.DefaultPageSettings.PrinterResolution=            
                        printDoc.PrinterSettings.PrinterResolutions [cmbPrintResolution.SelectedIndex];*/
                        ps.Resolution = cmbPrintResolution.SelectedIndex;
                    
                    }

                    ps.Delete(con);

                    if (ps.ADD_Print_Settings(con))
                    {
                        MessageBox.Show("Settings Changed Successfully");
                    }
                    else 
                    {
                        MessageBox.Show("System Error. Please contact your administrator");
                    }
                  
            }
            catch (Exception a )
            {

                MessageBox.Show(a.Message);
            }
        }

        private void LoadPrinterName()
        {
            try
            {
                List<string> PrinterList = new List<string>();

                if (System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count < 1)
                {
                    MetroMessageBox.Show(this, "No Printes Found!!!", "MetroMessageBox", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }

                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    PrinterList.Add(printer);
                }
                cmbPrinterName.DataSource = PrinterList;
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LoadPaperSize()
        {
            try
            {
                comboPaperSize.DisplayMember = "PaperName";
                PaperSize pkSize;
                for (int i = 0; i < printDoc.PrinterSettings.PaperSizes.Count; i++)
                { pkSize = printDoc.PrinterSettings.PaperSizes[i]; comboPaperSize.Items.Add(pkSize); }

                PaperSize pkCustomSize1 = new PaperSize("First custom size", 100, 200);
                comboPaperSize.Items.Add(pkCustomSize1); 
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LoadPaperSource()
        {
            try
            {
                comboPaperSource.DisplayMember = "SourceName";
                PaperSource pkSource;
                for (int i = 0; i < printDoc.PrinterSettings.PaperSources.Count; i++)
                {
                    pkSource = printDoc.PrinterSettings.PaperSources[i];
                    comboPaperSource.Items.Add(pkSource);
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LoadResolution()
        {
            try
            {
                PrinterResolution pkResolution;
                for (int i = 0; i < printDoc.PrinterSettings.PrinterResolutions.Count; i++)
                {
                    pkResolution = printDoc.PrinterSettings.PrinterResolutions[i];
                    cmbPrintResolution.Items.Add(pkResolution);
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, "System Error " + ex.Message, "MetroMessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            

        }

        private void lnkHome_Click(object sender, EventArgs e)
        {
            this.Close();
            //MainMenu_Form mn = new MainMenu_Form();
            //mn.Show();
        }

    }
}
