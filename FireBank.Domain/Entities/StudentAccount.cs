namespace FireBank.Domain.Entities
{
    public class StudentAccount : BaseAccount
    {
        public int StudentId { get; set; }

        public int BalanceNegativeLimit()
        {
            return 0;
        }
    }
}
