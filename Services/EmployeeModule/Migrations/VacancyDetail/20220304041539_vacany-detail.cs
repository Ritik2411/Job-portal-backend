using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeModule.Migrations.VacancyDetail
{
    public partial class vacanydetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vacancies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    No_of_Vacancies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Minimum_qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Min_Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Max_Salary = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
