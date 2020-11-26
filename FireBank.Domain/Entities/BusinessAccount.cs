using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireBank.Domain.Entities
{
    public class BusinessAccount : IAccountType
    {
        public int BusinessId { get; set; }

        [Key]
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }

        public int BalanceNegativeLimit()
        {
            return -100000;
        }
    }
}
