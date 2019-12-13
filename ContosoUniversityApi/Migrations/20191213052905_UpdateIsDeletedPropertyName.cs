using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversityApi.Migrations
{
    public partial class UpdateIsDeletedPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                schema: "dbo",
                table: "Person",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                schema: "dbo",
                table: "Department",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                schema: "dbo",
                table: "Course",
                newName: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Person",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Department",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Course",
                newName: "isDeleted");
        }
    }
}
