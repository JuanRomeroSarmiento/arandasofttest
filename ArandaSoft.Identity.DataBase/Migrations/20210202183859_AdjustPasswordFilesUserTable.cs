using System;
using ArandaSoft.Identity.DataBase.Seed;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArandaSoft.Identity.DataBase.Migrations
{
    public partial class AdjustPasswordFilesUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "bnl",
                table: "User");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                schema: "bnl",
                table: "User",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                schema: "bnl",
                table: "User",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            DataInitializer.Seed(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "bnl",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Salt",
                schema: "bnl",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "bnl",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
