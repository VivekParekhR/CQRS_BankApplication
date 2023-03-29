using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Shared.Common
{
    public class ERPConstant
    {
        public const string FromEmail = "vivekparekh111@gmail.com";
        public const string ToEmail = " Email ";
        public const string PhonNo = " PhoneNo ";

        

        public const string RabbitMQ_URL = "rabbitmq://localhost";
        public const string RabbitMQ_UserName = "guest";
        public const string RabbitMQ_Password = "guest";

        public const string RabbitMQ_EmailQueue = "emailQueue";


        public const string SmtpClient = "smtp.gmail.com";
        public const bool SmtpEnable = false; 
        public const int SmtpSSLCommnicationPort = 465;
        public const string SmtpUserName = " email ";
        public const string SmtpUserPassword = " password ";
        public const string SMSToken = " Sms token of ultra message if we want to run message functionality "; 
    }
}
