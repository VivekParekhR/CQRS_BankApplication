using Bank.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Bank.Domain.Entity
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public Guid TransactionId { get; set; }
        public int BankId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransectionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public string TransectionRemarks { get; set; }

        public virtual Bank bank { get; set; }
        public virtual Customer customer { get; set; }  
    }
}
