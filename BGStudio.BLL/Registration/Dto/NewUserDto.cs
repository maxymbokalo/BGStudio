using System.ComponentModel.DataAnnotations;

namespace BGStudio.BLL.Registration.Dto
{
    public class NewUserDto
    { 
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [Range(minimum:16,maximum:70)]
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}