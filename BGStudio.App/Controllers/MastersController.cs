using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGStudio.BLL.Masters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BGStudio.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        private IMastersAppService _masterAppService;

        public MastersController(IMastersAppService mastersAppService)
        {
            _masterAppService = mastersAppService;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetMasters()
        {
            var masters = _masterAppService.GetAllMasters();
            return Ok(masters);
        }
    }
}
