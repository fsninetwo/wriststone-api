using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Wriststone.Common.Domain.Enums;
using Wriststone.Data.Entities.Entities;

namespace Wriststone.Data.Migrations.Migrations
{
    public partial class AddUserPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dbContextFactory = new EfCoreDbContextFactory();
            var context = dbContextFactory.CreateDbContext(null);

            var permissions = new List<Permission>
            {
                new Permission { Name = "User" }
            };

            context.AddRange(permissions);

            context.SaveChanges();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
