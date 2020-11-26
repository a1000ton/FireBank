using FireBank.Domain.Entities.Old;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Infra.Data.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace FireBank.Infra.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FireBankContext _db;

        public TransactionRepository(FireBankContext db)
        {
            _db = db;
        }

        public Transaction Add(Transaction obj)
        {
            _db.Set<Transaction>().Add(obj);
            _db.SaveChanges();

            return obj;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _db.Set<Transaction>().ToList();
        }

        public Transaction GetById(int id)
        {
            return _db.Set<Transaction>().Find(id);
        }
    }
}
