using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_MobileBankApp.Migrations
{
    public partial class pixMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Managers",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Customers",
                type: "longblob",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Customers");
        }
    }
}
