using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
namespace FireBank.Service.Services
{
    public class BaseAccountService<TEntity> : IBaseAccountService<TEntity> where TEntity : class
    {
        private readonly IBaseAccountRepository<TEntity> _repository;

        public BaseAccountService(IBaseAccountRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Add(TEntity obj)
        {
            return _repository.Add(obj);
        }

        public bool BalanceIsValid(int balance, int accountId)
        {
            var account = _repository.GetById(accountId);
            var accountType = account.GetType();

            var balanceNegativLimit = (int)accountType.GetMethod("BalanceNegativeLimit").Invoke(account, new object[] { });

            return balance >= balanceNegativLimit;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public int GetBalance(int accountId)
        {
            return _repository.GetBalance(accountId);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public TEntity Update(TEntity obj)
        {
            return _repository.Update(obj);
        }
    }
}
