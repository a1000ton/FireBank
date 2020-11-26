using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBank.Domain.Interfaces.Repository.NewRepos
{
    public interface IBaseAccountRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        int GetBalance(int accountId);
    }
}
