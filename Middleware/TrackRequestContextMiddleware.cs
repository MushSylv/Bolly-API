using BollyAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BollyAPI.Middleware
{
    public class TrackRequestContextMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly IApplicationRequestContext _requestContext;
        private readonly ILogger<TrackRequestContextMiddleware> _logger;

        //public TrackRequestContextMiddleware(RequestDelegate next, IApplicationRequestContext requestContext)
        //{
        //    _next = next;
        //    _requestContext = requestContext;
        //}

        public TrackRequestContextMiddleware(RequestDelegate next, ILogger<TrackRequestContextMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        //public async Task InvokeAsync(HttpContext context, IApplicationRequestContext requestContext)
        //{
        //    context.Response.Headers.Add("X-Guid", requestContext.Id.ToString());
        //    await _next(context);
        //}

        public async Task InvokeAsync(HttpContext context, IApplicationRequestContext requestContext)
        {
            _logger.LogInformation($"X-Guid : {requestContext.Id}");
            await _next(context);
        }
    }
}
