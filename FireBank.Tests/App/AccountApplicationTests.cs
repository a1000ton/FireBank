using Effort;
using FireBank.Application.Applications;
using FireBank.Application.Models;
using FireBank.Domain.Entities;
using FireBank.Infra.Data.Configuration;
using FireBank.Infra.Data.Repositories;
using FireBank.Service.Services;
using System;
using Xunit;

namespace FireBank.Tests.App
{
    public class AccountApplicationTests
    {
        [Fact]
        public void Create_WhenPassValidBusinessAccount_ShouldCreateTheNewAccount()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var businessId = 10;
                var name = Guid.NewGuid().ToString();

                var accountToBeCreated = new BusinessAccountCreationModel()
                {
                    BusinessId = businessId,
                    Name = name,
                };

                var expectedBusinessAccount = new BusinessAccountCreatedModel()
                {
                    BusinessId = businessId,
                };

                var accountRepository = new AccountRepository(context);
                var accountService = new AccountService(accountRepository);
                var accountApp = new AccountApplication(accountService);

                var addedAccount = accountApp.CreateBusinessAccount(accountToBeCreated);
                var addedAccountType = (BusinessAccountCreatedModel)addedAccount.Type;

                Assert.Equal(addedAccount.Name, name);
                Assert.Equal(addedAccount.Type.GetType(), expectedBusinessAccount.GetType());
                Assert.Equal(addedAccountType.BusinessId, expectedBusinessAccount.BusinessId);
            }
        }
    }
}
