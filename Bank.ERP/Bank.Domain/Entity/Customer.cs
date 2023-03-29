using System.ComponentModel.DataAnnotations;

namespace Bank.Domain.Entity
{
    public class Customer 
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string FirstName { get; set; }

        [MaxLength(200)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string PhoneNo { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedById { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }

    }
}
