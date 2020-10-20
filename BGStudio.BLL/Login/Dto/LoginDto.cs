using System.ComponentModel.DataAnnotations;

namespace BGStudio.BLL.Login.Dto
{
    public class LoginDto
    {

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}