using System.ComponentModel.DataAnnotations;

namespace Exam2_University
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            UniversitySystem universitySystem = new UniversitySystem();
            universitySystem.StartSystem();

            //using var dbContext = new UniversityContext();

            //var dep = dbContext.Departments.Single(x => x.Name == ".NET");

            //StudentService studentService = new StudentService(dbContext);
            //var stud = dbContext.Students.Single(x => x.FirstName == "Vincas");

            //studentService.CreateStudent("34511231268", "Vincas", "Kudirka", "vinciukas@gmail.com",dep);
            //DepartmentService departmentService = new DepartmentService(dbContext);

            //departmentService.CreateDepartment("ND100",".NET");
            //departmentService.CreateDepartment("JD100", "Jave");
            //departmentService.CreateDepartment("PD100", "Python");

            //LectureService lectureService = new LectureService(dbContext);
            //lectureService.CreateLecture("C# pazengusiems", dep);
            //var lec = dbContext.Lectures.Single(x => x.Title == "C# pradmenys");
            //stud.Lectures.Add(lec);
            //dbContext.SaveChanges();
            
        }
    }
}