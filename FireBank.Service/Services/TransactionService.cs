using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace FireBank.Service.Services
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
            var accountId = obj.AccountId;
            var account = _accountService.GetById(accountId);

            obj.Account = account;

            var oldBalance = _accountService.GetBalance(account);
            var currentBalance = oldBalance;

            if (obj.Type == TransactionType.Deposit)
                currentBalance = Deposit(obj.Amount, oldBalance);
            else if (obj.Type == TransactionType.Withdrawal)
                currentBalance = Withdrawal(obj.Amount, oldBalance);

            obj.Date = DateTime.Now;
            obj.Balance = oldBalance;

            if (CanCompleteTransaction(currentBalance, accountId))
            {
                obj.Balance = currentBalance;
                obj.Status = TransactionStatus.Completed;

                var newTransaction = _repository.Add(obj);

                return newTransaction;
            }

            obj.Status = TransactionStatus.Cancelled;

            return obj;
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
