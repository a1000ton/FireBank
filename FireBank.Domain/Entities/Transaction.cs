using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireBank.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public TransactionType Type { get; set; }
        public int Balance { get; set; }
        public virtual Account Account { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
    }

    public enum TransactionType
    {
        Withdrawal = 0,
        Deposit = 1,
    }
}
