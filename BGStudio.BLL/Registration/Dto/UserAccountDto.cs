using System.ComponentModel.DataAnnotations;

namespace BGStudio.BLL.Registration.Dto
{
    public class UserAccountDto
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}