using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_MobileBankApp.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassWord",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "PassWord",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PassWord",
                table: "CEOs");

            migrationBuilder.DropColumn(
                name: "PassWord",
                table: "Admins");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "CEOs",
                type: "longblob",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "CEOs");

            migrationBuilder.AddColumn<string>(
                name: "PassWord",
                table: "Managers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PassWord",
                table: "Customers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PassWord",
                table: "CEOs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PassWord",
                table: "Admins",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
