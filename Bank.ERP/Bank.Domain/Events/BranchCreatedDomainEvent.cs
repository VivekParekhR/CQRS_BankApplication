#region Using
using Bank.Domain.Shared;

#endregion
namespace Bank.Domain.Events
{
    public sealed record BranchCreatedDomainEvent : IDomainEvent
    {
        public Entity.Branch Branch { get; set; } = new Entity.Branch();    

    }
}
