using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireBank.Domain.Entities
{
    public class BusinessAccount
    {
        [Key]
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public int BusinessId { get; set; }
        public virtual Account Account { get; set; }
    }
}
