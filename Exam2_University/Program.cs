using System.ComponentModel.DataAnnotations;

namespace Exam2_University
{
    public class Program
    {
        static void Main(string[] args)
        {
            //using var dbContext = new UniversityContext();

            //var stud = dbContext.Students.Single(x => x.FirstName == "kl");

            //dbContext.Students.Remove(stud);
            //dbContext.SaveChanges();

            UniversitySystem universitySystem = new UniversitySystem();
            universitySystem.StartSystem();

            
        }
    }
}