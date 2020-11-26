using FireBank.Application.Models;

namespace FireBank.Application.Applications.Interfaces
{
    public interface IAccountApplication
    {
        AccountCreatedModel CreateBusinessAccount(BusinessAccountCreationModel account);
        AccountCreatedModel CreateStudentAccount(StudentAccountCreationModel account);
        AccountCreatedModel CreateGiroAccount(GiroAccountCreationModel account);
    }
}
