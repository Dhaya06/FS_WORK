using POS.AddToCart.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace POS.AddToCart
{
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
            Thread.Sleep(7000);
            this.MaximizeBox = false;
            this.CenterToScreen();
            //this.Resizable = false;
            //this.Movable = false;
           

            this.ActiveControl = txName;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void PBMinimise_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BusinessObjects.MemoryManagement.FlushMemory();
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
            if (string.IsNullOrEmpty(txName.text) || string.IsNullOrEmpty(txtMessage.Text) || string.IsNullOrEmpty(txtSubject.text))
            {
                MessageBox.Show("Invalid Data! Please enter valid data to the text area");
                return;
            }
            string name = txName.text;
            string message = txtMessage.Text;
            string subject2 = txtSubject.text;

            
                var fromAddress = new MailAddress("futuresoftf24@gmail.com", "Vista POS");
            var toAddress = new MailAddress("dhayanthdharma@gmail.com", "Dharmalingam Dhayananth");
            const string fromPassword = "mntcidyjahveljme";
             string subject = "Vista User Message : "+DateTime.Now.ToString();

             string body = @"Name: " + name + "\n" + "Subject: " + subject2 + "\n" + "Message: " + message;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var messagee = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {

                smtp.Send(messagee);

                PopupNotifier pop = new PopupNotifier();
                pop.ContentText = "Message has been Sent";
                pop.TitleText = "Delivered";
                pop.Image = Resources.success_48; // or Image.FromFile(--Path--)
                pop.IsRightToLeft = false;
                pop.ContentHoverColor = Color.OrangeRed;
                pop.BodyColor = Color.Orange;
                pop.Popup();
                
                txtMessage.Text = string.Empty;
                txtSubject.text = string.Empty;
                txName.text = string.Empty;
            }

           
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        }
    }
}
