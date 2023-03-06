using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_MobileBankApp.Migrations
{
    public partial class seventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "PassWord", "Role" },
                values: new object[] { 1, "ceo3@gmail.com", true, "Ceo0004", "CEO" });

            migrationBuilder.InsertData(
                table: "CEOs",
                columns: new[] { "CEOId", "Address", "Age", "DateCreated", "DateModified", "Email", "FirstName", "Gender", "IsActive", "LastName", "MaritalStatus", "PhoneNumber", "ProfilePicture", "UserId" },
                values: new object[] { "ZENITH-CEO-100", "10,Abayomi street", 22, new DateTime(2023, 3, 6, 13, 54, 32, 27, DateTimeKind.Local).AddTicks(1550), null, "ceo3@gmail.com", "uthman", 1, true, "Tijani", 2, "+2348087054632", null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CEOs",
                keyColumn: "CEOId",
                keyValue: "ZENITH-CEO-100");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
