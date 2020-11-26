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
            return _repository.Add(obj);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _repository.GetAll();
        }

        public Transaction GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
