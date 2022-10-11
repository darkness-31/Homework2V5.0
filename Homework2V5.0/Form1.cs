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
        Понидельник,
        Вторник,
        Среда,
        Четверг,
        Пятница
    }

    public partial class MainForm : MaterialForm
    {

        public ObservableCollection<ListLesson> listLessons = new ObservableCollection<ListLesson>();

        public MainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500,
                                                              Primary.Indigo300,
                                                              Primary.Indigo600,
                                                              Accent.Amber400,
                                                              TextShade.WHITE);

            listLessons.CollectionChanged += new NotifyCollectionChangedEventHandler(listLessons_CollectionChanged);
        }

        private void listLessons_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ListLesson newLesson = null;
            foreach (var item in e.NewItems)
                newLesson = (ListLesson?)item;

            ListViewItemCollection ItemCollection = ListViewLesson.Items;
            foreach(ListViewItem item in ItemCollection)
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
            for (int i=0; i <= 60; i++)
                minutes.Add(i);
            ComboBoxMinuts.DataSource = minutes;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            var name = NameLessonTextBox.Text.ToString();
            if (name == "")
            {
                MaterialMessageBox.Show( "Нет имени урока","Ошибка", 
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
  
            Random rnd = new Random();

            foreach (ListLesson item in listLessons)
            {

            }
        }
    }

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

    public class ListLessonWeek
    {
        internal ListLesson[] Lesson { get; set; } = new ListLesson[6];
        internal Week NameWeek { get; set; }
    }
}