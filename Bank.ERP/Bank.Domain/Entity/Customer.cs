using Bank.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Bank.Domain.Entity
{
    public class Customer : AggregateRoot
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedById { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }

    }
}
