using FireBank.Domain.Entities.Old;
using System.Collections.Generic;

namespace FireBank.Domain.Interfaces.Service
{
    public interface ITransactionService
    {
        Transaction Add(Transaction obj);
        Transaction GetById(int id);
        IEnumerable<Transaction> GetAll();
    }
}
