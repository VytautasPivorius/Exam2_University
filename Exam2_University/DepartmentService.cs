using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Exam2_University
{
    public class DepartmentService
    {
        private readonly UniversityContext _dbContext;

        public DepartmentService(UniversityContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateDepartment(string id, string name)
        {
            var department = new Department(id,name);

            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
        }
        public void AddLectures()
        {

        }
        public void PrintStudents(Department department)
        {
            var students = department.Students;
            Console.WriteLine("------------STUDENTAI------------");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} {student.Email} - {student.Department.Name}");
            }
        }
        public void PrintDepartments()
        {
            var departments = _dbContext.Departments;
            Console.WriteLine("----------DEPARTAMENTAI----------");
            
            foreach (var department in departments)
            {
                Console.WriteLine($"[{department.DepartmentId}] - {department.Name}");
            }
        }

        public void PrintLectures(List<Lecture> lectures)
        {
            Console.WriteLine("------------PASKAITOS------------");
            int i = 1;
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{i} - {lecture.Title}");
                i++;
            }
        }
        public void PrintDepartmentMenu()
        {
            Console.WriteLine("--------------MENIU--------------");
            Console.WriteLine("1 - Paskaitos");
            Console.WriteLine("2 - Studentai");
        }
        public Department GetCurrentDepartment(string input)
        {
            return _dbContext.Departments.Include(x=>x.Lectures).Include(x=>x.Students).Single(x => x.DepartmentId == input);
        }

    }
}
