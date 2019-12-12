using System;
using System.Collections.Generic;

namespace ContosoUniversityApi.Models
{
    public class Person
    {
        public int Id { get; set; } // ID (Primary key)
        public string LastName { get; set; } // LastName (length: 50)
        public string FirstName { get; set; } // FirstName (length: 50)
        public DateTime? HireDate { get; set; } // HireDate
        public DateTime? EnrollmentDate { get; set; } // EnrollmentDate
        public string Discriminator { get; set; } // Discriminator (length: 128)

        // Reverse navigation

        /// <summary>
        /// Child CourseInstructors where [CourseInstructor].[InstructorID] point to this entity (FK_dbo.CourseInstructor_dbo.Instructor_InstructorID)
        /// </summary>
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } // CourseInstructor.FK_dbo.CourseInstructor_dbo.Instructor_InstructorID

        /// <summary>
        /// Child Departments where [Department].[InstructorID] point to this entity (FK_dbo.Department_dbo.Instructor_InstructorID)
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; } // Department.FK_dbo.Department_dbo.Instructor_InstructorID

        /// <summary>
        /// Child Enrollments where [Enrollment].[StudentID] point to this entity (FK_dbo.Enrollment_dbo.Person_StudentID)
        /// </summary>
        public virtual ICollection<Enrollment> Enrollments { get; set; } // Enrollment.FK_dbo.Enrollment_dbo.Person_StudentID

        /// <summary>
        /// Parent (One-to-One) Person pointed by [OfficeAssignment].[InstructorID] (FK_dbo.OfficeAssignment_dbo.Instructor_InstructorID)
        /// </summary>
        public virtual OfficeAssignment OfficeAssignment { get; set; } // OfficeAssignment.FK_dbo.OfficeAssignment_dbo.Instructor_InstructorID

        public Person()
        {
            Discriminator = "Instructor";
            CourseInstructors = new List<CourseInstructor>();
            Departments = new List<Department>();
            Enrollments = new List<Enrollment>();
        }
    }
}