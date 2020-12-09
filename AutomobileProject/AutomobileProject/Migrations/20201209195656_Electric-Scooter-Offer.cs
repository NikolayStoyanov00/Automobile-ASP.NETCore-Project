using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomobileProject.Migrations
{
    public partial class ElectricScooterOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElectricScooterOfferId",
                table: "OfferImages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ElectricScooterOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Year = table.Column<int>(nullable: true),
                    Condition = table.Column<int>(nullable: false),
                    MotorPower = table.Column<int>(nullable: false),
                    TravellingDistance = table.Column<int>(nullable: false),
                    MaxSpeedAchievable = table.Column<int>(nullable: false),
                    MaxWeight = table.Column<int>(nullable: false),
                    WaterproofLevel = table.Column<int>(nullable: false),
                    Kilometers = table.Column<int>(nullable: false),
                    ScooterSize = table.Column<string>(nullable: false),
                    TiresSize = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    OfferImage = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricScooterOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricScooterOffers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectricScooters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricScooters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferImages_ElectricScooterOfferId",
                table: "OfferImages",
                column: "ElectricScooterOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricScooterOffers_UserId",
                table: "ElectricScooterOffers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferImages_ElectricScooters_ElectricScooterOfferId",
                table: "OfferImages",
                column: "ElectricScooterOfferId",
                principalTable: "ElectricScooters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferImages_ElectricScooters_ElectricScooterOfferId",
                table: "OfferImages");

            migrationBuilder.DropTable(
                name: "ElectricScooterOffers");

            migrationBuilder.DropTable(
                name: "ElectricScooters");

            migrationBuilder.DropIndex(
                name: "IX_OfferImages_ElectricScooterOfferId",
                table: "OfferImages");

            migrationBuilder.DropColumn(
                name: "ElectricScooterOfferId",
                table: "OfferImages");
        }
    }
}
