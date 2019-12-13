using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversityApi.Migrations
{
    public partial class AddDateModifiedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                schema: "dbo",
                table: "Person",
                nullable: false,
                defaultValueSql: "('0001-01-01T00:00:00.0000000')");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                schema: "dbo",
                table: "Department",
                nullable: false,
                defaultValueSql: "('0001-01-01T00:00:00.0000000')");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                schema: "dbo",
                table: "Course",
                nullable: false,
                defaultValueSql: "('0001-01-01T00:00:00.0000000')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModified",
                schema: "dbo",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DateModified",
                schema: "dbo",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DateModified",
                schema: "dbo",
                table: "Course");
        }
    }
}
