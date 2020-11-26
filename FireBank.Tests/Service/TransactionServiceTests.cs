using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
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

            var service = new TransactionService(repositoryMock.Object);

            var returnedTransaction = service.Add(transaction);

            repositoryMock.Verify(rep => rep.Add(transaction), Times.Once());
            Assert.Equal(returnedTransaction, addedTransaction);
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldShowAllObjects()
        {
            var transactionOne = new Transaction()
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

            var transactionTwo = new Transaction()
            {
                Account = new Account()
                {
                    CreatedAt = DateTime.Now,
                    Name = Guid.NewGuid().ToString()
                },
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
            repositoryMock.Setup(r => r.GetAll()).Returns(transactions);

            var service = new TransactionService(repositoryMock.Object);

            var returnedTransactions = service.GetAll();

            repositoryMock.Verify(rep => rep.GetAll(), Times.Once());
            Assert.Equal(transactions, returnedTransactions);
        }

        [Fact]
        public void GetById_WhenPassValidId_ShouldReturnFoundObject()
        {
            var transactionId = 3;

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
                Type = TransactionType.Deposit,
                Id = transactionId
            };

            var repositoryMock = new Mock<ITransactionRepository>();
            repositoryMock.Setup(r => r.GetById(transactionId)).Returns(transaction);

            var service = new TransactionService(repositoryMock.Object);

            var returnedTransaction = service.GetById(transactionId);

            repositoryMock.Verify(rep => rep.GetById(transactionId), Times.Once());
            Assert.Equal(transaction, returnedTransaction);
        }
    }
}
