namespace Semana13.Request
{
    public class StudentListByGradeRequest
    {
        public int GradeID { get; set; }
        public List<StudentInsertRequest> Students { get; set; }
    }
}
