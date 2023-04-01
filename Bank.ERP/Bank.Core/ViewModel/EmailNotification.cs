using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ViewModel
{
    public class EmailNotification
    {
        public EmailNotification() {
            this.MessageForQueueGenerationTime = System.DateTime.Now;
        }
        public string Subject { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Body { get; set; }
        public DateTime MessageForQueueGenerationTime { get; set; }
        public string PhonNo { get; set; }

    }
}
