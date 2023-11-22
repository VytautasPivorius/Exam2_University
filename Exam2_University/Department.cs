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
        [Key]
        [MaxLength(5)]
        public string DepartmentId { get; set; }
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
