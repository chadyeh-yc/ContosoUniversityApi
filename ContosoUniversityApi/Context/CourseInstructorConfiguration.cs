using ContosoUniversityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversityApi.Context
{
    public class CourseInstructorConfiguration : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            builder.ToTable("CourseInstructor", "dbo");
            builder.HasKey(x => new { x.CourseId, x.InstructorId }).HasName("PK_dbo.CourseInstructor").IsClustered();
            builder.HasAlternateKey(x => x.CourseId).HasName("IX_CourseID");
            builder.HasAlternateKey(x => x.InstructorId).HasName("IX_InstructorID");

            builder.Property(x => x.CourseId).HasColumnName(@"CourseID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.InstructorId).HasColumnName(@"InstructorID").HasColumnType("int").IsRequired().ValueGeneratedNever();

            // Foreign keys
            builder.HasOne(a => a.Course).WithMany(b => b.CourseInstructors).HasForeignKey(c => c.CourseId).HasConstraintName("FK_dbo.CourseInstructor_dbo.Course_CourseID");
            builder.HasOne(a => a.Person).WithMany(b => b.CourseInstructors).HasForeignKey(c => c.InstructorId).HasConstraintName("FK_dbo.CourseInstructor_dbo.Instructor_InstructorID");
        }
    }
}