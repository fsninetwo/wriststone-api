using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Wriststone.Data.Migrations;
using Wriststone.Data.Migrations.Configuration;
using Wriststone.Wriststone.API.Helpers;
using Wriststone.Wriststone.API.Mappers;
using Wriststone.Wriststone.API.Middlewares;
using Wriststone.Wriststone.Data.IRepositories;
using Wriststone.Wriststone.Data.Repositories;
using Wriststone.Wriststone.Services.Helpers;
using Wriststone.Wriststone.Services.IServices;
using Wriststone.Wriststone.Services.Services;

namespace Wriststone.Wriststone.API.Extensions
{
    static class ServiceExtensions
    {
        public static void AddDependencyInjectionServices(this IServiceCollection services)
        {
            services.AddSingleton<IAppSettings, AppSettings>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IPermissionsRepository, PermissionsRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPermissionsService, PermissionsService>();
            services.AddScoped<IUserManagementService, UserManagementService>();

            services.AddScoped<ITokenService, TokenService>();

            services.AddSingleton<JwtHelper>();
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "Wriststone.Wriststone.API", Version = "v1"});

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentification",
                    Description = "Enter JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                };

                options.AddSecurityDefinition(securityScheme.Scheme, securityScheme);
                options.AddSecurityRequirement(doc => new OpenApiSecurityRequirement
                    { [new OpenApiSecuritySchemeReference(securityScheme.Scheme, doc)] = [] }
                );
            });
        }

        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("SecretKey").Value);

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                    };
                });
        }

        public static void AddAutoMapperService(this IServiceCollection services)
        {
            var autoMapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMappers()); 
            }, null);

            var mapper = autoMapper.CreateMapper();

            services.AddSingleton(mapper);
        }

        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfCoreDbContext>
                (options => options.UseSqlServer(configuration.GetSection("ConnectionString").Value, opts =>
                {
                    opts.CommandTimeout(int.MaxValue);
                    opts.EnableRetryOnFailure(
                        10, TimeSpan.FromSeconds(30), null);
                }));
        }

        public static void AddCorsService(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", 
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });
        }

        public static void AddMediatrService(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }

        public static void UseSwaggerService(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wriststone.Wriststone.API");
                c.RoutePrefix = string.Empty;
            });
        }


        public static void UseExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }

        public static void UsePermissions(this IApplicationBuilder app)
        {
            app.UseMiddleware<PermissionMiddleware>();
        }

        public static void UseJwtAuthorization(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtPermissionMiddleware>();
        }
    }
}
