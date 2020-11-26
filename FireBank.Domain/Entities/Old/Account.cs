using System;
using System.Collections.Generic;

namespace FireBank.Domain.Entities.Old
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
