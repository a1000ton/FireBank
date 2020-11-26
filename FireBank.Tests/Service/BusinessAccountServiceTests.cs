using FireBank.Domain.Entities.Old;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Service.Services;
using Moq;
using Xunit;

namespace FireBank.Tests.Service
{
    public class BusinessAccountServiceTests
    {
        [Fact]
        public void BalanceIsValid_WhenPassObjectWithValidBalance_ShouldReturnTrue()
        {
            var validBalance = 1;
            var invalidBalance = -200000;
            var accountId = 2;

            var account = new BusinessAccount() { AccountId = accountId };

            var repository = new Mock<IBaseAccountRepository<BusinessAccount>>();
            repository.Setup(b => b.GetById(accountId)).Returns(account);

            var service = new BaseAccountService<BusinessAccount>(repository.Object);

            var isValidBalanceValid = service.BalanceIsValid(validBalance, accountId);
            var isInvalidBalanceValid = service.BalanceIsValid(invalidBalance, accountId);

            Assert.True(isValidBalanceValid);
            Assert.False(isInvalidBalanceValid);
        }
    }
}
