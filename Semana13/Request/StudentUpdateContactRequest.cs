using Semana13.Models;

namespace Semana13.Request
{
    public class StudentUpdateContactRequest
    {
        
        public int StudentID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
