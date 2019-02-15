using Management_Bootcamp_WPF.Properties;
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

        // IDetailLessonService _detailLessonService = new DetailLessonService();
        //DetailLessonParam detailLessonParam = new DetailLessonParam();

        IScheduleService _scheduleService = new ScheduleService();
        ScheduleParam scheduleParam = new ScheduleParam();

        IDailyScoreService _dailyScoreService = new DailyScoreService();
        DailyScoreParam dailyScoreParam = new DailyScoreParam();

        IStudentService _studentService = new StudentService();
        StudentParam studentParam = new StudentParam();

        IWeeklyScoreService _weeklyScoreService = new WeeklyScoreService();
        WeeklyScoreParam taskScoreParam = new WeeklyScoreParam();

        IEmployeeService _employeeService = new EmployeeService();
        EmployeeParam employeeParam = new EmployeeParam();

        IDepartmentService _departmentService = new DepartmentService();
        //DepartmentParam departmentParam = new DepartmentParam();

        MyContext _context = new MyContext();
        //Department supplier = new Department();

        public MenuMentor()
        {
            InitializeComponent();
            textBlockMentor.Text = Convert.ToString(Settings.Default.username);
            textBlockIdMentor.Text = Convert.ToString(Settings.Default.Id);
        }
        private void buttonLogoutMentor_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void LoadGridLesson()
        {
            textBlockIdLesson.Text = "";
            textBoxNameLesson.Text = "";
            comboBoxLevelLesson.Text = "";
            comboBoxDepartmentLesson.Text = "";
            dataGridLesson.ItemsSource = _lessonService.Get();
        }

        //private void LoadGridDetailLesson()
        //{
        //    textBlockIdDetailLesson.Text = "";
        //    textBoxNameDetailLesson.Text = "";
        //    textBoxLinkfileDetailLesson.Text = "";
        //    comboBoxLessonDetailLesson.Text = "";
        //    dataGridDetailLesson.ItemsSource = _detailLessonService.Get();
        //}

        private void LoadGridSchedule()
        {
            textBlockIdSchedule.Text = "";
            comboBoxLessonSchedule.Text = "";
            comboBoxClassSchedule.Text = "";
            comboBoxRoomSchedule.Text = "";
            DatePickerStartSchedule.Text = "";
            DatePickerEndSchedule.Text = "";
            dataGridSchedule.ItemsSource = _scheduleService.Get();
        }

        private void LoadGridDailyScore()
        {
            textBlockIdDailyScore.Text = "";
            comboBoxLessonDailyScore.Text = "";
            textBoxScore1DailyScore.Text = "";
            textBoxScore2DailyScore.Text = "";
            textBoxScore3DailyScore.Text = "";
            textBlockIdStudent.Text = "";
            dataGridStudentsDailyScore.ItemsSource = _studentService.Join(Settings.Default.Id);
            dataGridDailyScore.ItemsSource = _dailyScoreService.Get();
        }

        private void LoadGridTaskScore()
        {
            textBlockIdTaskScore.Text = "";
            textBoxNameTaskScore.Text = "";
            textBoxScore1TaskScore.Text = "";
            textBoxScore2TaskScore.Text = "";
            textBoxScore3TaskScore.Text = "";
            textBoxScore4TaskScore.Text = "";
            textBoxScore5TaskScore.Text = "";
            textBlockIdStudentTaskScore.Text = "";
            dataGridStudentsTaskScore.ItemsSource = _studentService.Join(Settings.Default.Id);
            dataGridTaskScore.ItemsSource = _weeklyScoreService.Get();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //manage lesson
            dataGridLesson.ItemsSource = _lessonService.Get();         //Data grid department
            comboBoxDepartmentLesson.ItemsSource = _context.Departments.Where(x => x.IsDelete == false).ToList();

            //manage detail lesson
            //dataGridDetailLesson.ItemsSource = _detailLessonService.Get();
            //comboBoxLessonDetailLesson.ItemsSource = _context.Lessons.Where(x => x.IsDelete == false).ToList();

            //manage schedule
            dataGridSchedule.ItemsSource = _scheduleService.Get();
            comboBoxLessonSchedule.ItemsSource = _context.Lessons.Where(x => x.IsDelete == false).ToList();
            comboBoxClassSchedule.ItemsSource = _context.Classes.Where(x => x.IsDelete == false).ToList();
            comboBoxRoomSchedule.ItemsSource = _context.Rooms.Where(x => x.IsDelete == false).ToList();

            //manage daily score
            comboBoxLessonDailyScore.ItemsSource = _context.Lessons.Where(x => x.IsDelete == false).ToList();
            dataGridDailyScore.ItemsSource = _dailyScoreService.Get();
            dataGridStudentsDailyScore.ItemsSource = _studentService.Join(Settings.Default.Id);

            //manage weekly score
            dataGridStudentsTaskScore.ItemsSource = _studentService.Join(Settings.Default.Id);
            dataGridTaskScore.ItemsSource = _weeklyScoreService.Get();

            //manage history lesson
            //dataGridHistoryLesson.ItemsSource = _historyLessonService.Get();
        }

        private void loadcombo()
        {
            comboBoxDepartmentLesson.ItemsSource = _context.Departments.Where(x => x.IsDelete == false).ToList();
            //comboBoxLessonDetailLesson.ItemsSource = _context.Lessons.Where(x => x.IsDelete == false).ToList();
            comboBoxLessonSchedule.ItemsSource = _context.Lessons.Where(x => x.IsDelete == false).ToList();
            comboBoxClassSchedule.ItemsSource = _context.Classes.Where(x => x.IsDelete == false).ToList();
            comboBoxRoomSchedule.ItemsSource = _context.Rooms.Where(x => x.IsDelete == false).ToList();
            comboBoxLessonDailyScore.ItemsSource = _context.Lessons.Where(x => x.IsDelete == false).ToList();
        }
        //================================================================================================================================
        //Menu Detail Lesson

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
            lessonParam.Level = comboBoxLevelLesson.Text;
            lessonParam.Departements = comboBoxDepartmentLesson.SelectedValue.ToString();
            lessonParam.LinkFile = textBoxLinkFileLesson.Text;
            lessonParam.Employees = textBlockIdMentor.Text;
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
                loadcombo();
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
                lessonParam.Level = comboBoxLevelLesson.Text;
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
                    loadcombo();
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
                loadcombo();
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

        //===============================================================================================================================
        //Schedule
        private void buttonSearchSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchSchedule.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(comboBoxSearchSchedule.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(comboBoxSearchSchedule.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridSchedule.ItemsSource = _scheduleService.Search(textBoxSearchSchedule.Text, comboBoxSearchSchedule.Text);
                }
            }
        }

        private void buttonInsertSchedule_Click(object sender, RoutedEventArgs e)
        {
            //scheduleParam.Employees = textBlockIdMentor.Text;
            scheduleParam.lessons = comboBoxLessonSchedule.SelectedValue.ToString();
            scheduleParam.classes = comboBoxClassSchedule.SelectedValue.ToString();
            scheduleParam.room = comboBoxRoomSchedule.SelectedValue.ToString();
            DateTime? selectedDateStart = DatePickerStartSchedule.SelectedDate;
            DateTime? selectedDateEnd = DatePickerEndSchedule.SelectedDate;
            if (selectedDateStart.HasValue && selectedDateEnd.HasValue)
            {
                scheduleParam.DateStart = selectedDateStart.Value;
                scheduleParam.DateEnd = selectedDateEnd.Value;
            }
            if (string.IsNullOrEmpty(comboBoxLessonSchedule.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(comboBoxLessonSchedule.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _scheduleService.Insert(scheduleParam);
                LoadGridSchedule();
                loadcombo();
            }
            // _scheduleService.Insert(scheduleParam);
            //  LoadGridSchedule();
        }

        private void buttonUpdateSchedule_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridSchedule.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                //scheduleParam.employees = textBlockIdMentor.Text;
                scheduleParam.lessons = comboBoxLessonSchedule.SelectedValue.ToString();
                scheduleParam.classes = comboBoxClassSchedule.SelectedValue.ToString();
                scheduleParam.room = comboBoxRoomSchedule.SelectedValue.ToString();
                DateTime? selectedDateStart = DatePickerStartSchedule.SelectedDate;
                DateTime? selectedDateEnd = DatePickerEndSchedule.SelectedDate;
                if (selectedDateStart.HasValue && selectedDateEnd.HasValue)
                {
                    scheduleParam.DateStart = selectedDateStart.Value;
                    scheduleParam.DateEnd = selectedDateEnd.Value;
                }
                if (string.IsNullOrEmpty(comboBoxLessonSchedule.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(comboBoxLessonSchedule.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _scheduleService.Update(Convert.ToInt16(textBlockIdSchedule.Text), scheduleParam);
                    LoadGridSchedule();
                    loadcombo();
                }
            }
        }

        private void buttonDeleteSchedule_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridSchedule.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _scheduleService.Delete(Convert.ToInt16(textBlockIdSchedule.Text));
                LoadGridSchedule();
                loadcombo();
            }
        }

        private void dataGridSchedule_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridSchedule.SelectedItem;
            if (dataGridSchedule.SelectedIndex < 0)
            {
                textBlockIdSchedule.Text = "";
                comboBoxLessonSchedule.Text = "";
                comboBoxClassSchedule.Text = "";
                comboBoxRoomSchedule.Text = "";
                DatePickerStartSchedule.Text = "";
                DatePickerEndSchedule.Text = "";
            }
            else
            {
                textBlockIdSchedule.Text = (dataGridSchedule.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                comboBoxLessonSchedule.Text = (dataGridSchedule.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                comboBoxClassSchedule.Text = (dataGridSchedule.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                comboBoxRoomSchedule.Text = (dataGridSchedule.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                DatePickerStartSchedule.Text = (dataGridSchedule.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                DatePickerEndSchedule.Text = (dataGridSchedule.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        //==============================================================================================================================
        

        private void buttonSearchDailyScore_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchDailyScore.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(comboBoxSearchDailyScore.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(comboBoxSearchDailyScore.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridDailyScore.ItemsSource = _dailyScoreService.Search(textBoxSearchDailyScore.Text, comboBoxSearchDailyScore.Text);
                }
            }
        }

        private void buttonInsertDailyScore_Click(object sender, RoutedEventArgs e)
        {
            dailyScoreParam.Score1 = Convert.ToDouble(textBoxScore1DailyScore.Text);
            dailyScoreParam.Score2 = Convert.ToDouble(textBoxScore2DailyScore.Text);
            dailyScoreParam.Score3 = Convert.ToDouble(textBoxScore3DailyScore.Text);
            dailyScoreParam.Students = textBlockIdStudent.Text;
            dailyScoreParam.Employees = textBlockIdMentor.Text;
            dailyScoreParam.Lessons = comboBoxLessonDailyScore.SelectedValue.ToString();
            if (string.IsNullOrEmpty(textBoxScore1DailyScore.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxScore1DailyScore.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _dailyScoreService.Insert(dailyScoreParam);
                LoadGridDailyScore();
                loadcombo();
            }
        }

        private void buttonUpdateDailyScore_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridDailyScore.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                dailyScoreParam.Score1 = Convert.ToDouble(textBoxScore1DailyScore.Text);
                dailyScoreParam.Score2 = Convert.ToDouble(textBoxScore2DailyScore.Text);
                dailyScoreParam.Score3 = Convert.ToDouble(textBoxScore3DailyScore.Text);
                dailyScoreParam.Students = textBlockIdStudent.Text;
                dailyScoreParam.Employees = textBlockIdMentor.Text;
                dailyScoreParam.Lessons = comboBoxLessonDailyScore.SelectedValue.ToString();
                if (string.IsNullOrEmpty(textBoxScore1DailyScore.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxScore1DailyScore.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _dailyScoreService.Update(Convert.ToInt16(textBlockIdDailyScore.Text), dailyScoreParam);
                    LoadGridDailyScore();
                    loadcombo();
                }
            }
        }

        private void buttonDeleteDailyScore_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridDailyScore.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _dailyScoreService.Delete(Convert.ToInt16(textBlockIdDailyScore.Text));
                LoadGridDailyScore();
                loadcombo();
            }
        }

        private void dataGridStudentsDailyScore_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridStudentsDailyScore.SelectedItem;
            if (dataGridStudentsDailyScore.SelectedIndex < 0)
            {
                textBlockIdStudent.Text = "";
            }
            else
            {
                textBlockIdStudent.Text = (dataGridStudentsDailyScore.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void dataGridDailyScore_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridDailyScore.SelectedItem;
            if (dataGridDailyScore.SelectedIndex < 0)
            {
                textBlockIdDailyScore.Text = "";
                textBoxScore1DailyScore.Text = "";
                textBoxScore2DailyScore.Text = "";
                textBoxScore3DailyScore.Text = "";
                comboBoxLessonDailyScore.Text = "";
                textBlockIdStudent.Text = "";
            }
            else
            {
                textBlockIdDailyScore.Text = (dataGridDailyScore.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxScore1DailyScore.Text = (dataGridDailyScore.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                textBoxScore2DailyScore.Text = (dataGridDailyScore.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                textBoxScore3DailyScore.Text = (dataGridDailyScore.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                comboBoxLessonDailyScore.Text = (dataGridDailyScore.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                textBlockIdStudent.Text = (dataGridDailyScore.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        //=================================================================================================================================
        //MANAGE TASK SCORE

        private void buttonSearchTaskScore_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchTaskScore.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(comboBoxSearchTaskScore.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(comboBoxSearchTaskScore.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridTaskScore.ItemsSource = _weeklyScoreService.Search(textBoxSearchTaskScore.Text, comboBoxSearchTaskScore.Text);
                }
            }
        }

        //private void buttonSearchStudentTaskScore_Click(object sender, RoutedEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(comboBoxSearchStudentTaskScore.Text) == true)
        //    {
        //        MessageBox.Show("Please choice category search!");
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(comboBoxSearchStudentTaskScore.Text) == true)
        //        {
        //            MessageBox.Show("Please insert keywoard search!");
        //        }
        //        else if (string.IsNullOrWhiteSpace(comboBoxSearchStudentTaskScore.Text) == true)
        //        {
        //            MessageBox.Show("Don't insert white space");
        //        }
        //        else
        //        {
        //            dataGridStudentsTaskScore.ItemsSource = _studentService.Search(textBoxSearchStudentTaskScore.Text, comboBoxSearchStudentTaskScore.Text);
        //        }
        //    }
        //}

        private void buttonInsertTaskScore_Click(object sender, RoutedEventArgs e)
        {
            taskScoreParam.Name = textBoxNameTaskScore.Text;
            taskScoreParam.Score1 = Convert.ToDouble(textBoxScore1TaskScore.Text);
            taskScoreParam.Score2 = Convert.ToDouble(textBoxScore2TaskScore.Text);
            taskScoreParam.Score3 = Convert.ToDouble(textBoxScore3TaskScore.Text);
            taskScoreParam.Score4 = Convert.ToDouble(textBoxScore4TaskScore.Text);
            taskScoreParam.Score5 = Convert.ToDouble(textBoxScore5TaskScore.Text);
            taskScoreParam.students = textBlockIdStudentTaskScore.Text;
            taskScoreParam.employees = textBlockIdMentor.Text;
            if (string.IsNullOrEmpty(textBoxScore1TaskScore.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxScore1TaskScore.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _weeklyScoreService.Insert(taskScoreParam);
                LoadGridTaskScore();
            }
        }

        private void buttonUpdateTaskScore_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridTaskScore.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                taskScoreParam.Name = textBoxNameTaskScore.Text;
                taskScoreParam.Score1 = Convert.ToDouble(textBoxScore1TaskScore.Text);
                taskScoreParam.Score2 = Convert.ToDouble(textBoxScore2TaskScore.Text);
                taskScoreParam.Score3 = Convert.ToDouble(textBoxScore3TaskScore.Text);
                taskScoreParam.Score4 = Convert.ToDouble(textBoxScore4TaskScore.Text);
                taskScoreParam.Score5 = Convert.ToDouble(textBoxScore5TaskScore.Text);
                taskScoreParam.students = textBlockIdStudentTaskScore.Text;
                taskScoreParam.employees = textBlockIdMentor.Text;
                if (string.IsNullOrEmpty(textBoxScore1TaskScore.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxScore1TaskScore.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _weeklyScoreService.Update(Convert.ToInt16(textBlockIdTaskScore.Text), taskScoreParam);
                    LoadGridTaskScore();
                }
            }
        }

        private void buttonDeleteTaskScore_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridTaskScore.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _weeklyScoreService.Delete(Convert.ToInt16(textBlockIdTaskScore.Text));
                LoadGridTaskScore();
            }
        }

        private void dataGridStudentsTaskScore_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridStudentsTaskScore.SelectedItem;
            if (dataGridStudentsTaskScore.SelectedIndex < 0)
            {
                textBlockIdStudentTaskScore.Text = "";
            }
            else
            {
                textBlockIdStudentTaskScore.Text = (dataGridStudentsTaskScore.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void dataGridTaskScore_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridTaskScore.SelectedItem;
            if (dataGridTaskScore.SelectedIndex < 0)
            {
                textBlockIdTaskScore.Text = "";
                textBoxNameTaskScore.Text = "";
                textBoxScore1TaskScore.Text = "";
                textBoxScore2TaskScore.Text = "";
                textBoxScore3TaskScore.Text = "";
                textBoxScore4TaskScore.Text = "";
                textBoxScore5TaskScore.Text = "";
                textBlockIdStudentTaskScore.Text = "";
            }
            else
            {
                textBlockIdTaskScore.Text = (dataGridTaskScore.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameTaskScore.Text = (dataGridTaskScore.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                textBoxScore1TaskScore.Text = (dataGridTaskScore.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                textBoxScore2TaskScore.Text = (dataGridTaskScore.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                textBoxScore3TaskScore.Text = (dataGridTaskScore.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                textBoxScore4TaskScore.Text = (dataGridTaskScore.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                textBoxScore5TaskScore.Text = (dataGridTaskScore.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                textBlockIdStudentTaskScore.Text = (dataGridTaskScore.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void dataGridHistoryLesson_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void textBoxNameLesson_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        //Manage ProfileMentor
        private void LoadProfile()
        {
            var get = _employeeService.Get(Settings.Default.Id);
            textBlockIdProfileMentor.Text = Convert.ToString(get.Id);
            textBoxFirstNameProfileMentor.Text = get.FirstName;
            textBoxLastNameProfileMentor.Text = get.LastName;
            dateDobProfileMentor.SelectedDate = Convert.ToDateTime(get.Dob);
            textBoxPobProfileMentor.Text = get.Pob;
            comboBoxGenderProfileMentor.Text = get.Gender;
            comboBoxReligionProfileMentor.Text = get.Religion;
            textBoxPhoneProfileMentor.Text = get.Phone;
            textBoxEmailProfileMentor.Text = get.Email;
            textBoxAddressProfileMentor.Text = get.Address;
            textBoxRtProfileMentor.Text = Convert.ToString(get.RT);
            textBoxRwProfileMentor.Text = Convert.ToString(get.RW);
            textBoxVillageProfileMentor.Text = get.Village;
            textBoxDistrictProfileMentor.Text = get.District;
            textBoxRegencieProfileMentor.Text = get.Regencies;
            textBoxProvienceProfileMentor.Text = get.Provience;
            textBlockUsernameProfileMentor.Text = get.Username;
        }

        private void buttonSaveProfileMentor_Click(object sender, RoutedEventArgs e)
        {
            employeeParam.FirstName = textBoxFirstNameProfileMentor.Text;
            employeeParam.LastName = textBoxLastNameProfileMentor.Text;
            DateTime? selectedDate = dateDobProfileMentor.SelectedDate;
            if (selectedDate.HasValue)
            {
                employeeParam.Dob = selectedDate.Value;
            }
            employeeParam.Pob = textBoxPobProfileMentor.Text;
            employeeParam.Gender = comboBoxGenderProfileMentor.Text;
            employeeParam.Religion = comboBoxReligionProfileMentor.Text;
            employeeParam.Phone = textBoxPhoneProfileMentor.Text;
            employeeParam.Email = textBoxEmailProfileMentor.Text;
            employeeParam.Address = textBoxAddressProfileMentor.Text;
            employeeParam.RT = Convert.ToInt16(textBoxRtProfileMentor.Text);
            employeeParam.RW = Convert.ToInt16(textBoxRwProfileMentor.Text);
            employeeParam.Village = textBoxVillageProfileMentor.Text;
            employeeParam.District = textBoxDistrictProfileMentor.Text;
            employeeParam.Regencies = textBoxRegencieProfileMentor.Text;
            employeeParam.Provience = textBoxProvienceProfileMentor.Text;
            if (string.IsNullOrEmpty(textBoxFirstNameProfileMentor.Text) == true)
            {
                MessageBox.Show("Please insert name employee!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxFirstNameProfileMentor.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _employeeService.UpdatePr(Convert.ToInt16(textBlockIdProfileMentor.Text), employeeParam);
                LoadProfile();
            }
        }

        private void textBoxPhoneProfileMentor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[0-9+]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxEmailProfileMentor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z.0-9@]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxUsernameProfileMentor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxNameProfileMentor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxRtProfileMentor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[1-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonChangeProfileMentor_Click(object sender, RoutedEventArgs e)
        {
            new CheckSecretEmployee().Show();
            this.Close();
        }
    }
}
