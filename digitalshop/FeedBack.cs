using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace digitalshop
{
    public partial class FeedBack : Form
    {
        public FeedBack()
        {
            InitializeComponent();
        }

        private void FeedBack_Load(object sender, EventArgs e)
        {
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            MailAddress fromMailAddress = new MailAddress("shlepamaster73@gmail.com", "DigitalShop");
            MailAddress toAddress = new MailAddress("shlepamaster73@gmail.com", "user");
            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))

            using (SmtpClient smtpClient = new SmtpClient())
            {
                mailMessage.Subject = comboBox1.Text;
                mailMessage.Body = "Salam Aleikum brat!" + Environment.NewLine + textBox1.Text;
                mailMessage.IsBodyHtml = true;


                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "OtmeniteOGE2022");

                smtpClient.Send(mailMessage);

            }
            MessageBox.Show("Ваша заяка была успеша отправлена!");
            Close();
        }
    }
}

