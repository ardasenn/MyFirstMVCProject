using MVC_Pratik_25_07.Entities.Concrete;
using System.Collections.Generic;

namespace MVC_Pratik_25_07.Models
{
    public class StudentWithSchoolsVM
    {

        public StudentWithSchoolsVM()
        {
            Schools = new List<School>();
            Lessons = new List<Lesson>();
        }
        public Student Student { get; set; }
        public IEnumerable<School> Schools { get; set; }
        public int LessonID { get; set; }
        public IEnumerable<Lesson> Lessons { get; set; }

    }
}
