using FireBank.Application.Applications.Interfaces;
using FireBank.Application.Models;
using System.Web.Http;

namespace FireBank.WebApi.Controllers
{
    public class BusinessAccountController : ApiController
    {
        private readonly IAccountApplication _app; 
        public BusinessAccountController(IAccountApplication app)
        {
            _app = app;
        }

        [HttpPost]
        public AccountCreatedModel Post([FromBody] BusinessAccountCreationModel account)
        {
            return _app.CreateBusinessAccount(account);
        }
    }
}