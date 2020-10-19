using System;

namespace BGStudio.App.Models
{
    public class User
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}