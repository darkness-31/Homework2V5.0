using MaterialSkin;
using MaterialSkin.Controls;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using static System.Windows.Forms.ListView;
using static System.Windows.Forms.ListViewItem;

namespace Homework2V5._0
{
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
            ListViewItemCollection ItemCollection = ListViewLesson.Items;
            foreach(ListViewItem item in ItemCollection)
            {
                if (listLessons.Any(i => i.Name == item.Text && i.Time.ToString() == item.SubItems[1].Text))
                {
                    item.SubItems[2].Text = (int.Parse(item.SubItems[2].Text) + 1).ToString();
                    return;
                }
            }

            ObservableCollection<ListLesson> lesson = sender as ObservableCollection<ListLesson>;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<int> hours = new List<int>();
            for (int i = 0; i <= 24; i++)
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
                MaterialMessageBox.Show( "Нет имени урока","Ошибка", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error, 
                    false, 
                    FlexibleMaterialForm.ButtonsPosition.Center);
            TimeOnly time = new TimeOnly(int.Parse(ComboBoxHour.Text), int.Parse(ComboBoxMinuts.Text));
            listLessons.Add(new ListLesson(name, time));
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
}