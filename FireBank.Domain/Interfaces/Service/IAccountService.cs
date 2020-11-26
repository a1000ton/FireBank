using FireBank.Domain.Entities;
using System.Collections.Generic;

namespace FireBank.Domain.Interfaces.Service
{
    public interface IAccountService
    {
        Account Add(Account obj);
        Account GetById(int id);
        IEnumerable<Account> GetAll();
        Account Update(Account obj);
        void Remove(Account obj);
        bool BalanceIsValid(int balance, int accountId);
        int GetBalance(Account account);
    }
}
