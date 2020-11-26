using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;
using System.Linq;

namespace FireBank.Service.Services
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        private new readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public int GetBalance(int accountId)
        {
            var account = _repository.GetById(accountId);

            var balance = account.Transactions.OrderBy(transaction => transaction.Date).Last().Balance;

            return balance;
        }
    }
}
