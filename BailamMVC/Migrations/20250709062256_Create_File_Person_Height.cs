using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BailamMVC.Migrations
{
    /// <inheritdoc />
    public partial class Create_File_Person_Height : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Persons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Employee",
                type: "TEXT",
                nullable: true);
        }
    }
}
