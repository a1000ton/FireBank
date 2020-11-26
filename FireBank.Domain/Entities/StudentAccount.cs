using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireBank.Domain.Entities
{
    public class StudentAccount : BaseAccount
    {
        [Key]
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public int StudentId { get; set; }

        public int BalanceNegativeLimit()
        {
            return 0;
        }
    }
}
