using MaterialSkin;
using MaterialSkin.Controls;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using static System.Windows.Forms.ListView;
using static System.Windows.Forms.ListViewItem;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;

namespace Homework2V5._0
{
    public partial class MainForm : MaterialForm
    {
        public ObservableCollection<ListLesson> listLessons = new ObservableCollection<ListLesson>();
        public List<WeekList> weekWork = new List<WeekList>();

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

            ListViewItemCollection ItemCollection = LessonListView.Items;
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

            List<ListLesson> LMonday = new List<ListLesson>(6);
            List<ListLesson> LTuesday = new List<ListLesson>(6);
            List<ListLesson> LWednesday = new List<ListLesson>(6);
            List<ListLesson> LThursday = new List<ListLesson>(6);
            List<ListLesson> LFriday = new List<ListLesson>(6);

            foreach (ListLesson item in listLessons)
            {
                switch (new Random().Next(0, 5))
                {
                    case (int)Week.Monday:
                        LMonday.Add(item);
                        LMonday = LMonday.OrderBy(i => i.Time).ToList<ListLesson>();
                        break;
                    case (int)Week.Tuesday:
                        LTuesday.Add(item);
                        LTuesday = LTuesday.OrderBy(i => i.Time).ToList<ListLesson>();
                        break;
                    case (int)Week.Wednesday:
                        LWednesday.Add(item);
                        LWednesday = LWednesday.OrderBy(i => i.Time).ToList<ListLesson>();
                        break;
                    case (int)Week.Thursday:
                        LThursday.Add(item);
                        LThursday = LThursday.OrderBy(i => i.Time).ToList<ListLesson>();
                        break;
                    case (int)Week.Friday:
                        LFriday.Add(item);
                        LFriday = LFriday.OrderBy(i => i.Time).ToList<ListLesson>();
                        break;
                }
            }

            weekWork.Add(new WeekList("Monday", LMonday));
            weekWork.Add(new WeekList("Tuesday", LTuesday));
            weekWork.Add(new WeekList("Wednesday", LWednesday));
            weekWork.Add(new WeekList("Thursday", LThursday));
            weekWork.Add(new WeekList("Friday", LFriday));

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
                    (i + 1).ToString(),
                    HelpfulClass.CheckTimeDayToString(Monday.Time),
                    Monday.Name,
                    HelpfulClass.CheckTimeDayToString(Tuesday.Time),
                    Tuesday.Name,
                    HelpfulClass.CheckTimeDayToString(Wednesday.Time),
                    Wednesday.Name,
                    HelpfulClass.CheckTimeDayToString(Thursday.Time),
                    Thursday.Name,
                    HelpfulClass.CheckTimeDayToString(Friday.Time),
                    Friday.Name
                );
            }

            GridLesson.DataSource = new DataTable();
            GridLesson.DataSource = dt;
        }

        private void ClearList_Click(object sender, EventArgs e)
        {
            LessonListView.Items.Clear();
            listLessons.Clear();
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            HelpfulClass.SaveDataInDesktop(weekWork, listLessons);
        }

        private void SaveAsData_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "json file (*.json)|*.json";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                HelpfulClass.SaveDataInFolder(sfd.FileName, weekWork, listLessons);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (weekWork.Count() != 0 ||
                listLessons.Count() != 0)
                HelpfulClass.SaveDataInDesktop(weekWork, listLessons);
            this.Close();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "json file (*.json)|*.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(ofd.FileName);
                    string RTE = sr.ReadToEnd();

                    JObject json = JObject.Parse(RTE);

                    listLessons.Clear();
                    LessonListView.Items.Clear();
                    foreach (var item in json["List"].Select(a => new ListLesson((string?)a["Name"], new TimeOnly((long)a["Time"]["Ticks"]))).ToList())
                    {
                        listLessons.Add(item);
                    }

                    weekWork.Clear();
                    weekWork = json["Table"].Select(a => new WeekList
                        (
                            (string)a["NameWeek"],
                            a["Lessons"].Select(i => new ListLesson
                                (
                                    (string)i["Name"],
                                    new TimeOnly((long)i["Time"]["Ticks"])
                                )).ToList()
                        )).ToList();

                    GridLesson.DataSource = HelpfulClass.GenerateTable(weekWork);

                }
                catch (Exception ex)
                {
                        MessageBox.Show($"Неправильный json\n\n{ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }

        private async void ExportFileTXT_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "text file (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName, System.Text.Encoding.UTF8);
                string? line;
                while((line = await sr.ReadLineAsync()) != null)
                {
                    listLessons.Add(new ListLesson(line, new TimeOnly(new Random().Next(8,18),new Random().Next(0,59))));
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!LessonListView.Focused)
                return;

            var _temp = LessonListView.FocusedItem;

            if (_temp == null)
                return;

            var Name  = _temp.SubItems[0].Text;
            var Time = _temp.SubItems[1].Text;
            var Count = _temp.SubItems[2].Text;

            foreach (var item in listLessons)
            {
                if (item.Name == Name &&
                    item.Time.ToString("H:mm") == Time)
                {
                    listLessons.Remove(item);
                    LessonListView.Items.Remove(_temp);
                    return;
                }
            }
        }
    }
}