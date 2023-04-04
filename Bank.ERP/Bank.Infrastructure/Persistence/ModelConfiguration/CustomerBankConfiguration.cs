#region Using
using Bank.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion
namespace Bank.Infrastructure.Persistence.ModelConfiguration
{
    internal class CustomerBankConfiguration : IEntityTypeConfiguration<CustomerBank>
    {
        public void Configure(EntityTypeBuilder<CustomerBank> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.BankId).IsRequired();

            builder.Property(x => x.CustomerId).IsRequired();

            builder.Property(x => x.AccountNumber).IsRequired().HasMaxLength(50);

            builder.Property(x => x.AccountType).IsRequired();

            builder.Property(x => x.Balance).IsRequired(); 

            builder.Property(x => x.CreatedById).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
