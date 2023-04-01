
using Bank.Domain.Entity;
using Bank.Infrastructure.Common;
using MassTransit;

namespace Bank.Notification.Consumer
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
