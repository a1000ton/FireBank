using FireBank.Application.Applications.Interfaces;
using FireBank.Application.Models;
using System.Web.Http;

namespace FireBank.WebApi.Controllers
{
    public class GiroAccountController : ApiController
    {
        private readonly IAccountApplication _app;
        public GiroAccountController(IAccountApplication app)
        {
            _app = app;
        }

        [HttpPost]
        public AccountCreatedModel Post([FromBody] GiroAccountCreationModel account)
        {
            return _app.CreateGiroAccount(account);
        }
    }
}