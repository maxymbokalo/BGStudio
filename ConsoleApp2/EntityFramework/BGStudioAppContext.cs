using BGStudio.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BGStudio.DAL.EntityFramework
{
    public class BGStudioAppContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public BGStudioAppContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "TestName",
                    UserName = "TestUserName",
                    SurName = "TestSurName",
                    EmailAddress = "test@gmail.com",
                    PhoneNumber = "041414131",
                    IsAdmin = false,
                    Password = "test",
                    RoleId = 2
                },
                new User
                {
                    Id = 2,
                    Name = "Admin",
                    UserName = "Admin",
                    SurName = "Admin",
                    EmailAddress = "admin@gmail.com",
                    PhoneNumber = "066161661",
                    IsAdmin = false,
                    Password = "admin",
                    RoleId = 1
                });
        }
    }
}