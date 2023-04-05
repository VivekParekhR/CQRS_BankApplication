
using Bank.Core.Common;
using Bank.Core.ViewModel;
using MassTransit;

namespace Bank.NotificationApi.Consumer
{
    public class EmailConsumer:IConsumer<EmailNotification>
    {
        public async Task Consume(ConsumeContext<EmailNotification> context)
        {
            var data = context.Message;
            await EmailUtility.SendEmail(data);
            await SMSUtility.SendMessage(data);
            Console.WriteLine(data);    
        }
    }
}
