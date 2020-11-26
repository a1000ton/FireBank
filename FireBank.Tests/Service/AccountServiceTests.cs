using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace FireBank.Tests.Service
{
    public class AccountServiceTests
    {
        [Fact]
        public void Add_WhenPassObject_ShouldAddObject()
        {
            var account = new Account()
            {
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                AccountType = new BusinessAccount()
                {
                    BusinessId = 2,
                }
            };

            var addedAccount = new Account()
            {
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                AccountType = new BusinessAccount()
                {
                    BusinessId = 2,
                }
            };

            var repositoryMock = new Mock<IAccountRepository>();
            repositoryMock.Setup(r => r.Add(account)).Returns(addedAccount);

            var service = new AccountService(repositoryMock.Object);

            var returnedAccount = service.Add(account);

            repositoryMock.Verify(rep => rep.Add(account), Times.Once());
            Assert.Equal(returnedAccount, addedAccount);
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldShowAllObjects()
        {
            var accountOne = new Account()
            {
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                AccountType = new BusinessAccount()
                {
                    BusinessId = 2,
                }
            };

            var accountTwo = new Account()
            {
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                AccountType = new StudentAccount()
                {
                    StudentId = 22,
                }
            };

            var accounts = new List<Account>()
            {
                accountOne, accountTwo
            };

            var repositoryMock = new Mock<IAccountRepository>();
            repositoryMock.Setup(r => r.GetAll()).Returns(accounts);

            var service = new AccountService(repositoryMock.Object);

            var returnedAccounts = service.GetAll();

            repositoryMock.Verify(rep => rep.GetAll(), Times.Once());
            Assert.Equal(accounts, returnedAccounts);
        }

        [Fact]
        public void GetBalance_WhenCalled_ShouldReturnRepositoryBalance()
        {
            var currentBalance = 1000;
            var accountId = 5;
            var account = new Account() { Id = accountId };

            var repositoryMock = new Mock<IAccountRepository>();
            repositoryMock.Setup(r => r.GetBalance(accountId)).Returns(currentBalance);

            var service = new AccountService(repositoryMock.Object);
            var returnedBalance = service.GetBalance(account);

            Assert.Equal(returnedBalance, currentBalance);
            repositoryMock.Verify(r => r.GetBalance(accountId), Times.Once());
        }

        [Fact]
        public void GetById_WhenPassValidId_ShouldReturnFoundObject()
        {
            var accountId = 3;

            var account = new Account()
            {
                Id = accountId,
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                AccountType = new BusinessAccount()
                {
                    BusinessId = 2,
                }
            };

            var repositoryMock = new Mock<IAccountRepository>();
            repositoryMock.Setup(r => r.GetById(accountId)).Returns(account);

            var service = new AccountService(repositoryMock.Object);

            var returnedAccount = service.GetById(accountId);

            repositoryMock.Verify(rep => rep.GetById(accountId), Times.Once());
            Assert.Equal(account, returnedAccount);
        }

        [Fact]
        public void Remove_WhenPassValidObject_ShouldDeleteObject()
        {
            var account = new Account()
            {
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                AccountType = new GiroAccount() { }
            };

            var repositoryMock = new Mock<IAccountRepository>();
            repositoryMock.Setup(r => r.Remove(account));

            var service = new AccountService(repositoryMock.Object);

            service.Remove(account);

            repositoryMock.Verify(rep => rep.Remove(account), Times.Once());
        }

        [Fact]
        public void Update_WhenPassUpdatedObject_ShouldUpdateObject()
        {
            var account = new Account()
            {
                Id = 3,
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                AccountType = new GiroAccount() { }
            };

            var updatedAccount = new Account()
            {
                Id = 3,
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                AccountType = new GiroAccount() { }
            };


            var repositoryMock = new Mock<IAccountRepository>();
            repositoryMock.Setup(r => r.Update(account)).Returns(updatedAccount);

            var service = new AccountService(repositoryMock.Object);

            var returnedAccount = service.Update(account);

            repositoryMock.Verify(rep => rep.Update(account), Times.Once());
            Assert.Equal(returnedAccount, updatedAccount);
        }

        [Fact]
        public void BalanceIsValid_WhenPassBusinessObjectWithValidAndInvalidBalance_ShouldReturnFalseForInvalidAndTrueForValid()
        {
            var validBalance = 1;
            var invalidBalance = -200000;
            var accountId = 2;

            var account = new Account()
            {
                Id = 3,
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                AccountType = new BusinessAccount()
                {
                    BusinessId = 1
                }
            };

            var repository = new Mock<IAccountRepository>();
            repository.Setup(b => b.GetById(accountId)).Returns(account);

            var service = new AccountService(repository.Object);

            var isValidBalanceValid = service.BalanceIsValid(validBalance, accountId);
            var isInvalidBalanceValid = service.BalanceIsValid(invalidBalance, accountId);

            Assert.True(isValidBalanceValid);
            Assert.False(isInvalidBalanceValid);
        }

        [Fact]
        public void BalanceIsValid_WhenPassStudentObjectWithValidAndInvalidBalance_ShouldReturnFalseForInvalidAndTrueForValid()
        {
            var validBalance = 5;
            var invalidBalance = -1;
            var accountId = 2;

            var account = new Account()
            {
                Id = 3,
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                AccountType = new StudentAccount()
                {
                    StudentId = 10
                }
            };

            var repository = new Mock<IAccountRepository>();
            repository.Setup(b => b.GetById(accountId)).Returns(account);

            var service = new AccountService(repository.Object);

            var isValidBalanceValid = service.BalanceIsValid(validBalance, accountId);
            var isInvalidBalanceValid = service.BalanceIsValid(invalidBalance, accountId);

            Assert.True(isValidBalanceValid);
            Assert.False(isInvalidBalanceValid);
        }

        [Fact]
        public void BalanceIsValid_WhenPassGiroObjectWithValidAndInvalidBalance_ShouldReturnFalseForInvalidAndTrueForValid()
        {
            var validBalance = 2000;
            var invalidBalance = -5000;
            var accountId = 2;

            var account = new Account()
            {
                Id = 3,
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                AccountType = new GiroAccount() { }
            };

            var repository = new Mock<IAccountRepository>();
            repository.Setup(b => b.GetById(accountId)).Returns(account);

            var service = new AccountService(repository.Object);

            var isValidBalanceValid = service.BalanceIsValid(validBalance, accountId);
            var isInvalidBalanceValid = service.BalanceIsValid(invalidBalance, accountId);

            Assert.True(isValidBalanceValid);
            Assert.False(isInvalidBalanceValid);
        }
    }
}
