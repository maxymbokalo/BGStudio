using System;

namespace BGStudio.App.Models
{
    public class UserERD
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public bool IsAdmin { get; set; }
        public int RoleId { get; set; }
        public bool IsDeleted { get; set; }

        public AccountERD Account { get; set; }
    }
}