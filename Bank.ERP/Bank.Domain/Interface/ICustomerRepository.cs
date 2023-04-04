﻿#region Using
using Bank.Domain.Entity;
using Bank.Domain.Interface;

#endregion

namespace Bank.Core.Interface
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<int> AddCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(int id);  
        bool CheckEmailWithPhoneExists(string email, string PhoneNo);
    }
}
