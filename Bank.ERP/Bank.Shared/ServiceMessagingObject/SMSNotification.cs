using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Shared.ServiceMessagingObject
{
    public class SMSNotification
    {
        public string FromMobile { get; set; }
        public string ToMobile { get; set; }
        public string Message { get; set; }
    }
}
