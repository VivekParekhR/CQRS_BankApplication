using Bank.Core.Constant; 
using Bank.NotificationApi.Consumer;
using MassTransit;

namespace Bank.Notification.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNotification(
          this IServiceCollection services)
        {
            //// Resolve Behaviours
            services.AddMassTransit(x =>
            {
                x.AddConsumer<EmailConsumer>();
                x.AddConsumer<DomainEventConsumer>(); 
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(ERPConstant.RabbitMQ_URL), h =>
                    {
                        h.Username(ERPConstant.RabbitMQ_UserName);
                        h.Password(ERPConstant.RabbitMQ_Password);
                    });
                    cfg.ReceiveEndpoint(ERPConstant.RabbitMQ_EmailQueue, ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<EmailConsumer>(provider); 

                    });
                    cfg.ReceiveEndpoint(ERPConstant.RabbitMQ_DomainEventQueue, ep =>
                    {
                        ep.PrefetchCount = 20;
                        ep.UseMessageRetry(r => r.Interval(3, 150));
                        ep.ConfigureConsumer<DomainEventConsumer>(provider);

                    });
                }));
            });

            return services;
        }
    }
}
