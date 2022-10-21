using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Data.Migrations.Migrations
{
    public partial class AddNewMappings : Migration
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
                    PermissionId = (long)PermissionEnum.User,
                    AccessLevelId = (long)AccessLevelEnum.Read
                },
                new PermissionMapping
                {
                    UserRoleId = (long)UserRoleEnum.Administrator,
                    PermissionId = (long)PermissionEnum.User,
                    AccessLevelId = (long)AccessLevelEnum.Write
                },
                new PermissionMapping
                {
                    UserRoleId = (long)UserRoleEnum.User,
                    PermissionId = (long)PermissionEnum.User,
                    AccessLevelId = (long)AccessLevelEnum.Read
                },
                new PermissionMapping
                {
                    UserRoleId = (long)UserRoleEnum.User,
                    PermissionId = (long)PermissionEnum.User,
                    AccessLevelId = (long)AccessLevelEnum.Write
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
