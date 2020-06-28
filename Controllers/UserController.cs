using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BollyApi.Service.Abstractions.Users;
using BollyApi.Service.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BollyAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [HttpPost, Route("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateParameters authParams)
        {
            var authUser = _userService.Authenticate(authParams);
            return authUser == null ? (IActionResult)Unauthorized() : Ok(authUser);
        }
    }
}