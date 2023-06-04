using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPOS_API.Utilities;

namespace EPOS_API
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

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseCors(builder =>
            //builder.WithOrigins("http://localhost", "http://localhost:3000", "http://124.29.235.77:8082", "http://124.29.235.77", "http://192.168.61.111:8082", "http://192.168.61.111",
            //"http://124.29.235.78:8082", "http://124.29.235.78", "http://192.168.61.112:8082", "http://192.168.61.112", "http://124.29.235.77:8010", "http://124.29.235.77",
            //"http://192.168.61.111:8010", "https://localhost:44351", "https://localhost:8082", "http://00.00.00.00")
            //.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader().AllowAnyMethod());

            app.UseCors(builder =>
            builder.WithOrigins(

                "http://localhost",
                "http://localhost:3000",
                "https://localhost:8082",
                "https://localhost:44351",

                "http://00.00.00.00",

                "http://192.168.61.111",
                "http://192.168.61.111:8082",
                "http://192.168.61.111:8010",

                "http://124.29.235.77",

                "http://124.29.235.77:8082",
                "http://124.29.235.77:8010",

                "http://192.168.61.112",
                "http://192.168.61.112:8082",

                "http://124.29.235.78",
                "http://124.29.235.78:8082"
              )
            .AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader().AllowAnyMethod());

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseTokenValidatorMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
