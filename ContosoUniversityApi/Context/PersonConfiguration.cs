using ContosoUniversityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversityApi.Context
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_dbo.Person").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            builder.Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            builder.Property(x => x.HireDate).HasColumnName(@"HireDate").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.EnrollmentDate).HasColumnName(@"EnrollmentDate").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.Discriminator).HasColumnName(@"Discriminator").HasColumnType("nvarchar").IsRequired().HasMaxLength(128);
        }
    }
}