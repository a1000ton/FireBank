using FireBank.Domain.Entities.Old;

namespace FireBank.Application.Models
{
    public class TransactionCreationModel
    {
        public int Amount { get; set; }
        public TransactionType Type { get; set; }
        public int AccountId { get; set; }
    }
}
