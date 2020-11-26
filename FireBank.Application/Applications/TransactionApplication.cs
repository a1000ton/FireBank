using FireBank.Application.Applications.Interfaces;
using FireBank.Application.Models;
using FireBank.Application.Models.Transaction;
using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace FireBank.Application.Applications
{
    public class TransactionApplication : ITransactionApplication
    {
        private readonly ITransactionService _service;

        public TransactionApplication(ITransactionService service)
        {
            _service = service;
        }

        public TransactionCreatedModel Create(TransactionCreationModel transaction)
        {
            var transactionEntity = new Transaction()
            {
                AccountId = transaction.AccountId,
                Amount = transaction.Amount,
                Type = transaction.Type,
            };

            var newTransaction = _service.Add(transactionEntity);

            return new TransactionCreatedModel()
            {
                Account = newTransaction.Account,
                Amount = newTransaction.Amount,
                Balance = newTransaction.Balance,
                Date = newTransaction.Date,
                Id = newTransaction.Id,
                Type = newTransaction.Type,
                Status = newTransaction.Status,
            };
        }

        public TransactionsModel List(int accountId)
        {
            var transactions = _service.GetAll(accountId);

            var transactionsModel = new TransactionsModel()
            {
                AccountId = accountId,
                Transactions = new List<TransactionModel>()
            };

            foreach (var transaction in transactions)
            {
                transactionsModel.Transactions.Add(
                    new TransactionModel()
                    {
                        Amount = transaction.Amount,
                        Balance = transaction.Balance,
                        Date = transaction.Date,
                        Id = transaction.Id,
                        Status = transaction.Status,
                        Type = transaction.Type,
                    });
            }

            return transactionsModel;
        }
    }
}
