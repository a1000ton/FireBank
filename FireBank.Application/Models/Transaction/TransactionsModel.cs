using FireBank.Application.Models.Transaction;
using System.Collections.Generic;

namespace FireBank.Application.Models
{
    public class TransactionsModel
    {
        public int AccountId { get; set; }
        public List<TransactionModel> Transactions { get; set; }
    }
}
