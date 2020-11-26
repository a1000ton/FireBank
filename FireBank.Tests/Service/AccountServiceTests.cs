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
        public void GetBalance_WhenPassValidAccountId_ShouldReturnLastTransactionBalance()
        {
            var accountId = 5;
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
                Name = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                Transactions = transactions,
                Id = accountId
            };

            var repositoryMock = new Mock<IAccountRepository>();
            repositoryMock.Setup(rep => rep.GetById(accountId)).Returns(account);

            var service = new AccountService(repositoryMock.Object);

            var balance = service.GetBalance(accountId);

            Assert.Equal(balance, lastBalance);
        }
    }
}
