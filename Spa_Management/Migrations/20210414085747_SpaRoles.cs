using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Spa_Management.Migrations
{
    public partial class SpaRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "spaRolesId",
                table: "SpaUsers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "spaRolesId1",
                table: "SpaUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpaRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    SpaDetailsId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaRoles_SpaDetails_SpaDetailsId",
                        column: x => x.SpaDetailsId,
                        principalTable: "SpaDetails",
                        principalColumn: "spaGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpaUsers_spaRolesId1",
                table: "SpaUsers",
                column: "spaRolesId1");

            migrationBuilder.CreateIndex(
                name: "IX_SpaRoles_SpaDetailsId",
                table: "SpaRoles",
                column: "SpaDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaUsers_SpaRoles_spaRolesId1",
                table: "SpaUsers",
                column: "spaRolesId1",
                principalTable: "SpaRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaUsers_SpaRoles_spaRolesId1",
                table: "SpaUsers");

            migrationBuilder.DropTable(
                name: "SpaRoles");

            migrationBuilder.DropIndex(
                name: "IX_SpaUsers_spaRolesId1",
                table: "SpaUsers");

            migrationBuilder.DropColumn(
                name: "spaRolesId",
                table: "SpaUsers");

            migrationBuilder.DropColumn(
                name: "spaRolesId1",
                table: "SpaUsers");
        }
    }
}
