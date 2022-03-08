using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeModule.Migrations.VacancyDetail
{
    public partial class vacancyModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vacancies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    No_of_Vacancies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minimum_qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Min_Salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Max_Salary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacancies", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vacancies");
        }
    }
}
