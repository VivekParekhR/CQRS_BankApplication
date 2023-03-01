using Bank.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Bank.Core.Context
{
    public class BankDbContext : DbContext
    {
        #region Property
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Entity.Bank> Banks { get; set; }
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
            modelBuilder.Entity<Branch>().HasKey(b => b.Id); 
            modelBuilder.Entity<Entity.Bank>().HasKey(b => b.Id);
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<CustomerBank>().HasKey(a => a.Id);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
        }
    }
}
