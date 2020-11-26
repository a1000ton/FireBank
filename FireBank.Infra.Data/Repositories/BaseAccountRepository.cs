using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository.NewRepos;
using FireBank.Infra.Data.Configuration;
using System.Collections.Generic;
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
    }
}
