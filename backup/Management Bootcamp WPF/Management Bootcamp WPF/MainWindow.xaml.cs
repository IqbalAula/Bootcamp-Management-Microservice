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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Management_Bootcamp_WPF.Properties;

namespace Management_Bootcamp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ILoginService loginService = new LoginService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = textBoxUsername.Text;
            var password = passwordBoxPassword.Password;
            var loginas = comboBoxLoginAs.Text;
            if (loginas == "Student")
            {
                var get = loginService.GetStudent(username, password);
                if (get == null)
                {
                    MessageBox.Show("Sorry your username and password not correct");

                }
                else
                {
                    Settings.Default.Id = get.Id;
                    Settings.Default.username = get.Username;
                    Settings.Default.password = get.Password;
                    new MenuStudent().Show();
                    this.Close();
                }
            }
            else if (loginas == "Employee")
            {
                var get = loginService.GetEmployee(username, password);
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
                    if (get.Role == "Manager")
                    {
                        new MenuHR().Show();
                        this.Close();
                    }
                    else if (get.Role == "HR")
                    {
                        new MenuHR().Show();
                        this.Close();
                    } else if (get.Role == "Mentor")
                    {
                        new MenuMentor().Show();
                        this.Close();
                    } else
                    {
                        MessageBox.Show("Sorry account cannot access the systems!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Choice Category As Login");
            }
        }

        private void passwordBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            var username = textBoxUsername.Text;
            var password = passwordBoxPassword.Password;
            var loginas = comboBoxLoginAs.Text;
            if (loginas == "Student")
            {
                var get = loginService.GetStudent(username, password);
                if (get == null)
                {
                    MessageBox.Show("Sorry your username and password not correct");

                }
                else
                {
                    Settings.Default.Id = get.Id;
                    Settings.Default.username = get.Username;
                    Settings.Default.password = get.Password;
                    new MenuStudent().Show();
                    this.Close();
                }
            }
            else if (loginas == "Employee")
            {
                var get = loginService.GetEmployee(username, password);
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
                    if (get.Role == "Manager")
                    {
                        new MenuHR().Show();
                        this.Close();
                    }
                    else if (get.Role == "HR")
                    {
                        new MenuHR().Show();
                        this.Close();
                    }
                    else if (get.Role == "Mentor")
                    {
                        new MenuMentor().Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sorry account cannot access the systems!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Choice Category As Login");
            }
        }
    }
}
