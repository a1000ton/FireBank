using System.ComponentModel.DataAnnotations;

namespace FireBank.Application.Models
{
    public class AccountCreationModel
    {
        [Required]
        public string Name { get; set; }
    }
}
