using System.Collections.Generic;

namespace FireBank.Domain.Interfaces.Service
{
    public interface IBaseAccountService<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
