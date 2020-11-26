using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;

namespace FireBank.Service.Services
{
    public class GiroAccountService : BaseService<GiroAccount>, IGiroAccountService
    {
        private readonly IGiroAccountRepository _repository;

        public GiroAccountService(IGiroAccountRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public int GetBalance(int accountId)
        {
            throw new System.NotImplementedException();
        }
    }
}
