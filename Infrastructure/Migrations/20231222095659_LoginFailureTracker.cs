using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class LoginFailureTracker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginFailureTrackerId",
                table: "AppUsers",
                type: "int",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoginFailureTracker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginTryCount = table.Column<int>(type: "int", nullable: false),
                    BlockLoginExpireTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginFailureTracker", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_LoginFailureTrackerId",
                table: "AppUsers",
                column: "LoginFailureTrackerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_LoginFailureTracker_LoginFailureTrackerId",
                table: "AppUsers",
                column: "LoginFailureTrackerId",
                principalTable: "LoginFailureTracker",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_LoginFailureTracker_LoginFailureTrackerId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "LoginFailureTracker");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_LoginFailureTrackerId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "LoginFailureTrackerId",
                table: "AppUsers");
        }
    }
}
