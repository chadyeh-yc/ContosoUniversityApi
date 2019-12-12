using ContosoUniversityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversityApi.Context
{
    public class VwCourseStudentConfiguration : IEntityTypeConfiguration<VwCourseStudent>
    {
        public void Configure(EntityTypeBuilder<VwCourseStudent> builder)
        {
            builder.ToView("vwCourseStudents", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.DepartmentId).HasColumnName(@"DepartmentID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.DepartmentName).HasColumnName(@"DepartmentName").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.CourseId).HasColumnName(@"CourseID").HasColumnType("int").IsRequired();
            builder.Property(x => x.CourseTitle).HasColumnName(@"CourseTitle").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.StudentId).HasColumnName(@"StudentID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.StudentName).HasColumnName(@"StudentName").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(101);
        }
    }
}