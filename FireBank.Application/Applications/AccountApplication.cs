using FireBank.Application.Applications.Interfaces;
using FireBank.Application.Models;
using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Service;
using System;

namespace FireBank.Application.Applications
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountService _service;
        public AccountApplication(IAccountService service)
        {
            _service = service;
        }

        public AccountCreatedModel CreateBusinessAccount(BusinessAccountCreationModel account)
        {
            var accountEntity = new Account()
            {
                Name = account.Name,
                AccountType = new BusinessAccount()
                {
                    BusinessId = account.BusinessId
                }
            };

            var addedAccount = _service.Add(accountEntity);
            var businessAccount = (BusinessAccount)addedAccount.AccountType;

            return new AccountCreatedModel()
            {
                Name = addedAccount.Name,
                Type = new BusinessAccountCreatedModel()
                {
                    BusinessId = businessAccount.BusinessId
                }
            };
        }

        public AccountCreatedModel CreateGiroAccount(GiroAccountCreationModel account)
        {
            throw new NotImplementedException();
        }

        public AccountCreatedModel CreateStudentAccount(StudentAccountCreationModel account)
        {
            throw new NotImplementedException();
        }
    }
}
