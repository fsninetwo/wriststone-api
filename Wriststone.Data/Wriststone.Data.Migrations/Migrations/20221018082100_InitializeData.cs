using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Data.Migrations.Migrations
{
    public partial class InitializeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dbContextFactory = new EfCoreDbContextFactory();
            var context = dbContextFactory.CreateDbContext(null);

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
            context.AddRange(userRoles);

            context.SaveChanges();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
