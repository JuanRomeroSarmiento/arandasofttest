using System;
using ArandaSoft.Identity.DataBase.Seed;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArandaSoft.Identity.DataBase.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bnl");

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "bnl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "bnl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolPermission",
                schema: "bnl",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermission", x => new { x.RolId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "bnl",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPermission_Rol_RolId",
                        column: x => x.RolId,
                        principalSchema: "bnl",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "bnl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Rol_RolId",
                        column: x => x.RolId,
                        principalSchema: "bnl",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolPermission_PermissionId",
                schema: "bnl",
                table: "RolPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RolId",
                schema: "bnl",
                table: "User",
                column: "RolId");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolPermission",
                schema: "bnl");

            migrationBuilder.DropTable(
                name: "User",
                schema: "bnl");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "bnl");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "bnl");
        }
    }
}
