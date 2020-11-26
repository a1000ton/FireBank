using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository.New;
using FireBank.Domain.Interfaces.Service.New;
using System.Collections.Generic;

namespace FireBank.Service.Services.New
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IAccountService _accountService;

        public TransactionService(ITransactionRepository repository, IAccountService accountService)
        {
            _repository = repository;
            _accountService = accountService;
        }

        public Transaction Add(Transaction obj)
        {
            var accountId = obj.Account.Id;
            var currentBalance = _accountService.GetBalance(accountId);

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
            return _accountService.BalanceIsValid(balance, accountId);
        }
    }
}
