using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.StaticProvider
{
    public class ERPConstant
    {
        public const string FromEmail = "vivekparekh111@gmail.com";
        public const string ToEmail = "vivekparekh111@gmail.com";
        public const string PhonNo = "63538799001";

        

        public const string RabbitMQ_URL = "rabbitmq://localhost";
        public const string RabbitMQ_UserName = "guest";
        public const string RabbitMQ_Password = "guest";

        public const string RabbitMQ_EmailQueue = "emailQueue";


        public const string SmtpClient = "smtp.gmail.com";
        public const bool SmtpEnable = false; 
        public const int SmtpSSLCommnicationPort = 465;
        public const string SmtpUserName = "vivekparekh111@gmail.com";
        public const string SmtpUserPassword = "Vivek#123@345";
        public const string SMSToken = "o60zz57v2pwmo4t8";



    }
}
