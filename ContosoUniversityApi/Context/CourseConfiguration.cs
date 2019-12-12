using ContosoUniversityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversityApi.Context
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course", "dbo");
            builder.HasKey(x => x.CourseId).HasName("PK_dbo.Course").IsClustered();
            builder.HasAlternateKey(x => x.DepartmentId).HasName("IX_DepartmentID");

            builder.Property(x => x.CourseId).HasColumnName(@"CourseID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Credits).HasColumnName(@"Credits").HasColumnType("int").IsRequired();
            builder.Property(x => x.DepartmentId).HasColumnName(@"DepartmentID").HasColumnType("int").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Department).WithMany(b => b.Courses).HasForeignKey(c => c.DepartmentId).HasConstraintName("FK_dbo.Course_dbo.Department_DepartmentID");
        }
    }
}