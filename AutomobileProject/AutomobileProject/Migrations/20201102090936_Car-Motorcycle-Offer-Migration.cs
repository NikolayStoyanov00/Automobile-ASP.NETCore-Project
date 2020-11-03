using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomobileProject.Migrations
{
    public partial class CarMotorcycleOfferMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    HorsePower = table.Column<int>(nullable: false),
                    Kilometers = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ImageFile = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOffers", x => x.Id);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
