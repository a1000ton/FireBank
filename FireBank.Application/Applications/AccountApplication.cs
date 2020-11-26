using FireBank.Application.Applications.Interfaces;
using FireBank.Application.Models;
using FireBank.Domain.Interfaces.Service;
using System;

namespace FireBank.Application.Applications
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountService _service;
        public AccountApplication(IAccountService service)
        {
            _service = service;
        }

        public AccountCreatedModel CreateBusinessAccount(BusinessAccountCreationModel account)
        {
            throw new NotImplementedException();
        }

        public AccountCreatedModel CreateGiroAccount(GiroAccountCreationModel account)
        {
            throw new NotImplementedException();
        }

        public AccountCreatedModel CreateStudentAccount(StudentAccountCreationModel account)
        {
            throw new NotImplementedException();
        }
    }
}
