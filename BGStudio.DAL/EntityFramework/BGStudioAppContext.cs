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
                    IsDeleted = false,
                    AccountId = 1
                },
                new UserERD
                {
                    Id = 2,
                    Name = "Juli",
                    SurName = "Maea",
                    Age = 31,
                    PhoneNumber = "12313515",
                    IsAdmin = false,
                    RoleId = 2,
                    IsDeleted = false,
                    AccountId = 2
                },
                new UserERD
                {
                    Id = 3,
                    Name = "Kate",
                    SurName = "Qweqr",
                    Age = 22,
                    PhoneNumber = "166616112",
                    IsAdmin = false,
                    RoleId = 2,
                    IsDeleted = false,
                    AccountId = 3
                },
                new UserERD
                {
                    Id = 4,
                    Name = "Admin",
                    SurName = "Admin",
                    Age = 21,
                    PhoneNumber = "066161661",
                    IsAdmin = true,
                    RoleId = 1,
                    IsDeleted = false,
                    AccountId = 4
                });

            modelBuilder.Entity<AccountERD>().HasData(
                new AccountERD
                {
                    Id = 1,
                    EmailAddress = "test1@gmail.com",
                    Password = "test1",
                    UserId = 1,
                    IsDeleted = false,
                },
                new AccountERD
                {
                    Id = 2,
                    EmailAddress = "test2@gmail.com",
                    Password = "test2",
                    UserId = 2,
                    IsDeleted = false,
                },
                new AccountERD
                {
                    Id = 3,
                    EmailAddress = "test3@gmail.com",
                    Password = "test3",
                    UserId = 3,
                    IsDeleted = false,
                }, new AccountERD
                {
                    Id = 4,
                    EmailAddress = "admin@gmail.com",
                    Password = "admin",
                    UserId = 4,
                    IsDeleted = false,
                });
        }
    }
}