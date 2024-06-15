namespace Semana13.Models
{
    public class StudentByNameEmail
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class StudentWithGrade
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string GradeName { get; set; }
    }

    public class StudentEnrollment
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CourseName { get; set; }
        public DateTime Date { get; set; }
    }

    public class StudentEnrollmentByGrade
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string GradeName { get; set; }
        public string CourseName { get; set; }
        public DateTime Date { get; set; }
    }
}
