using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamiliaControl.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Login = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Create = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastUserUpdate = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Create", "Email", "LastUpdate", "LastUserUpdate", "Login", "Password" },
                values: new object[] { new Guid("296eda1b-e034-4ca2-a6fa-cf8750333cfd"), true, new DateTime(2022, 2, 5, 2, 29, 33, 201, DateTimeKind.Local).AddTicks(8511), "admin@admin.com.br", null, null, "admin", "VIC1w0W0KioIAWVdSknoeQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
