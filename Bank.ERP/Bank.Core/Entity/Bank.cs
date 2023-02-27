
namespace Bank.Core.Entity
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IFSCCode { get; set; }
        public int BranchId { get; set; }
        public IList<Customer> Customers { get; set; }
        public IList<Transaction> Transactions { get; set; }
    } 

}
