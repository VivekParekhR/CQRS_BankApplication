using Bank.Domain.Events;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Shared
{
    public abstract class AggregateRoot
    {
        private static readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearEvent()
        {
            _domainEvents.Clear();
        }

        public static void RaiseEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        } 
    }
}
