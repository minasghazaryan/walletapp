using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletApp.WalletAppServices.Models;

namespace WalletApp.WalletAppServices
{
    public interface ITransactionService : IBaseService
    {
        IQueryable<TransactionServiceModel> GetByUserId(int userId);
        Task<TransactionServiceModel> GetById(int transactionId);
        Task<int> Create(TransactionServiceModel model);
        Task Delete(int id);
    }
}
