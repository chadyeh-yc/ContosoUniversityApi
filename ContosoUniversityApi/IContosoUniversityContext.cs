using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContosoUniversityApi.Context;
using ContosoUniversityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ContosoUniversityApi
{
    public interface IContosoUniversityContext : IDisposable
    {
        DbSet<Course> Courses { get; set; } // Course
        DbSet<CourseInstructor> CourseInstructors { get; set; } // CourseInstructor
        DbSet<Department> Departments { get; set; } // Department
        DbSet<Enrollment> Enrollments { get; set; } // Enrollment
        DbSet<OfficeAssignment> OfficeAssignments { get; set; } // OfficeAssignment
        DbSet<Person> People { get; set; } // Person
        DbSet<VwCourseStudent> VwCourseStudents { get; set; } // vwCourseStudents
        DbSet<VwCourseStudentCount> VwCourseStudentCounts { get; set; } // vwCourseStudentCount
        DbSet<VwDepartmentCourseCount> VwDepartmentCourseCounts { get; set; } // vwDepartmentCourseCount

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        DatabaseFacade Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();

        // Stored Procedures
        int DepartmentDelete(int? departmentId, byte[] rowVersionOriginal);
        // DepartmentDeleteAsync() cannot be created due to having out parameters, or is relying on the procedure result (int)

        List<DepartmentInsertReturnModel> DepartmentInsert(string name, decimal? budget, DateTime? startDate, int? instructorId);
        List<DepartmentInsertReturnModel> DepartmentInsert(string name, decimal? budget, DateTime? startDate, int? instructorId, out int procResult);
        Task<List<DepartmentInsertReturnModel>> DepartmentInsertAsync(string name, decimal? budget, DateTime? startDate, int? instructorId);

        List<DepartmentUpdateReturnModel> DepartmentUpdate(int? departmentId, string name, decimal? budget, DateTime? startDate, int? instructorId, byte[] rowVersionOriginal);
        List<DepartmentUpdateReturnModel> DepartmentUpdate(int? departmentId, string name, decimal? budget, DateTime? startDate, int? instructorId, byte[] rowVersionOriginal, out int procResult);
        Task<List<DepartmentUpdateReturnModel>> DepartmentUpdateAsync(int? departmentId, string name, decimal? budget, DateTime? startDate, int? instructorId, byte[] rowVersionOriginal);

    }
}