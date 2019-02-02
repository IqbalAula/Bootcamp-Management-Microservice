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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MenuHR : Window
    {
        MyContext _context = new MyContext();
        IEmployeeService _employeeService = new EmployeeService();
        IRoomService _roomService = new RoomService();
        IDepartmentService _departmentService = new DepartmentService();
        IBatchService _batchService = new BatchService();
        IClassService _classService = new ClassService();
        IPlacementService _placementService = new PlacementService();        
        IStudentService _studentService = new StudentService();
        EmployeeParam employeeParam = new EmployeeParam();
        RoomParam roomParam = new RoomParam();
        DepartmentParam departmentParam = new DepartmentParam();
        BatchParam batchParam = new BatchParam();
        ClassParam classParam = new ClassParam();
        PlacementParam placementParam = new PlacementParam();
        StudentParam studentParam = new StudentParam();        
                
        public MenuHR()
        {
            InitializeComponent();
        }        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            dataGridEmployee.ItemsSource = _employeeService.Get();
            dataGridRoom.ItemsSource = _roomService.Get();
            dataGridDepartment.ItemsSource = _departmentService.Get();
            dataGridBatch.ItemsSource = _batchService.Get();
            dataGridClass.ItemsSource = _classService.Get();
            dataGridPlacement.ItemsSource = _placementService.Get();
            dataGridStudent.ItemsSource = _studentService.Get();

            comboBoxDepartmentClass.ItemsSource = _context.Departments.Where(x => x.IsDelete == false).ToList();
            comboBoxBatchClass.ItemsSource = _context.Batchs.Where(x => x.IsDelete == false).ToList();
            comboBoxClassStudent.ItemsSource = _context.Classes.Where(x => x.IsDelete == false).ToList();

            var get = _employeeService.Get(Settings.Default.Id);
            textBlockIdProfileHR.Text = Convert.ToString(get.Id);
            textBoxNameProfileHR.Text = get.Name;
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

        private void LoadCombo()
        {
            comboBoxDepartmentClass.ItemsSource = _context.Departments.Where(x => x.IsDelete == false).ToList();
            comboBoxBatchClass.ItemsSource = _context.Batchs.Where(x => x.IsDelete == false).ToList();
            comboBoxClassStudent.ItemsSource = _context.Classes.Where(x => x.IsDelete == false).ToList();
        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
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

        //MANAGE ROOM

        private void LoadGridRoom()
        {
            textBlockIdRoom.Text = "";
            textBoxNameRoom.Text = "";
            textBoxCapacityRoom.Text = "";
            textBoxLocationRoom.Text = "";
            dataGridRoom.ItemsSource = _roomService.Get();
        }
        private void textBoxNameRoom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxCapacityRoom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertRoom_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxNameRoom.Text) == true)
            {
                MessageBox.Show("Please insert name room!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameRoom.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else if (string.IsNullOrEmpty(textBoxCapacityRoom.Text) == true)
            {
                MessageBox.Show("Please insert capacity room!");
            }
            else if (string.IsNullOrEmpty(textBoxLocationRoom.Text) == true)
            {
                MessageBox.Show("Please insert Location room!");
            }
            else
            {
                roomParam.Name = textBoxNameRoom.Text;
                roomParam.Capacity = Convert.ToInt32(textBoxCapacityRoom.Text);
                roomParam.Location = textBoxLocationRoom.Text;

                _roomService.Insert(roomParam);
                LoadGridRoom();
            }
        }
        
        private void dataGridRoom_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridRoom.SelectedItem;
            if (dataGridRoom.SelectedIndex < 0)
            {
                textBlockIdRoom.Text = "";
                textBoxNameRoom.Text = "";
                textBoxCapacityRoom.Text = "";
                textBoxLocationRoom.Text = "";
            }
            else
            {
                textBlockIdRoom.Text = (dataGridRoom.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameRoom.Text = (dataGridRoom.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                textBoxCapacityRoom.Text = (dataGridRoom.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                textBoxLocationRoom.Text = (dataGridRoom.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void buttonUpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridRoom.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {

                if (string.IsNullOrEmpty(textBoxNameRoom.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameRoom.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else if (string.IsNullOrEmpty(textBoxCapacityRoom.Text) == true)
                {
                    MessageBox.Show("Please insert capacity room!");
                }
                else if (string.IsNullOrEmpty(textBoxLocationRoom.Text) == true)
                {
                    MessageBox.Show("Please insert Location room!");
                }
                else
                {
                    roomParam.Name = textBoxNameRoom.Text;
                    roomParam.Capacity = Convert.ToInt32(textBoxCapacityRoom.Text);
                    roomParam.Location = textBoxLocationRoom.Text;

                    _roomService.Update(Convert.ToInt16(textBlockIdRoom.Text), roomParam);
                    LoadGridRoom();
                }
            }
        }

        private void buttonDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridRoom.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _roomService.Delete(Convert.ToInt16(textBlockIdRoom.Text));
                LoadGridRoom();
            }
        }

        private void buttonSearchRoom_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchRoom.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchRoom.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchRoom.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridRoom.ItemsSource = _roomService.Search(textBoxSearchRoom.Text, comboBoxSearchRoom.Text);
                }
            }
        }

        private void textBoxSearchRoom_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchRoom.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchRoom.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchRoom.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridRoom.ItemsSource = _employeeService.Search(textBoxSearchRoom.Text, comboBoxSearchRoom.Text);
                }
            }
        }

        //manage department
        private void LoadGridDepartment()
        {
            textBoxNameDepartment.Text = "";
            textBlockIdDepartment.Text = "";
            dataGridDepartment.ItemsSource = _departmentService.Get();
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
                LoadCombo();
            }
        }

        private void dataGridDepartment_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridDepartment.SelectedItem;
            if (dataGridDepartment.SelectedIndex < 0)
            {
                textBlockIdDepartment.Text = "";
                textBoxNameDepartment.Text = "";
            }
            else
            {
                textBlockIdDepartment.Text = (dataGridDepartment.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameDepartment.Text = (dataGridDepartment.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            }
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
                    LoadCombo();
                }
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
                LoadCombo();
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

        //MANAGE BATCH
        private void LoadGridBatch()
        {
            textBlockIdBatch.Text = "";
            textBoxNameBatch.Text = "";
            dateDateStartBatch.DisplayDate = Convert.ToDateTime("");
            dataGridBatch.ItemsSource = _batchService.Get();

        }

        private void textBoxNameBatch_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertBatch_Click(object sender, RoutedEventArgs e)
        {
            batchParam.Name = textBoxNameBatch.Text;
            DateTime? selectedDate = dateDateStartBatch.SelectedDate;
            if (selectedDate.HasValue)
            {
                batchParam.DateEnd = selectedDate.Value;
            }
            if (string.IsNullOrEmpty(textBoxNameBatch.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameBatch.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _batchService.Insert(batchParam);
                LoadGridBatch();
                LoadCombo();
            }
        }

        private void dataGridBatch_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridBatch.SelectedItem;
            if (dataGridBatch.SelectedIndex < 0)
            {
                textBlockIdBatch.Text = "";
                textBoxNameBatch.Text = "";
                dateDateStartBatch.DisplayDate = Convert.ToDateTime("");
            }
            else
            {
                textBlockIdBatch.Text = (dataGridBatch.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameBatch.Text = (dataGridBatch.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                dateDateStartBatch.DisplayDate = Convert.ToDateTime((dataGridBatch.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
            }
        }

        private void buttonUpdateBatch_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridBatch.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                batchParam.Name = textBoxNameBatch.Text;
                DateTime? selectedDate = dateDateStartBatch.SelectedDate;
                if (selectedDate.HasValue)
                {
                    batchParam.DateEnd = selectedDate.Value;
                }
                if (string.IsNullOrEmpty(textBoxNameBatch.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameBatch.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _batchService.Update(Convert.ToInt16(textBlockIdBatch.Text), batchParam);
                    LoadGridBatch();
                    LoadCombo();
                }
            }
        }

        private void buttonDeleteBatch_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridBatch.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _batchService.Delete(Convert.ToInt16(textBlockIdBatch.Text));
                LoadGridBatch();
                LoadCombo();
            }
        }

        private void buttonSearchBatch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchBatch.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchBatch.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchBatch.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridBatch.ItemsSource = _batchService.Search(textBoxSearchBatch.Text, comboBoxSearchBatch.Text);
                }
            }
        }

        private void textBoxSearchBatch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchBatch.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchBatch.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchBatch.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridBatch.ItemsSource = _batchService.Search(textBoxSearchBatch.Text, comboBoxSearchBatch.Text);
                }
            }
        }

        //manage class
        private void LoadGridClass()
        {
            textBlockIdClass.Text = "";
            textBoxNameClass.Text = "";
            comboBoxDepartmentClass.Text = "";
            comboBoxBatchClass.Text = "";
            dataGridClass.ItemsSource = _classService.Get();
        }

        private void textBoxNameClass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxCapacityClass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
        private void textBoxLocationClass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z.0-9 ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertClass_Click(object sender, RoutedEventArgs e)
        {
            classParam.Name = textBoxNameClass.Text;
            classParam.Departments = Convert.ToInt16(comboBoxDepartmentClass.SelectedValue);
            classParam.Batchs = Convert.ToInt16(comboBoxBatchClass.SelectedValue);
            if (string.IsNullOrEmpty(textBoxNameClass.Text) == true)
            {
                MessageBox.Show("Please insert name class!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameClass.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _classService.Insert(classParam);
                LoadGridClass();
                LoadCombo();
            }
        }

        private void dataGridClass_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridClass.SelectedItem;
            if (dataGridClass.SelectedIndex < 0)
            {                
                textBlockIdClass.Text = "";
                textBoxNameClass.Text = "";
                comboBoxDepartmentClass.Text = "";
                comboBoxBatchClass.Text = "";
            }
            else
            {
                textBlockIdClass.Text = (dataGridClass.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameClass.Text = (dataGridClass.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                comboBoxDepartmentClass.Text = (dataGridClass.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                comboBoxBatchClass.Text = (dataGridClass.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void buttonUpdateClass_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridClass.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                classParam.Name = textBoxNameClass.Text; classParam.Name = textBoxNameClass.Text;
                classParam.Departments = Convert.ToInt16(comboBoxDepartmentClass.SelectedValue);
                classParam.Batchs = Convert.ToInt16(comboBoxBatchClass.SelectedValue);
                if (string.IsNullOrEmpty(textBoxNameClass.Text) == true)
                {
                    MessageBox.Show("Please insert name class!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameClass.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _classService.Update(Convert.ToInt16(textBlockIdClass.Text), classParam);
                    LoadGridClass();
                    LoadCombo();
                }
            }
        }

        private void buttonDeleteClass_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridClass.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _classService.Delete(Convert.ToInt16(textBlockIdClass.Text));
                LoadGridClass();
                LoadCombo();
            }
        }

        private void buttonSearchClass_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchClass.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchClass.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchClass.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridClass.ItemsSource = _classService.Search(textBoxSearchClass.Text, comboBoxSearchClass.Text);
                }
            }
        }

        private void textBoxSearchClass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchClass.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchClass.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchClass.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridClass.ItemsSource = _classService.Search(textBoxSearchClass.Text, comboBoxSearchClass.Text);
                }
            }
        }

        //MANAGE PLACEMENT
        private void LoadGridPlacement()
        {
            textBlockIdPlacement.Text = "";
            textBoxNamePlacement.Text = "";
            textBoxAddressPlacement.Text = "";
            textBoxRtPlacement.Text = "";
            textBoxRwPlacement.Text = "";
            textBoxKelurahanPlacement.Text = "";
            textBoxKecamatanPlacement.Text = "";
            textBoxKabupatenPlacement.Text = "";
            textBoxPhonePlacement.Text = "";
            dataGridPlacement.ItemsSource = _placementService.Get();

        }

        private void textBoxNamePlacement_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z., 0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxPhonePlacement_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[+0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertPlacement_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxNamePlacement.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNamePlacement.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                placementParam.Name = textBoxNamePlacement.Text;
                placementParam.Address = textBoxAddressPlacement.Text;
                placementParam.RT = Convert.ToInt16(textBoxRtPlacement.Text);
                placementParam.RW = Convert.ToInt16(textBoxRwPlacement.Text);
                placementParam.Kelurahan = textBoxKelurahanPlacement.Text;
                placementParam.Kecamatan = textBoxKecamatanPlacement.Text;
                placementParam.Kabupaten = textBoxKabupatenPlacement.Text;
                placementParam.Phone = textBoxPhonePlacement.Text;

                _placementService.Insert(placementParam);
                LoadGridPlacement();
            }
        }

        private void dataGridPlacement_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridPlacement.SelectedItem;
            if (dataGridPlacement.SelectedIndex < 0)
            {
                textBlockIdPlacement.Text = "";
                textBoxNamePlacement.Text = "";
                textBoxAddressPlacement.Text = "";
                textBoxRtPlacement.Text = "";
                textBoxRwPlacement.Text = "";
                textBoxKelurahanPlacement.Text = "";
                textBoxKecamatanPlacement.Text = "";
                textBoxKabupatenPlacement.Text = "";
                textBoxPhonePlacement.Text = "";
            }
            else
            {
                textBlockIdPlacement.Text = (dataGridPlacement.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNamePlacement.Text = (dataGridPlacement.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                textBoxAddressPlacement.Text = (dataGridPlacement.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                textBoxRtPlacement.Text = (dataGridPlacement.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                textBoxRwPlacement.Text = (dataGridPlacement.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                textBoxKelurahanPlacement.Text = (dataGridPlacement.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                textBoxKecamatanPlacement.Text = (dataGridPlacement.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                textBoxKabupatenPlacement.Text = (dataGridPlacement.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                textBoxPhonePlacement.Text = (dataGridPlacement.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
            }

        }

        private void buttonUpdatePlacement_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridPlacement.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                placementParam.Name = textBoxNamePlacement.Text;
                placementParam.Address = textBoxAddressPlacement.Text;
                placementParam.RT = Convert.ToInt16(textBoxRtPlacement.Text);
                placementParam.RW = Convert.ToInt16(textBoxRwPlacement.Text);
                placementParam.Kelurahan = textBoxKelurahanPlacement.Text;
                placementParam.Kecamatan = textBoxKecamatanPlacement.Text;
                placementParam.Kabupaten = textBoxKabupatenPlacement.Text;
                placementParam.Phone = textBoxPhonePlacement.Text;
                if (string.IsNullOrEmpty(textBoxNamePlacement.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNamePlacement.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _placementService.Update(Convert.ToInt16(textBlockIdPlacement.Text), placementParam);
                    LoadGridPlacement();
                }
            }
        }

        private void buttonDeletePlacement_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridPlacement.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _placementService.Delete(Convert.ToInt16(textBlockIdPlacement.Text));
                LoadGridPlacement();
            }
        }
        
        private void buttonSearchPlacement_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchPlacement.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchPlacement.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchPlacement.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridPlacement.ItemsSource = _placementService.Search(textBoxSearchPlacement.Text, comboBoxSearchPlacement.Text);
                }
            }
        }

        private void textBoxSearchPlacement_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchPlacement.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchPlacement.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchPlacement.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridPlacement.ItemsSource = _placementService.Search(textBoxSearchPlacement.Text, comboBoxSearchPlacement.Text);
                }
            }
        }


        //manage student
        private void LoadGridStudent()
        {
            textBlockIdStudent.Text = "";
            textBoxNameStudent.Text = "";
            textBoxPhoneStudent.Text = "";
            comboBoxClassStudent.Text = "";
            textBoxEmailStudent.Text = "";
            textBoxUsernameStudent.Text = "";
            textBoxPasswordStudent.Text = "";
            dataGridStudent.ItemsSource = _studentService.Get();
        }

        private void textBoxNameStudent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxPhoneStudent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[0-9+]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
        private void textBoxEmailStudent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z.0-9@]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBoxUsernameStudent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonInsertStudent_Click(object sender, RoutedEventArgs e)
        {
            studentParam.Name = textBoxNameStudent.Text;
            studentParam.Phone = textBoxPhoneStudent.Text;
            studentParam.Classes = Convert.ToInt16(comboBoxClassStudent.SelectedValue);
            studentParam.Email = textBoxEmailStudent.Text;
            studentParam.Username = textBoxUsernameStudent.Text;
            studentParam.Password = textBoxPasswordStudent.Text;
            if (string.IsNullOrEmpty(textBoxNameStudent.Text) == true)
            {
                MessageBox.Show("Please insert name student!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameStudent.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _studentService.Insert(studentParam);
                LoadGridStudent();
            }
        }

        private void dataGridStudent_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridStudent.SelectedItem;
            if (dataGridStudent.SelectedIndex < 0)
            {
                textBlockIdStudent.Text = "";
                textBoxNameStudent.Text = "";
                comboBoxClassStudent.Text = "";
                textBoxPhoneStudent.Text = "";
                textBoxEmailStudent.Text = "";
                textBoxUsernameStudent.Text = "";
                textBoxPasswordStudent.Text = "";
            }
            else
            {
                textBlockIdStudent.Text = (dataGridStudent.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameStudent.Text = (dataGridStudent.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                textBoxPhoneStudent.Text = (dataGridStudent.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                textBoxEmailStudent.Text = (dataGridStudent.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                textBoxUsernameStudent.Text = (dataGridStudent.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                textBoxPasswordStudent.Text = (dataGridStudent.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                comboBoxClassStudent.Text = (dataGridStudent.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void buttonUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridStudent.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                studentParam.Name = textBoxNameStudent.Text;
                studentParam.Phone = textBoxPhoneStudent.Text;
                studentParam.Classes = Convert.ToInt16(comboBoxClassStudent.SelectedValue);
                studentParam.Email = textBoxEmailStudent.Text;
                studentParam.Username = textBoxUsernameStudent.Text;
                studentParam.Password = textBoxPasswordStudent.Text;
                if (string.IsNullOrEmpty(textBoxNameStudent.Text) == true)
                {
                    MessageBox.Show("Please insert name student!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameStudent.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _studentService.Update(Convert.ToInt16(textBlockIdStudent.Text), studentParam);
                    LoadGridStudent();
                }
            }
        }

        private void buttonDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridStudent.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _studentService.Delete(Convert.ToInt16(textBlockIdStudent.Text));
                LoadGridStudent();
            }
        }

        private void buttonSearchStudent_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchStudent.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchStudent.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchStudent.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridStudent.ItemsSource = _studentService.Search(textBoxSearchStudent.Text, comboBoxSearchStudent.Text);
                }
            }
        }

        private void textBoxSearchStudent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchStudent.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchStudent.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchStudent.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridStudent.ItemsSource = _studentService.Search(textBoxSearchStudent.Text, comboBoxSearchStudent.Text);
                }
            }
        }

        //Manage ProfileHR
        private void LoadProfile()
        {
            var get = _employeeService.Get(Settings.Default.Id);
            textBlockIdProfileHR.Text = Convert.ToString(get.Id);
            textBoxNameProfileHR.Text = get.Name;
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
            DateTime? selectedDate = dateDobProfileHR.SelectedDate;
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
            employeeParam.RT = Convert.ToInt16(textBoxRtProfileHR.Text);
            employeeParam.RW = Convert.ToInt16(textBoxRwProfileHR.Text);
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
