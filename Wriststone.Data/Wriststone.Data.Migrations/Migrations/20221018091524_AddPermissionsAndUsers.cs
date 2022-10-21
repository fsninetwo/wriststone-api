using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Data.Migrations.Migrations
{
    public partial class AddPermissionsAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dbContextFactory = new EfCoreDbContextFactory();
            var context = dbContextFactory.CreateDbContext(null);

            var permissionMappings = new List<PermissionMapping>
            {
                new PermissionMapping
                {
                    UserRoleId = (long)UserRoleEnum.Administrator,
                    PermissionId = (long)PermissionEnum.UsersManagement,
                    AccessLevelId = (long)AccessLevelEnum.Write
                },
                new PermissionMapping
                {
                    UserRoleId = (long)UserRoleEnum.User,
                    PermissionId = (long)PermissionEnum.UsersManagement,
                    AccessLevelId = (long)AccessLevelEnum.NoAccess
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
                    UserRoleId = (long)UserRoleEnum.Administrator,
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
