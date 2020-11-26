using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireBank.Domain.Entities
{
    public class GiroAccount : BaseAccount
    {
        [Key]
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public int BalanceNegativeLimit()
        {
            return -4000;
        }
    }
}
