using Management_Bootcamp_WPF.Properties;
using Microservice.BussinessLogic.Services;
using Microservice.BussinessLogic.Services.Master;
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
    /// Interaction logic for ForgotPass.xaml
    /// </summary>
    public partial class ForgotPass : Window
    {
        ILoginService _loginService = new LoginService();
        public ForgotPass()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            var username = textBoxUsername.Text;
            var loginas = comboBoxLoginAs.Text;
            if (string.IsNullOrEmpty(comboBoxLoginAs.Text) == false)
            {
                if (string.IsNullOrEmpty(textBoxUsername.Text) == true)
                {
                    MessageBox.Show("Please insert username!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxUsername.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    if (loginas == "Student")
                    {
                        var get = _loginService.GetStudent(username);
                        if (get != null)
                        {
                            Settings.Default.Id = get.Id;
                            Settings.Default.username = get.Username;
                            Settings.Default.password = get.Password;
                            new CheckSecretStudent().Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sorry the username you entered is incorrect");
                        }
                    }
                    else if (loginas == "Employee")
                    {
                        var get = _loginService.GetEmployee(username);
                        if (get != null)
                        {
                            Settings.Default.Id = get.Id;
                            Settings.Default.username = get.Username;
                            Settings.Default.password = get.Password;
                            new CheckSecretEmployee().Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sorry the username you entered is incorrect");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Choice Category As Login");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Choice Category As Login");
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
