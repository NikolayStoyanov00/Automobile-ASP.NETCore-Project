using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomobileProject.Migrations
{
    public partial class AddTownsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    ManufacturingDate = table.Column<DateTime>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    FuelType = table.Column<int>(nullable: false),
                    TransmissionType = table.Column<int>(nullable: false),
                    HorsePower = table.Column<int>(nullable: false),
                    Doors = table.Column<int>(nullable: false),
                    EngineName = table.Column<string>(nullable: true),
                    CoupeType = table.Column<int>(nullable: false),
                    SteeringWheelSide = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    MotorcycleType = table.Column<int>(nullable: false),
                    ManufacturingDate = table.Column<DateTime>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    FuelType = table.Column<int>(nullable: false),
                    HorsePower = table.Column<int>(nullable: false),
                    Doors = table.Column<int>(nullable: false),
                    EngineName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Motorcycles");
        }
    }
}
