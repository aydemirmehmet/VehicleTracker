using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleTrackerApi.Migrations
{
    public partial class IsEnterPlaceproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFirstEnter",
                table: "Reports",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstEnter",
                table: "Reports");
        }
    }
}
