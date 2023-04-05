using Bank.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Bank.Domain.Entity
{
    public class Branch : AggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
        public IList<Bank> Banks { get; set; }  
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedById { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
    }
}
