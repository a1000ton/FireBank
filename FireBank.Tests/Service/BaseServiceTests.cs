using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace FireBank.Tests.Service
{
    public class BaseServiceTests
    {
        [Fact]
        public void Add_WhenPassObject_ShouldAddObject()
        {
            var account = new Account()
            {
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now
            };

            var returnedAccount = new Account()
            {
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now
            };

            var repositoryMock = new Mock<IBaseRepository<Account>>();
            repositoryMock.Setup(r => r.Add(account)).Returns(returnedAccount);

            var service = new BaseService<Account>(repositoryMock.Object);

            var addedAccount = service.Add(account);

            repositoryMock.Verify(rep => rep.Add(account), Times.Once());
            Assert.Equal(addedAccount, returnedAccount);
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldShowAllObjects()
        {
            var accountOne = new Account()
            {
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now
            };

            var accountTwo = new Account()
            {
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now
            };

            var accounts = new List<Account>()
            {
                accountOne, accountTwo
            };

            var repositoryMock = new Mock<IBaseRepository<Account>>();
            repositoryMock.Setup(r => r.GetAll()).Returns(accounts);

            var service = new BaseService<Account>(repositoryMock.Object);

            var returnedAccounts = service.GetAll();

            repositoryMock.Verify(rep => rep.GetAll(), Times.Once());
            Assert.Equal(accounts, returnedAccounts);
        }

        [Fact]
        public void GetById_WhenPassValidId_ShouldReturnFoundObject()
        {
            var accountId = 3;

            var account = new Account()
            {
                Id = accountId,
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now
            };

            var repositoryMock = new Mock<IBaseRepository<Account>>();
            repositoryMock.Setup(r => r.GetById(accountId)).Returns(account);

            var service = new BaseService<Account>(repositoryMock.Object);

            var returnedAccount = service.GetById(accountId);

            repositoryMock.Verify(rep => rep.GetById(accountId), Times.Once());
            Assert.Equal(account, returnedAccount);
        }

        [Fact]
        public void Remove_WhenPassValidObject_ShouldDeleteObject()
        {
            var account = new Account()
            {
                Id = 3,
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now
            };

            var repositoryMock = new Mock<IBaseRepository<Account>>();
            repositoryMock.Setup(r => r.Remove(account));

            var service = new BaseService<Account>(repositoryMock.Object);

            service.Remove(account);

            repositoryMock.Verify(rep => rep.Remove(account), Times.Once());
        }
    }
}
