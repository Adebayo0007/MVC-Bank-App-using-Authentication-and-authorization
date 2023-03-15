using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_MobileBankApp.Migrations
{
    public partial class fanny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CEOs",
                keyColumn: "CEOId",
                keyValue: "ZENITH-CEO-100",
                column: "DateCreated",
                value: new DateTime(2023, 3, 6, 15, 15, 36, 579, DateTimeKind.Local).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 99,
                column: "PassWord",
                value: "$2b$10$TTLiRlERCsRl3OZR6kSua..OHido.lrlrxcASUyAUD602B3zcUkSG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CEOs",
                keyColumn: "CEOId",
                keyValue: "ZENITH-CEO-100",
                column: "DateCreated",
                value: new DateTime(2023, 3, 6, 14, 25, 17, 416, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 99,
                column: "PassWord",
                value: "Ceo0004");
        }
    }
}
