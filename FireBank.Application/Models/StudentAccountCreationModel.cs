using System.ComponentModel.DataAnnotations;

namespace FireBank.Application.Models
{
    public class StudentAccountCreationModel : AccountCreationModel
    {
        [Required]
        public int StudentId { get; set; }
    }
}

