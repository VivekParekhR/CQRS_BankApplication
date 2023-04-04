#region Using
using Bank.Domain.Entity;
using Bank.Domain.Interface;

#endregion

namespace Bank.Core.Interface
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    { 
        bool CheckEmailWithPhoneExists(string email, string PhoneNo);
    }
}
