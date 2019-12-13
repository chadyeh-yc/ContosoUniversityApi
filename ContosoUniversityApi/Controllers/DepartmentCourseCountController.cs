using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversityApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentCourseCountController : ControllerBase
    {
        private readonly IContosoUniversityContext _contosoUniversityContext;

        public DepartmentCourseCountController(IContosoUniversityContext contosoUniversityContext)
        {
            _contosoUniversityContext = contosoUniversityContext;
        }

        // GET: api/DepartmentCourseCount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VwDepartmentCourseCount>>> Get()
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(" SELECT [DepartmentID] ");
            sqlQuery.AppendLine("       ,[Name] ");
            sqlQuery.AppendLine("       ,[CourseCount] ");
            sqlQuery.AppendLine(" FROM [ContosoUniversity].[dbo].[vwDepartmentCourseCount] ");
            return await _contosoUniversityContext.VwDepartmentCourseCounts.FromSqlRaw(sqlQuery.ToString()).ToListAsync();
        }

        // GET: api/DepartmentCourseCount/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<VwDepartmentCourseCount>> Get(int id)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(" SELECT [DepartmentID] ");
            sqlQuery.AppendLine("       ,[Name] ");
            sqlQuery.AppendLine("       ,[CourseCount] ");
            sqlQuery.AppendLine(" FROM [ContosoUniversity].[dbo].[vwDepartmentCourseCount] ");
            sqlQuery.AppendLine(" WHERE [DepartmentID] = @DepartmentID ");
            var departmentIdParam = new SqlParameter
            {
                ParameterName = "@DepartmentID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id,
                Precision = 10,
                Scale = 0
            };
            return await _contosoUniversityContext.VwDepartmentCourseCounts.FromSqlRaw(sqlQuery.ToString(), departmentIdParam).SingleOrDefaultAsync();
        }
    }
}
