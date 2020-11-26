using Effort;
using FireBank.Domain.Entities;
using FireBank.Infra.Data.Configuration;
using FireBank.Infra.Data.Repositories;
using System;
using System.Linq;
using Xunit;

namespace FireBank.Tests.Repository
{
    public class BaseRepositoryTests
    {
        [Fact]
        public void Add_WhenPassObject_ShouldAddObject()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var account = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString()
                };


                var repository = new BaseRepository<Account>(context);
                var addedAccount = repository.Add(account);

                Assert.Equal(1, context.Accounts.Count());
                Assert.Equal(addedAccount.Name, context.Accounts.ToList().First().Name);
                Assert.Equal(addedAccount.Id, context.Accounts.ToList().First().Id);
            }
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldShowAllObjects()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var repository = new BaseRepository<Account>(context);
                repository.Add(new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString()
                });

                repository.Add(new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString()
                });

                repository.Add(new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString()
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
                    Name = Guid.NewGuid().ToString()
                };

                var repository = new BaseRepository<Account>(context);
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
                    Name = Guid.NewGuid().ToString()
                };

                var repository = new BaseRepository<Account>(context);
                repository.Add(account);
                repository.Add(new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString()
                });

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
                    Name = oldName
                };

                var repository = new BaseRepository<Account>(context);

                var addedAccount = repository.Add(account);

                addedAccount.Name = newName;

                repository.Update(addedAccount);

                Assert.False(context.Accounts.Where(acc => acc.Name == oldName).Any());
                Assert.True(context.Accounts.Where(acc => acc.Name == newName).Any());
            }
        }
    }
}
