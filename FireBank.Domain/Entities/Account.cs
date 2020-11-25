using System;
using System.Collections.Generic;

namespace FireBank.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
