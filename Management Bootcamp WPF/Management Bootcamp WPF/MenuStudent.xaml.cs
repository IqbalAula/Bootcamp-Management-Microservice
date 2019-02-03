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
        ISkillService _skillService = new SkillService();
        IAchievementService _achievementService = new AchievementService();
        IOrganizationService _organizationService = new OrganizationService();
        IWorkExperienceService _workExperienceService = new WorkExperienceService();
        IErrorBankService _errorBankService = new ErrorBankService();
        SkillParam skillParam = new SkillParam();
        AchievementParam achievementParam = new AchievementParam();
        OrganizationParam organizationParam = new OrganizationParam();
        WorkExperienceParam workExperienceParam = new WorkExperienceParam();
        ErrorBankParam errorBankParam = new ErrorBankParam();
        public MenuStudent()
        {
            InitializeComponent();
        }

        private void buttonSaveSkill_Click(object sender, RoutedEventArgs e)
        {
            skillParam.Name = textBoxNameSkill.Text;
            if (string.IsNullOrEmpty(textBoxNameSkill.Text) == true)
            {
                MessageBox.Show("Please insert name skill!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameSkill.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {                
                _skillService.Insert(skillParam);
                LoadGrid();
            }                        
        }
        private void LoadGrid()
        {
            textBoxNameSkill.Text = "";
            textBlockIdSkill.Text = "";
            dataGridSkill.ItemsSource = _skillService.Get();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridSkill.ItemsSource = _skillService.Get();            
        }

        private void buttonUpdateSkill_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridSkill.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                skillParam.Name = textBoxNameSkill.Text;
                if (string.IsNullOrEmpty(textBoxNameSkill.Text) == true)
                {
                    MessageBox.Show("Please insert name skill!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameSkill.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _skillService.Update(Convert.ToInt16(textBlockIdSkill.Text), skillParam);
                    LoadGrid();
                }
            }            
        }

        private void buttonDeleteSkill_Click(object sender, RoutedEventArgs e)
        {           
            object item = dataGridSkill.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _skillService.Delete(Convert.ToInt16(textBlockIdSkill.Text));
                LoadGrid();
            }            
        }

        private void dataGridSkill_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridSkill.SelectedItem;
            if ( dataGridSkill.SelectedIndex < 0)
            {
                textBlockIdSkill.Text = "";
                textBoxNameSkill.Text = "";
            } else
            {
                textBlockIdSkill.Text = (dataGridSkill.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameSkill.Text = (dataGridSkill.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            }            
        }

        private void textBoxNameSkill_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonSearchSkill_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchSkill.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchSkill.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchSkill.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridSkill.ItemsSource = _skillService.Search(textBoxSearchSkill.Text, comboBoxSearchSkill.Text);
                }
            }            
        }

        private void textBoxSearchSkill_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchSkill.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchSkill.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchSkill.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridSkill.ItemsSource = _skillService.Search(textBoxSearchSkill.Text, comboBoxSearchSkill.Text);
                }
            }
        }

        //Manage Achievement
        private void LoadGridAchievement()
        {
            textBlockIdAchievement.Text = "";
            textBoxNameAchievement.Text = "";
            dateDateAchievement.Text = "";
            dataGridAchievement.ItemsSource = _achievementService.Get();

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

        //MANAGE BATCH
        private void LoadGridOrganization()
        {
            textBlockIdOrganization.Text = "";
            textBoxNameOrganization.Text = "";
            dateDateStartOrganization.Text = "";
            dataGridOrganization.ItemsSource = _organizationService.Get();

        }

        private void textBoxNameOrganization_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertOrganization_Click(object sender, RoutedEventArgs e)
        {
            organizationParam.Name = textBoxNameOrganization.Text;
            DateTime? selectedDate = dateDateStartOrganization.SelectedDate;
            if (selectedDate.HasValue)
            {
                organizationParam.DateStart = selectedDate.Value;
            }
            if (string.IsNullOrEmpty(textBoxNameOrganization.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameOrganization.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _organizationService.Insert(organizationParam);
                LoadGridOrganization();
                LoadCombo();
            }
        }

        private void dataGridOrganization_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridOrganization.SelectedItem;
            if (dataGridOrganization.SelectedIndex < 0)
            {
                textBlockIdOrganization.Text = "";
                textBoxNameOrganization.Text = "";
                dateDateStartOrganization.Text = "";
            }
            else
            {
                textBlockIdOrganization.Text = (dataGridOrganization.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameOrganization.Text = (dataGridOrganization.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                dateDateStartOrganization.SelectedDate = Convert.ToDateTime((dataGridOrganization.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
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
                DateTime? selectedDate = dateDateStartOrganization.SelectedDate;
                if (selectedDate.HasValue)
                {
                    organizationParam.DateStart = selectedDate.Value;
                }
                if (string.IsNullOrEmpty(textBoxNameOrganization.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameOrganization.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _organizationService.Update(Convert.ToInt16(textBlockIdOrganization.Text), organizationParam);
                    LoadGridOrganization();
                    LoadCombo();
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
                LoadCombo();
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

    }
}
