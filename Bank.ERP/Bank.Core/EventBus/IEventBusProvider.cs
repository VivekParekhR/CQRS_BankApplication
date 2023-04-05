using Bank.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.EventBus
{
    public interface IEventBusProvider
    {
        void publishEvent(DomainEvents objDomainEvents);
    }
}
