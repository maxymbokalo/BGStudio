using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGStudio.BLL.Authetication;
using BGStudio.BLL.Login;
using BGStudio.BLL.Login.Dto;
using BGStudio.BLL.Registration;
using BGStudio.BLL.Registration.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BGStudio.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginAppService _loginAppService;
        private IRegistrationAppService _registrationAppService;

        public AuthController(ILoginAppService loginAppService, IRegistrationAppService registrationAppService)
        {
            _loginAppService = loginAppService;
            _registrationAppService = registrationAppService;
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto requestLoginDto)
        {
            var account = _loginAppService.AuthenticateUser(requestLoginDto.EmailAddress, requestLoginDto.Password);
            if (account == null) return Unauthorized();

            var token = _loginAppService.GenerateJwt(account);

            return Ok(new
            {
                access_token = token
            });
        }
        [Route("register")]
        [HttpPost]
        public IActionResult Registration([FromBody] NewUserDto requestNewUserDto)
        {
            var registrationExceptions = _registrationAppService.CheckEmailAndPhoneForDuplicates(requestNewUserDto);
            if (registrationExceptions.Count > 0)
                return BadRequest(registrationExceptions);

            _registrationAppService.RegisterNewUser(requestNewUserDto);
            return Ok(requestNewUserDto);
        }
    }
}
