﻿#region Using
using Bank.Core.Entity; 
#endregion

namespace Bank.Core.Interface
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(int id);  
        bool CheckEmailWithPhoneExists(string email, string PhoneNo);
    }
}
