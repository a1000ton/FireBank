using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireBank.Domain.Entities.Old
{
    public class BusinessAccount : BaseAccount
    {
        public BusinessAccount()
        {
        }

        public int BusinessId { get; set; }

        public int BalanceNegativeLimit()
        {
            return -100000;
        }
    }
}
