using FireBank.Application.Models;

namespace FireBank.Application.Applications.Interfaces
{
    public interface ITransactionApplication
    {
        TransactionCreatedModel Create(TransactionCreationModel transaction);
    }
}
