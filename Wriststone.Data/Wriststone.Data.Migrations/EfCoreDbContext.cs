using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Data.Migrations
{
    public class EfCoreDbContext : DbContext
    {
        public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options)
        {

        }

        public EfCoreDbContext()
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<PermissionMapping> PermissionMappings { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<AccessLevel> AccessLevels { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
      
    }
}
