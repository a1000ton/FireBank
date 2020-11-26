using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Domain.Interfaces.Service;

namespace FireBank.Service.Services
{
    public class StudentAccountService : BaseService<StudentAccount>, IStudentAccountService
    {
        private readonly IStudentAccountRepository _repository;

        public StudentAccountService(IStudentAccountRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public int GetBalance(int accountId)
        {
            throw new System.NotImplementedException();
        }
    }
}
