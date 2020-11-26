using FireBank.Domain.Entities.Old;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;

namespace FireBank.Service.Services
{
    public class StudentAccountService : BaseAccountService<StudentAccount>, IStudentAccountService
    {
        public StudentAccountService(IStudentAccountRepository repository) : base(repository)
        {
        }
    }
}
