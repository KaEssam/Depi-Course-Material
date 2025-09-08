using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Day2.Migrations
{
    /// <inheritdoc />
    public partial class empmanageDept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Managerssn",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Managerssn",
                table: "Departments",
                column: "Managerssn");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_Managerssn",
                table: "Departments",
                column: "Managerssn",
                principalTable: "Employees",
                principalColumn: "ssn");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_Managerssn",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Managerssn",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Managerssn",
                table: "Departments");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
