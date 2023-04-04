#region Using
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
#endregion

namespace Bank.Infrastructure.Persistence.ModelConfiguration
{
    internal class BankConfiguration : IEntityTypeConfiguration<Bank.Domain.Entity.Bank>
    {
        public void Configure(EntityTypeBuilder<Bank.Domain.Entity.Bank> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.BranchId).IsRequired();

            builder.Property(x => x.CreatedById).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
