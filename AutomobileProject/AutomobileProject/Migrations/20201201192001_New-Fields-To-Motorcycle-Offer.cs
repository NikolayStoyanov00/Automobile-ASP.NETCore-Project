using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomobileProject.Migrations
{
    public partial class NewFieldsToMotorcycleOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CubicCentimers",
                table: "MotorcycleOffers");

            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "MotorcycleOffers");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MotorcycleOffers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Condition",
                table: "MotorcycleOffers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "MotorcycleOffers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CubicCentimeters",
                table: "MotorcycleOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuelType",
                table: "MotorcycleOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gearbox",
                table: "MotorcycleOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "OfferImage",
                table: "MotorcycleOffers",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MotorcycleOffers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SteeringWheelSide",
                table: "CarOffers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Gearbox",
                table: "CarOffers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FuelType",
                table: "CarOffers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Condition",
                table: "CarOffers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_MotorcycleOffers_UserId",
                table: "MotorcycleOffers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotorcycleOffers_AspNetUsers_UserId",
                table: "MotorcycleOffers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotorcycleOffers_AspNetUsers_UserId",
                table: "MotorcycleOffers");

            migrationBuilder.DropIndex(
                name: "IX_MotorcycleOffers_UserId",
                table: "MotorcycleOffers");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "MotorcycleOffers");

            migrationBuilder.DropColumn(
                name: "CubicCentimeters",
                table: "MotorcycleOffers");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "MotorcycleOffers");

            migrationBuilder.DropColumn(
                name: "Gearbox",
                table: "MotorcycleOffers");

            migrationBuilder.DropColumn(
                name: "OfferImage",
                table: "MotorcycleOffers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MotorcycleOffers");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MotorcycleOffers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "MotorcycleOffers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CubicCentimers",
                table: "MotorcycleOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageFile",
                table: "MotorcycleOffers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AlterColumn<string>(
                name: "SteeringWheelSide",
                table: "CarOffers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Gearbox",
                table: "CarOffers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FuelType",
                table: "CarOffers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "CarOffers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
