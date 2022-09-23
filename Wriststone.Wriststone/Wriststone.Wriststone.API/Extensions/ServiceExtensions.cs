using System;
using AutoMapper;
using EFCore.App.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Wriststone.Data.Migrations;
using Wriststone.Data.Migrations.Configuration;
using Wriststone.Wriststone.Data.IRepositories;
using Wriststone.Wriststone.Data.Repositories;
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
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRatingService, RatingService>();
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Wriststone.Wriststone.API", Version = "v1"});
            });
        }

        public static void AddAutoMapperService(this IServiceCollection services)
        {
            var autoMapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMappers()); 
            });

            var mapper = autoMapper.CreateMapper();

            services.AddSingleton(mapper);
        }

        public static void AddDatabaseConfiguration(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<EfCoreDbContext>
                (options => options.UseSqlServer(appSettings.ConnectionString, opts =>
                {
                    opts.CommandTimeout(int.MaxValue);
                    opts.EnableRetryOnFailure(
                        10,
                        TimeSpan.FromSeconds(30),
                        null);
                }));
        }
    }
}
