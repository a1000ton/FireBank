using System;
using System.Collections.Generic;

namespace FireBank.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual IAccountType AccountType { get; set; }
    }
}
