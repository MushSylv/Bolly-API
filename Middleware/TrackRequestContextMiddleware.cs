using BollyAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BollyAPI.Middleware
{
    public class TrackRequestContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApplicationRequestContext _requestContext;

        public TrackRequestContextMiddleware(RequestDelegate next, IApplicationRequestContext requestContext)
        {
            _next = next;
            _requestContext = requestContext;
        }

        public async Task InvokeAsync(HttpContext context, IApplicationRequestContext requestContext)
        {
            context.Response.Headers.Add("X-Guid", requestContext.Id.ToString());
            await _next(context);
        }
    }
}
