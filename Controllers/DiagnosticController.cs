using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BollyAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BollyAPI.Controllers
{
    [Route("api/_system")]
    [ApiController]
    public class DiagnosticController : ControllerBase
    {
        private readonly IApplicationRequestContext _requestContext;
        public DiagnosticController(IApplicationRequestContext requestContext) => _requestContext = requestContext;

        [HttpGet, HttpHead, Route("healthcheck")]
        public IActionResult HealthCheck()
        {
            ControllerContext.HttpContext.Response.Headers.Add("X-Guid2", _requestContext.Id.ToString());
            return Ok("system_ok");
        }
    }
}