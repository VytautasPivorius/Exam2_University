using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Exam2_University
{
    public class Student
    {
        private string _id;
        private string _email;
        [Key]
        [MaxLength(11)]
        public string StudentId 
        {
            get { return _id; }

            set
            {
                if (value.Length != 11 || !value.All(char.IsDigit))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!!Asmens koda turi sudaryti 11 skaiciu!!");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    _id = null;
                }
                _id = value;
            } 
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        public string? Email 
        {
            get { return _email; }
            set
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (regex.IsMatch(value))
                {
                    _email = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"!!Nurodytas blogo formato email - reiksme priskirta null!!");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    _email = null;
                }
            }
        }
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
