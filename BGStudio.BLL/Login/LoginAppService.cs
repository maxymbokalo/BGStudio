using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using BGStudio.App.Models;
using BGStudio.BLL.Authetication;
using BGStudio.BLL.Login.Dto;
using BGStudio.DAL.EntityFramework;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BGStudio.BLL.Login
{
    public class LoginAppService : ILoginAppService
    {
        private BGStudioAppContext _appContext;
        private IOptions<AuthOptions> _authOptions;

        public LoginAppService(BGStudioAppContext bgStudioAppContext,IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions;
            _appContext = bgStudioAppContext;
        }
        public string GenerateJwt(AccountERD account)
        {
            var authParams = _authOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, account.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
                new Claim("role",GetAccountUser(account).RoleId.ToString())
            };

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AccountERD AuthenticateUser(string email, string password)
        {
            return _appContext.Accounts.SingleOrDefault(u => u.EmailAddress == email && u.Password == password);
        }

        private UserERD GetAccountUser(AccountERD account)
        {
            return _appContext.Users.SingleOrDefault(u => u.Id == account.UserId);
        }
    }
}