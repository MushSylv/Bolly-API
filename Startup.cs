using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BollyApi.Business.DependencyInjection.Extensions;
using BollyApi.Repository.Mock.Users;
using BollyApi.Service.DependencyInjection.Extensions;
using BollyAPI.DependencyInjection.Extensions;
using BollyAPI.Implementation;
using BollyAPI.Interfaces;
using BollyAPI.Middleware;
using Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BollyAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DiagnosticOptions>(Configuration.GetSection("Diagnostic"));
            services.Configure<MockUsers>(Configuration.GetSection("MockUsers"));
            services.AddMasterClassSwagger();
            //services.ConfigureMock(Configuration);

            services.AddRepository();
            services.AddBusiness();
            services.AddService();
            services.AddControllers();
            //services.AddScoped<IApplicationRequestContext, ApplicationRequestContext>();
            services.AddSingleton<IApplicationRequestContext, ApplicationRequestContext>();
            //services.AddTransient<IApplicationRequestContext, ApplicationRequestContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<TrackMachineMiddleware>();
            app.UseMiddleware<TrackRequestContextMiddleware>();
            app.UseMasterClassSwaggerUI();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
