using Bank.Core.Constant;
using Bank.Core.ViewModel;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.EventBus
{
    internal class EventBusProvider : IEventBusProvider
    {

        private IBus _bus;
        public EventBusProvider(IBus bus)
        {
            _bus = bus;

        }
        public async Task publishDomainEventAsync(DomainEvents objDomainEvents)
        {
            Uri uri = new Uri("rabbitmq://localhost/" + ERPConstant.RabbitMQ_DomainEventQueue);
            var endPoint = await _bus.GetSendEndpoint(uri);
            if (endPoint != null)
            {
                await endPoint.Send(objDomainEvents);
            }
        }

        public async Task publishEmailEventAsync(EmailNotification objEmailNotification)
        {
            Uri uri = new Uri("rabbitmq://localhost/" + ERPConstant.RabbitMQ_EmailQueue);
            var endPoint = await _bus.GetSendEndpoint(uri);
            if (endPoint != null)
            {
                await endPoint.Send(objEmailNotification);
            }
        }
    }
}
