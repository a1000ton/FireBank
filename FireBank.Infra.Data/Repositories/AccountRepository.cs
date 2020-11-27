using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Infra.Data.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FireBank.Infra.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FireBankContext _db;
        public AccountRepository(FireBankContext db)
        {
            _db = db;
        }

        public Account Add(Account account)
        {
            _db.Set<Account>().Add(account);
            _db.SaveChanges();

            account.AccountType.Account = account;
            _db.Set(account.AccountType.GetType()).Add(account.AccountType);
            _db.SaveChanges();

            return account;
        }

        public IEnumerable<Account> GetAll()
        {
            return _db.Set<Account>().ToList();
        }

        public int GetBalance(int accountId)
        {
            var account = _db.Set<Account>().Find(accountId);

            var lastTransaction =
                account.Transactions
                    .Where(transaction => transaction.Status == TransactionStatus.Completed)
                    .OrderBy(transaction => transaction.Date)
                    .LastOrDefault();

            if (lastTransaction == null)
                return 0;

            return lastTransaction.Balance;
        }

        public Account GetById(int id)
        {
            var account = _db.Set<Account>().Find(id);
            account.AccountType = GetAccountType(id);

            return account;
        }

        public void Remove(Account obj)
        {
            _db.Set<Account>().Remove(obj);
            _db.SaveChanges();
        }

        public Account Update(Account obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();

            return obj;
        }

        private IAccountType GetAccountType(int accountId)
        {
            var businessAccount = _db.Set<BusinessAccount>().Find(accountId);

            if (businessAccount != null)
                return businessAccount;

            var studentAccount = _db.Set<StudentAccount>().Find(accountId);

            if (studentAccount != null)
                return studentAccount;

            var giroAccount = _db.Set<GiroAccount>().Find(accountId);

            if (giroAccount != null)
                return giroAccount;

            return null;
        }
    }
}
