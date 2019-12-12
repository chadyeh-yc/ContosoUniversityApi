namespace ContosoUniversityApi.Models
{
    public class VwCourseStudentCount
    {
        public int? DepartmentId { get; set; } // DepartmentID
        public string Name { get; set; } // Name (length: 50)
        public int CourseId { get; set; } // CourseID
        public string Title { get; set; } // Title (length: 50)
        public int? StudentCount { get; set; } // StudentCount
    }
}