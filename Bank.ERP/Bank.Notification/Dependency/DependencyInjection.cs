using Bank.Core.Constant;
using Bank.Notification.Consumer;
 
using MassTransit;

namespace Bank.Notification.Extention
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
                }));
            });

            return services;
        }
    }
}
