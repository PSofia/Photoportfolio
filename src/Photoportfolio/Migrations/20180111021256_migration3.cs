using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Photoportfolio.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_User_UserId",
                table: "Album");

            migrationBuilder.AlterColumn<float>(
                name: "Mark",
                table: "UserFeedback",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_User_UserId",
                table: "Album",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_User_UserId",
                table: "Album");

            migrationBuilder.AlterColumn<int>(
                name: "Mark",
                table: "UserFeedback",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_User_UserId",
                table: "Album",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
