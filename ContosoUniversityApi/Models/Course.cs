using System.Collections.Generic;

namespace ContosoUniversityApi.Models
{
    public class Course
    {
        public int CourseId { get; set; } // CourseID (Primary key)
        public string Title { get; set; } // Title (length: 50)
        public int Credits { get; set; } // Credits
        public int DepartmentId { get; set; } // DepartmentID

        // Reverse navigation

        /// <summary>
        /// Child CourseInstructors where [CourseInstructor].[CourseID] point to this entity (FK_dbo.CourseInstructor_dbo.Course_CourseID)
        /// </summary>
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } // CourseInstructor.FK_dbo.CourseInstructor_dbo.Course_CourseID

        /// <summary>
        /// Child Enrollments where [Enrollment].[CourseID] point to this entity (FK_dbo.Enrollment_dbo.Course_CourseID)
        /// </summary>
        public virtual ICollection<Enrollment> Enrollments { get; set; } // Enrollment.FK_dbo.Enrollment_dbo.Course_CourseID

        // Foreign keys

        /// <summary>
        /// Parent Department pointed by [Course].([DepartmentId]) (FK_dbo.Course_dbo.Department_DepartmentID)
        /// </summary>
        public virtual Department Department { get; set; } // FK_dbo.Course_dbo.Department_DepartmentID

        public Course()
        {
            DepartmentId = 1;
            CourseInstructors = new List<CourseInstructor>();
            Enrollments = new List<Enrollment>();
        }
    }
}