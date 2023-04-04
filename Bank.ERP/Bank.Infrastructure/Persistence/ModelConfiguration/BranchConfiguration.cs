#region Using
using Bank.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
#endregion
namespace Bank.Infrastructure.Persistence.ModelConfiguration
{
    internal class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.BranchCode).IsRequired().HasMaxLength(15);

            builder.Property(x => x.CreatedById).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
