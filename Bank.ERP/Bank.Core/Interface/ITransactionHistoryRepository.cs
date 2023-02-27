using Bank.Core.Entity;
using Bank.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Interface
{
    public interface ITransactionHistoryRepository
    {
        Task<int> AddTransactionHistoryAsync(TransactionHistory transactionHistory);
        Task<TransactionHistoryViewModel> GetTransactionHistoryByAccountIdAsync(Guid accountNumber);

    }
}
