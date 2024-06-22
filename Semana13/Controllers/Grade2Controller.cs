using Azure.Core;
using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semana13.Models;
using Semana13.Request;

namespace Semana13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Grade2Controller : ControllerBase
    {
        private readonly SchoolContext _context;

        public Grade2Controller(SchoolContext context)
        {
            _context = context;
        }
        [HttpPost]
        public void Insert(GradeInsertRequest request)
        {
            //convietiendo a objeto modelo de mi curso
            Grade grade = new Grade();
            grade.Name = request.Name;
            grade.Descripcion = request.Descripcion;
            grade.Activo = 1;

            _context.Grades.Add(grade);
            _context.SaveChanges();

        }
        [HttpPost]
        public void Delete(GradeDeleteRequest request)
        {
            var grade = _context.Grades.Find(request.GradeID);
            grade.Activo = 0;
            _context.Grades.Update(grade);
            _context.SaveChanges();
        }

        [HttpPost]
        public void InsertListStudentByGrade(StudentListByGradeRequest request)
        {
            //convietiendo a objeto modelo de mi curso
            var grade = _context.Grades.Find(request.GradeID);
            if (grade == null)
            {
                //Agregamos el error
            }

            foreach (var studentRequest in request.Students)
            {
                var student = new Student
                {
                    FirstName = studentRequest.FirstName,
                    LastName = studentRequest.LastName,
                    Phone = studentRequest.Phone,
                    Email = studentRequest.Email,
                    Activo = 1,
                    GradeID = request.GradeID
                };
                _context.Students.Add(student);
            }

            _context.SaveChanges();

         

        }

    }
}

