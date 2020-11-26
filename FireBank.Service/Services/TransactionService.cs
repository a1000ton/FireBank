using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace FireBank.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IBaseAccountService<BaseAccount> _service;

        public TransactionService(ITransactionRepository repository, IBaseAccountService<BaseAccount> service)
        {
            _repository = repository;
            _service = service;
        }

        public Transaction Add(Transaction obj)
        {
            var accountId = obj.Account.Id;
            var currentBalance = _service.GetBalance(accountId);

            if (obj.Type == TransactionType.Deposit)
                currentBalance = Deposit(obj.Amount, currentBalance);
            else if (obj.Type == TransactionType.Withdrawal)
                currentBalance = Withdrawal(obj.Amount, currentBalance);

            if (CanCompleteTransaction(currentBalance, accountId))
                return _repository.Add(obj);

            return null;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _repository.GetAll();
        }

        public Transaction GetById(int id)
        {
            return _repository.GetById(id);
        }

        private int Withdrawal(int amount, int balance)
        {
            return balance -= amount;
        }

        private int Deposit(int amount, int balance)
        {
            return balance += amount;
        }

        private bool CanCompleteTransaction(int balance, int accountId)
        {
            return _service.BalanceIsValid(balance, accountId);
        }
    }
}
