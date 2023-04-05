using Bank.Core.ViewModel;
using MassTransit;

namespace Bank.NotificationApi.Consumer
{
    public class DomainEventConsumer : IConsumer<DomainEvents>
    {
        public Task Consume(ConsumeContext<DomainEvents> context)
        {
            var data = context.Message;
            return Task.CompletedTask;
            Console.WriteLine(data);
        }
    }
}
