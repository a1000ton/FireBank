using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;
using FireBank.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace FireBank.Tests.Service
{
    public class TransactionServiceTests
    {
        [Fact]
        public void Add_WhenPassObject_ShouldAddObject()
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

            var addedTransaction = new Transaction()
            {
                Id = 2,
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

            var repositoryMock = new Mock<ITransactionRepository>();
            repositoryMock.Setup(r => r.Add(transaction)).Returns(addedTransaction);

            var serviceAccountMock = new Mock<IAccountService>();
            serviceAccountMock.Setup(s => s.GetBalance(It.IsAny<Account>())).Returns(100);
            serviceAccountMock.Setup(s => s.BalanceIsValid(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            var service = new TransactionService(repositoryMock.Object, serviceAccountMock.Object);

            var returnedTransaction = service.Add(transaction);

            repositoryMock.Verify(rep => rep.Add(transaction), Times.Once());
            Assert.Equal(returnedTransaction, addedTransaction);
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldShowAllObjects()
        {
            var accountId = 3;
            var transactionOne = new Transaction()
            {
                Account = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString()
                },
                AccountId = accountId,
                Amount = 10,
                Balance = 80,
                Date = DateTime.Now,
                Type = TransactionType.Deposit
            };

            var transactionTwo = new Transaction()
            {
                Account = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString()
                },
                AccountId = accountId,
                Amount = 15,
                Balance = 90,
                Date = DateTime.Now,
                Type = TransactionType.Withdrawal
            };

            var transactions = new List<Transaction>()
            {
                transactionOne, transactionTwo
            };

            var repositoryMock = new Mock<ITransactionRepository>();
            repositoryMock.Setup(r => r.GetAll(accountId)).Returns(transactions);

            var serviceAccountMock = new Mock<IAccountService>();

            var service = new TransactionService(repositoryMock.Object, serviceAccountMock.Object);

            var returnedTransactions = service.GetAll(accountId);

            repositoryMock.Verify(rep => rep.GetAll(accountId), Times.Once());
            Assert.Equal(transactions, returnedTransactions);
        }
    }
}
