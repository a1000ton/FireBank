using FireBank.Domain.Entities.Old;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;

namespace FireBank.Service.Services
{
    public class BusinessAccountService : BaseAccountService<BusinessAccount>, IBusinessAccountService
    {
        public BusinessAccountService(IBusinessAccountRepository repository) : base(repository)
        {
        }
    }
}
