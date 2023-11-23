using Microsoft.EntityFrameworkCore;
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

        public Student CreateStudent()
        {
            Console.Write("Asmens kodas: ");
            string inputId = Console.ReadLine().ToUpper();

            Console.Write("Vardas: ");
            string inputFistName = Console.ReadLine();

            Console.Write("Pavarde: ");
            string inputLastName = Console.ReadLine();

            Console.Write("Email: ");
            string inputEmail = Console.ReadLine();

            Console.Write("Department ID: ");
            string inputDepartmentId = Console.ReadLine();
            
            Student student = new Student(inputId, inputFistName, inputLastName);



            Department department = GetDepartmentById(inputDepartmentId);

            student.Department = department;
            student.Lectures = department.Lectures;
            student.Email = inputEmail;
            return student;
        }

        public Department GetDepartmentById(string departmentId)
        {
            return _dbContext.Departments.Single(x => x.DepartmentId == departmentId);
        }
        public Student GetStudentById(Department department, string studentId)
        {
            return department.Students.Single(x => x.StudentId == studentId);
        }
        public void PrintStudents(List<Student> students)
        {
            Console.WriteLine("------------STUDENTAI------------");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.StudentId} {student.FirstName} {student.LastName} {student.Email} - {student.Department.Name}");
            }
        }
    }
}
