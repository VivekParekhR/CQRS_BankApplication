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
        public void publishEvent(DomainEvents objDomainEvents)
        {
            Uri uri = new Uri("rabbitmq://localhost/domainEventQueue");
            var endPoint = _bus.GetSendEndpoint(uri).Result;
            if (endPoint != null)
            {
                endPoint.Send(objDomainEvents);
            }
        }
    }
}
