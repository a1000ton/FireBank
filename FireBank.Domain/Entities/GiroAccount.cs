namespace FireBank.Domain.Entities
{
    public class GiroAccount : BaseEntity
    {
        public virtual Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
