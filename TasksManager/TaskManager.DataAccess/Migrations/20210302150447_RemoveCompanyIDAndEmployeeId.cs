using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.DataAccess.Migrations
{
    public partial class RemoveCompanyIDAndEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Boards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Managers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Boards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
