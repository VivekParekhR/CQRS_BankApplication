
#region Using
using Bank.Domain.Shared;
#endregion

namespace Bank.Domain.Events
{
    public sealed record BankCreatedDomainEvent : IDomainEvent
    {
        public Entity.Bank Bank { get; set; } = new Entity.Bank();  
    }
}
