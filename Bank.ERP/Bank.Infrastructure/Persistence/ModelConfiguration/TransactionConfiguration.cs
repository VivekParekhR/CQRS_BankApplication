using Bank.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Persistence.ModelConfiguration
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TransactionId).IsRequired();

            builder.Property(x => x.BankId).IsRequired();

            builder.Property(x => x.CustomerId).IsRequired();

            builder.Property(x => x.Amount).IsRequired();

            builder.Property(x => x.TransectionDate).IsRequired();

            builder.Property(x => x.TransactionType).IsRequired();

            builder.Property(x => x.TransectionRemarks).IsRequired();

            builder.HasOne(x => x.Bank)
               .WithMany()
               .HasForeignKey(x => x.BankId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
              .WithMany()
              .HasForeignKey(x => x.CustomerId)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
