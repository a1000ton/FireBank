using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Infra.Data.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FireBank.Infra.Data.Repositories
{
    public class BaseAccountRepository<TEntity> : IBaseAccountRepository<TEntity> where TEntity : class
    {
        private readonly FireBankContext _db;

        public BaseAccountRepository(FireBankContext db)
        {
            _db = db;
        }

        public int GetBalance(int accountId)
        {
            var obj = _db.Set<TEntity>().Find(accountId);

            var generalAccountType = obj.GetType();

            var account = generalAccountType.GetProperty("Account").GetValue(obj);
            var accountType = account.GetType();

            var transactions = (List<Transaction>)accountType.GetProperty("Transactions").GetValue(account);

            var balance = transactions.OrderBy(transaction => transaction.Date).Last().Balance;

            return balance;
        }

        public TEntity Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges();

            return obj;
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity Update(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();

            return obj;
        }

        public void Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
            _db.SaveChanges();
        }
    }
}
