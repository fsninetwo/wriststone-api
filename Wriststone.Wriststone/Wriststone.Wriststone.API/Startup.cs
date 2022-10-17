using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Wriststone.Data.Migrations;
using Wriststone.Wriststone.API.Extensions;
using Wriststone.Data.Migrations.Configuration;

namespace Wriststone.Wriststone.API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddLogging();
            services.AddSwaggerService();
            services.AddJwtAuthentication(Configuration);
            services.AddAutoMapperService();
            services.AddDatabaseConfiguration(Configuration);
            services.AddDependencyInjectionServices();
            services.AddCorsService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(env);

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseSwaggerService();
            app.UseRouting();

            app.UseJwtAuthorization();
            app.UsePermissions();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
