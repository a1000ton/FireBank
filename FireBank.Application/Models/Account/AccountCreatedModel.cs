using System;

namespace FireBank.Application.Models
{
    public class AccountCreatedModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public IAccountCreatedModelType Type { get; set; }
    }

    public interface IAccountCreatedModelType
    {

    }

    public class BusinessAccountCreatedModel : IAccountCreatedModelType
    {
        public int BusinessId { get; set; }
    }

    public class StudentAccountCreatedModel : IAccountCreatedModelType
    {
        public int StudentId { get; set; }
    }

    public class GiroAccountCreatedModel : IAccountCreatedModelType
    {

    }
}
