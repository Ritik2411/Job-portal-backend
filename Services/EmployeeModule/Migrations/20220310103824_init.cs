using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeModule.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfEmployee = table.Column<int>(type: "int", nullable: false),
                    StartYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    about = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");
        }
    }
}
