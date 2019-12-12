namespace ContosoUniversityApi.Models
{
    public class OfficeAssignment
    {
        public int InstructorId { get; set; } // InstructorID (Primary key)
        public string Location { get; set; } // Location (length: 50)

        // Foreign keys

        /// <summary>
        /// Parent Person pointed by [OfficeAssignment].([InstructorId]) (FK_dbo.OfficeAssignment_dbo.Instructor_InstructorID)
        /// </summary>
        public virtual Person Person { get; set; } // FK_dbo.OfficeAssignment_dbo.Instructor_InstructorID
    }
}