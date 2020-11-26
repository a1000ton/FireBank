using System;

namespace FireBank.Application.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Balance { get; set; }
        public string Name { get; set; }
        public IAccountCreatedModelType Type { get; set; }
    }

    public interface IAccountModelType
    {

    }

    public class BusinessAccountModel : IAccountModelType
    {
        public int BusinessId { get; set; }
    }

    public class StudentAccountModel : IAccountModelType
    {
        public int StudentId { get; set; }
    }

    public class GiroAccountModel : IAccountModelType
    {

    }
}
