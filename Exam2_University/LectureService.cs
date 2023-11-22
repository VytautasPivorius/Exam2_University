namespace Exam2_University
{
    public class LectureService
    {
        private readonly UniversityContext _dbContext;

        public LectureService(UniversityContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateLecture(string title,Department department)
        {
            Lecture lecture = new Lecture(title);
            lecture.Departments.Add(department);
            _dbContext.Lectures.Add(lecture);
            _dbContext.SaveChanges();
        }
        
    }
}
