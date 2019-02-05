using Management_Bootcamp_WPF.Properties;
using Microservice.BussinessLogic.Services;
using Microservice.BussinessLogic.Services.Master;
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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MenuStudent : Window
    {
        //ISkillService _skillService = new SkillService();
        IAchievementService _achievementService = new AchievementService();
        IOrganizationService _organizationService = new OrganizationService();
        IWorkExperienceService _workExperienceService = new WorkExperienceService();
        IErrorBankService _errorBankService = new ErrorBankService();
        //IDetailLessonService _detailLessonService = new DetailLessonService();
        //IHistoryDetailLessonService _historyDetailLessonService = new HistoryDetailLessonService();
        //SkillParam skillParam = new SkillParam();
        AchievementParam achievementParam = new AchievementParam();
        OrganizationParam organizationParam = new OrganizationParam();
        WorkExperienceParam workExperienceParam = new WorkExperienceParam();
        ErrorBankParam errorBankParam = new ErrorBankParam();
        //DetailLessonParam detailLessonParam = new DetailLessonParam();
        //HistoryDetailLessonParam historyDetailLessonParam = new HistoryDetailLessonParam();
        public MenuStudent()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dataGridSkill.ItemsSource = _skillService.Get();
            dataGridAchievement.ItemsSource = _achievementService.GetStudent(Settings.Default.Id);
            dataGridOrganization.ItemsSource = _organizationService.GetStudent(Settings.Default.Id);
            dataGridWorkExperience.ItemsSource = _workExperienceService.GetStudent(Settings.Default.Id);
            dataGridErrorBank.ItemsSource = _errorBankService.Get();
        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        //manage skill
        //private void LoadGrid()
        //{
        //    textBoxNameSkill.Text = "";
        //    textBlockIdSkill.Text = "";
        //    dataGridSkill.ItemsSource = _skillService.Get();
        //}

        //private void buttonSaveSkill_Click(object sender, RoutedEventArgs e)
        //{
        //    skillParam.Name = textBoxNameSkill.Text;
        //    if (string.IsNullOrEmpty(textBoxNameSkill.Text) == true)
        //    {
        //        MessageBox.Show("Please insert name skill!");
        //    }
        //    else if (string.IsNullOrWhiteSpace(textBoxNameSkill.Text) == true)
        //    {
        //        MessageBox.Show("Don't insert white space");
        //    }
        //    else
        //    {
        //        _skillService.Insert(skillParam);
        //        LoadGrid();
        //    }
        //}

        //private void buttonUpdateSkill_Click(object sender, RoutedEventArgs e)
        //{
        //    object item = dataGridSkill.SelectedItem;
        //    if (item == null)
        //    {
        //        MessageBox.Show("Please choice data want to edit!");
        //    }
        //    else
        //    {
        //        skillParam.Name = textBoxNameSkill.Text;
        //        if (string.IsNullOrEmpty(textBoxNameSkill.Text) == true)
        //        {
        //            MessageBox.Show("Please insert name skill!");
        //        }
        //        else if (string.IsNullOrWhiteSpace(textBoxNameSkill.Text) == true)
        //        {
        //            MessageBox.Show("Don't insert white space");
        //        }
        //        else
        //        {
        //            _skillService.Update(Convert.ToInt16(textBlockIdSkill.Text), skillParam);
        //            LoadGrid();
        //        }
        //    }            
        //}

        //private void buttonDeleteSkill_Click(object sender, RoutedEventArgs e)
        //{           
        //    object item = dataGridSkill.SelectedItem;
        //    if (item == null)
        //    {
        //        MessageBox.Show("Please choice data want to delete!");
        //    }
        //    else
        //    {
        //        _skillService.Delete(Convert.ToInt16(textBlockIdSkill.Text));
        //        LoadGrid();
        //    }            
        //}

        //private void dataGridSkill_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        //{
        //    object item = dataGridSkill.SelectedItem;
        //    if ( dataGridSkill.SelectedIndex < 0)
        //    {
        //        textBlockIdSkill.Text = "";
        //        textBoxNameSkill.Text = "";
        //    } else
        //    {
        //        textBlockIdSkill.Text = (dataGridSkill.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
        //        textBoxNameSkill.Text = (dataGridSkill.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
        //    }            
        //}

        //private void textBoxNameSkill_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9. ]*$");
        //    e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        //}

        //private void buttonSearchSkill_Click(object sender, RoutedEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(comboBoxSearchSkill.Text) == true)
        //    {
        //        MessageBox.Show("Please choice category search!");
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(textBoxSearchSkill.Text) == true)
        //        {
        //            MessageBox.Show("Please insert keywoard search!");
        //        }
        //        else if (string.IsNullOrWhiteSpace(textBoxSearchSkill.Text) == true)
        //        {
        //            MessageBox.Show("Don't insert white space");
        //        }
        //        else
        //        {
        //            dataGridSkill.ItemsSource = _skillService.Search(textBoxSearchSkill.Text, comboBoxSearchSkill.Text);
        //        }
        //    }            
        //}

        //private void textBoxSearchSkill_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.Key != Key.Enter) return;

        //    // your event handler here
        //    e.Handled = true;
        //    if (string.IsNullOrEmpty(comboBoxSearchSkill.Text) == true)
        //    {
        //        MessageBox.Show("Please choice category search!");
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(textBoxSearchSkill.Text) == true)
        //        {
        //            MessageBox.Show("Please insert keywoard search!");
        //        }
        //        else if (string.IsNullOrWhiteSpace(textBoxSearchSkill.Text) == true)
        //        {
        //            MessageBox.Show("Don't insert white space");
        //        }
        //        else
        //        {
        //            dataGridSkill.ItemsSource = _skillService.Search(textBoxSearchSkill.Text, comboBoxSearchSkill.Text);
        //        }
        //    }
        //}

        //Manage Achievement
        private void LoadGridAchievement()
        {
            textBlockIdAchievement.Text = "";
            textBoxNameAchievement.Text = "";
            dateDateAchievement.Text = "";
            dataGridAchievement.ItemsSource = _achievementService.GetStudent(Settings.Default.Id);

        }

        private void textBoxNameAchievement_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertAchievement_Click(object sender, RoutedEventArgs e)
        {
            achievementParam.Name = textBoxNameAchievement.Text;
            DateTime? selectedDate = dateDateAchievement.SelectedDate;
            if (selectedDate.HasValue)
            {
                achievementParam.Date = selectedDate.Value;
            }
            achievementParam.students = Settings.Default.Id;
            if (string.IsNullOrEmpty(textBoxNameAchievement.Text) == true)
            {
                MessageBox.Show("Please insert name achievement!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameAchievement.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _achievementService.Insert(achievementParam);
                LoadGridAchievement();
            }
        }

        private void dataGridAchievement_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridAchievement.SelectedItem;
            if (dataGridAchievement.SelectedIndex < 0)
            {
                textBlockIdAchievement.Text = "";
                textBoxNameAchievement.Text = "";
                dateDateAchievement.Text = "";
            }
            else
            {
                textBlockIdAchievement.Text = (dataGridAchievement.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameAchievement.Text = (dataGridAchievement.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                dateDateAchievement.SelectedDate = Convert.ToDateTime((dataGridAchievement.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
            }
        }

        private void buttonUpdateAchievement_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridAchievement.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                achievementParam.Name = textBoxNameAchievement.Text;
                DateTime? selectedDate = dateDateAchievement.SelectedDate;
                if (selectedDate.HasValue)
                {
                    achievementParam.Date = selectedDate.Value;
                }
                achievementParam.students = Settings.Default.Id;
                if (string.IsNullOrEmpty(textBoxNameAchievement.Text) == true)
                {
                    MessageBox.Show("Please insert name achievement!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameAchievement.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _achievementService.Update(Convert.ToInt16(textBlockIdAchievement.Text), achievementParam);
                    LoadGridAchievement();
                }
            }
        }

        private void buttonDeleteAchievement_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridAchievement.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _achievementService.Delete(Convert.ToInt16(textBlockIdAchievement.Text));
                LoadGridAchievement();
            }
        }

        private void buttonSearchAchievement_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchAchievement.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchAchievement.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchAchievement.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridAchievement.ItemsSource = _achievementService.Search(textBoxSearchAchievement.Text, comboBoxSearchAchievement.Text);
                }
            }
        }

        private void textBoxSearchAchievement_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchAchievement.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchAchievement.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchAchievement.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridAchievement.ItemsSource = _achievementService.Search(textBoxSearchAchievement.Text, comboBoxSearchAchievement.Text);
                }
            }
        }

        //Manage Organization
        private void LoadGridOrganization()
        {
            textBlockIdOrganization.Text = "";
            textBoxNameOrganization.Text = "";
            textBoxPositionOrganization.Text = "";
            textBoxDescriptionOrganization.Text = "";
            dateDateStartOrganization.Text = "";
            dateDateEndOrganization.Text = "";
            dataGridOrganization.ItemsSource = _organizationService.GetStudent(Settings.Default.Id);

        }

        private void textBoxNameOrganization_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertOrganization_Click(object sender, RoutedEventArgs e)
        {
            organizationParam.Name = textBoxNameOrganization.Text;
            organizationParam.Position = textBoxPositionOrganization.Text;
            organizationParam.Description = textBoxDescriptionOrganization.Text;                        
            DateTime? selectedDateS = dateDateStartOrganization.SelectedDate;
            if (selectedDateS.HasValue)
            {
                organizationParam.DateStart = selectedDateS.Value;
            }
            DateTime? selectedDateE = dateDateEndOrganization.SelectedDate;
            if (selectedDateE.HasValue)
            {
                organizationParam.DateEnd = selectedDateE.Value;
            }
            organizationParam.students = Settings.Default.Id;
            if (string.IsNullOrEmpty(textBoxNameOrganization.Text) == true)
            {
                MessageBox.Show("Please insert name Organization!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameOrganization.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _organizationService.Insert(organizationParam);
                LoadGridOrganization();
            }
        }

        private void dataGridOrganization_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridOrganization.SelectedItem;
            if (dataGridOrganization.SelectedIndex < 0)
            {
                textBlockIdOrganization.Text = "";
                textBoxNameOrganization.Text = "";
                textBoxPositionOrganization.Text = "";
                textBoxDescriptionOrganization.Text = "";
                dateDateStartOrganization.Text = "";
                dateDateEndOrganization.Text = "";
            }
            else
            {
                textBlockIdOrganization.Text = (dataGridOrganization.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameOrganization.Text = (dataGridOrganization.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                textBoxPositionOrganization.Text = (dataGridOrganization.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                dateDateStartOrganization.SelectedDate = Convert.ToDateTime((dataGridOrganization.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                dateDateEndOrganization.SelectedDate = Convert.ToDateTime((dataGridOrganization.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
                textBoxDescriptionOrganization.Text = (dataGridOrganization.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;                
            }
        }

        private void buttonUpdateOrganization_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridOrganization.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                organizationParam.Name = textBoxNameOrganization.Text;
                organizationParam.Position = textBoxPositionOrganization.Text;
                organizationParam.Description = textBoxDescriptionOrganization.Text;
                DateTime? selectedDateS = dateDateStartOrganization.SelectedDate;
                if (selectedDateS.HasValue)
                {
                    organizationParam.DateStart = selectedDateS.Value;
                }
                DateTime? selectedDateE = dateDateEndOrganization.SelectedDate;
                if (selectedDateE.HasValue)
                {
                    organizationParam.DateEnd = selectedDateE.Value;
                }
                organizationParam.students = Settings.Default.Id;
                if (string.IsNullOrEmpty(textBoxNameOrganization.Text) == true)
                {
                    MessageBox.Show("Please insert name organization!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameOrganization.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _organizationService.Update(Convert.ToInt16(textBlockIdOrganization.Text), organizationParam);
                    LoadGridOrganization();
                }
            }
        }

        private void buttonDeleteOrganization_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridOrganization.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _organizationService.Delete(Convert.ToInt16(textBlockIdOrganization.Text));
                LoadGridOrganization();
            }
        }

        private void buttonSearchOrganization_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchOrganization.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchOrganization.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchOrganization.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridOrganization.ItemsSource = _organizationService.Search(textBoxSearchOrganization.Text, comboBoxSearchOrganization.Text);
                }
            }
        }

        private void textBoxSearchOrganization_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchOrganization.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchOrganization.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchOrganization.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridOrganization.ItemsSource = _organizationService.Search(textBoxSearchOrganization.Text, comboBoxSearchOrganization.Text);
                }
            }
        }

        //Manage WorkExperience
        private void LoadGridWorkExperience()
        {
            textBlockIdWorkExperience.Text = "";
            textBoxNameWorkExperience.Text = "";
            textBoxPositionWorkExperience.Text = "";
            textBoxDescriptionWorkExperience.Text = "";
            dateDateStartWorkExperience.Text = "";
            dateDateEndWorkExperience.Text = "";
            dataGridWorkExperience.ItemsSource = _workExperienceService.GetStudent(Settings.Default.Id);

        }

        private void textBoxNameWorkExperience_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertWorkExperience_Click(object sender, RoutedEventArgs e)
        {
            workExperienceParam.Name = textBoxNameWorkExperience.Text;
            workExperienceParam.Position = textBoxPositionWorkExperience.Text;
            workExperienceParam.Description = textBoxDescriptionWorkExperience.Text;
            DateTime? selectedDateS = dateDateStartWorkExperience.SelectedDate;
            if (selectedDateS.HasValue)
            {
                workExperienceParam.DateStart = selectedDateS.Value;
            }
            DateTime? selectedDateE = dateDateEndWorkExperience.SelectedDate;
            if (selectedDateE.HasValue)
            {
                workExperienceParam.DateEnd = selectedDateE.Value;
            }
            workExperienceParam.students = Settings.Default.Id;
            if (string.IsNullOrEmpty(textBoxNameWorkExperience.Text) == true)
            {
                MessageBox.Show("Please insert name work experience!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameWorkExperience.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _workExperienceService.Insert(workExperienceParam);
                LoadGridWorkExperience();
            }
        }

        private void dataGridWorkExperience_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridWorkExperience.SelectedItem;
            if (dataGridWorkExperience.SelectedIndex < 0)
            {
                textBlockIdWorkExperience.Text = "";
                textBoxNameWorkExperience.Text = "";
                textBoxPositionWorkExperience.Text = "";
                textBoxDescriptionWorkExperience.Text = "";
                dateDateStartWorkExperience.Text = "";
                dateDateEndWorkExperience.Text = "";
            }
            else
            {
                textBlockIdWorkExperience.Text = (dataGridWorkExperience.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameWorkExperience.Text = (dataGridWorkExperience.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                textBoxPositionWorkExperience.Text = (dataGridWorkExperience.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                dateDateStartWorkExperience.SelectedDate = Convert.ToDateTime((dataGridWorkExperience.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                dateDateEndWorkExperience.SelectedDate = Convert.ToDateTime((dataGridWorkExperience.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
                textBoxDescriptionWorkExperience.Text = (dataGridWorkExperience.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void buttonUpdateWorkExperience_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridWorkExperience.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                workExperienceParam.Name = textBoxNameWorkExperience.Text;
                workExperienceParam.Position = textBoxPositionWorkExperience.Text;
                workExperienceParam.Description = textBoxDescriptionWorkExperience.Text;
                DateTime? selectedDateS = dateDateStartWorkExperience.SelectedDate;
                if (selectedDateS.HasValue)
                {
                    workExperienceParam.DateStart = selectedDateS.Value;
                }
                DateTime? selectedDateE = dateDateEndWorkExperience.SelectedDate;
                if (selectedDateE.HasValue)
                {
                    workExperienceParam.DateEnd = selectedDateE.Value;
                }
                workExperienceParam.students = Settings.Default.Id;
                if (string.IsNullOrEmpty(textBoxNameWorkExperience.Text) == true)
                {
                    MessageBox.Show("Please insert name Work Experience!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameWorkExperience.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _workExperienceService.Update(Convert.ToInt16(textBlockIdWorkExperience.Text), workExperienceParam);
                    LoadGridWorkExperience();
                }
            }
        }

        private void buttonDeleteWorkExperience_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridWorkExperience.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _workExperienceService.Delete(Convert.ToInt16(textBlockIdWorkExperience.Text));
                LoadGridWorkExperience();
            }
        }

        private void buttonSearchWorkExperience_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchWorkExperience.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchWorkExperience.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchWorkExperience.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridWorkExperience.ItemsSource = _workExperienceService.Search(textBoxSearchWorkExperience.Text, comboBoxSearchWorkExperience.Text);
                }
            }
        }

        private void textBoxSearchWorkExperience_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchWorkExperience.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchWorkExperience.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchWorkExperience.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridWorkExperience.ItemsSource = _workExperienceService.Search(textBoxSearchWorkExperience.Text, comboBoxSearchWorkExperience.Text);
                }
            }
        }

        //Manage ErrorBank
        private void LoadGridErrorBank()
        {
            textBlockIdErrorBank.Text = "";
            textBoxMessageErrorBank.Text = "";            
            textBoxDescriptionErrorBank.Text = "";
            textBoxSolutionErrorBank.Text = "";
            dataGridErrorBank.ItemsSource = _errorBankService.Get();
        }

        private void textBoxMessageErrorBank_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertErrorBank_Click(object sender, RoutedEventArgs e)
        {
            errorBankParam.Message = textBoxMessageErrorBank.Text;            
            errorBankParam.Description = textBoxDescriptionErrorBank.Text;
            errorBankParam.Solution = textBoxSolutionErrorBank.Text;
            errorBankParam.Date = DateTime.Now.ToLocalTime();
            errorBankParam.students = Settings.Default.Id;
            if (string.IsNullOrEmpty(textBoxMessageErrorBank.Text) == true)
            {
                MessageBox.Show("Please insert message Error Bank!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxMessageErrorBank.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _errorBankService.Insert(errorBankParam);
                LoadGridErrorBank();
            }
        }

        private void dataGridErrorBank_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridErrorBank.SelectedItem;
            if (dataGridErrorBank.SelectedIndex < 0)
            {
                textBlockIdErrorBank.Text = "";
                textBoxMessageErrorBank.Text = "";
                textBoxDescriptionErrorBank.Text = "";
                textBoxSolutionErrorBank.Text = "";
            }
            else
            {
                textBlockIdErrorBank.Text = (dataGridErrorBank.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxMessageErrorBank.Text = (dataGridErrorBank.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                textBoxDescriptionErrorBank.Text = (dataGridErrorBank.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                textBoxSolutionErrorBank.Text = (dataGridErrorBank.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void buttonUpdateErrorBank_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridErrorBank.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                errorBankParam.Message = textBoxMessageErrorBank.Text;
                errorBankParam.Description = textBoxDescriptionErrorBank.Text;
                errorBankParam.Solution = textBoxSolutionErrorBank.Text;
                errorBankParam.Date = DateTime.Now.ToLocalTime();
                errorBankParam.students = Settings.Default.Id;
                if (string.IsNullOrEmpty(textBoxMessageErrorBank.Text) == true)
                {
                    MessageBox.Show("Please insert message Error Bank!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxMessageErrorBank.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _errorBankService.Update(Convert.ToInt16(textBlockIdErrorBank.Text), errorBankParam);
                    LoadGridErrorBank();
                }
            }
        }

        private void buttonDeleteErrorBank_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridErrorBank.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _errorBankService.Delete(Convert.ToInt16(textBlockIdErrorBank.Text));
                LoadGridErrorBank();
            }
        }

        private void buttonSearchErrorBank_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchErrorBank.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchErrorBank.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchErrorBank.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridErrorBank.ItemsSource = _errorBankService.Search(textBoxSearchErrorBank.Text, comboBoxSearchErrorBank.Text);
                }
            }
        }

        private void textBoxSearchErrorBank_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchErrorBank.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchErrorBank.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchErrorBank.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridErrorBank.ItemsSource = _errorBankService.Search(textBoxSearchErrorBank.Text, comboBoxSearchErrorBank.Text);
                }
            }
        }

        private void textBoxSearchDetailLesson_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void buttonSearchDetailLesson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBoxNameDetailLesson_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void buttonDownloadDetailLesson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridDetailLesson_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        //manage DetailLesson
        //private void LoadGridDetailLesson()
        //{
        //    textBoxNameDetailLesson.Text = "";
        //    textBlockIdDetailLesson.Text = "";
        //    dataGridDetailLesson.ItemsSource = _detailLessonService.Get();
        //}

        //private void textBoxNameDetailLesson_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z. ]*$");
        //    e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        //}

        //private void buttonDownloadDetailLesson_Click(object sender, RoutedEventArgs e)
        //{
        //    historyDetailLessonParam.detailLessons = Convert.ToInt16(textBlockIdDetailLesson.Text);
        //    historyDetailLessonParam.students = Settings.Default.Id;
        //    _historyDetailLessonService.Insert(historyDetailLessonParam);
        //}

        //private void dataGridDetailLesson_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        //{
        //    object item = dataGridDetailLesson.SelectedItem;
        //    if (dataGridDetailLesson.SelectedIndex < 0)
        //    {
        //        textBlockIdDetailLesson.Text = "";
        //        textBoxNameDetailLesson.Text = "";
        //    }
        //    else
        //    {
        //        textBlockIdDetailLesson.Text = (dataGridDetailLesson.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
        //        textBoxNameDetailLesson.Text = (dataGridDetailLesson.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

        //    }
        //}

        //private void buttonSearchDetailLesson_Click(object sender, RoutedEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(comboBoxSearchDetailLesson.Text) == true)
        //    {
        //        MessageBox.Show("Please choice category search!");
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(textBoxSearchDetailLesson.Text) == true)
        //        {
        //            MessageBox.Show("Please insert keywoard search!");
        //        }
        //        else if (string.IsNullOrWhiteSpace(textBoxSearchDetailLesson.Text) == true)
        //        {
        //            MessageBox.Show("Don't insert white space");
        //        }
        //        else
        //        {
        //            dataGridDetailLesson.ItemsSource = _detailLessonService.Search(textBoxSearchDetailLesson.Text, comboBoxSearchDetailLesson.Text);
        //        }
        //    }
        //}

        //private void textBoxSearchDetailLesson_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.Key != Key.Enter) return;

        //    // your event handler here
        //    e.Handled = true;
        //    if (string.IsNullOrEmpty(comboBoxSearchDetailLesson.Text) == true)
        //    {
        //        MessageBox.Show("Please choice category search!");
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(textBoxSearchDetailLesson.Text) == true)
        //        {
        //            MessageBox.Show("Please insert keywoard search!");
        //        }
        //        else if (string.IsNullOrWhiteSpace(textBoxSearchDetailLesson.Text) == true)
        //        {
        //            MessageBox.Show("Don't insert white space");
        //        }
        //        else
        //        {
        //            dataGridDetailLesson.ItemsSource = _detailLessonService.Search(textBoxSearchDetailLesson.Text, comboBoxSearchDetailLesson.Text);
        //        }
        //    }
        //}
    }
}
