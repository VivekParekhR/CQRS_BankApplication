using Bank.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Bank.Core.Context
{
    public class BankDbContext : DbContext
    {
        #region Property
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Entity.Bank> Banks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
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
            modelBuilder.Entity<Branch>().HasKey(b => b.Id); 
            modelBuilder.Entity<Entity.Bank>().HasKey(b => b.Id);
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
            modelBuilder.Entity<TransactionHistory>().HasKey(th => th.Id); 
        }
    }
}
