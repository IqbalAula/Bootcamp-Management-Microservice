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
using Management_Bootcamp_WPF.Properties;

namespace Management_Bootcamp_WPF
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MenuHR : Window
    {
        IDepartmentService _departmentService = new DepartmentService();
        IEmployeeService _employeeService = new EmployeeService();
        DepartmentParam departmentParam = new DepartmentParam();
        EmployeeParam employeeParam = new EmployeeParam();
        public MenuHR()
        {
            InitializeComponent();
        }        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridDepartment.ItemsSource = _departmentService.Get();
            dataGridEmployee.ItemsSource = _employeeService.Get();

            var get = _employeeService.Get(Settings.Default.Id);

            textBoxNameProfileHR.Text = Convert.ToString(get.Id);
            //dateDobProfileHR.DisplayDateStart = Convert.ToDateTime(get.Dob);
            textBoxPobProfileHR.Text = get.Pob;
            comboBoxGenderProfileHR.Text = get.Gender;
            comboBoxReligionProfileHR.Text = get.Religion;
            textBoxPhoneProfileHR.Text = get.Phone;
            textBoxEmailProfileHR.Text = get.Email;
            textBoxUsernameProfileHR.Text = get.Username;
            textBoxPasswordProfileHR.Text = get.Password;
            textBoxAddressProfileHR.Text = get.Address;
            textBoxRtProfileHR.Text = Convert.ToString(get.RT);
            textBoxRwProfileHR.Text = Convert.ToString(get.RW);
            textBoxKelurahanProfileHR.Text = get.Kelurahan;
            textBoxKecamatanProfileHR.Text = get.Kecamatan;
            textBoxKabupatenProfileHR.Text = get.Kabupaten;
        }
//manage department
        private void LoadGridDepartment()
        {
            textBoxNameDepartment.Text = "";
            textBlockIdDepartment.Text = "";
            dataGridDepartment.ItemsSource = _departmentService.Get();
        }

        private void buttonUpdateDepartment_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridDepartment.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                departmentParam.Name = textBoxNameDepartment.Text;
                if (string.IsNullOrEmpty(textBoxNameDepartment.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameDepartment.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _departmentService.Update(Convert.ToInt16(textBlockIdDepartment.Text), departmentParam);
                    LoadGridDepartment();
                }
            }            
        }

        private void textBoxNameDepartment_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertDepartment_Click(object sender, RoutedEventArgs e)
        {
            departmentParam.Name = textBoxNameDepartment.Text;
            if (string.IsNullOrEmpty(textBoxNameDepartment.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameDepartment.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _departmentService.Insert(departmentParam);
                LoadGridDepartment();
            }
        }

        private void buttonDeleteDepartment_Click(object sender, RoutedEventArgs e)
        {           
            object item = dataGridDepartment.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _departmentService.Delete(Convert.ToInt16(textBlockIdDepartment.Text));
                LoadGridDepartment();
            }            
        }

        private void dataGridDepartment_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridDepartment.SelectedItem;
            if ( dataGridDepartment.SelectedIndex < 0)
            {
                textBlockIdDepartment.Text = "";
                textBoxNameDepartment.Text = "";
            } else
            {
                textBlockIdDepartment.Text = (dataGridDepartment.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameDepartment.Text = (dataGridDepartment.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            }            
        }        

        private void buttonSearchDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchDepartment.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchDepartment.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchDepartment.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridDepartment.ItemsSource = _departmentService.Search(textBoxSearchDepartment.Text, comboBoxSearchDepartment.Text);
                }
            }            
        }

        private void textBoxSearchDepartment_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchDepartment.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchDepartment.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchDepartment.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridDepartment.ItemsSource = _departmentService.Search(textBoxSearchDepartment.Text, comboBoxSearchDepartment.Text);
                }
            }
        }

//manage employee
        private void LoadGridEmployee()
        {
            textBlockIdEmployee.Text = "";
            textBoxNameEmployee.Text = "";
            textBoxPhoneEmployee.Text = "";
            comboBoxRoleEmployee.Text = "";
            textBoxEmailEmployee.Text = "";
            textBoxUsernameEmployee.Text = "";
            textBoxPasswordEmployee.Text = "";
            dataGridEmployee.ItemsSource = _employeeService.Get();
        }

        private void buttonUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridEmployee.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                employeeParam.Name = textBoxNameEmployee.Text;
                employeeParam.Phone = textBoxPhoneEmployee.Text;
                employeeParam.Role = comboBoxRoleEmployee.Text;
                employeeParam.Email = textBoxEmailEmployee.Text;
                employeeParam.Username = textBoxUsernameEmployee.Text;
                employeeParam.Password = textBoxPasswordEmployee.Text;
                if (string.IsNullOrEmpty(textBoxNameEmployee.Text) == true)
                {
                    MessageBox.Show("Please insert name employee!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameEmployee.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _employeeService.Update(Convert.ToInt16(textBlockIdEmployee.Text), employeeParam);
                    LoadGridEmployee();
                }
            }
        }

        private void textBoxNameEmployee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxPhoneEmployee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[0-9+]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
        private void textBoxEmailEmployee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z.0-9@]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxUsernameEmployee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertEmployee_Click(object sender, RoutedEventArgs e)
        {
            employeeParam.Name = textBoxNameEmployee.Text;
            employeeParam.Phone = textBoxPhoneEmployee.Text;
            employeeParam.Role = comboBoxRoleEmployee.Text;
            employeeParam.Email = textBoxEmailEmployee.Text;
            employeeParam.Username = textBoxUsernameEmployee.Text;
            employeeParam.Password = textBoxPasswordEmployee.Text;
            if (string.IsNullOrEmpty(textBoxNameEmployee.Text) == true)
            {
                MessageBox.Show("Please insert name employee!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameEmployee.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _employeeService.Insert(employeeParam);
                LoadGridEmployee();
            }
        }

        private void buttonDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridEmployee.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _employeeService.Delete(Convert.ToInt16(textBlockIdEmployee.Text));
                LoadGridEmployee();
            }
        }

        private void dataGridEmployee_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridEmployee.SelectedItem;
            if (dataGridEmployee.SelectedIndex < 0)
            {
                textBlockIdEmployee.Text = "";
                textBoxNameEmployee.Text = "";
                textBoxPhoneEmployee.Text = "";
                comboBoxRoleEmployee.Text = "";
                textBoxEmailEmployee.Text = "";
                textBoxUsernameEmployee.Text = "";
                textBoxPasswordEmployee.Text = "";
            }
            else
            {
                textBlockIdEmployee.Text = (dataGridEmployee.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameEmployee.Text = (dataGridEmployee.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                textBoxPhoneEmployee.Text = (dataGridEmployee.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;                
                textBoxEmailEmployee.Text = (dataGridEmployee.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                textBoxUsernameEmployee.Text = (dataGridEmployee.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                textBoxPasswordEmployee.Text = (dataGridEmployee.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                comboBoxRoleEmployee.Text = (dataGridEmployee.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void buttonSearchEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchEmployee.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchEmployee.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchEmployee.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridEmployee.ItemsSource = _employeeService.Search(textBoxSearchEmployee.Text, comboBoxSearchEmployee.Text);
                }
            }
        }

        private void textBoxSearchEmployee_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchEmployee.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchEmployee.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchEmployee.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridEmployee.ItemsSource = _employeeService.Search(textBoxSearchEmployee.Text, comboBoxSearchEmployee.Text);
                }
            }
        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        //Manage ProfileHR
        private void LoadProfile()
        {
            var get = _employeeService.Get(Settings.Default.Id);

            textBoxNameProfileHR.Text = Convert.ToString(get.Id);
            dateDobProfileHR.DisplayDate = Convert.ToDateTime(get.Dob);
            textBoxPobProfileHR.Text = get.Pob;
            comboBoxGenderProfileHR.Text = get.Gender;
            comboBoxReligionProfileHR.Text = get.Religion;
            textBoxPhoneProfileHR.Text = get.Phone;
            textBoxEmailProfileHR.Text = get.Email;
            textBoxUsernameProfileHR.Text = get.Username;
            textBoxPasswordProfileHR.Text = get.Password;
            textBoxAddressProfileHR.Text = get.Address;
            textBoxRtProfileHR.Text = Convert.ToString(get.RT);
            textBoxRwProfileHR.Text = Convert.ToString(get.RW);
            textBoxKelurahanProfileHR.Text = get.Kelurahan;
            textBoxKecamatanProfileHR.Text = get.Kecamatan;
            textBoxKabupatenProfileHR.Text = get.Kabupaten;
        }

        private void buttonSaveProfileHR_Click(object sender, RoutedEventArgs e)
        {
            employeeParam.Name = textBoxNameProfileHR.Text;
            DateTimeOffset? selectedDate = dateDobProfileHR.SelectedDate;
            if (selectedDate.HasValue)
            {
                employeeParam.Dob = selectedDate.Value;
            }
            employeeParam.Pob = textBoxPobProfileHR.Text;
            employeeParam.Gender = comboBoxGenderProfileHR.Text;
            employeeParam.Religion = comboBoxReligionProfileHR.Text;
            employeeParam.Phone = textBoxPhoneProfileHR.Text;
            employeeParam.Email = textBoxEmailProfileHR.Text;
            employeeParam.Username = textBoxUsernameProfileHR.Text;
            employeeParam.Password = textBoxPasswordProfileHR.Text;
            employeeParam.Address = textBoxAddressProfileHR.Text;
            employeeParam.RT = Convert.ToInt16(textBoxRtProfileHR);
            employeeParam.RW = Convert.ToInt16(textBoxRwProfileHR);
            employeeParam.Kelurahan = textBoxKelurahanProfileHR.Text;
            employeeParam.Kecamatan = textBoxKecamatanProfileHR.Text;
            employeeParam.Kabupaten = textBoxKabupatenProfileHR.Text;
            if (string.IsNullOrEmpty(textBoxNameProfileHR.Text) == true)
            {
                MessageBox.Show("Please insert name employee!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameProfileHR.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _employeeService.Update(Convert.ToInt16(textBlockIdProfileHR.Text), employeeParam);
                LoadProfile();
            }
        }

        private void textBoxNameProfileHR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxRtProfileHR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[1-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
    }
}
