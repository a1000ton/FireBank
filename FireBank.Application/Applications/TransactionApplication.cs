using FireBank.Application.Applications.Interfaces;
using FireBank.Application.Models;

namespace FireBank.Application.Applications
{
    public class TransactionApplication : ITransactionApplication
    {
        public TransactionCreatedModel Create(TransactionCreationModel transaction)
        {
            throw new System.NotImplementedException();
        }
    }
}
