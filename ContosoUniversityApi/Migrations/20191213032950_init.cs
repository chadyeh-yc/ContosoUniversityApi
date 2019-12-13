using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversityApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "dbo");

            //migrationBuilder.CreateTable(
            //    name: "DepartmentInsertReturnModel",
            //    columns: table => new
            //    {
            //        DepartmentID = table.Column<int>(nullable: false),
            //        RowVersion = table.Column<byte[]>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DepartmentUpdateReturnModel",
            //    columns: table => new
            //    {
            //        RowVersion = table.Column<byte[]>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Person",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LastName = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: false),
            //        FirstName = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: false),
            //        HireDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        EnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        Discriminator = table.Column<string>(type: "nvarchar", maxLength: 128, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_dbo.Person", x => x.ID)
            //            .Annotation("SqlServer:Clustered", true);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Department",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        DepartmentID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: true),
            //        Budget = table.Column<decimal>(type: "money", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        InstructorID = table.Column<int>(type: "int", nullable: true),
            //        RowVersion = table.Column<byte[]>(type: "timestamp", fixedLength: true, maxLength: 8, rowVersion: true, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_dbo.Department", x => x.DepartmentID)
            //            .Annotation("SqlServer:Clustered", true);
            //        table.ForeignKey(
            //            name: "FK_dbo.Department_dbo.Instructor_InstructorID",
            //            column: x => x.InstructorID,
            //            principalSchema: "dbo",
            //            principalTable: "Person",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OfficeAssignment",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        InstructorID = table.Column<int>(type: "int", nullable: false),
            //        Location = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("IX_InstructorID", x => x.InstructorID)
            //            .Annotation("SqlServer:Clustered", true);
            //        table.ForeignKey(
            //            name: "FK_dbo.OfficeAssignment_dbo.Instructor_InstructorID",
            //            column: x => x.InstructorID,
            //            principalSchema: "dbo",
            //            principalTable: "Person",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Course",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        CourseID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: true),
            //        Credits = table.Column<int>(type: "int", nullable: false),
            //        DepartmentID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_dbo.Course", x => x.CourseID)
            //            .Annotation("SqlServer:Clustered", true);
            //        table.UniqueConstraint("IX_DepartmentID", x => x.DepartmentID);
            //        table.ForeignKey(
            //            name: "FK_dbo.Course_dbo.Department_DepartmentID",
            //            column: x => x.DepartmentID,
            //            principalSchema: "dbo",
            //            principalTable: "Department",
            //            principalColumn: "DepartmentID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CourseInstructor",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        CourseID = table.Column<int>(type: "int", nullable: false),
            //        InstructorID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_dbo.CourseInstructor", x => new { x.CourseID, x.InstructorID })
            //            .Annotation("SqlServer:Clustered", true);
            //        table.UniqueConstraint("IX_CourseID", x => x.CourseID);
            //        table.UniqueConstraint("IX_InstructorID", x => x.InstructorID);
            //        table.ForeignKey(
            //            name: "FK_dbo.CourseInstructor_dbo.Course_CourseID",
            //            column: x => x.CourseID,
            //            principalSchema: "dbo",
            //            principalTable: "Course",
            //            principalColumn: "CourseID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_dbo.CourseInstructor_dbo.Instructor_InstructorID",
            //            column: x => x.InstructorID,
            //            principalSchema: "dbo",
            //            principalTable: "Person",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Enrollment",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        EnrollmentID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CourseID = table.Column<int>(type: "int", nullable: false),
            //        StudentID = table.Column<int>(type: "int", nullable: false),
            //        Grade = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_dbo.Enrollment", x => x.EnrollmentID)
            //            .Annotation("SqlServer:Clustered", true);
            //        table.UniqueConstraint("IX_CourseID", x => x.CourseID);
            //        table.UniqueConstraint("IX_StudentID", x => x.StudentID);
            //        table.ForeignKey(
            //            name: "FK_dbo.Enrollment_dbo.Course_CourseID",
            //            column: x => x.CourseID,
            //            principalSchema: "dbo",
            //            principalTable: "Course",
            //            principalColumn: "CourseID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_dbo.Enrollment_dbo.Person_StudentID",
            //            column: x => x.StudentID,
            //            principalSchema: "dbo",
            //            principalTable: "Person",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_InstructorID",
            //    schema: "dbo",
            //    table: "Department",
            //    column: "InstructorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "DepartmentInsertReturnModel");

            //migrationBuilder.DropTable(
            //    name: "DepartmentUpdateReturnModel");

            //migrationBuilder.DropTable(
            //    name: "CourseInstructor",
            //    schema: "dbo");

            //migrationBuilder.DropTable(
            //    name: "Enrollment",
            //    schema: "dbo");

            //migrationBuilder.DropTable(
            //    name: "OfficeAssignment",
            //    schema: "dbo");

            //migrationBuilder.DropTable(
            //    name: "Course",
            //    schema: "dbo");

            //migrationBuilder.DropTable(
            //    name: "Department",
            //    schema: "dbo");

            //migrationBuilder.DropTable(
            //    name: "Person",
            //    schema: "dbo");
        }
    }
}
