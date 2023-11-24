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
        
        //Priimama naudotojo ivestis,
        //sukuriama paskaita.
        public Lecture CreateLecture()
        {

            Console.Write("Paskaitos pavadinimas: ");
            string inputTitle = Console.ReadLine();

            Lecture lecture = new Lecture(inputTitle);

            return lecture;
        }

        //Priimama naudoto ivestis,
        //pridedamas departamentas i paskaita.
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
                if(department != null)
                {
                    lecture.Departments.Add(department);
                }
                
            }
        }

        //Gaunama paskaita is DB pagal ID.
        public Lecture GetLectureById(int id)
        {
            return _dbContext.Lectures.FirstOrDefault(x => x.LectureId == id);
        }

        //Gaunamas departamentas is DB pagal Departamento ID.
        public Department GetDepartmentById( string departmentId)
        {
            return _dbContext.Departments.FirstOrDefault(x => x.DepartmentId == departmentId);
        }

        //Spausdinamos paskaitos.
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
