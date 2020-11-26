using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;
using System;

namespace FireBank.Service.Services
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public int GetBalance(int id)
        {
            throw new NotImplementedException();
        }
    }
}
