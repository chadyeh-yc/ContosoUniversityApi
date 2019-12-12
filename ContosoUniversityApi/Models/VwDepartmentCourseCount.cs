namespace ContosoUniversityApi.Models
{
    public class VwDepartmentCourseCount
    {
        public int DepartmentId { get; set; } // DepartmentID
        public string Name { get; set; } // Name (length: 50)
        public int? CourseCount { get; set; } // CourseCount
    }
}