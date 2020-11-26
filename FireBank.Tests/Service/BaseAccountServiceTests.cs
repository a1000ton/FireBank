using FireBank.Domain.Entities.Old;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace FireBank.Tests.Service
{
    public class BaseAccountServiceTests
    {
        [Fact]
        public void Add_WhenPassObject_ShouldAddObject()
        {
            var businessAccount = new BusinessAccount()
            {
                Account = new Account()
                {
                    Name = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now
                },
                BusinessId = 2,
            };

            var addedBusinessAccount = new BusinessAccount()
            {
                Account = new Account()
                {
                    Name = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now
                },
                BusinessId = 2,
            };

            var repositoryMock = new Mock<IBaseAccountRepository<BusinessAccount>>();
            repositoryMock.Setup(r => r.Add(businessAccount)).Returns(addedBusinessAccount);

            var service = new BaseAccountService<BusinessAccount>(repositoryMock.Object);

            var returnedAccount = service.Add(businessAccount);

            repositoryMock.Verify(rep => rep.Add(businessAccount), Times.Once());
            Assert.Equal(returnedAccount, addedBusinessAccount);
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldShowAllObjects()
        {
            var accountOne = new BusinessAccount()
            {
                Account = new Account()
                {
                    Name = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now
                },
                BusinessId = 2,
            };

            var accountTwo = new BusinessAccount()
            {
                Account = new Account()
                {
                    Name = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now
                },
                BusinessId = 3,
            };

            var accounts = new List<BusinessAccount>()
            {
                accountOne, accountTwo
            };

            var repositoryMock = new Mock<IBaseAccountRepository<BusinessAccount>>();
            repositoryMock.Setup(r => r.GetAll()).Returns(accounts);

            var service = new BaseAccountService<BusinessAccount>(repositoryMock.Object);

            var returnedAccounts = service.GetAll();

            repositoryMock.Verify(rep => rep.GetAll(), Times.Once());
            Assert.Equal(accounts, returnedAccounts);
        }

        [Fact]
        public void GetBalance_WhenCalled_ShouldReturnRepositoryBalance()
        {
            var currentBalance = 1000;
            var accountId = 5;

            var repositoryMock = new Mock<IBaseAccountRepository<BusinessAccount>>();
            repositoryMock.Setup(r => r.GetBalance(accountId)).Returns(currentBalance);

            var service = new BaseAccountService<BusinessAccount>(repositoryMock.Object);
            var returnedBalance = service.GetBalance(accountId);

            Assert.Equal(returnedBalance, currentBalance);
            repositoryMock.Verify(r => r.GetBalance(accountId), Times.Once());
        }

        //GetBalance

        [Fact]
        public void GetById_WhenPassValidId_ShouldReturnFoundObject()
        {
            var accountId = 3;

            var account = new BusinessAccount()
            {
                Account = new Account()
                {
                    Id = accountId,
                    Name = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now
                },
                BusinessId = 5,
            };

            var repositoryMock = new Mock<IBaseAccountRepository<BusinessAccount>>();
            repositoryMock.Setup(r => r.GetById(accountId)).Returns(account);

            var service = new BaseAccountService<BusinessAccount>(repositoryMock.Object);

            var returnedAccount = service.GetById(accountId);

            repositoryMock.Verify(rep => rep.GetById(accountId), Times.Once());
            Assert.Equal(account, returnedAccount);
        }

        [Fact]
        public void Remove_WhenPassValidObject_ShouldDeleteObject()
        {
            var account = new BusinessAccount()
            {
                Account = new Account()
                {
                    Id = 3,
                    Name = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now
                },
                BusinessId = 2,
            };

            var repositoryMock = new Mock<IBaseAccountRepository<BusinessAccount>>();
            repositoryMock.Setup(r => r.Remove(account));

            var service = new BaseAccountService<BusinessAccount>(repositoryMock.Object);

            service.Remove(account);

            repositoryMock.Verify(rep => rep.Remove(account), Times.Once());
        }

        [Fact]
        public void Update_WhenPassUpdatedObject_ShouldUpdateObject()
        {
            var account = new BusinessAccount()
            {
                Account = new Account()
                {
                    Id = 3,
                    Name = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now
                },
                BusinessId = 2,
            };

            var updatedAccount = new BusinessAccount()
            {
                Account = new Account()
                {
                    Id = 3,
                    Name = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now
                },
                BusinessId = 2,
            };

            var repositoryMock = new Mock<IBaseAccountRepository<BusinessAccount>>();
            repositoryMock.Setup(r => r.Update(account)).Returns(updatedAccount);

            var service = new BaseAccountService<BusinessAccount>(repositoryMock.Object);

            var returnedAccount = service.Update(account);

            repositoryMock.Verify(rep => rep.Update(account), Times.Once());
            Assert.Equal(returnedAccount, updatedAccount);
        }
    }
}
