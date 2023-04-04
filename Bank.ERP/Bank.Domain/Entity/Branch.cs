using System.ComponentModel.DataAnnotations;

namespace Bank.Domain.Entity
{
    public class Branch 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BranchCode { get; set; }
        public IList<Bank> Banks { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedById { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
    }
}
