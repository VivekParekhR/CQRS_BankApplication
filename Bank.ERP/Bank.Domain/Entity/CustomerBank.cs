#region Using
using Bank.Domain.Enum;
using Bank.Domain.Shared;
using System.ComponentModel.DataAnnotations;

#endregion
namespace Bank.Domain.Entity
{
    public class CustomerBank : EventGenerator
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public int CustomerId { get; set; }
        public string AccountNumber { get; set; } = string.Empty;   
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedById { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }  
    }
}
