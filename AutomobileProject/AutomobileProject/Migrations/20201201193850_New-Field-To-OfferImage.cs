using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomobileProject.Migrations
{
    public partial class NewFieldToOfferImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferImages_CarOffers_CarOfferId",
                table: "OfferImages");

            migrationBuilder.AlterColumn<int>(
                name: "CarOfferId",
                table: "OfferImages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MotorcycleOfferId",
                table: "OfferImages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferImages_MotorcycleOfferId",
                table: "OfferImages",
                column: "MotorcycleOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferImages_CarOffers_CarOfferId",
                table: "OfferImages",
                column: "CarOfferId",
                principalTable: "CarOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferImages_MotorcycleOffers_MotorcycleOfferId",
                table: "OfferImages",
                column: "MotorcycleOfferId",
                principalTable: "MotorcycleOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferImages_CarOffers_CarOfferId",
                table: "OfferImages");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferImages_MotorcycleOffers_MotorcycleOfferId",
                table: "OfferImages");

            migrationBuilder.DropIndex(
                name: "IX_OfferImages_MotorcycleOfferId",
                table: "OfferImages");

            migrationBuilder.DropColumn(
                name: "MotorcycleOfferId",
                table: "OfferImages");

            migrationBuilder.AlterColumn<int>(
                name: "CarOfferId",
                table: "OfferImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferImages_CarOffers_CarOfferId",
                table: "OfferImages",
                column: "CarOfferId",
                principalTable: "CarOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
