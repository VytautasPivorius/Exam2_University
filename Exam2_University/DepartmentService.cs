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
        public Department CreateDepartment()
        {
            Console.Write("Iveskite departamento ID: ");
            string inputId = Console.ReadLine().ToUpper();
            Console.Write("Iveskite departamento pavadinima: ");
            string inputName = Console.ReadLine();

            Department department = new Department(inputId, inputName);
            return department;
        }

        public void AddLecturesToDepartment(Department department)
        {
            while (true)
            {
                Console.WriteLine("Pasirinkite paskaita kuria norite prideti: ");
                Console.WriteLine("Grizti - spauskite [Q]");

                string inputLectureAdd = Console.ReadLine().ToUpper();
                int id = 0;
                if (inputLectureAdd == "Q")
                {
                    break;
                }
                else if (!int.TryParse(inputLectureAdd, out id))
                {
                    continue;
                }
                Lecture lecture = GetLectureById(id);
                department.Lectures.Add(lecture);
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


        public Department GetCurrentDepartment(string input)
        {
            return _dbContext.Departments.Include(x=>x.Lectures).Include(x=>x.Students).SingleOrDefault(x => x.DepartmentId == input);
        }
        public Department GetDepartmentById(string departmentId)
        {
            return _dbContext.Departments.SingleOrDefault(x => x.DepartmentId == departmentId);
        }
        public Lecture GetLectureById(int id)
        {
            return _dbContext.Lectures.SingleOrDefault(x => x.LectureId == id);
        }

    }
}
