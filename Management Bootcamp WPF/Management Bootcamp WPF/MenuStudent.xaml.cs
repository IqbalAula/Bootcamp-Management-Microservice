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
        SkillParam skillParam = new SkillParam();        
        //string id;
        //string name;
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


                
    }
}
