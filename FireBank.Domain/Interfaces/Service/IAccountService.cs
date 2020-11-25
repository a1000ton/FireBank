using FireBank.Domain.Entities;

namespace FireBank.Domain.Interfaces.Service
{
    public interface IAccountService : IServiceBase<Account>
    {
        int GetBalance(int id);
    }
}
