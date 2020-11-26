namespace FireBank.Domain.Entities
{
    public class StudentAccount
    {
        public int StudentId { get; set; }
        public virtual Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
