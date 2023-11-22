using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Exam2_University
{
    public class Student
    {

        [Key]
        [MaxLength(11)]
        public string StudentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [AllowNull]
        public string Email { get; set; }
        public Department Department { get; set; }
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();

        public Student(string studentId,string firstName,string lastName)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
        }
    }


}
