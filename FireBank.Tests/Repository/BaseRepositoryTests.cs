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
        public void Add_WhenPassObject_ShouldAddAndSaveChanges()
        {
            var connection = DbConnectionFactory.CreateTransient();

            using (var context = new FireBankContext(connection))
            {
                var accountToAdd = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString()
                };


                var repository = new BaseRepository<Account>(context);
                repository.Add(accountToAdd);

                Assert.Equal(1, context.Accounts.Count());
                Assert.Equal(accountToAdd.Name, context.Accounts.Find(1).Name);
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

                Assert.Equal(3, context.Accounts.Count());
            }
        }
    }
}
