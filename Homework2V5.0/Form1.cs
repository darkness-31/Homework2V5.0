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
        public List<WeekList> WeekWorkTemp = new List<WeekList>();

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

            TabMenu.Show();

            List<WeekList> WorkWeek = new List<WeekList>()
            {
                new WeekList(Week.Monday.DisplayName(), new List<ListLesson>()),
                new WeekList(Week.Tuesday.DisplayName(), new List<ListLesson>()),
                new WeekList(Week.Wednesday.DisplayName(), new List<ListLesson>()),
                new WeekList(Week.Thursday.DisplayName(), new List<ListLesson>()),
                new WeekList(Week.Friday.DisplayName(), new List<ListLesson>())
            };

            foreach (ListLesson item in listLessons)
            {
                switch (HelpfulClass.RandomLessonWeek(item, WorkWeek))
                {
                    case "Monday":
                        WorkWeek.First(i => i.Name == Week.Monday.DisplayName()).Lesson.Add(item);
                        break;
                    case "Tuesday":
                        WorkWeek.First(i => i.Name == Week.Tuesday.DisplayName()).Lesson.Add(item);
                        break;
                    case "Wednesday":
                        WorkWeek.First(i => i.Name == Week.Wednesday.DisplayName()).Lesson.Add(item);
                        break;
                    case "Thursday":
                        WorkWeek.First(i => i.Name == Week.Thursday.DisplayName()).Lesson.Add(item);
                        break;
                    case "Friday":
                        WorkWeek.First(i => i.Name == Week.Friday.DisplayName()).Lesson.Add(item);
                        break;
                    default:
                        break;
                };
            }

            WeekWorkTemp = WorkWeek;

            GridLesson.DataSource = new DataTable();
            GridLesson.DataSource = HelpfulClass.CreateTable(WorkWeek);
        }

        private void ClearList_Click(object sender, EventArgs e)
        {
            LessonListView.Items.Clear();
            listLessons.Clear();
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            HelpfulClass.SaveDataInDesktop(WeekWorkTemp, listLessons);
        }

        private void SaveAsData_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "json file (*.json)|*.json";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                HelpfulClass.SaveDataInFolder(sfd.FileName, WeekWorkTemp, listLessons);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            HelpfulClass.SaveDataInDesktop(WeekWorkTemp, listLessons);
            this.Close();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "json file (*.json)|*.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                JObject json = JObject.Parse(sr.ReadToEnd());
                listLessons.Clear();
                foreach (var item in json["List"].Select(a => new ListLesson((string?)a["Name"],new TimeOnly((long)a["Time"]["Ticks"]))).ToList())
                {
                    listLessons.Add(item);
                }
                WeekWorkTemp.Clear();
                WeekWorkTemp = json["Table"].Select(a => new WeekList
                    (
                        (string)a["Name"],
                        a["Lesson"].Select(i => new ListLesson
                            (
                                (string)i["Name"],
                                new TimeOnly((long)i["Time"]["Ticks"])
                            )).ToList()
                    )).ToList();
                GridLesson.DataSource = HelpfulClass.CreateTable(WeekWorkTemp);
            }
        }
    }
}