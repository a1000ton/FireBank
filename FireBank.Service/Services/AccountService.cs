using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace FireBank.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public Account Add(Account obj)
        {
            if (obj.Transactions == null)
                obj.Transactions = new List<Transaction>() { };

            return _repository.Add(obj);
        }

        public bool BalanceIsValid(int balance, int accountId)
        {
            var account = _repository.GetById(accountId);
            var balanceNegativLimit = account.AccountType.BalanceNegativeLimit();

            return balance >= balanceNegativLimit;
        }

        public IEnumerable<Account> GetAll()
        {
            return _repository.GetAll();
        }

        public int GetBalance(Account account)
        {
            return _repository.GetBalance(account.Id);
        }

        public Account GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(Account obj)
        {
            _repository.Remove(obj);
        }

        public Account Update(Account obj)
        {
            return _repository.Update(obj);
        }
    }
}
