
using System.ComponentModel.DataAnnotations;

namespace Bank.Domain.Entity
{
    public class Bank 
    { 
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public int BranchId { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedById { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
    } 

}
