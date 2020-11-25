using System;

namespace FireBank.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public TransactionType Type { get; set; }
        public int Balance { get; set; }
        public virtual Account Account { get; set; }
    }

    public enum TransactionType
    {
        Withdrawal = 0,
        Deposit = 1,
    }
}
