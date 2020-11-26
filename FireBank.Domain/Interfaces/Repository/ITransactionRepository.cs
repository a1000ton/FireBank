using FireBank.Domain.Entities.Old;
using System.Collections.Generic;

namespace FireBank.Domain.Interfaces.Repository
{
    public interface ITransactionRepository
    {
        Transaction Add(Transaction obj);
        Transaction GetById(int id);
        IEnumerable<Transaction> GetAll();
    }
}
