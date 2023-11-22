using System.ComponentModel.DataAnnotations;

namespace Exam2_University
{
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }
        public string Title { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Student> Students { get; set; }

        public Lecture(string title) 
        {   
            Title = title;
            
        }
    }


}
