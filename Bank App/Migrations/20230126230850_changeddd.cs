using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_MobileBankApp.Migrations
{
    public partial class changeddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerPass",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerPass",
                table: "Admins");
        }
    }
}
