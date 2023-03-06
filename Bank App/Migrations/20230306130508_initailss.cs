using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_MobileBankApp.Migrations
{
    public partial class initailss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CEOs",
                keyColumn: "CEOId",
                keyValue: "ZENITH-CEO-100",
                column: "DateCreated",
                value: new DateTime(2023, 3, 6, 14, 5, 8, 62, DateTimeKind.Local).AddTicks(5794));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CEOs",
                keyColumn: "CEOId",
                keyValue: "ZENITH-CEO-100",
                column: "DateCreated",
                value: new DateTime(2023, 3, 6, 13, 59, 56, 701, DateTimeKind.Local).AddTicks(705));
        }
    }
}
