using Bank.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Events
{
    public sealed record CustomerBankCreatedDomainEvent : IDomainEvent
    {
        public Entity.CustomerBank CustomerBank { get; set; } = new Entity.CustomerBank();  
    }
}
