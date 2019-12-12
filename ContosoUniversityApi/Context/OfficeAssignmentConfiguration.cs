using ContosoUniversityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversityApi.Context
{
    public class OfficeAssignmentConfiguration : IEntityTypeConfiguration<OfficeAssignment>
    {
        public void Configure(EntityTypeBuilder<OfficeAssignment> builder)
        {
            builder.ToTable("OfficeAssignment", "dbo");
            builder.HasKey(x => x.InstructorId).HasName("PK_dbo.OfficeAssignment").IsClustered();
            builder.HasAlternateKey(x => x.InstructorId).HasName("IX_InstructorID");

            builder.Property(x => x.InstructorId).HasColumnName(@"InstructorID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Location).HasColumnName(@"Location").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(50);

            // Foreign keys
            builder.HasOne(a => a.Person).WithOne(b => b.OfficeAssignment).HasForeignKey<OfficeAssignment>(c => c.InstructorId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_dbo.OfficeAssignment_dbo.Instructor_InstructorID");
        }
    }
}