using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversityApi.Migrations
{
    public partial class AddIsDeletedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                schema: "dbo",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                schema: "dbo",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                schema: "dbo",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                schema: "dbo",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                schema: "dbo",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                schema: "dbo",
                table: "Course");
        }
    }
}
