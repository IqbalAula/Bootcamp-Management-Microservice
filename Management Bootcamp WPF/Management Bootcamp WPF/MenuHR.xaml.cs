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
            _departmentService.Insert(departmentParam);
            LoadGrid();            
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
            int id = Convert.ToInt16(textBlockId.Text);
            departmentParam.Name = textBoxName.Text;
            _departmentService.Update(id, departmentParam);
            LoadGrid();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt16(textBlockId.Text);
            _departmentService.Delete(id);
            LoadGrid();
        }

        private void dataGridDepartment_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridDepartment.SelectedItem;
            textBlockId.Text = (dataGridDepartment.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            textBoxName.Text = (dataGridDepartment.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
        }

        private void textBoxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            dataGridDepartment.ItemsSource = _departmentService.Search(textBoxSearch.Text, comboBoxSearch.Text);
        }
    }
}
