using Bank.Domain.Enum;
using Bank.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Bank.Domain.Entity
{
    public class Transaction : EventGenerator
    { 
        public int Id { get; set; }
        public Guid TransactionId { get; set; }
        public int BankId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransectionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public string TransectionRemarks { get; set; } = string.Empty;  
        public virtual Bank Bank { get; set; } = new Bank();
        public virtual Customer Customer { get; set; } = new Customer();
    }
}
