using FireBank.Application.Applications.Interfaces;
using FireBank.Application.Models;
using System.Web.Http;

namespace FireBank.WebApi.Controllers
{
    public class StudentAccountController : ApiController
    {
        private readonly IAccountApplication _app;
        public StudentAccountController(IAccountApplication app)
        {
            _app = app;
        }

        [HttpPost]
        public AccountCreatedModel Post([FromBody] StudentAccountCreationModel account)
        {
            return _app.CreateStudentAccount(account);
        }
    }
}