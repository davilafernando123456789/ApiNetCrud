using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semana13.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semana13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterStudentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public FilterStudentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/FilterStudentsController/ByNameEmail
        [HttpGet("ByNameEmail")]
        public async Task<ActionResult<IEnumerable<StudentByNameEmail>>> GetStudentsByNameEmail(string query)
        {
            var students = await _context.Students
                .Where(s => s.Activo == 1 &&
                            (s.FirstName.Contains(query) || s.LastName.Contains(query) || s.Email.Contains(query)))
                .OrderByDescending(s => s.LastName)
                .Select(s => new StudentByNameEmail
                {
                    StudentID = s.StudentID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email
                })
                .ToListAsync();

            return students;
        }

        // GET: api/FilterStudentsController/ByGradeAndName
        [HttpGet("ByGradeAndName")]
        public async Task<ActionResult<IEnumerable<StudentWithGrade>>> GetStudentsByGradeAndName(string studentName, string gradeName)
        {
            var students = await _context.Students
                .Include(s => s.Grade)
                .Where(s => s.Activo == 1 &&
                            s.FirstName.Contains(studentName) &&
                            s.Grade.Name.Contains(gradeName))
                .OrderByDescending(s => s.Grade.Name)
                .Select(s => new StudentWithGrade
                {
                    StudentID = s.StudentID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Phone = s.Phone,
                    Email = s.Email,
                    GradeName = s.Grade.Name
                })
                .ToListAsync();

            return students;
        }

        // GET: api/FilterStudentsController/ByCourseName
        [HttpGet("ByCourseName")]
        public async Task<ActionResult<IEnumerable<StudentEnrollment>>> GetStudentsByCourseName(string courseName)
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.Course.Name.Contains(courseName) && e.Student.Activo == 1)
                .OrderBy(e => e.Course.Name)
                .ThenBy(e => e.Student.LastName)
                .Select(e => new StudentEnrollment
                {
                    StudentID = e.Student.StudentID,
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName,
                    Email = e.Student.Email,
                    CourseName = e.Course.Name,
                    Date = e.Date
                })
                .ToListAsync();

            return enrollments;
        }

        // GET: api/FilterStudentsController/ByGrade
        [HttpGet("ByGrade")]
        public async Task<ActionResult<IEnumerable<StudentEnrollmentByGrade>>> GetStudentsByGrade(string gradeName)
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Include(e => e.Student.Grade)
                .Where(e => e.Student.Grade.Name.Contains(gradeName) && e.Student.Activo == 1)
                .OrderBy(e => e.Course.Name)
                .ThenBy(e => e.Student.LastName)
                .Select(e => new StudentEnrollmentByGrade
                {
                    StudentID = e.Student.StudentID,
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName,
                    Email = e.Student.Email,
                    GradeName = e.Student.Grade.Name,
                    CourseName = e.Course.Name,
                    Date = e.Date
                })
                .ToListAsync();

            return enrollments;
        }
    }
}

//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Semana13.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FilterStudentsController : ControllerBase
//    {
//        // GET: api/<FilterStudentsController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<FilterStudentsController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }



//        // PUT api/<FilterStudentsController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }


//    }
//}
