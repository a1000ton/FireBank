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
                Id = addedAccount.Id,
                CreatedAt = addedAccount.CreatedAt,
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
                Id = addedAccount.Id,
                CreatedAt = addedAccount.CreatedAt,
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
                Id = addedAccount.Id,
                CreatedAt = addedAccount.CreatedAt,
                Name = addedAccount.Name,
                Type = new StudentAccountCreatedModel()
                {
                    StudentId = studentAccount.StudentId
                }
            };
        }

        public AccountModel GetAccount(int accountId)
        {
            var account = _service.GetById(accountId);
            var balance = _service.GetBalance(account);

            var accountType = GetAccountType(account.AccountType);

            return new AccountModel()
            {
                Balance = balance,
                CreatedAt = account.CreatedAt,
                Id = account.Id,
                Name = account.Name,
                Type = accountType
            };
        }

        private IAccountModelType GetAccountType(IAccountType accountType)
        {
            if (accountType.GetType() == typeof(BusinessAccount))
            {
                var businessAccountType = (BusinessAccount)accountType;

                return new BusinessAccountModel()
                {
                    BusinessId = businessAccountType.BusinessId
                };
            }

            if (accountType.GetType() == typeof(StudentAccount))
            {
                var studentAccountType = (StudentAccount)accountType;

                return new StudentAccountModel()
                {
                    StudentId = studentAccountType.StudentId
                };
            }

            return new GiroAccountModel();
        }
    }
}
