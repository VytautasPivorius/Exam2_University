using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2_University
{
    public class StudentService
    {
        private readonly UniversityContext _dbContext;

        public StudentService(UniversityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateStudent(string id,string firstName,string lastName,string email,Department department)
        {
            var student = new Student(id, firstName, lastName);
            student.Department = department;
            student.Email = email;
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }
        public void AddStudentToDepartment()
        {

        }

    }
}
