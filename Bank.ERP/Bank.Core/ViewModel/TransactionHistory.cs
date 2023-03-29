using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.ViewModel
{

    public class TransactionHistory
    {
        public int Id { get; set; }
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransectionDate { get; set; }
        public string? TransactionType { get; set; }
        public string? TransectionRemarks { get; set; }
    }
}
