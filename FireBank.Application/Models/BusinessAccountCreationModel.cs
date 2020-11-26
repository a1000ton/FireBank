using System.ComponentModel.DataAnnotations;

namespace FireBank.Application.Models
{
    public class BusinessAccountCreationModel : AccountCreationModel
    {
        [Required]
        public int BusinessId { get; set; }
    }
}
