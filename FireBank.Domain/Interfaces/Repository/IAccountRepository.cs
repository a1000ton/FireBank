using FireBank.Domain.Entities;
using System.Collections.Generic;

namespace FireBank.Domain.Interfaces.Repository
{
    public interface IAccountRepository
    {
        Account Add(Account account);
        Account GetById(int id);
        int GetBalance(int accountId);
        IEnumerable<Account> GetAll();
        Account Update(Account obj);
        void Remove(Account obj);
    }
}
