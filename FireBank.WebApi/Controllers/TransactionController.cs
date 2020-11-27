using FireBank.Application.Applications.Interfaces;
using FireBank.Application.Models;
using System.Web.Http;

namespace FireBank.WebApi.Controllers
{
    public class TransactionController : ApiController
    {

        private readonly ITransactionApplication _app;
        public TransactionController(ITransactionApplication app)
        {
            _app = app;
        }

        [HttpGet]
        public TransactionsModel Get(int id)
        {
            return _app.List(id);
        }

        [HttpPost]
        public TransactionCreatedModel Post([FromBody] TransactionCreationModel transaction)
        {
            return _app.Create(transaction);
        }
    }
}