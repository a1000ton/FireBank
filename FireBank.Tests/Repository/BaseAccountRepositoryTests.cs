using Effort;
using FireBank.Domain.Entities;
using FireBank.Infra.Data.Configuration;
using FireBank.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FireBank.Tests.Repository
{
    public class BaseAccountRepositoryTests
    {
        [Fact]
        public void Add_WhenPassObject_ShouldAddObject()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var businessAccount = new BusinessAccount()
                {
                    Account = new Account()
                    {
                        CreatedAt = DateTime.Now,
                        Name = Guid.NewGuid().ToString(),
                    },
                    BusinessId = 10,
                };


                var repository = new BaseAccountRepository<BusinessAccount>(context);

                var addedAccount = repository.Add(businessAccount);

                Assert.Equal(1, context.BusinessAccounts.Count());
                Assert.Equal(1, context.Accounts.Count());
                Assert.Equal(addedAccount.BusinessId, context.BusinessAccounts.ToList().First().BusinessId);
                Assert.Equal(addedAccount.Account.Name, context.BusinessAccounts.ToList().First().Account.Name);
            }
        }

        [Fact]
        public void GetBalance_WhenPassValidAccountId_ShouldReturnLastTransactionBalance()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var lastBalance = 100;
                var transactionOne = new Transaction()
                {
                    Balance = lastBalance,
                    Amount = 20,
                    Type = TransactionType.Deposit,
                    Date = DateTime.Now.AddDays(-10)
                };

                var transactionTwo = new Transaction()
                {
                    Balance = 80,
                    Amount = 10,
                    Type = TransactionType.Deposit,
                    Date = DateTime.Now.AddDays(-15)
                };

                var transactions = new List<Transaction>()
                    {
                        transactionOne, transactionTwo
                    };

                var businessAccount = new BusinessAccount()
                {
                    Account = new Account()
                    {
                        CreatedAt = DateTime.Now,
                        Name = Guid.NewGuid().ToString(),
                        Transactions = transactions
                    },
                    BusinessId = 10,
                };

                var repository = new BaseAccountRepository<BusinessAccount>(context);

                repository.Add(businessAccount);

                var balance = repository.GetBalance(1);

                Assert.Equal(balance, lastBalance);
            }
        }
    }
}
