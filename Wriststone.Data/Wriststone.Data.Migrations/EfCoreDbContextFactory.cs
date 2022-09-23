using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Wriststone.Data.Migrations.Configuration;

namespace Wriststone.Data.Migrations
{
    class EfCoreDbContextFactory : IDesignTimeDbContextFactory<EfCoreDbContext>
    {
        public EfCoreDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.local.json", optional: true);

            IConfigurationRoot configuration = builder.Build();
            var settings = new AppSettings();
            configuration.Bind(settings);

            var optionsBuilder = new DbContextOptionsBuilder<EfCoreDbContext>();
            optionsBuilder.UseSqlServer(settings.ConnectionString,
                b => b.MigrationsAssembly(typeof(EfCoreDbContext).Assembly.FullName)
            );

            Console.WriteLine("Migration is started");
            return new EfCoreDbContext(optionsBuilder.Options);
        }
    }
}
