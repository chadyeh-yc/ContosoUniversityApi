namespace ContosoUniversityApi.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; } // EnrollmentID (Primary key)
        public int CourseId { get; set; } // CourseID
        public int StudentId { get; set; } // StudentID
        public int? Grade { get; set; } // Grade

        // Foreign keys

        /// <summary>
        /// Parent Course pointed by [Enrollment].([CourseId]) (FK_dbo.Enrollment_dbo.Course_CourseID)
        /// </summary>
        public virtual Course Course { get; set; } // FK_dbo.Enrollment_dbo.Course_CourseID

        /// <summary>
        /// Parent Person pointed by [Enrollment].([StudentId]) (FK_dbo.Enrollment_dbo.Person_StudentID)
        /// </summary>
        public virtual Person Person { get; set; } // FK_dbo.Enrollment_dbo.Person_StudentID
    }
}