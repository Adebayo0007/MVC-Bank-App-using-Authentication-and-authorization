﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_MobileBankApp.Migrations
{
    public partial class eighthMigrationd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "PassWord", "Role" },
                values: new object[] { 99, "ceo93@gmail.com", true, "Ceo0004", "CEO" });

            migrationBuilder.UpdateData(
                table: "CEOs",
                keyColumn: "CEOId",
                keyValue: "ZENITH-CEO-100",
                columns: new[] { "DateCreated", "Email", "UserId" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 59, 56, 701, DateTimeKind.Local).AddTicks(705), "ceo93@gmail.com", 99 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "PassWord", "Role" },
                values: new object[] { 2, "ceo3@gmail.com", true, "Ceo0004", "CEO" });

            migrationBuilder.UpdateData(
                table: "CEOs",
                keyColumn: "CEOId",
                keyValue: "ZENITH-CEO-100",
                columns: new[] { "DateCreated", "Email", "UserId" },
                values: new object[] { new DateTime(2023, 3, 6, 13, 55, 39, 496, DateTimeKind.Local).AddTicks(8861), "ceo3@gmail.com", 2 });
        }
    }
}
