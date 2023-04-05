#region Using
using Bank.Domain.Shared;  
#endregion

namespace Bank.Core.ViewModel
{
    public sealed class DomainEvents 
    {
        public List<DomainEventMetaData> DomainEventMetaData { get; set; } = new();
    }

}
