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
    public partial class MenuHR : Window
    {
        IDepartmentService _departmentService = new DepartmentService();
        DepartmentParam departmentParam = new DepartmentParam();        
        //string id;
        //string name;
        public MenuHR()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            departmentParam.Name = textBoxName.Text;
            if (string.IsNullOrEmpty(textBoxName.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxName.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {                
                _departmentService.Insert(departmentParam);
                LoadGrid();
            }                        
        }
        private void LoadGrid()
        {
            textBoxName.Text = "";
            textBlockId.Text = "";
            dataGridDepartment.ItemsSource = _departmentService.Get();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridDepartment.ItemsSource = _departmentService.Get();            
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridDepartment.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                departmentParam.Name = textBoxName.Text;
                if (string.IsNullOrEmpty(textBoxName.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxName.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _departmentService.Update(Convert.ToInt16(textBlockId.Text), departmentParam);
                    LoadGrid();
                }
            }            
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {           
            object item = dataGridDepartment.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _departmentService.Delete(Convert.ToInt16(textBlockId.Text));
                LoadGrid();
            }            
        }

        private void dataGridDepartment_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridDepartment.SelectedItem;
            if ( dataGridDepartment.SelectedIndex < 0)
            {
                textBlockId.Text = "";
                textBoxName.Text = "";
            } else
            {
                textBlockId.Text = (dataGridDepartment.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxName.Text = (dataGridDepartment.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            }            
        }

        private void textBoxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearch.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearch.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearch.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridDepartment.ItemsSource = _departmentService.Search(textBoxSearch.Text, comboBoxSearch.Text);
                }
            }            
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearch.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearch.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearch.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridDepartment.ItemsSource = _departmentService.Search(textBoxSearch.Text, comboBoxSearch.Text);
                }
            }
        }
    }
}
