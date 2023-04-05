#region Using
using Bank.Domain.Entity;
using Bank.Infrastructure.Persistence.ModelConfiguration;
using Microsoft.EntityFrameworkCore; 
#endregion

namespace Bank.Infrastructure.Persistence
{
    public class BankDbContext : DbContext
    {
        #region Property
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Domain.Entity.Bank> Banks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerBank> CustomerBanks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// OnModelCreating Configuration
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerBankConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
