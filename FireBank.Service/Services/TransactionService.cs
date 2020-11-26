using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace FireBank.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Transaction Add(Transaction obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Transaction> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Transaction GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
