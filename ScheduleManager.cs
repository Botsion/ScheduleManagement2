using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement2
{
    public class ScheduleManager
    {
        private List<Lesson> _lessons;

        public ScheduleManager()
        {
            _lessons = new List<Lesson>();
        }

        public void AddLesson(string name, string group, string teacher, string classroom, DateTime date)
        {
            _lessons.Add(new Lesson(name, group, teacher, classroom, date));
        }

        public List<Lesson> GetScheduleForGroup(string groupName)
        {
            return _lessons
                .Where(lesson => lesson.Group.Equals(groupName, StringComparison.OrdinalIgnoreCase))
                .OrderBy(lesson => lesson.Date)
                .ToList();
        }

        public List<Lesson> GetScheduleForDate(DateTime date)
        {
            return _lessons
                .Where(lesson => lesson.Date.Date == date.Date)
                .OrderBy(lesson => lesson.Date)
                .ToList();
        }

        public List<Lesson> GetFullSchedule()
        {
            return _lessons
                .OrderBy(lesson => lesson.Date)
                .ToList();
        }
    }
}
