using ContosoUniversityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversityApi.Context
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment", "dbo");
            builder.HasKey(x => x.EnrollmentId).HasName("PK_dbo.Enrollment").IsClustered();
            builder.HasAlternateKey(x => x.CourseId).HasName("IX_CourseID");
            builder.HasAlternateKey(x => x.StudentId).HasName("IX_StudentID");

            builder.Property(x => x.EnrollmentId).HasColumnName(@"EnrollmentID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.CourseId).HasColumnName(@"CourseID").HasColumnType("int").IsRequired();
            builder.Property(x => x.StudentId).HasColumnName(@"StudentID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Grade).HasColumnName(@"Grade").HasColumnType("int").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Course).WithMany(b => b.Enrollments).HasForeignKey(c => c.CourseId).HasConstraintName("FK_dbo.Enrollment_dbo.Course_CourseID");
            builder.HasOne(a => a.Person).WithMany(b => b.Enrollments).HasForeignKey(c => c.StudentId).HasConstraintName("FK_dbo.Enrollment_dbo.Person_StudentID");
        }
    }
}