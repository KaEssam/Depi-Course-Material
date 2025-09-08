using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Day2.Migrations
{
    /// <inheritdoc />
    public partial class upadeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Prod");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Employees",
                newName: "ssn");

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "Prod",
                columns: table => new
                {
                    ProductId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => new { x.ProductId, x.ProjectN });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects",
                schema: "Prod");

            migrationBuilder.RenameColumn(
                name: "ssn",
                table: "Employees",
                newName: "id");
        }
    }
}
