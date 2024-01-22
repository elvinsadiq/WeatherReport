using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedUserIdToLoginFailure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_LoginFailureTracker_LoginFailureTrackerId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_LoginFailureTrackerId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "LoginFailureTrackerId",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "LoginFailureTracker",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoginFailureTracker_AppUserId",
                table: "LoginFailureTracker",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginFailureTracker_AppUsers_AppUserId",
                table: "LoginFailureTracker",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginFailureTracker_AppUsers_AppUserId",
                table: "LoginFailureTracker");

            migrationBuilder.DropIndex(
                name: "IX_LoginFailureTracker_AppUserId",
                table: "LoginFailureTracker");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "LoginFailureTracker");

            migrationBuilder.AddColumn<int>(
                name: "LoginFailureTrackerId",
                table: "AppUsers",
                type: "int",
                maxLength: 50,
                nullable: true);

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
    }
}
