using Microsoft.EntityFrameworkCore.Migrations;

namespace CHA.Migrations.DbLogin
{
    public partial class Signup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "loginDatas",
                type: "text",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "loginDatas",
                type: "text",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "loginDatas");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "loginDatas");
        }
    }
}
