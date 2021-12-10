using Microsoft.EntityFrameworkCore.Migrations;

namespace CHA.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Stations",
                table: "AircraftTypes",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stations",
                table: "AircraftTypes");
        }
    }
}
