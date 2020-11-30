using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomobileProject.Migrations
{
    public partial class AddSteeringWheelSideColtoCarOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SteeringWheelSide",
                table: "CarOffers",
                nullable: false,
                defaultValue: "");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SteeringWheelSide",
                table: "CarOffers");
        }
    }
}
