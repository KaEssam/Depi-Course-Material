using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Day2.Migrations
{
    /// <inheritdoc />
    public partial class addAddressProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Departments");
        }
    }
}
