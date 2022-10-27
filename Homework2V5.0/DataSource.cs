using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2V5._0
{
    public class ListLesson
    {
        public ListLesson(string Name, TimeOnly Time)
        {
            this.Time = Time;
            this.Name = Name;
        }

        public string Name { get; set; }
        public TimeOnly Time { get; set; }
    }

    public class WeekList
    {
        public WeekList(string nameWeek, List<ListLesson> lessons)
        {
            NameWeek = nameWeek;
            Lessons = lessons;
        }
        public string NameWeek { get; set; }
        public List<ListLesson> Lessons { get; set; }
    }
}
