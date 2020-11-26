using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;

namespace FireBank.Service.Services
{
    public class BusinessAccountService : BaseService<BusinessAccount>, IBusinessAccountService
    {
        private readonly IBusinessAccountRepository _repository;

        public BusinessAccountService(IBusinessAccountRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public int GetBalance(int accountId)
        {
            throw new System.NotImplementedException();
        }
    }
}
