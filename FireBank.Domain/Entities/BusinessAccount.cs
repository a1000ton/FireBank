namespace FireBank.Domain.Entities
{
    public class BusinessAccount
    {
        public int BusinessId { get; set; }
        public virtual Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
