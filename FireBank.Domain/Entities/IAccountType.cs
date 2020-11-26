namespace FireBank.Domain.Entities
{
    public interface IAccountType
    {
        int BalanceNegativeLimit();
        int AccountId { get; set; }
        Account Account { get; set; }
    }
}
