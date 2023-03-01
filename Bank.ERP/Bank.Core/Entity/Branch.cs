using System.ComponentModel.DataAnnotations;

namespace Bank.Core.Entity
{
    public class Branch 
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(15)]
        public string BranchCode { get; set; }

        public IList<Bank> Banks { get; set; }

        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedById { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
    }
}
