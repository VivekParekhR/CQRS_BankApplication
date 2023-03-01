using Bank.Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ViewModel
{
    public class CustomerBankViewModel
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        
        [MaxLength(50)]
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }  
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedById { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
    }
}
