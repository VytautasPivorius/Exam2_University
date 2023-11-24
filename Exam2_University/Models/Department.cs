using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2_University
{
    public class Department
    {
        private string _id;
        [Key]
        [MaxLength(5)]
        public string DepartmentId 
        {
            get { return _id; }
            set
            {
                if (value.Length != 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!!Departamento ID turi sudaryti 5 simboliai!!");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    _id = null;
                }
                _id = value;
            }
        }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Lecture> Lectures { get; set;} = new List<Lecture>();

        public Department(string departmentId, string name) 
        {
            DepartmentId = departmentId;
            Name = name;
        }
    }
}
