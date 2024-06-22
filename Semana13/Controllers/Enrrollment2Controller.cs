using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semana13.Models;
using Semana13.Request;

namespace Semana13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Enrrollment2Controller : ControllerBase
    {
        private readonly SchoolContext _context;

        public Enrrollment2Controller(SchoolContext context)
        {
            _context = context;
        }
        [HttpPost]
        public void Insert(EnrollmentRequest request)
        {
            //convietiendo a objeto modelo de mi curso
            var student = _context.Students.Find(request.StudentID);
            if (student == null)
            {
                //
                Console.WriteLine("Campo nulo");
            }

            foreach (var courseId in request.CourseIds)
            {
                var course = _context.Courses.Find(courseId);
                if (course != null)
                {
                    var enrollment = new Enrollment
                    {
                        StudentID = request.StudentID,
                        CourseID = courseId
                    };
                    _context.Enrollments.Add(enrollment);
                }
            }
            _context.SaveChanges();
          

        }
    }
}
