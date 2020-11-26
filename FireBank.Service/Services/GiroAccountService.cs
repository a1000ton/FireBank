using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;

namespace FireBank.Service.Services
{
    public class GiroAccountService : BaseAccountService<GiroAccount>, IGiroAccountService
    {
        public GiroAccountService(IGiroAccountRepository repository) : base(repository)
        {
        }
    }
}
