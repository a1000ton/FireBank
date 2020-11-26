using FireBank.Application.Applications.Interfaces;
using FireBank.Application.Models;
using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Service;

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
            var accountEntity = new Account()
            {
                Name = account.Name,
                AccountType = new GiroAccount() { }
            };

            var addedAccount = _service.Add(accountEntity);

            return new AccountCreatedModel()
            {
                Name = addedAccount.Name,
                Type = new GiroAccountCreatedModel() { }
            };
        }

        public AccountCreatedModel CreateStudentAccount(StudentAccountCreationModel account)
        {
            var accountEntity = new Account()
            {
                Name = account.Name,
                AccountType = new StudentAccount()
                {
                    StudentId = account.StudentId
                }
            };

            var addedAccount = _service.Add(accountEntity);
            var studentAccount = (StudentAccount)addedAccount.AccountType;

            return new AccountCreatedModel()
            {
                Name = addedAccount.Name,
                Type = new StudentAccountCreatedModel()
                {
                    StudentId = studentAccount.StudentId
                }
            };
        }
    }
}
