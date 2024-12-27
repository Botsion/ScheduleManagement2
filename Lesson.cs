using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//asa
namespace ScheduleManagement2
{
    public class Lesson
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Teacher { get; set; }
        public string Classroom { get; set; }
        public DateTime Date { get; set; }

        public Lesson(string name, string group, string teacher, string classroom, DateTime date)
        {
            Name = name;
            Group = group;
            Teacher = teacher;
            Classroom = classroom;
            Date = date;
        }
    }
}
