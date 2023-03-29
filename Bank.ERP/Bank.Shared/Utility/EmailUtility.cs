using Bank.Shared.Common;
using Bank.Shared.ServiceMessagingObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Shared.Utility
{
    public static class EmailUtility
    {
        public static async Task SendEmail(EmailNotification emailNotification)
        {
            try
            {
                MailMessage newMail = new();

                // SMTP HOST
                SmtpClient client = new(ERPConstant.SmtpClient);

                // FROM
                newMail.From = new MailAddress(emailNotification.FromAddress, emailNotification.FromName);

                // TO
                newMail.To.Add(emailNotification.ToAddress);// declare the email subject

                // SUBJECT
                newMail.Subject = emailNotification.Subject; // use HTML for the email body

                // BODY
                newMail.IsBodyHtml = true; newMail.Body = emailNotification.Body;

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                System.Net.ServicePointManager.Expect100Continue = false;
                // SSL
                client.EnableSsl = ERPConstant.SmtpEnable;

                // SSL Communication PORT
                client.Port = ERPConstant.SmtpSSLCommnicationPort;
                
                // NETWORK Credential
                client.Credentials = new System.Net.NetworkCredential(ERPConstant.SmtpUserName, ERPConstant.SmtpUserPassword);
 
                await client.SendMailAsync(newMail); 
                Console.WriteLine("Email Sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -" + ex);
            }

        }   
    }
}
