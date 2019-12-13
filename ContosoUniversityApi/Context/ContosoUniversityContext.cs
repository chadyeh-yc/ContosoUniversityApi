using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContosoUniversityApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ContosoUniversityApi.Context
{
    public class ContosoUniversityContext : DbContext, IContosoUniversityContext
    {
        private readonly IConfiguration _configuration;

        public ContosoUniversityContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ContosoUniversityContext(DbContextOptions<ContosoUniversityContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Course> Courses { get; set; } // Course
        public DbSet<CourseInstructor> CourseInstructors { get; set; } // CourseInstructor
        public DbSet<Department> Departments { get; set; } // Department
        public DbSet<Enrollment> Enrollments { get; set; } // Enrollment
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; } // OfficeAssignment
        public DbSet<Person> People { get; set; } // Person
        public DbSet<VwCourseStudent> VwCourseStudents { get; set; } // vwCourseStudents
        public DbSet<VwCourseStudentCount> VwCourseStudentCounts { get; set; } // vwCourseStudentCount
        public DbSet<VwDepartmentCourseCount> VwDepartmentCourseCounts { get; set; } // vwDepartmentCourseCount

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && _configuration != null)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString(@"DefaultConnection"));
            }
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            if (sqlValue is INullable nullableValue)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == DBNull.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseInstructorConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new VwCourseStudentConfiguration());
            modelBuilder.ApplyConfiguration(new VwCourseStudentCountConfiguration());
            modelBuilder.ApplyConfiguration(new VwDepartmentCourseCountConfiguration());

            modelBuilder.Entity<DepartmentInsertReturnModel>().HasNoKey();
            modelBuilder.Entity<DepartmentUpdateReturnModel>().HasNoKey();

            modelBuilder.Entity<Course>().Property<bool>("IsDeleted").HasColumnType("bit");
            modelBuilder.Entity<Course>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Department>().Property<bool>("IsDeleted").HasColumnType("bit");
            modelBuilder.Entity<Department>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Person>().Property<bool>("IsDeleted").HasColumnType("bit");
            modelBuilder.Entity<Person>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }

        // Stored Procedures
        public int DepartmentDelete(int? departmentId, byte[] rowVersionOriginal)
        {
            var departmentIdParam = new SqlParameter { ParameterName = "@DepartmentID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = departmentId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!departmentId.HasValue)
                departmentIdParam.Value = DBNull.Value;

            var rowVersionOriginalParam = new SqlParameter { ParameterName = "@RowVersion_Original", SqlDbType = SqlDbType.Timestamp, Direction = ParameterDirection.Input, Value = rowVersionOriginal };
            if (rowVersionOriginalParam.Value == null)
                rowVersionOriginalParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            Database.ExecuteSqlRaw("EXEC @procResult = [dbo].[Department_Delete] @DepartmentID, @RowVersion_Original", departmentIdParam, rowVersionOriginalParam, procResultParam);

            return (int)procResultParam.Value;
        }

        // DepartmentDeleteAsync() cannot be created due to having out parameters, or is relying on the procedure result (int)

        public List<DepartmentInsertReturnModel> DepartmentInsert(string name, decimal? budget, DateTime? startDate, int? instructorId)
        {
            int procResult;
            return DepartmentInsert(name, budget, startDate, instructorId, out procResult);
        }

        public List<DepartmentInsertReturnModel> DepartmentInsert(string name, decimal? budget, DateTime? startDate, int? instructorId, out int procResult)
        {
            var nameParam = new SqlParameter { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = name, Size = 50 };
            if (nameParam.Value == null)
                nameParam.Value = DBNull.Value;

            var budgetParam = new SqlParameter { ParameterName = "@Budget", SqlDbType = SqlDbType.Money, Direction = ParameterDirection.Input, Value = budget.GetValueOrDefault(), Precision = 19, Scale = 4 };
            if (!budget.HasValue)
                budgetParam.Value = DBNull.Value;

            var startDateParam = new SqlParameter { ParameterName = "@StartDate", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = startDate.GetValueOrDefault() };
            if (!startDate.HasValue)
                startDateParam.Value = DBNull.Value;

            var instructorIdParam = new SqlParameter { ParameterName = "@InstructorID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = instructorId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!instructorId.HasValue)
                instructorIdParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            const string sqlCommand = "EXEC @procResult = [dbo].[Department_Insert] @Name, @Budget, @StartDate, @InstructorID";
            var procResultData = Set<DepartmentInsertReturnModel>()
                .FromSqlRaw(sqlCommand, nameParam, budgetParam, startDateParam, instructorIdParam, procResultParam)
                .ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async Task<List<DepartmentInsertReturnModel>> DepartmentInsertAsync(string name, decimal? budget, DateTime? startDate, int? instructorId)
        {
            var nameParam = new SqlParameter { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = name, Size = 50 };
            if (nameParam.Value == null)
                nameParam.Value = DBNull.Value;

            var budgetParam = new SqlParameter { ParameterName = "@Budget", SqlDbType = SqlDbType.Money, Direction = ParameterDirection.Input, Value = budget.GetValueOrDefault(), Precision = 19, Scale = 4 };
            if (!budget.HasValue)
                budgetParam.Value = DBNull.Value;

            var startDateParam = new SqlParameter { ParameterName = "@StartDate", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = startDate.GetValueOrDefault() };
            if (!startDate.HasValue)
                startDateParam.Value = DBNull.Value;

            var instructorIdParam = new SqlParameter { ParameterName = "@InstructorID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = instructorId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!instructorId.HasValue)
                instructorIdParam.Value = DBNull.Value;

            const string sqlCommand = "EXEC [dbo].[Department_Insert] @Name, @Budget, @StartDate, @InstructorID";
            var procResultData = await Set<DepartmentInsertReturnModel>()
                .FromSqlRaw(sqlCommand, nameParam, budgetParam, startDateParam, instructorIdParam)
                .ToListAsync();

            return procResultData;
        }

        public List<DepartmentUpdateReturnModel> DepartmentUpdate(int? departmentId, string name, decimal? budget, DateTime? startDate, int? instructorId, byte[] rowVersionOriginal)
        {
            int procResult;
            return DepartmentUpdate(departmentId, name, budget, startDate, instructorId, rowVersionOriginal, out procResult);
        }

        public List<DepartmentUpdateReturnModel> DepartmentUpdate(int? departmentId, string name, decimal? budget, DateTime? startDate, int? instructorId, byte[] rowVersionOriginal, out int procResult)
        {
            var departmentIdParam = new SqlParameter { ParameterName = "@DepartmentID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = departmentId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!departmentId.HasValue)
                departmentIdParam.Value = DBNull.Value;

            var nameParam = new SqlParameter { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = name, Size = 50 };
            if (nameParam.Value == null)
                nameParam.Value = DBNull.Value;

            var budgetParam = new SqlParameter { ParameterName = "@Budget", SqlDbType = SqlDbType.Money, Direction = ParameterDirection.Input, Value = budget.GetValueOrDefault(), Precision = 19, Scale = 4 };
            if (!budget.HasValue)
                budgetParam.Value = DBNull.Value;

            var startDateParam = new SqlParameter { ParameterName = "@StartDate", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = startDate.GetValueOrDefault() };
            if (!startDate.HasValue)
                startDateParam.Value = DBNull.Value;

            var instructorIdParam = new SqlParameter { ParameterName = "@InstructorID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = instructorId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!instructorId.HasValue)
                instructorIdParam.Value = DBNull.Value;

            var rowVersionOriginalParam = new SqlParameter { ParameterName = "@RowVersion_Original", SqlDbType = SqlDbType.Timestamp, Direction = ParameterDirection.Input, Value = rowVersionOriginal };
            if (rowVersionOriginalParam.Value == null)
                rowVersionOriginalParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            const string sqlCommand = "EXEC @procResult = [dbo].[Department_Update] @DepartmentID, @Name, @Budget, @StartDate, @InstructorID, @RowVersion_Original";
            var procResultData = Set<DepartmentUpdateReturnModel>()
                .FromSqlRaw(sqlCommand, departmentIdParam, nameParam, budgetParam, startDateParam, instructorIdParam, rowVersionOriginalParam, procResultParam)
                .ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async Task<List<DepartmentUpdateReturnModel>> DepartmentUpdateAsync(int? departmentId, string name, decimal? budget, DateTime? startDate, int? instructorId, byte[] rowVersionOriginal)
        {
            var departmentIdParam = new SqlParameter { ParameterName = "@DepartmentID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = departmentId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!departmentId.HasValue)
                departmentIdParam.Value = DBNull.Value;

            var nameParam = new SqlParameter { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = name, Size = 50 };
            if (nameParam.Value == null)
                nameParam.Value = DBNull.Value;

            var budgetParam = new SqlParameter { ParameterName = "@Budget", SqlDbType = SqlDbType.Money, Direction = ParameterDirection.Input, Value = budget.GetValueOrDefault(), Precision = 19, Scale = 4 };
            if (!budget.HasValue)
                budgetParam.Value = DBNull.Value;

            var startDateParam = new SqlParameter { ParameterName = "@StartDate", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = startDate.GetValueOrDefault() };
            if (!startDate.HasValue)
                startDateParam.Value = DBNull.Value;

            var instructorIdParam = new SqlParameter { ParameterName = "@InstructorID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = instructorId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!instructorId.HasValue)
                instructorIdParam.Value = DBNull.Value;

            var rowVersionOriginalParam = new SqlParameter { ParameterName = "@RowVersion_Original", SqlDbType = SqlDbType.Timestamp, Direction = ParameterDirection.Input, Value = rowVersionOriginal };
            if (rowVersionOriginalParam.Value == null)
                rowVersionOriginalParam.Value = DBNull.Value;

            const string sqlCommand = "EXEC [dbo].[Department_Update] @DepartmentID, @Name, @Budget, @StartDate, @InstructorID, @RowVersion_Original";
            var procResultData = await Set<DepartmentUpdateReturnModel>()
                .FromSqlRaw(sqlCommand, departmentIdParam, nameParam, budgetParam, startDateParam, instructorIdParam, rowVersionOriginalParam)
                .ToListAsync();

            return procResultData;
        }

        public override int SaveChanges()
        {
            UpdateDateModified();
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateDateModified();
            UpdateSoftDeleteStatuses();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateDateModified();
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateDateModified();
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Updates the date modified.
        /// </summary>
        private void UpdateDateModified()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.CurrentValues.SetValues(new { DateModified = DateTime.UtcNow });
                }
            }
        }

        /// <summary>
        /// Updates the soft delete statuses.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entityEntry.CurrentValues.SetValues(new { isDeleted = false });
                        break;
                    case EntityState.Deleted:
                        entityEntry.State = EntityState.Modified;
                        entityEntry.CurrentValues.SetValues(new { isDeleted = true });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}