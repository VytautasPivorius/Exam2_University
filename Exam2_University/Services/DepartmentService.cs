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

        //Priimama naudotojo ivestis,
        //sukuriamas departamentas.
        public Department CreateDepartment()
        {
            Console.Write("Iveskite departamento ID: ");
            string inputId = Console.ReadLine().ToUpper();
            Console.Write("Iveskite departamento pavadinima: ");
            string inputName = Console.ReadLine();

            Department department = new Department(inputId, inputName);
            return department;
        }
        

        //Atspausdinami visi DB departamentai
        public void PrintDepartments()
        {
            var departments = _dbContext.Departments;
            Console.WriteLine("----------DEPARTAMENTAI----------");
            
            foreach (var department in departments)
            {
                Console.WriteLine($"[{department.DepartmentId}] - {department.Name}");
            }
        }

        //Gaunamas departamentas, paskaitos ir studentai is DB pagal Departamento ID.
        public Department GetCurrentDepartment(string input)
        {
            return _dbContext.Departments.Include(x=>x.Lectures).Include(x=>x.Students).FirstOrDefault(x => x.DepartmentId == input);
        }

        //Gaunamas Departamentas is DB pagal ID
        public Department GetDepartmentById(string departmentId)
        {
            return _dbContext.Departments.FirstOrDefault(x => x.DepartmentId == departmentId);
        }
        
        //Gaunama paskaita is DB pagal ID
        public Lecture GetLectureById(int id)
        {
            return _dbContext.Lectures.FirstOrDefault(x => x.LectureId == id);
        }

    }
}
