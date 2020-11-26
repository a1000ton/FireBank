using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;

namespace FireBank.Service.Services
{
    public class StudentAccountService : BaseAccountService<StudentAccount>, IStudentAccountService
    {
        private new readonly IStudentAccountRepository _repository;

        public StudentAccountService(IStudentAccountRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
