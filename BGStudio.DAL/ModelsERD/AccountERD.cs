using System;
using System.ComponentModel.DataAnnotations;

namespace BGStudio.App.Models
{
    public class AccountERD
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        public UserERD User { get; set; }
    }

}