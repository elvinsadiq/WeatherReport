using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addcolortofavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginFailureTracker_AppUsers_AppUserId",
                table: "LoginFailureTracker");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BlockLoginExpireTime",
                table: "LoginFailureTracker",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "LoginFailureTracker",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ColorId",
                table: "Favorites",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Colors_ColorId",
                table: "Favorites",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginFailureTracker_AppUsers_AppUserId",
                table: "LoginFailureTracker",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Colors_ColorId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginFailureTracker_AppUsers_AppUserId",
                table: "LoginFailureTracker");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_ColorId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Favorites");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BlockLoginExpireTime",
                table: "LoginFailureTracker",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "LoginFailureTracker",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginFailureTracker_AppUsers_AppUserId",
                table: "LoginFailureTracker",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }
    }
}
