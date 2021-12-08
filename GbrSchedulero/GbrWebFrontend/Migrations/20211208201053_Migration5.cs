using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace CHA.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_Stations_StationID",
                table: "Qualifications");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_StationID",
                table: "Qualifications");

            migrationBuilder.AddColumn<int>(
                name: "Station",
                table: "Qualifications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Station",
                table: "Qualifications");

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    CrewStationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CrewStationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.CrewStationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_StationID",
                table: "Qualifications",
                column: "StationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_Stations_StationID",
                table: "Qualifications",
                column: "StationID",
                principalTable: "Stations",
                principalColumn: "CrewStationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
