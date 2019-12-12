using ContosoUniversityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversityApi.Context
{
    public class VwCourseStudentCountConfiguration : IEntityTypeConfiguration<VwCourseStudentCount>
    {
        public void Configure(EntityTypeBuilder<VwCourseStudentCount> builder)
        {
            builder.ToView("vwCourseStudentCount", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.DepartmentId).HasColumnName(@"DepartmentID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.CourseId).HasColumnName(@"CourseID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.StudentCount).HasColumnName(@"StudentCount").HasColumnType("int").IsRequired(false);
        }
    }
}