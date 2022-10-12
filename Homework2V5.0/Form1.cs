using MaterialSkin;
using MaterialSkin.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using static System.Windows.Forms.ListView;
using static System.Windows.Forms.ListViewItem;

namespace Homework2V5._0
{
    enum Week
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        none = -1
    }

    public partial class MainForm : MaterialForm
    {
        public HelpfulClass helpfulClass = new HelpfulClass();
        public ObservableCollection<ListLesson> listLessons = new ObservableCollection<ListLesson>();

        public MainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepPurple600,
                                                              Primary.DeepPurple700,
                                                              Primary.DeepPurple500,
                                                              Accent.Pink100,
                                                              TextShade.WHITE);

            listLessons.CollectionChanged += new NotifyCollectionChangedEventHandler(listLessons_CollectionChanged);
        }

        private void listLessons_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems == null)
                return;

            ListLesson newLesson = null;
            foreach (var item in e.NewItems)
                newLesson = (ListLesson?)item;

            ListViewItemCollection ItemCollection = ListViewLesson.Items;
            foreach (ListViewItem item in ItemCollection)
            {
                if (newLesson.Name == item.Text && newLesson.Time.ToString() == item.SubItems[1].Text)
                {
                    item.SubItems[2].Text = (int.Parse(item.SubItems[2].Text) + 1).ToString();
                    ClearMenu();
                    return;
                }
            }
            ListViewItem newItem = new ListViewItem();
            ListViewSubItem TimeItem = new ListViewSubItem();
            ListViewSubItem CountItem = new ListViewSubItem();

            newItem.Text = newLesson.Name;
            TimeItem.Text = newLesson.Time.ToString();
            CountItem.Text = "1";

            new ListViewSubItemCollection(owner: newItem) { TimeItem, CountItem };

            ItemCollection.Add(newItem);
            ClearMenu();
        }

        private void ClearMenu()
        {
            NameLessonTextBox.Text = "";
            ComboBoxHour.Text = "0";
            ComboBoxHour.Refresh();
            ComboBoxMinuts.Text = "0";
            ComboBoxMinuts.Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<int> hours = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                hours.Add(i);
            }
            ComboBoxHour.DataSource = hours;

            List<int> minutes = new List<int>();
            for (int i = 0; i < 60; i++)
                minutes.Add(i);
            ComboBoxMinuts.DataSource = minutes;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            var name = NameLessonTextBox.Text.ToString();
            if (name == "")
            {
                MaterialMessageBox.Show("Нет имени урока", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    false,
                    FlexibleMaterialForm.ButtonsPosition.Center);
                return;
            }

            TimeOnly time = new TimeOnly(int.Parse(ComboBoxHour.Text), int.Parse(ComboBoxMinuts.Text));
            listLessons.Add(new ListLesson(name, time));
        }

        private void CreateTable_Click(object sender, EventArgs e)
        {
            if (listLessons.Count == 0)
            {
                MaterialMessageBox.Show("Нет данных для заполнения", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    false,
                    FlexibleMaterialForm.ButtonsPosition.Center);
                return;
            }

            TabMenu.Show();

            List<WeekList> WorkWeek = new List<WeekList>()
            {
                new WeekList(Week.Monday, new List<ListLesson>()),
                new WeekList(Week.Tuesday, new List<ListLesson>()),
                new WeekList(Week.Wednesday, new List<ListLesson>()),
                new WeekList(Week.Thursday, new List<ListLesson>()),
                new WeekList(Week.Friday, new List<ListLesson>())
            };
            foreach (ListLesson item in listLessons)
            {
                switch (RandomLessonWeek(item, WorkWeek))
                {
                    case Week.Monday:
                        WorkWeek.First(i => i.Name == Week.Monday).Lesson.Add(item);
                        break;
                    case Week.Tuesday:
                        WorkWeek.First(i => i.Name == Week.Tuesday).Lesson.Add(item);
                        break;
                    case Week.Wednesday:
                        WorkWeek.First(i => i.Name == Week.Wednesday).Lesson.Add(item);
                        break;
                    case Week.Thursday:
                        WorkWeek.First(i => i.Name == Week.Thursday).Lesson.Add(item);
                        break;
                    case Week.Friday:
                        WorkWeek.First(i => i.Name == Week.Friday).Lesson.Add(item);
                        break;
                    default:
                        break;
                };
            }

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

            for (int i = 0; i < WorkWeek.Max(i => i.Lesson.Count); i++)
            {
                (string, string) Monday = (Name:"", Time:"");
                (string, string) Tuesday = (Name: "", Time: "");
                (string, string) Wednesday = (Name: "", Time: "");
                (string, string) Thursday = (Name: "", Time: "");
                (string, string) Friday = (Name: "", Time: "");

                if (i == 6) break;

                if (WorkWeek.Where(i => i.Name == Week.Monday).First().Lesson.Count() >= i+1)
                    Monday = (WorkWeek.Where(i => i.Name == Week.Monday).First().Lesson[i].Name,
                              WorkWeek.Where(i => i.Name == Week.Monday).First().Lesson[i].Time.ToString());
                if (WorkWeek.Where(i => i.Name == Week.Tuesday).First().Lesson.Count() >= i+1)
                    Tuesday = (WorkWeek.Where(i => i.Name == Week.Tuesday).First().Lesson[i].Name,
                               WorkWeek.Where(i => i.Name == Week.Tuesday).First().Lesson[i].Time.ToString());
                if (WorkWeek.Where(i => i.Name == Week.Wednesday).First().Lesson.Count() >= i+1)
                    Wednesday = (WorkWeek.Where(i => i.Name == Week.Wednesday).First().Lesson[i].Name,
                                 WorkWeek.Where(i => i.Name == Week.Wednesday).First().Lesson[i].Time.ToString());
                if (WorkWeek.Where(i => i.Name == Week.Thursday).First().Lesson.Count() >= i+1)
                    Thursday = (WorkWeek.Where(i => i.Name == Week.Thursday).First().Lesson[i].Name,
                                WorkWeek.Where(i => i.Name == Week.Thursday).First().Lesson[i].Time.ToString());
                if (WorkWeek.Where(i => i.Name == Week.Friday).First().Lesson.Count() >= i+1)
                    Friday = (WorkWeek.Where(i => i.Name == Week.Friday).First().Lesson[i].Name,
                              WorkWeek.Where(i => i.Name == Week.Friday).First().Lesson[i].Time.ToString());
                dt.Rows.Add(i+1, 
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

            GridLesson.DataSource = new DataTable();
            GridLesson.DataSource = dt;
        }

        private Week RandomLessonWeek(ListLesson listlesson, List<WeekList> weeklist)
        {
            Week random = (Week)new Random().Next((int)Week.Monday, (int)Week.Friday);
            WeekList oneweek = weeklist.Where(i => i.Name == random).First();

            if (!oneweek.Lesson.Any(i => (i.Name == listlesson.Name) ||
                                        (i.Name != listlesson.Name &&
                                         i.Time == listlesson.Time)))
                return oneweek.Name;
            else if (weeklist.GroupBy(i => i.Name).Count() == 5)
                return weeklist.FirstOrDefault(i => i.Name != oneweek.Name &&
                                                    i.Lesson.Any(i => (i.Name != listlesson.Name) ||
                                                                (i.Name == listlesson.Name &&
                                                                 i.Time != listlesson.Time)))?.Name ?? Week.none;

            return Week.none;
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void SaveAsData_Click(object sender, EventArgs e)
        {

        }

        private void ClearList_Click(object sender, EventArgs e)
        {
            ListViewLesson.Items.Clear();
            listLessons.Clear();
        }
    }
}