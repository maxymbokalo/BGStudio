using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGStudio.BLL.Authetication;
using BGStudio.BLL.Login;
using BGStudio.BLL.Login.Dto;
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

        public AuthController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
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
    }
}
