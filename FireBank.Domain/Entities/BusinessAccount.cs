using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireBank.Domain.Entities
{
    public class BusinessAccount : BaseAccount
    {
        public int BusinessId { get; set; }

        public int BalanceNegativeLimit()
        {
            return -100000;
        }
    }
}
