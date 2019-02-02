using Microservice.BussinessLogic.Services;
using Microservice.BussinessLogic.Services.Master;
using Microservice.DataAccess.Context;
using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Management_Bootcamp_WPF
{
    /// <summary>
    /// Interaction logic for MenuMentor.xaml
    /// </summary>
    public partial class MenuMentor : Window
    {
        ILessonService _lessonService = new LessonService();
        LessonParam lessonParam = new LessonParam();

        IDepartmentService _departmentService = new DepartmentService();
        DepartmentParam departmentParam = new DepartmentParam();

        MyContext _context = new MyContext();
        //Department supplier = new Department();

        public MenuMentor()
        {
            InitializeComponent();
        }

        private void LoadGridLesson()
        {
            textBlockIdLesson.Text = "";
            textBoxNameLesson.Text = "";
            comboBoxLevelLesson.Text = "";
            comboBoxDepartmentLesson.Text = "";
            dataGridLesson.ItemsSource = _lessonService.Get();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridLesson.ItemsSource = _lessonService.Get();         //Data grid department
            comboBoxDepartmentLesson.ItemsSource = _context.Departments.Where(x => x.IsDelete == false).ToList();
        }

        private void buttonSearchLesson_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchLesson.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchLesson.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchLesson.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridLesson.ItemsSource = _lessonService.Search(textBoxSearchLesson.Text, comboBoxSearchLesson.Text);
                }
            }
        }

        private void buttonInsertLesson_Click(object sender, RoutedEventArgs e)
        {
            lessonParam.Name = textBoxNameLesson.Text;
            lessonParam.level = comboBoxLevelLesson.Text;
            lessonParam.Departements = comboBoxDepartmentLesson.SelectedValue.ToString();
            if (string.IsNullOrEmpty(textBoxNameLesson.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameLesson.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _lessonService.Insert(lessonParam);
                LoadGridLesson();
            }
        }

        private void buttonUpdateLesson_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridLesson.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                lessonParam.Name = textBoxNameLesson.Text;
                lessonParam.level = comboBoxLevelLesson.Text;
                lessonParam.Departements = comboBoxDepartmentLesson.SelectedValue.ToString();
                if (string.IsNullOrEmpty(textBoxNameLesson.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameLesson.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _lessonService.Update(Convert.ToInt16(textBlockIdLesson.Text), lessonParam);
                    LoadGridLesson();
                }
            }
        }

        private void buttonDeleteLesson_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridLesson.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _lessonService.Delete(Convert.ToInt16(textBlockIdLesson.Text));
                LoadGridLesson();
            }
        }

        private void dataGridLesson_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridLesson.SelectedItem;
            if (dataGridLesson.SelectedIndex < 0)
            {
                textBlockIdLesson.Text = "";
                textBoxNameLesson.Text = "";
                comboBoxLevelLesson.Text = "";
                comboBoxDepartmentLesson.Text = "";
            }
            else
            {
                textBlockIdLesson.Text = (dataGridLesson.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameLesson.Text = (dataGridLesson.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                comboBoxLevelLesson.Text = (dataGridLesson.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                comboBoxDepartmentLesson.Text = (dataGridLesson.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void textBoxNameLesson_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
