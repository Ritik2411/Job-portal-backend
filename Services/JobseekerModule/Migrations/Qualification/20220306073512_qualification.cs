using Microsoft.EntityFrameworkCore.Migrations;

namespace JobseekerModule.Migrations.Qualification
{
    public partial class qualification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "qualifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    university = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yearOfCompletion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qualifications", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "qualifications");
        }
    }
}
