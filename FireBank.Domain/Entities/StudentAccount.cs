using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireBank.Domain.Entities
{
    public class StudentAccount : IAccountType
    {
        public int StudentId { get; set; }

        [Key]
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }

        public int BalanceNegativeLimit()
        {
            return 0;
        }
    }
}
