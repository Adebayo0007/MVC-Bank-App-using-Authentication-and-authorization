using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_MobileBankApp.Migrations
{
    public partial class changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identity",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "Identity",
                table: "Admins",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
