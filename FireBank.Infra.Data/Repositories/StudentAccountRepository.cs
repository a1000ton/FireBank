using FireBank.Domain.Entities.Old;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Infra.Data.Configuration;

namespace FireBank.Infra.Data.Repositories
{
    public class StudentAccountRepository : BaseAccountRepository<StudentAccount>, IStudentAccountRepository
    {
        public StudentAccountRepository(FireBankContext db) : base(db)
        {

        }
    }
}
