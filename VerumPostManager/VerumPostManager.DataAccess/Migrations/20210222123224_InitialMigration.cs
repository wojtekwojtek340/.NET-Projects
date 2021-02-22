using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VerumPostManager.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receiveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    RecipientId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receiveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receiveds_Customers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receiveds_Customers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receiveds_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ConfirmationOfSending = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    RecipientId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sents_Customers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sents_Customers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sents_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receiveds_EmployeeId",
                table: "Receiveds",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiveds_RecipientId",
                table: "Receiveds",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiveds_SenderId",
                table: "Receiveds",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Sents_EmployeeId",
                table: "Sents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sents_RecipientId",
                table: "Sents",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sents_SenderId",
                table: "Sents",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receiveds");

            migrationBuilder.DropTable(
                name: "Sents");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
