using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;

namespace FireBank.Service.Services
{
    public class BusinessAccountService : BaseService<BusinessAccount>, IBusinessAccountService
    {
        private new readonly IBusinessAccountRepository _repository;

        public BusinessAccountService(IBusinessAccountRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
