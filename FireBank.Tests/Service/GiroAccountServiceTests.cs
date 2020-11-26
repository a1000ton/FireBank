using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Service.Services;
using Moq;
using Xunit;

namespace FireBank.Tests.Service
{
    public class GiroAccountServiceTests
    {
        [Fact]
        public void BalanceIsValid_WhenPassObjectWithValidBalance_ShouldReturnTrue()
        {
            var validBalance = 2000;
            var invalidBalance = -5000;
            var accountId = 2;

            var account = new GiroAccount() { AccountId = accountId };

            var repository = new Mock<IBaseAccountRepository<GiroAccount>>();
            repository.Setup(b => b.GetById(accountId)).Returns(account);

            var service = new BaseAccountService<GiroAccount>(repository.Object);

            var isValidBalanceValid = service.BalanceIsValid(validBalance, accountId);
            var isInvalidBalanceValid = service.BalanceIsValid(invalidBalance, accountId);

            Assert.True(isValidBalanceValid);
            Assert.False(isInvalidBalanceValid);
        }
    }
}
