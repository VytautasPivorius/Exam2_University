using Microsoft.EntityFrameworkCore;

namespace Exam2_University
{
    public class LectureService
    {
        private readonly UniversityContext _dbContext;

        public LectureService(UniversityContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Lecture CreateLecture()
        {

            Console.Write("Paskaitos pavadinimas: ");
            string inputTitle = Console.ReadLine().ToUpper();

            Lecture lecture = new Lecture(inputTitle);

            return lecture;
        }
        public void AddDepartmentsToLecture(Lecture lecture)
        {
            while (true)
            {
                Console.WriteLine("Pasirinkite departamenta kuri norite prideti: ");
                Console.WriteLine("Grizti - spauskite [Q]");

                string departmentId = Console.ReadLine().ToUpper();
                int id = 0;
                if (departmentId == "Q")
                {
                    break;
                }
                var department = GetDepartmentById(departmentId);
                lecture.Departments.Add(department);
            }
        }

        public Department GetDepartmentById( string departmentId)
        {
            return _dbContext.Departments.SingleOrDefault(x => x.DepartmentId == departmentId);
        }

        public void PrintLectures(List<Lecture> lectures)
        {
            Console.WriteLine("------------PASKAITOS------------");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"[{lecture.LectureId}] - {lecture.Title}");
            }
        }
    }
}
