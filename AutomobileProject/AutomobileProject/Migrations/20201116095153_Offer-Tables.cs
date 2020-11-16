using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomobileProject.Migrations
{
    public partial class OfferTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MotorcycleOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Condition = table.Column<string>(nullable: false),
                    HorsePower = table.Column<int>(nullable: false),
                    CubicCentimers = table.Column<int>(nullable: false),
                    Kilometers = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ImageFile = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcycleOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Condition = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    FuelType = table.Column<string>(nullable: false),
                    HorsePower = table.Column<int>(nullable: false),
                    EngineSize = table.Column<int>(nullable: false),
                    Gearbox = table.Column<string>(nullable: false),
                    Doors = table.Column<string>(nullable: false),
                    Kilometers = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    OfferImage = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOffers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferImages",
                columns: table => new
                {
                    ImageId = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    CarOfferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_OfferImages_CarOffers_CarOfferId",
                        column: x => x.CarOfferId,
                        principalTable: "CarOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarOffers_UserId",
                table: "CarOffers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferImages_CarOfferId",
                table: "OfferImages",
                column: "CarOfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotorcycleOffers");

            migrationBuilder.DropTable(
                name: "OfferImages");

            migrationBuilder.DropTable(
                name: "CarOffers");
        }
    }
}
