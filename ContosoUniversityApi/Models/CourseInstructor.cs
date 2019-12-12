namespace ContosoUniversityApi.Models
{
    public class CourseInstructor
    {
        public int CourseId { get; set; } // CourseID (Primary key)
        public int InstructorId { get; set; } // InstructorID (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent Course pointed by [CourseInstructor].([CourseId]) (FK_dbo.CourseInstructor_dbo.Course_CourseID)
        /// </summary>
        public virtual Course Course { get; set; } // FK_dbo.CourseInstructor_dbo.Course_CourseID

        /// <summary>
        /// Parent Person pointed by [CourseInstructor].([InstructorId]) (FK_dbo.CourseInstructor_dbo.Instructor_InstructorID)
        /// </summary>
        public virtual Person Person { get; set; } // FK_dbo.CourseInstructor_dbo.Instructor_InstructorID
    }
}