#region Using
using Bank.Domain.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace Bank.Domain.Shared
{
    public abstract class EventGenerator : AggregateRoot
    {
        public static void GenerateDomainEvent(IDomainEvent domain)
        {
            RaiseEvent(domain); 
        }

    }
}
