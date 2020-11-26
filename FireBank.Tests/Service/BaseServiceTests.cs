using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Service.Services;
using Moq;
using System;
using Xunit;

namespace FireBank.Tests.Service
{
    public class BaseServiceTests
    {
        [Fact]
        public void Add_WhenPassObject_ShouldAddOnRepository()
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

            var repositoryMock  = new Mock<IBaseRepository<Account>>();
            repositoryMock.Setup(r => r.Add(account)).Returns(returnedAccount);

            var service = new BaseService<Account>(repositoryMock.Object);

            var addedAccount =  service.Add(account);

            repositoryMock.Verify(rep => rep.Add(account), Times.Once());
            Assert.Equal(addedAccount, returnedAccount);
        }
    }
}
