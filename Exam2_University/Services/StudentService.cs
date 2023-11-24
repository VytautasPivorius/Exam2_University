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

        //Priimama naudotojo ivestis,
        //sukuriamas studentas,
        //priskiramas departamentas studentui pagal nurodyta departamento ID,
        //priskiriamos to departamento paskaitos studentui
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
            if(department != null && student != null)
            {
                student.Department = department;
                student.Lectures = department.Lectures;
                student.Email = inputEmail;
            }
            
            return student;
        }

        //Gaunamas departamentas is DB pagal Departamento ID.
        private Department GetDepartmentById(string departmentId)
        {
            return _dbContext.Departments.FirstOrDefault(x => x.DepartmentId == departmentId);
        }

        //Gaunamas studentas is DB pagal Departamento ID.
        public Student GetStudentById(Department department, string studentId)
        {
            return department.Students.FirstOrDefault(x => x.StudentId == studentId);
        }

        //Spausdinami studentai
        public void PrintStudents(List<Student> students)
        {
            Console.WriteLine("------------STUDENTAI------------");
            foreach (var student in students)
            {
                string akv = $"A.k:{student.StudentId} Vardas:{student.FirstName} {student.LastName} ";
                string em = $"Email:{student.Email} ";
                string dep = $"Departamentas:{student.Department.Name}";

                Console.WriteLine($"{akv.PadRight(55)}{em.PadRight(40)}{dep.PadRight(30)}");
            }
        }
    }
}
