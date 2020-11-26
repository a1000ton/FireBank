using System.Collections.Generic;

namespace FireBank.Domain.Interfaces.Repository
{
    public interface IBaseAccountRepository<TEntity> where TEntity : class
    {
        int GetBalance(int accountId);

        TEntity Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
