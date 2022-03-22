using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeModule.Migrations.VacancyRequests
{
    public partial class VacancyRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vacancyRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacancy_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    applied_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    awaiting_approval = table.Column<bool>(type: "bit", nullable: false),
                    approved = table.Column<bool>(type: "bit", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacancyRequests", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vacancyRequests");
        }
    }
}
