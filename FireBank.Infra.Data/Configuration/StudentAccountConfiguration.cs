using FireBank.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FireBank.Infra.Data.Configuration
{
    public class StudentAccountConfiguration : EntityTypeConfiguration<StudentAccount>
    {
        public StudentAccountConfiguration()
        {
            HasKey(sa => new { sa.AccountId, sa.StudentId });
        }
    }
}
