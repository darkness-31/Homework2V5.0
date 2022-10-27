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
using System.Reflection.Metadata.Ecma335;
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

        public static DataTable GenerateTable(List<WeekList> week)
        {
            if (week.Count() == 0)
                return new DataTable();
            
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

            List<ListLesson> LMonday =    week[0].Lessons;
            List<ListLesson> LTuesday =   week[1].Lessons;
            List<ListLesson> LWednesday = week[2].Lessons;
            List<ListLesson> LThursday =  week[3].Lessons;
            List<ListLesson> LFriday =    week[4].Lessons;

            for (int i = 0; i < 6; i++)
            {
                ListLesson Monday = new ListLesson(string.Empty, new TimeOnly(0));
                ListLesson Tuesday = new ListLesson(string.Empty, new TimeOnly(0));
                ListLesson Wednesday = new ListLesson(string.Empty, new TimeOnly(0));
                ListLesson Thursday = new ListLesson(string.Empty, new TimeOnly(0));
                ListLesson Friday = new ListLesson(string.Empty, new TimeOnly(0));

                if (LMonday.Count() > i)
                {
                    Monday = LMonday[i];
                }
                if (LTuesday.Count() > i)
                {
                    Tuesday = LTuesday[i];
                }
                if (LWednesday.Count() > i)
                {
                    Wednesday = LWednesday[i];
                }
                if (LThursday.Count() > i)
                {
                    Thursday = LThursday[i];
                }
                if (LFriday.Count() > i)
                {
                    Friday = LFriday[i];
                }

                dt.Rows.Add
                (
                    i.ToString(),
                    CheckTimeDayToString(Monday.Time),
                    Monday.Name,
                    CheckTimeDayToString(Tuesday.Time),
                    Tuesday.Name,
                    CheckTimeDayToString(Wednesday.Time),
                    Wednesday.Name,
                    CheckTimeDayToString(Thursday.Time),
                    Thursday.Name,
                    CheckTimeDayToString(Friday.Time),
                    Friday.Name
                );
            }
            return dt;
        }

        public static string CheckTimeDayToString(TimeOnly time) => time == new TimeOnly(0) ? "" : time.ToString("H:mm");
    }
}
