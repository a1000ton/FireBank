using FireBank.Domain.Entities;

namespace FireBank.Domain.Interfaces.Service
{
    public interface IAccountService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        int GetBalance(int accountId);
    }
}
