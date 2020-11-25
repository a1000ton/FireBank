using FireBank.Domain.Interfaces.Repository;
using FireBank.Infra.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FireBank.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly FireBankContext _db;

        public BaseRepository(FireBankContext db)
        {
            _db = db;
        }

        public void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
            _db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
