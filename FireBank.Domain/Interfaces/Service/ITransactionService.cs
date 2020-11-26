using FireBank.Domain.Entities;
using System.Collections.Generic;

namespace FireBank.Domain.Interfaces.Service
{
    public interface ITransactionService
    {
        Transaction Add(Transaction obj);
        IEnumerable<Transaction> GetAll(int accountId);
    }
}
