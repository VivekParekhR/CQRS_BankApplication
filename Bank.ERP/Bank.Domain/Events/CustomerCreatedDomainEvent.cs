#region Using
using Bank.Domain.Shared; 
#endregion

namespace Bank.Domain.Events
{
    public sealed record CustomerCreatedDomainEvent : IDomainEvent
    {
        public Entity.Customer Customer { get; set; }  = new Entity.Customer();     
    }
}
