using Effort;
using FireBank.Domain.Entities;
using FireBank.Infra.Data.Configuration;
using FireBank.Infra.Data.Repositories.New;
using System;
using System.Linq;
using Xunit;

namespace FireBank.Tests.Repository.New
{
    public class TransactionRepositoryTests
    {
        [Fact]
        public void Add_WhenPassObject_ShouldAddObject()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var transaction = new Transaction()
                {
                    Account = new Account()
                    {
                        CreatedAt = DateTime.Now,
                        Name = Guid.NewGuid().ToString()
                    },
                    Amount = 10,
                    Balance = 80,
                    Date = DateTime.Now,
                    Type = TransactionType.Deposit
                };

                var repository = new TransactionRepository(context);

                var addedTransaction = repository.Add(transaction);

                Assert.Equal(1, context.Transactions.Count());
                Assert.Equal(addedTransaction.Balance, context.Transactions.ToList().First().Balance);
                Assert.Equal(addedTransaction.Id, context.Transactions.ToList().First().Id);
            }
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldShowAllObjects()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var repository = new TransactionRepository(context);

                repository.Add(new Transaction()
                {
                    Account = new Account()
                    {
                        CreatedAt = DateTime.Now,
                        Name = Guid.NewGuid().ToString()
                    },
                    Amount = 10,
                    Balance = 80,
                    Date = DateTime.Now,
                    Type = TransactionType.Deposit
                });

                repository.Add(new Transaction()
                {
                    Account = new Account()
                    {
                        CreatedAt = DateTime.Now,
                        Name = Guid.NewGuid().ToString()
                    },
                    Amount = 10,
                    Balance = 80,
                    Date = DateTime.Now,
                    Type = TransactionType.Deposit
                });

                repository.Add(new Transaction()
                {
                    Account = new Account()
                    {
                        CreatedAt = DateTime.Now,
                        Name = Guid.NewGuid().ToString()
                    },
                    Amount = 10,
                    Balance = 80,
                    Date = DateTime.Now,
                    Type = TransactionType.Deposit
                });

                var transactions = repository.GetAll();

                Assert.Equal(3, transactions.Count());
            }
        }

        [Fact]
        public void GetById_WhenPassValidId_ShouldReturnFoundObject()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var transaction = new Transaction()
                {
                    Account = new Account()
                    {
                        CreatedAt = DateTime.Now,
                        Name = Guid.NewGuid().ToString()
                    },
                    Amount = 10,
                    Balance = 80,
                    Date = DateTime.Now,
                    Type = TransactionType.Deposit
                };

                var repository = new TransactionRepository(context);

                var addedTransaction = repository.Add(transaction);
                var foundTransaction = repository.GetById(1);

                Assert.Equal(addedTransaction.Id, foundTransaction.Id);
                Assert.Equal(addedTransaction.Balance, foundTransaction.Balance);
            }
        }
    }
}
