using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Photoportfolio.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Photo",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Album",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Album_UserId",
                table: "Album",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_User_UserId",
                table: "Album",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_User_UserId",
                table: "Album");

            migrationBuilder.DropIndex(
                name: "IX_Album_UserId",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Album");
        }
    }
}
