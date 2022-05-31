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
    public partial class SendMail : Form
    {
        public SendMail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailAddress fromMailAddress = new MailAddress("shlepamaster73@gmail.com", "DigitalShop");
            MailAddress toAddress = new MailAddress(textBox1.Text, "user");

            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))

            using (SmtpClient smtpClient = new SmtpClient())
            {
                mailMessage.Subject = "Ваша корзина";
                mailMessage.Body = "Salam Aleikum brat!" + Environment.NewLine;
                mailMessage.IsBodyHtml = true;

                System.IO.File.WriteAllText("Ваш заказ.csv", "Название,Цена(руб),Количество(шт.)");

                foreach (KeyValuePair<Videocards, int> Fav_Videocards in Favourite.favouriteVideocards)
                {
                    Videocards videocard = Fav_Videocards.Key;
                    System.IO.File.AppendAllText("Ваш заказ.csv",
                    Environment.NewLine + 
                    videocard.name + ", " + videocard.price + ", " + Fav_Videocards.Value);
                }

                System.IO.File.AppendAllText("Ваш заказ.csv",
                  Environment.NewLine + "Общая стоимость заказа (руб.) " + Favourite.totalPrice);


                mailMessage.Attachments.Add(new Attachment("Ваш заказ.csv"));

                    smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "OtmeniteOGE2022");

                smtpClient.Send(mailMessage);
                
            }
            MessageBox.Show("Ваша заяка была успеша отправлена!");

        }
    }
}
