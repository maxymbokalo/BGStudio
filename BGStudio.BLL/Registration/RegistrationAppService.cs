using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGStudio.App.Models;
using BGStudio.BLL.Registration.Dto;
using BGStudio.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BGStudio.BLL.Registration
{
    public class RegistrationAppService : IRegistrationAppService
    {
        private BGStudioAppContext _appContext;
        public RegistrationAppService(BGStudioAppContext bgStudioAppContext)
        {
            _appContext = bgStudioAppContext;
        }

        public async void RegisterNewUser(NewUserDto newUserDto)
        {
            await AddNewUser(newUserDto);
            var newUser = _appContext.Users.SingleOrDefault(user => user.PhoneNumber == newUserDto.PhoneNumber);
            await AddNewAccount(newUserDto, newUser);
            var newAccount = _appContext.Accounts.SingleOrDefault(account => account.EmailAddress == newUserDto.EmailAddress);
            newUser.AccountId = newAccount.Id;
            _appContext.SaveChanges();

        }

        public List<Exception> CheckEmailAndPhoneForDuplicates(NewUserDto newUserDto)
        {
            var exceptions = new List<Exception>();
            if (_appContext.Users.Any(user => user.PhoneNumber == newUserDto.PhoneNumber))
                exceptions.Add(new Exception("DuplicatePhoneNumber"));
            if(_appContext.Accounts.Any(account => account.EmailAddress == newUserDto.EmailAddress))
                exceptions.Add(new Exception("DuplicateEmailAddress"));
            return exceptions;
        }

        private async Task AddNewAccount(NewUserDto newUserDto, UserERD newUser)
        {
             await _appContext.Accounts.AddAsync(new AccountERD
            {
                EmailAddress = newUserDto.EmailAddress,
                Password = newUserDto.Password,
                UserId = newUser.Id,
                IsDeleted = false
            });
             _appContext.SaveChanges();
        }

        private async Task AddNewUser(NewUserDto newUserDto)
        {
             await _appContext.Users.AddAsync(new UserERD
            {
                Name = newUserDto.Name,
                SurName = newUserDto.SurName,
                Age = newUserDto.Age,
                RoleId = newUserDto.RoleId,
                PhoneNumber = newUserDto.PhoneNumber,
                IsDeleted = false,
                IsAdmin = false
            });
             _appContext.SaveChanges();
        }
    }
}