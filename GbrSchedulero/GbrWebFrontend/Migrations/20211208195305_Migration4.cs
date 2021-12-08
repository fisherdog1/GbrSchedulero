using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace CHA.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    CrewQualificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AicraftTypeID = table.Column<int>(type: "int", nullable: false),
                    StationID = table.Column<int>(type: "int", nullable: false),
                    AcTypeAircraftTypeID = table.Column<int>(type: "int", nullable: true),
                    CrewmemberID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.CrewQualificationID);
                    table.ForeignKey(
                        name: "FK_Qualifications_AircraftTypes_AcTypeAircraftTypeID",
                        column: x => x.AcTypeAircraftTypeID,
                        principalTable: "AircraftTypes",
                        principalColumn: "AircraftTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Qualifications_Crewmembers_CrewmemberID",
                        column: x => x.CrewmemberID,
                        principalTable: "Crewmembers",
                        principalColumn: "CrewmemberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Qualifications_Stations_StationID",
                        column: x => x.StationID,
                        principalTable: "Stations",
                        principalColumn: "CrewStationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_AcTypeAircraftTypeID",
                table: "Qualifications",
                column: "AcTypeAircraftTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_CrewmemberID",
                table: "Qualifications",
                column: "CrewmemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_StationID",
                table: "Qualifications",
                column: "StationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
