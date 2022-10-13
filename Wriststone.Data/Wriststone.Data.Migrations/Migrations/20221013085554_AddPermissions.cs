using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Data.Migrations.Migrations
{
    public partial class AddPermissions : Migration
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
                    UserGroup = UserGroup.Administrator,
                    AccessLevel = AccessLevel.Write
                },
            };
            context.AddRange(permissionMappings);
            context.SaveChanges();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
