using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Homework2V5._0
{
    public enum Week
    {
        [Description("Monday")]
        Monday,
        [Description("Tuesday")]
        Tuesday,
        [Description("Wednesday")]
        Wednesday,
        [Description("Thursday")]
        Thursday,
        [Description("Friday")]
        Friday,
        [Description("None")]
        None = -1
    }

    public static class HelpfulClass
    {
        private static readonly ConcurrentDictionary<string, string> DisplayNameCache = new ConcurrentDictionary<string, string>();
        public static string DisplayName(this Enum value)
        {
            var key = $"{value.GetType().FullName}.{value}";

            var displayName = DisplayNameCache.GetOrAdd(key, x =>
            {
                var name = (DescriptionAttribute[])value
                    .GetType()
                    .GetTypeInfo()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);

                return name.Length > 0 ? name[0].Description : value.ToString();
            });

            return displayName;
        }

        public static string RandomLessonWeek(ListLesson listlesson, List<WeekList> weeklist)
        {
            Week random = (Week)new Random().Next((int)Week.Monday, (int)Week.Friday);
            WeekList oneweek = weeklist.Where(i => i.Name == random.DisplayName()).First();

            if (!oneweek.Lesson.Any(i => (i.Name == listlesson.Name) ||
                                        (i.Name != listlesson.Name &&
                                         i.Time == listlesson.Time)))
                return oneweek.Name;
            else if (weeklist.GroupBy(i => i.Name).Count() == 5)
                return weeklist.FirstOrDefault(i => i.Name != oneweek.Name &&
                                                    i.Lesson.Any(i => (i.Name != listlesson.Name) ||
                                                                (i.Name == listlesson.Name &&
                                                                 i.Time != listlesson.Time)))?.Name ?? Week.None.DisplayName();

            return Week.None.DisplayName();
        }

        public static void SaveDataInDesktop(List<WeekList> tableWithWeek, ObservableCollection<ListLesson> listLesson)
        {
            var temp = new
            {
                Table = tableWithWeek,
                List = listLesson
            };

            string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Lesson.json", json);
        }
        public static void SaveDataInFolder(string path,List<WeekList> tableWithWeek, ObservableCollection<ListLesson> listLesson)
        {
            var temp = new
            {
                Table = tableWithWeek,
                List = listLesson
            };

            string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static DataTable CreateTable(List<WeekList> week)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn() {ColumnName = "CountLesson",                      Caption = "№"},
                new DataColumn() {ColumnName = Week.Monday.ToString() + "Time",    Caption = " "},
                new DataColumn() {ColumnName = Week.Monday.ToString(),             Caption = "Понидельник"},
                new DataColumn() {ColumnName = Week.Tuesday.ToString() + "Time",   Caption = " "},
                new DataColumn() {ColumnName = Week.Tuesday.ToString(),            Caption = "Вторник"},
                new DataColumn() {ColumnName = Week.Wednesday.ToString() + "Time", Caption = " "},
                new DataColumn() {ColumnName = Week.Wednesday.ToString(),           Caption = "Среда"},
                new DataColumn() {ColumnName = Week.Thursday.ToString() + "Time",   Caption = " "},
                new DataColumn() {ColumnName = Week.Thursday.ToString(),            Caption = "Четверг"},
                new DataColumn() {ColumnName = Week.Friday.ToString() + "Time",     Caption = " "},
                new DataColumn() {ColumnName = Week.Friday.ToString(),              Caption = "Пятница"}
            });

            for (int i = 0; i < week.Max(i => i.Lesson.Count); i++)
            {
                (string, string) Monday = (string.Empty, string.Empty);
                (string, string) Tuesday = Monday;
                (string, string) Wednesday = Monday;
                (string, string) Thursday = Monday;
                (string, string) Friday = Monday;

                if (i == 6) break;

                if (week.Where(i => i.Name == Week.Monday.DisplayName()).First().Lesson.Count() >= i + 1)
                    Monday = (week.Where(i => i.Name == Week.Monday.DisplayName()).First().Lesson[i].Name,
                              week.Where(i => i.Name == Week.Monday.DisplayName()).First().Lesson[i].Time.ToString());
                if (week.Where(i => i.Name == Week.Tuesday.DisplayName()).First().Lesson.Count() >= i + 1)
                    Tuesday = (week.Where(i => i.Name == Week.Tuesday.DisplayName()).First().Lesson[i].Name,
                               week.Where(i => i.Name == Week.Tuesday.DisplayName()).First().Lesson[i].Time.ToString());
                if (week.Where(i => i.Name == Week.Wednesday.DisplayName()).First().Lesson.Count() >= i + 1)
                    Wednesday = (week.Where(i => i.Name == Week.Wednesday.DisplayName()).First().Lesson[i].Name,
                                 week.Where(i => i.Name == Week.Wednesday.DisplayName()).First().Lesson[i].Time.ToString());
                if (week.Where(i => i.Name == Week.Thursday.DisplayName()).First().Lesson.Count() >= i + 1)
                    Thursday = (week.Where(i => i.Name == Week.Thursday.DisplayName()).First().Lesson[i].Name,
                                week.Where(i => i.Name == Week.Thursday.DisplayName()).First().Lesson[i].Time.ToString());
                if (week.Where(i => i.Name == Week.Friday.DisplayName()).First().Lesson.Count() >= i + 1)
                    Friday = (week.Where(i => i.Name == Week.Friday.DisplayName()).First().Lesson[i].Name,
                              week.Where(i => i.Name == Week.Friday.DisplayName()).First().Lesson[i].Time.ToString());
                dt.Rows.Add(i + 1,
                            Monday.Item2,
                            Monday.Item1,
                            Tuesday.Item2,
                            Tuesday.Item1,
                            Wednesday.Item2,
                            Wednesday.Item1,
                            Thursday.Item2,
                            Thursday.Item1,
                            Friday.Item2,
                            Friday.Item1);
            }

            return dt;
        }
    }
}
