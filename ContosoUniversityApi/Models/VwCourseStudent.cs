namespace ContosoUniversityApi.Models
{
    public class VwCourseStudent
    {
        public int? DepartmentId { get; set; } // DepartmentID
        public string DepartmentName { get; set; } // DepartmentName (length: 50)
        public int CourseId { get; set; } // CourseID
        public string CourseTitle { get; set; } // CourseTitle (length: 50)
        public int? StudentId { get; set; } // StudentID
        public string StudentName { get; set; } // StudentName (length: 101)
    }
}