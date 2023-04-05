using Bank.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Events
{
    public sealed record TransactionCreatedDomainEvent : IDomainEvent
    {
        public Entity.Transaction Transaction { get; set; } = new Entity.Transaction(); 
        public Entity.CustomerBank CustomerBank { get; set; } = new Entity.CustomerBank();
    }
}
