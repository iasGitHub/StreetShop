using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace GestionStock.App_Start
{
    public class GMailer
    {
 
            public static string GmailUsername { get; set; }
            public static string GmailPassword { get; set; }
            public static string GmailHost { get; set; }
            public static int GmailPort { get; set; }
            public static bool GmailSSL { get; set; }

            public string ToEmail { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public bool IsHtml { get; set; }

            static GMailer()
            {
                GmailHost = "smtp.gmail.com";
                GmailPort = 25; // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment.
                GmailSSL = true;
            }

            public void Send()
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = GmailHost;
                smtp.Port = GmailPort;
                smtp.EnableSsl = GmailSSL;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

                using (var message = new MailMessage(GmailUsername, ToEmail))
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = IsHtml;
                    //smtp.Send(message);
                }
            }

        public static void senMail(string destinataire, string subjet, string body)
        {

                GMailer.GmailUsername = ConfigurationManager.AppSettings["UserEmail"];
                GMailer.GmailPassword = ConfigurationManager.AppSettings["UserPassword"];
                

                GMailer mailer = new GMailer();
                mailer.ToEmail = destinataire;
                mailer.Subject = subjet;
                mailer.Body = body;
                mailer.IsHtml = true;
                mailer.Send();
            }
        }
    
}