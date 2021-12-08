using Microsoft.EntityFrameworkCore.Migrations;

namespace CHA.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlans_Airports_DestinationAirportId",
                table: "FlightPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlans_Airports_OriginAirportId",
                table: "FlightPlans");

            migrationBuilder.DropIndex(
                name: "IX_FlightPlans_DestinationAirportId",
                table: "FlightPlans");

            migrationBuilder.DropIndex(
                name: "IX_FlightPlans_OriginAirportId",
                table: "FlightPlans");

            migrationBuilder.DropColumn(
                name: "DestinationAirportId",
                table: "FlightPlans");

            migrationBuilder.DropColumn(
                name: "OriginAirportId",
                table: "FlightPlans");

            migrationBuilder.AddColumn<int>(
                name: "DestinationID",
                table: "FlightPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginID",
                table: "FlightPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlans_DestinationID",
                table: "FlightPlans",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlans_OriginID",
                table: "FlightPlans",
                column: "OriginID");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPlans_Airports_DestinationID",
                table: "FlightPlans",
                column: "DestinationID",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPlans_Airports_OriginID",
                table: "FlightPlans",
                column: "OriginID",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlans_Airports_DestinationID",
                table: "FlightPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlans_Airports_OriginID",
                table: "FlightPlans");

            migrationBuilder.DropIndex(
                name: "IX_FlightPlans_DestinationID",
                table: "FlightPlans");

            migrationBuilder.DropIndex(
                name: "IX_FlightPlans_OriginID",
                table: "FlightPlans");

            migrationBuilder.DropColumn(
                name: "DestinationID",
                table: "FlightPlans");

            migrationBuilder.DropColumn(
                name: "OriginID",
                table: "FlightPlans");

            migrationBuilder.AddColumn<int>(
                name: "DestinationAirportId",
                table: "FlightPlans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginAirportId",
                table: "FlightPlans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlans_DestinationAirportId",
                table: "FlightPlans",
                column: "DestinationAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlans_OriginAirportId",
                table: "FlightPlans",
                column: "OriginAirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPlans_Airports_DestinationAirportId",
                table: "FlightPlans",
                column: "DestinationAirportId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPlans_Airports_OriginAirportId",
                table: "FlightPlans",
                column: "OriginAirportId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
