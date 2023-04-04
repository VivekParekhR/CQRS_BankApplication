#region Using
using Bank.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace Bank.Infrastructure.Persistence.ModelConfiguration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(200);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(200);
            
            builder.Property(x => x.PhoneNo).IsRequired().HasMaxLength(20);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);

            builder.Property(x => x.CreatedById).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
