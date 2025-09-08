using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Day2.Migrations
{
    /// <inheritdoc />
    public partial class deptWithProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentProject",
                columns: table => new
                {
                    Departmentsid = table.Column<int>(type: "int", nullable: false),
                    ProjectSsN = table.Column<byte>(type: "tinyint", nullable: false),
                    ProjectsName = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentProject", x => new { x.Departmentsid, x.ProjectSsN, x.ProjectsName });
                    table.ForeignKey(
                        name: "FK_DepartmentProject_Departments_Departmentsid",
                        column: x => x.Departmentsid,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentProject_Projects_ProjectSsN_ProjectsName",
                        columns: x => new { x.ProjectSsN, x.ProjectsName },
                        principalSchema: "Prod",
                        principalTable: "Projects",
                        principalColumns: new[] { "ProductId", "ProjectN" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentProject_ProjectSsN_ProjectsName",
                table: "DepartmentProject",
                columns: new[] { "ProjectSsN", "ProjectsName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentProject");
        }
    }
}
