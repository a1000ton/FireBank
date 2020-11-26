using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Service.Services;
using Moq;
using Xunit;

namespace FireBank.Tests.Service
{
    public class StudentAccountServiceTests
    {
        [Fact]
        public void BalanceIsValid_WhenPassObjectWithValidBalance_ShouldReturnTrue()
        {
            var validBalance = 5;
            var invalidBalance = -1;
            var accountId = 2;

            var account = new StudentAccount() { AccountId = accountId };

            var repository = new Mock<IBaseAccountRepository<StudentAccount>>();
            repository.Setup(b => b.GetById(accountId)).Returns(account);

            var service = new BaseAccountService<StudentAccount>(repository.Object);

            var isValidBalanceValid = service.BalanceIsValid(validBalance, accountId);
            var isInvalidBalanceValid = service.BalanceIsValid(invalidBalance, accountId);

            Assert.True(isValidBalanceValid);
            Assert.False(isInvalidBalanceValid);
        }
    }
}
