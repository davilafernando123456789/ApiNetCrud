namespace Semana13.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public DateTime Date { get; set; }
        public int Activo { get; set; }


        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public int? CourseID { get; set; }
        public Course Course { get; set; }
    }
}
