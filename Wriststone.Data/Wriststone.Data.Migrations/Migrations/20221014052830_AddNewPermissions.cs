using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Data.Migrations.Migrations
{
    public partial class AddNewPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dbContextFactory = new EfCoreDbContextFactory();
            var context = dbContextFactory.CreateDbContext(null);
            context.SaveChanges();

            var permissionMappings = new List<PermissionMapping>
            {
                new PermissionMapping
                {
                    Permission = Permission.Users,
                    UserGroup = UserGroup.User,
                    AccessLevel = AccessLevel.NoAccess
                },
                new PermissionMapping
                {
                    Permission = Permission.Users,
                    UserGroup = UserGroup.Moderator,
                    AccessLevel = AccessLevel.NoAccess
                }
            };
            context.AddRange(permissionMappings);
            context.SaveChanges();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
