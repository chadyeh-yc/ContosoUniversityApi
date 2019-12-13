using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversityApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseStudentController : ControllerBase
    {
        private readonly IContosoUniversityContext _contosoUniversityContext;

        public CourseStudentController(IContosoUniversityContext contosoUniversityContext)
        {
            _contosoUniversityContext = contosoUniversityContext;
        }

        // GET: api/CourseStudent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VwCourseStudent>>> GetCourseStudents()
        {
            return await _contosoUniversityContext.VwCourseStudents.ToListAsync();
        }

        // GET: api/CourseStudent/5
        [HttpGet("{id}", Name = "GetCourseStudent")]
        public async Task<ActionResult<VwCourseStudent>> GetCourseStudent(int id)
        {
            var courseStudent = await _contosoUniversityContext.VwCourseStudents.FindAsync(id);

            if (courseStudent == null)
            {
                return NotFound();
            }

            return courseStudent;
        }

        // GET: api/CourseStudent/Count
        [HttpGet("/Count")]
        public async Task<ActionResult<IEnumerable<VwCourseStudentCount>>> GetCountEnumerable()
        {
            return await _contosoUniversityContext.VwCourseStudentCounts.ToListAsync();
        }

        // GET: api/CourseStudent/Count/5
        [HttpGet("/Count/{id}", Name = "GetCount")]
        public async Task<ActionResult<VwCourseStudentCount>> GetCount(int id)
        {
            var courseStudentCount = await _contosoUniversityContext.VwCourseStudentCounts.FindAsync(id);

            if (courseStudentCount == null)
            {
                return NotFound();
            }

            return courseStudentCount;
        }
    }
}
