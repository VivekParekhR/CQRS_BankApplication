
using Bank.Domain.Events;
using Bank.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Bank.Domain.Entity
{
    public sealed class Bank : EventGenerator
    { 
        public int Id { get; set; }
        public string Name { get; set; } =String.Empty;
        public int BranchId { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedById { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
 

        //public static Bank GenerateDomainEvent(Bank bank)
        //{
        //    bank.RaiseEvent(new BankCreatedDomainEvent
        //    {
        //        BankId = Guid.NewGuid()
        //    });

        //    return bank;
        //}
    } 

}
