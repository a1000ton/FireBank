using FireBank.Domain.Entities;
using System.Collections.Generic;

namespace FireBank.Domain.Interfaces.Service.New
{
    public interface ITransactionService
    {
        Transaction Add(Transaction obj);
        Transaction GetById(int id);
        IEnumerable<Transaction> GetAll();
    }
}
