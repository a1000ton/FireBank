namespace FireBank.Domain.Entities.Old
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
