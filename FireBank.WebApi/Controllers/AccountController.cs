using FireBank.Application.Applications.Interfaces;
using FireBank.Application.Models;
using System.Web.Http;

namespace FireBank.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountApplication _app;
        public AccountController(IAccountApplication app)
        {
            _app = app;
        }

        [HttpGet]
        public AccountModel Get(int id)
        {
            return _app.GetAccount(id);
        }
    }
}