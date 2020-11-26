namespace FireBank.Domain.Entities
{
    public class GiroAccount : BaseAccount
    {
        public int BalanceNegativeLimit()
        {
            return -4000;
        }
    }
}
