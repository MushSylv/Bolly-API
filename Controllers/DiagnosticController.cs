using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BollyAPI.Interfaces;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BollyAPI.Controllers
{
    [Route("api/_system")]
    [ApiController]
    public class DiagnosticController : ControllerBase
    {
        private readonly IApplicationRequestContext _requestContext;
        private readonly DiagnosticOptions _options;

        public DiagnosticController(IOptionsSnapshot<DiagnosticOptions> options)
        {
            _options = options.Value;
        }
        //public DiagnosticController(IApplicationRequestContext requestContext) => _requestContext = requestContext;

        //[HttpGet, HttpHead, Route("healthcheck")]
        //public IActionResult HealthCheck()
        //{
        //    ControllerContext.HttpContext.Response.Headers.Add("X-Guid2", _requestContext.Id.ToString());
        //    return Ok(_options.HealthCheckContent);
        //}

        [HttpGet, HttpHead, Route("healthcheck")]
        public IActionResult HealthCheck() => Ok(_options.HealthCheckContent);
    }
}