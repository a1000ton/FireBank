using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Infra.Data.Configuration;

namespace FireBank.Infra.Data.Repositories
{
    public class StudentAccountRepository : BaseRepository<StudentAccount>, IStudentAccountRepository
    {
        public StudentAccountRepository(FireBankContext db) : base(db)
        {

        }
    }
}
