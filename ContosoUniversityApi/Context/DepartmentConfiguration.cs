using ContosoUniversityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversityApi.Context
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department", "dbo");
            builder.HasKey(x => x.DepartmentId).HasName("PK_dbo.Department").IsClustered();

            builder.Property(x => x.DepartmentId).HasColumnName(@"DepartmentID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Budget).HasColumnName(@"Budget").HasColumnType("money").IsRequired();
            builder.Property(x => x.StartDate).HasColumnName(@"StartDate").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.InstructorId).HasColumnName(@"InstructorID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.RowVersion).HasColumnName(@"RowVersion").HasColumnType("timestamp").IsRequired().IsFixedLength().HasMaxLength(8).IsRowVersion();
            builder.Property(x => x.DateModified).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            // Foreign keys
            builder.HasOne(a => a.Person).WithMany(b => b.Departments).HasForeignKey(c => c.InstructorId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_dbo.Department_dbo.Instructor_InstructorID");

            builder.HasIndex(x => x.InstructorId).HasName("IX_InstructorID");
        }
    }
}