using Effort;
using FireBank.Application.Applications;
using FireBank.Application.Models;
using FireBank.Domain.Entities;
using FireBank.Infra.Data.Configuration;
using FireBank.Infra.Data.Repositories;
using FireBank.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FireBank.Tests.App
{
    public class TransactionApplicationTests
    {
        [Fact]
        public void Create_WhenPassValidTransaction_ShouldCreateTheTransactionAndUpdateTheBalance()
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
                };

                var accountRepository = new AccountRepository(context);
                var accountService = new AccountService(accountRepository);

                var addedAccount = accountService.Add(account);

                var transactionRepository = new TransactionRepository(context);
                var transactionService = new TransactionService(transactionRepository, accountService);

                var validTransaction = new TransactionCreationModel()
                {
                    AccountId = addedAccount.Id,
                    Amount = 10,
                    Type = TransactionType.Withdrawal,
                };

                var transactionApp = new TransactionApplication(transactionService);
                var addedTransaction = transactionApp.Create(validTransaction);

                Assert.Equal(TransactionStatus.Completed, addedTransaction.Status);
                Assert.Equal(addedTransaction.Account.Id, account.Id);
                Assert.Equal(addedTransaction.Balance, -10);
                Assert.Equal(10, addedTransaction.Amount);
                Assert.Equal(TransactionType.Withdrawal, addedTransaction.Type);
            }
        }

        [Fact]
        public void Create_WhenPassInvalidTransaction_ShouldNotCreateTheTransactionAndKeepTheBalance()
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
                        StudentId = 10,
                    },
                };

                var accountRepository = new AccountRepository(context);
                var accountService = new AccountService(accountRepository);

                var addedAccount = accountService.Add(account);

                var transactionRepository = new TransactionRepository(context);
                var transactionService = new TransactionService(transactionRepository, accountService);

                var invalidTransaction = new TransactionCreationModel()
                {
                    AccountId = addedAccount.Id,
                    Amount = 10,
                    Type = TransactionType.Withdrawal,
                };

                var transactionApp = new TransactionApplication(transactionService);
                var addedTransaction = transactionApp.Create(invalidTransaction);

                Assert.Equal(TransactionStatus.Cancelled, addedTransaction.Status);
                Assert.Equal(0, addedTransaction.Balance);
                Assert.Equal(10, addedTransaction.Amount);
                Assert.Equal(TransactionType.Withdrawal, addedTransaction.Type);
            }
        }

        [Fact]
        public void List_WhenCalled_ShouldReturnAllTransactionsFromAccount()
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
                        StudentId = 10,
                    },
                };

                var accountRepository = new AccountRepository(context);
                var accountService = new AccountService(accountRepository);

                var addedAccount = accountService.Add(account);

                var transactionRepository = new TransactionRepository(context);
                var transactionService = new TransactionService(transactionRepository, accountService);

                var transactionOne = new Transaction()
                {
                    AccountId = addedAccount.Id,
                    Amount = 10,
                    Type = TransactionType.Deposit
                };

                var transactionTwo = new Transaction()
                {
                    AccountId = addedAccount.Id,
                    Amount = 100,
                    Type = TransactionType.Deposit
                };

                var transactionThree = new Transaction()
                {
                    AccountId = addedAccount.Id,
                    Amount = 20,
                    Type = TransactionType.Withdrawal
                };

                transactionService.Add(transactionOne);
                transactionService.Add(transactionTwo);
                transactionService.Add(transactionThree);

                var transactionApp = new TransactionApplication(transactionService);
                var transactionsList = transactionApp.List(addedAccount.Id);

                Assert.Equal(transactionsList.AccountId, account.Id);
                Assert.Equal(3, transactionsList.Transactions.Count);
                Assert.Equal(90, transactionsList.Transactions.OrderBy(t => t.Date).Last().Balance);
            }
        }
    }
}
