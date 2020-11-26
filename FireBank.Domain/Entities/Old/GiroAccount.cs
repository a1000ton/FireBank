namespace FireBank.Domain.Entities.Old
{
    public class GiroAccount : BaseAccount
    {
        public int BalanceNegativeLimit()
        {
            return -4000;
        }
    }
}
