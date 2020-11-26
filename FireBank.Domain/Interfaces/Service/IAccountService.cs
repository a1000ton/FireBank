using FireBank.Domain.Entities;

namespace FireBank.Domain.Interfaces.Service
{
    public interface IAccountService : IBaseService<Account>
    {
        int GetBalance(int accountId);
    }
}
