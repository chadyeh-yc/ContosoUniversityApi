using ContosoUniversityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversityApi.Context
{
    public class VwDepartmentCourseCountConfiguration : IEntityTypeConfiguration<VwDepartmentCourseCount>
    {
        public void Configure(EntityTypeBuilder<VwDepartmentCourseCount> builder)
        {
            builder.ToView("vwDepartmentCourseCount", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.DepartmentId).HasColumnName(@"DepartmentID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.CourseCount).HasColumnName(@"CourseCount").HasColumnType("int").IsRequired(false);
        }
    }
}