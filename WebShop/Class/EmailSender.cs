using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;

namespace WebShop.Class
{
    public class EmailSender
    {
        

        public void SendEmail(string ime, string email,string message) //slanje mejla na sopstveni mejl sa kontakt forme
        {
            MailMessage mailMessage = new MailMessage("petarpetrovicnjegos4@gmail.com", "petarpetrovicnjegos4@gmail.com");
            mailMessage.Subject = "ime: " + ime + " Email: " + email + " KONTAKT PORUKA";
            StringBuilder bodyMessage=new StringBuilder();
            bodyMessage.Append("<br/>");
            bodyMessage.Append("Poruka:");
            bodyMessage.Append("<br/>");
            bodyMessage.Append(message);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587);
            smtpClient.Credentials=new System.Net.NetworkCredential()
            {
                UserName = "petarpetrovicnjegos4@gmail.com",
                Password="petarpetrovic123"
            };
            mailMessage.Body = bodyMessage.ToString();
            smtpClient.EnableSsl = true;
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);

        }

        public void SendEmailTOreset(string ime, string email, string message) //slanje mejla korisniku za reset
        {
            MailMessage mailMessage = new MailMessage("petarpetrovicnjegos4@gmail.com",email);
            mailMessage.Subject = ime + " Email: " + email + " LINK ZA RESET LOZINKE BOOKSTORE.COM";
            StringBuilder bodyMessage = new StringBuilder();
            bodyMessage.Append("<br/>");
            bodyMessage.Append("Link za reset Lozinke:");
            bodyMessage.Append("<br/>");
            bodyMessage.Append(message);

            mailMessage.Body = bodyMessage.ToString();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "petarpetrovicnjegos4@gmail.com",
                Password = "petarpetrovic123"
            };
            smtpClient.EnableSsl = true;
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);

        }
        public void SendEmailTO(string ime, string email, string message) //slanje mejla korisniku 
        {
            MailMessage mailMessage = new MailMessage("petarpetrovicnjegos4@gmail.com", email);
            mailMessage.Subject = ime + " Email: " + email + " NARUČENI ARTIKLI BOOKSTORE.COM";
            StringBuilder bodyMessage = new StringBuilder();
            bodyMessage.Append("<br/>");
            bodyMessage.Append("Poručeni artikli:");
            bodyMessage.Append("<br/>");
            bodyMessage.Append(message);
            mailMessage.Body = bodyMessage.ToString();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "petarpetrovicnjegos4@gmail.com",
                Password = "petarpetrovic123"
            };
            smtpClient.EnableSsl = true;
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);

        }
    }
}