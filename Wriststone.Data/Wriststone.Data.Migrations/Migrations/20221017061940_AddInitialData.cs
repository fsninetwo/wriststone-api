using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Data.Migrations.Migrations
{
    public partial class AddInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dbContextFactory = new EfCoreDbContextFactory();
            var context = dbContextFactory.CreateDbContext(null);
            context.SaveChanges();

            var permissions = new List<Permission>
            {
                new Permission { Name = "User Management" },
            };

            context.AddRange(permissions);

            var accessLevels = new List<AccessLevel>
            {
                new AccessLevel { Name = "Read" },
                new AccessLevel { Name = "Write" },
                new AccessLevel { Name = "No Access" }
            };
            context.AddRange(accessLevels);

            var userRoles = new List<UserRole>
            {
                new UserRole { Name = "Administrator" },
                new UserRole { Name = "User" },
            };
            context.AddRange(permissions);

            var permissionMappings = new List<PermissionMapping>
            {
                new PermissionMapping
                {
                    UserRole = userRoles[0],
                    Permission = permissions[0],
                    AccessLevel = accessLevels[1]
                },
                new PermissionMapping
                {
                    UserRole = userRoles[1],
                    Permission = permissions[0],
                    AccessLevel = accessLevels[2]
                }
            };
            context.AddRange(permissionMappings);

            var users = new List<User>
            {
                new User
                {
                    Login = "admin",
                    Email = "admin@admin.net",
                    Password = "12345678",
                    Created = DateTime.Now,
                    UserRole = userRoles[0],
                }
            };
            context.AddRange(users);

            context.SaveChanges();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
