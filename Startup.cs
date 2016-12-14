using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Celeste.Data;
using Microsoft.EntityFrameworkCore;

namespace CelesteAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var sqlConnectionString = System.Environment.GetEnvironmentVariable("Celeste_Db_Path");
            services.AddDbContext<CelesteContext>(options =>
                options.UseNpgsql(
                    sqlConnectionString
                )
            );
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", // allowing anyone to request anything in any way.
                    builder => builder
                        .AllowAnyOrigin() //this allows IP addresses/origins of anytime, could read something like ".WithOrigins("194.346.4.5" OR "acme.com")
                        .AllowAnyMethod() //such as get/post/put etc.

                        //CORS can go either in Startup OR on database methods themselves (for specificity)
                        .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("CorsPolicy");

            app.UseMvc();
            DbInitializer.Initialize(app.ApplicationServices);
        }
    }
}
