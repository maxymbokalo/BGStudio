using BGStudio.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BGStudio.DAL.EntityFramework
{
    public class BGStudioAppContext : DbContext
    {
        public DbSet<AccountERD> Accounts { get; set; }
        public DbSet<UserERD> Users { get; set; }
        public BGStudioAppContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserERD>()
                .HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<AccountERD>(a => a.UserId);

            modelBuilder.Entity<UserERD>().HasData(
                new UserERD
                {
                    Id = 1,
                    Name = "TestName",
                    SurName = "TestSurName",
                    Age = 21,
                    PhoneNumber = "041414131",
                    IsAdmin = false,
                    RoleId = 2,
                    IsDeleted = false
                },
                new UserERD
                {
                    Id = 2,
                    Name = "Admin",
                    SurName = "Admin",
                    Age = 21,
                    PhoneNumber = "066161661",
                    IsAdmin = false,
                    RoleId = 1,
                    IsDeleted = false
                });

            modelBuilder.Entity<AccountERD>().HasData(
                new AccountERD
                {
                    Id = 1,
                    EmailAddress = "test@gmail.com",
                    Password = "test",
                    UserId = 1,
                    IsDeleted = false
                },
                new AccountERD
                {
                    Id = 2,
                    EmailAddress = "admin@gmail.com",
                    Password = "admin",
                    UserId = 2,
                    IsDeleted = false
                });
        }
    }
}