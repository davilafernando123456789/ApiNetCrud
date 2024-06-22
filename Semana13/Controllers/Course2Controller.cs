using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semana13.Request;
using Semana13.Models;

namespace Semana13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Course2Controller : ControllerBase
    {
        private readonly SchoolContext _context;

        public Course2Controller(SchoolContext context)
        {
            _context = context;
        }
        [HttpPost]
        public void Insert(CourseInsertRequest request)
        {
            //convietiendo a objeto modelo de mi curso
            Course course = new Course();
            course.Name = request.Name;
            course.Credit = request.Credit;
            course.Activo = 1;

            _context.Courses.Add(course);
            _context.SaveChanges();

        }
        [HttpPost]
        public void Delete(CourseDeleteRequest request)
        {
            var course = _context.Courses.Find(request.CourseId);
            course.Activo = 0;
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
        [HttpPost]
        public void DeleteList(CoursesListDeleteRequest request)
        {
            foreach (var courseId in request.CourseIds)
            {
                var course = _context.Courses.Find(courseId);
                if (course != null)
                {
                    course.Activo = 0;
                    _context.Courses.Update(course);
         
                }
            }
            _context.SaveChanges();
        }
       
    }
}
