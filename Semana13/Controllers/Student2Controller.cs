using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semana13.Models;
using Semana13.Request;

namespace Semana13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Student2Controller : ControllerBase
    {
        private readonly SchoolContext _context;

        public Student2Controller(SchoolContext context)
        {
            _context = context;
        }
        [HttpPost]
        public void Insert(StudentInsertRequest request)
        {
            //convietiendo a objeto modelo de mi curso
            Student student = new Student();
            student.GradeID = request.Grade;
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Phone = request.Phone;
            student.Email = request.Email;
            student.Activo = 1;

            _context.Students.Add(student);
            _context.SaveChanges();

        }
        [HttpPost]
        public void UpdateContact(StudentUpdateContactRequest request)
        {
            var student = _context.Students.Find(request.StudentID);
            student.Phone = request.Phone;
            student.Email = request.Email;
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        [HttpPost]
        public void UpdatePerson(StudentPersonRequest request)
        {
            var student = _context.Students.Find(request.StudentID);
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
