using System;
using System.Collections.Generic;

namespace ContosoUniversityApi.Models
{
    public class Department
    {
        public int DepartmentId { get; set; } // DepartmentID (Primary key)
        public string Name { get; set; } // Name (length: 50)
        public decimal Budget { get; set; } // Budget
        public DateTime StartDate { get; set; } // StartDate
        public int? InstructorId { get; set; } // InstructorID
        public byte[] RowVersion { get; set; } // RowVersion (length: 8)

        // Reverse navigation

        /// <summary>
        /// Child Courses where [Course].[DepartmentID] point to this entity (FK_dbo.Course_dbo.Department_DepartmentID)
        /// </summary>
        public virtual ICollection<Course> Courses { get; set; } // Course.FK_dbo.Course_dbo.Department_DepartmentID

        // Foreign keys

        /// <summary>
        /// Parent Person pointed by [Department].([InstructorId]) (FK_dbo.Department_dbo.Instructor_InstructorID)
        /// </summary>
        public virtual Person Person { get; set; } // FK_dbo.Department_dbo.Instructor_InstructorID

        public Department()
        {
            Courses = new List<Course>();
        }
    }
}