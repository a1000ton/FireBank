﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireBank.Domain.Entities
{
    public class BaseAccount
    {
        [Key]
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
