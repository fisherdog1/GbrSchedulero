using Microsoft.EntityFrameworkCore.Migrations;

namespace CHA.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeOrders_Assignments_CurrentOrderID",
                table: "ChangeOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeOrders_Assignments_PreviousOrderID",
                table: "ChangeOrders");

            migrationBuilder.RenameColumn(
                name: "PreviousOrderID",
                table: "ChangeOrders",
                newName: "PreviousAssignmentID");

            migrationBuilder.RenameColumn(
                name: "CurrentOrderID",
                table: "ChangeOrders",
                newName: "CurrentAssignmentID");

            migrationBuilder.RenameIndex(
                name: "IX_ChangeOrders_PreviousOrderID",
                table: "ChangeOrders",
                newName: "IX_ChangeOrders_PreviousAssignmentID");

            migrationBuilder.RenameIndex(
                name: "IX_ChangeOrders_CurrentOrderID",
                table: "ChangeOrders",
                newName: "IX_ChangeOrders_CurrentAssignmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeOrders_Assignments_CurrentAssignmentID",
                table: "ChangeOrders",
                column: "CurrentAssignmentID",
                principalTable: "Assignments",
                principalColumn: "FlightCrewAssignmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeOrders_Assignments_PreviousAssignmentID",
                table: "ChangeOrders",
                column: "PreviousAssignmentID",
                principalTable: "Assignments",
                principalColumn: "FlightCrewAssignmentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeOrders_Assignments_CurrentAssignmentID",
                table: "ChangeOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeOrders_Assignments_PreviousAssignmentID",
                table: "ChangeOrders");

            migrationBuilder.RenameColumn(
                name: "PreviousAssignmentID",
                table: "ChangeOrders",
                newName: "PreviousOrderID");

            migrationBuilder.RenameColumn(
                name: "CurrentAssignmentID",
                table: "ChangeOrders",
                newName: "CurrentOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_ChangeOrders_PreviousAssignmentID",
                table: "ChangeOrders",
                newName: "IX_ChangeOrders_PreviousOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_ChangeOrders_CurrentAssignmentID",
                table: "ChangeOrders",
                newName: "IX_ChangeOrders_CurrentOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeOrders_Assignments_CurrentOrderID",
                table: "ChangeOrders",
                column: "CurrentOrderID",
                principalTable: "Assignments",
                principalColumn: "FlightCrewAssignmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeOrders_Assignments_PreviousOrderID",
                table: "ChangeOrders",
                column: "PreviousOrderID",
                principalTable: "Assignments",
                principalColumn: "FlightCrewAssignmentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
