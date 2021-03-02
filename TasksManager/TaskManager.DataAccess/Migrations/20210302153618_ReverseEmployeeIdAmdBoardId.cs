using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.DataAccess.Migrations
{
    public partial class ReverseEmployeeIdAmdBoardId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Boards_BoardId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BoardId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Boards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Boards_EmployeeId",
                table: "Boards",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Employees_EmployeeId",
                table: "Boards",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Employees_EmployeeId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_EmployeeId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Boards");

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BoardId",
                table: "Employees",
                column: "BoardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Boards_BoardId",
                table: "Employees",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
