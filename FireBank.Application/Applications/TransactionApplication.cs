using FireBank.Application.Applications.Interfaces;
using FireBank.Application.Models;
using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Service;

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
    }
}
