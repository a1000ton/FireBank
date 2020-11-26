using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace FireBank.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Add(TEntity obj)
        {
            return _repository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public TEntity Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
