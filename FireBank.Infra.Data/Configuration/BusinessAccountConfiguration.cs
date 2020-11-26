using FireBank.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FireBank.Infra.Data.Configuration
{
    public class BusinessAccountConfiguration : EntityTypeConfiguration<BusinessAccount>
    {
        public BusinessAccountConfiguration()
        {
            HasKey(ba => new { ba.AccountId, ba.BusinessId });
        }
    }
}
