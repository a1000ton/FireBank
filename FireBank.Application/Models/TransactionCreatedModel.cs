using FireBank.Domain.Entities;
using System;

namespace FireBank.Application.Models
{
    public class TransactionCreatedModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public TransactionType Type { get; set; }
        public Account Account { get; set; }
    }
}
