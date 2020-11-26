using Effort;
using FireBank.Domain.Entities;
using FireBank.Infra.Data.Configuration;
using FireBank.Infra.Data.Repositories.New;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FireBank.Tests.Repository.New
{
    public class AccountRepositoryTests
    {
        [Fact]
        public void Teste()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var account = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    AccountType = new BusinessAccount()
                    {
                        BusinessId = 10,
                    },
                    Transactions = new List<Transaction>() { }
                };

                var account2 = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    AccountType = new GiroAccount()
                    {
                    },
                    Transactions = new List<Transaction>()
                    {

                    }
                };

                var account3 = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    AccountType = new StudentAccount()
                    {
                        StudentId = 200
                    },
                    Transactions = new List<Transaction>()
                    {

                    }
                };


                var repository = new AccountRepository(context);

                repository.Add(account);
                repository.Add(account2);
                repository.Add(account3);
            }
        }


        [Fact]
        public void Add_WhenPassObject_ShouldAddObject()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var account = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    AccountType = new BusinessAccount()
                    {
                        BusinessId = 10,
                    },
                    Transactions = new List<Transaction>() { }
                };


                var repository = new AccountRepository(context);

                var addedAccount = repository.Add(account);

                Assert.Equal(1, context.Accounts.Count());
                Assert.Equal(addedAccount.Id, context.Accounts.ToList().First().Id);
                Assert.Equal(addedAccount.Name, context.Accounts.ToList().First().Name);
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

                var account = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    AccountType = new StudentAccount()
                    {
                        StudentId = 15,
                    },
                    Transactions = transactions
                };

                var repository = new AccountRepository(context);

                repository.Add(account);

                var balance = repository.GetBalance(1);

                Assert.Equal(balance, lastBalance);
            }
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldShowAllObjects()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var repository = new AccountRepository(context);

                repository.Add(new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    AccountType = new BusinessAccount()
                    {
                        BusinessId = 10,
                    },
                });

                repository.Add(new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    AccountType = new StudentAccount()
                    {
                        StudentId = 12,
                    },
                });

                repository.Add(new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    AccountType = new GiroAccount(){},
                });

                var accounts = repository.GetAll();

                Assert.Equal(3, accounts.Count());
            }
        }

        [Fact]
        public void GetById_WhenPassValidId_ShouldReturnFoundObject()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var account = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    AccountType = new StudentAccount()
                    {
                        StudentId = 15,
                    },
                };

                var repository = new AccountRepository(context);
                var addedAccount = repository.Add(account);

                var foundAccount = repository.GetById(1);

                Assert.Equal(addedAccount.Id, foundAccount.Id);
                Assert.Equal(addedAccount.Name, foundAccount.Name);
            }
        }

        [Fact]
        public void Remove_WhenPassValidObject_ShouldDeleteObject()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var account = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    AccountType = new StudentAccount()
                    {
                        StudentId = 15,
                    },
                };

                var repository = new AccountRepository(context);

                repository.Add(account);

                repository.Remove(account);

                Assert.False(context.Accounts.Where(acc => acc.Id == account.Id).Any());
            }
        }

        [Fact]
        public void Update_WhenPassUpdatedObject_ShouldUpdateObject()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var oldName = Guid.NewGuid().ToString();
                var newName = Guid.NewGuid().ToString();

                var account = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString(),
                    AccountType = new StudentAccount()
                    {
                        StudentId = 15,
                    },
                };

                var repository = new AccountRepository(context);

                var addedAccount = repository.Add(account);

                addedAccount.Name = newName;

                repository.Update(addedAccount);

                Assert.False(context.Accounts.Where(acc => acc.Name == oldName).Any());
                Assert.True(context.Accounts.Where(acc => acc.Name == newName).Any());
            }
        }

    }
}
