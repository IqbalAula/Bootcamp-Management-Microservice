using Management_Bootcamp_WPF.Properties;
using Microservice.BussinessLogic.Services;
using Microservice.BussinessLogic.Services.Master;
using Microservice.Common.Interfaces;
using Microservice.Common.Interfaces.Master;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Management_Bootcamp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IEmployeeService _employeeService = new EmployeeService();
        //IEmployeeRepository _employeeRepository = new EmployeeRepository();
        //MyContext _context = new MyContext();
        //Employee employee = new Employee();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Text;
            var get = _employeeService.Login(username, password);
            if (get == null)
            {
                MessageBox.Show("Sorry your username and password not correct");

            }
            else
            {
                Settings.Default.Id = get.Id;
                Settings.Default.username = get.Username;
                Settings.Default.password = get.Password;
                Settings.Default.role = get.Role;
                new MenuMentor().Show();
                this.Close();
                //if (UsernameTextBox.Text == employee.Username && PasswordTextBox.Text == employee.Password)
                //{
                //    new MenuHR().Show();
                //    this.Close();
                //}
                //else if (UsernameTextBox.Text == "1" && PasswordTextBox.Text == "1")
                //{
                //    new MenuHR().Show();
                //    this.Close();
                //}
                //else if (UsernameTextBox.Text == "2" && PasswordTextBox.Text == "2")
                //{
                //    new MenuMentor().Show();
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show("Failed");
                //    //new MenuHR().Show();
                //    //this.Close();
                //}
            }
        }
    }
}
