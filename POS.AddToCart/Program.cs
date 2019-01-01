
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS;
using System.Threading;
using BusinessObjects;
using System.Diagnostics;
using System.Runtime.InteropServices;
using log4net;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace POS.AddToCart
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        //private const int SW_SHOWMAXIMIZED = 3;

        //[DllImport("user32.dll")]
        //static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


           [STAThread]
        static void Main()
        {
           Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
   

            bool result=false;
            string procName = Process.GetCurrentProcess().ProcessName;
       

            Process[] processes = Process.GetProcessesByName(procName);
            if (processes.Length > 1)
            {
               // WindowHelperS.BringProcessToFront(Process.GetCurrentProcess());
              //  WindowHelperS.bringToFront(procName);            
                result= true;
            }
            else
            {
                result= false;
            }
            if (result)
            {
                //processes[0].Refresh();
                //processes[0].Start();

                //int id=processes[0].Id;
              MessageBox.Show("Shaleena Start Running behind the Screen");
              MessageBox.Show("Shaleena!  Hi, I will kill all running instances of the same process. So that, memory overhead consumption will be refrain");
              
              Process C_Proces = Process.GetCurrentProcess();
              foreach (var item in Process.GetProcessesByName(procName))
              {
                  if (C_Proces.Id == item.Id)
                      continue;
                  item.Kill();
              }
              Application.Run(new Login());
               // ShowWindow(processes[0].MainWindowHandle, SW_SHOWMAXIMIZED);
            }
            else
            {
                MessageBox.Show("This product is featured with 'Shaleena' an AI program (Beta 0.0 v (Introduce)) , that enforce Self Healing System. Please report any abnormal status of the system to the developers. Be patient when the system frozen. Thank you   - By Futuresoft"); 
                //throw new Exception("Crash Report Is delivered to the developer.");
                Application.Run(new Login());
            }            
            
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());
             /// -------------------------------------------------------------------------------------------------
        }

        /// <summary>
        /// We inherit from the VB.NET WindowsFormApplicationBase class, which has the 
        /// single-instance functionality.
        /// </summary>
        //bool checkSingleInstance()
        //{
        //    string procName = Process.GetCurrentProcess().ProcessName;
        //    // get the list of all processes by that name

        //    Process[] processes = Process.GetProcessesByName(procName);

        //    if (processes.Length > 1)
        //    {

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}




        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //ErrorLogging(e.Exception);
            SentMail(e.Exception);
            MessageBox.Show(e.Exception.Message, "Process Interuptions Occured, This will be automatically sent to developer when connected");
           // Thread.ResetAbort();
        }

        public static void ErrorLogging(Exception ex)
        {
            string strPath = @"D:\dhaya\Log.txt";//change this path 
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }

        public static void ReadError()
        {
            string strPath = @"D:\dhaya\Log.txt";//change this path 
            using (StreamReader sr = new StreamReader(strPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }


        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            SentMail(e.ExceptionObject as Exception);
            MessageBox.Show((e.ExceptionObject as Exception).Message, "System asd Unhandled Exception Occured");
           
        }

        static void SentMail(Exception e)
        {
            
            try
            {
                var fromAddress = new MailAddress("futuresoftf24@gmail.com", "Vista POS");
                var toAddress = new MailAddress("futuresoftf24@gmail.com", "Futuresoft");
            const string fromPassword = "mntcidyjahveljme";
             string subject = "Vista Pos Crash Report : "+DateTime.Now.ToString();
            //Exception exception = e.Exception;
          //  string body = exception.Message + "\n" + exception.Data + "\n" + exception.StackTrace + "\n" + exception.Source;
            string body = @"Error Message:" + "\n" + e.Message + "\n" + "Error Data:" + "\n" + e.Data + "\n" + "Error StackTrace:" + "\n" + e.StackTrace + "\n" + "Error Source:" + "\n" + e.Source;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                //You can also use SendAsync SendAsync(MailMessage, Object) :-
                smtp.Send(message);
                
            }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        
        }

      

    }
}


/*
//*********************i have pasted here. remove it. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS;

namespace POS.AddToCart
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu_Form());
        }
    }
}

*/