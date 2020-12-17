using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brutus_RestApi.Managers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Brutus_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager loginManager;
        public LoginController(ILoginManager loginManager)
        {
            this.loginManager = loginManager;
        }

        [HttpGet]
        [Route("AuthUser")]
        [EnableCors("AllowOrigin")]
        public IActionResult AuthUser2([FromQuery] string login, [FromQuery] string password)
        {
            var user = loginManager.AuthUser2(login, password);
            if (user == null)
            {
                return ValidationProblem();
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("ChangePassword")]
        [EnableCors("AllowOrigin")]

        public IActionResult ChangePassword([FromQuery] string login, [FromQuery] string oldPassword, [FromQuery] string newPassword)
        {
            var user = loginManager.ChangePassword(login,oldPassword,newPassword);
            if (user == null)
            {
                return ValidationProblem();
            }
            return Ok();
        }

    }
}