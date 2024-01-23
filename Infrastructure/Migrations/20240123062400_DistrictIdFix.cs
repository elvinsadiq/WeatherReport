using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class DistrictIdFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherReport_Districts_DistrictId1",
                table: "WeatherReport");

            migrationBuilder.DropIndex(
                name: "IX_WeatherReport_DistrictId1",
                table: "WeatherReport");

            migrationBuilder.DropColumn(
                name: "DistrictId1",
                table: "WeatherReport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId1",
                table: "WeatherReport",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherReport_DistrictId1",
                table: "WeatherReport",
                column: "DistrictId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherReport_Districts_DistrictId1",
                table: "WeatherReport",
                column: "DistrictId1",
                principalTable: "Districts",
                principalColumn: "Id");
        }
    }
}
