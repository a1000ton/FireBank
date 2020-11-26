using FireBank.Domain.Entities;
using System.Collections.Generic;

namespace FireBank.Domain.Interfaces.Repository
{
    public interface ITransactionRepository
    {
        Transaction Add(Transaction obj);
        IEnumerable<Transaction> GetAll(int accountId);
    }
}
