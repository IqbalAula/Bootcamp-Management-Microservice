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
        ILoginService _loginService = new LoginService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = textBoxUsername.Text;
            var password = passwordBoxPassword.Password;
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
                    if (string.IsNullOrEmpty(passwordBoxPassword.Password) == true)
                    {
                        MessageBox.Show("Please insert password!");
                    }
                    else if (string.IsNullOrWhiteSpace(passwordBoxPassword.Password) == true)
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
                                if (get.Password == password)
                                {
                                    if (get.IsDelete == false)
                                    {
                                        Settings.Default.Id = get.Id;
                                        Settings.Default.username = get.Username;
                                        Settings.Default.password = get.Password;
                                        if (string.IsNullOrEmpty(get.SecretQuestion) == false || string.IsNullOrEmpty(get.SecretAnswer) == false || string.IsNullOrWhiteSpace(get.SecretQuestion) == false || string.IsNullOrWhiteSpace(get.SecretAnswer) == false)
                                        {
                                            if (Settings.Default.password == "bootcamp")
                                            {
                                                new CheckSecretStudent().Show();
                                                this.Close();
                                            }
                                            else
                                            {
                                                new MenuStudent().Show(); 
                                                this.Close();
                                            }
                                        }
                                        else
                                        {
                                            new SecretStudent().Show();
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sorry your account was banned");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Sorry the password you entered are incorrect");
                                }
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
                                if (get.Password == password)
                                {
                                    if (get.IsDelete == false)
                                    {
                                        Settings.Default.Id = get.Id;
                                        Settings.Default.username = get.Username;
                                        Settings.Default.password = get.Password;
                                        Settings.Default.role = get.Role;
                                        if (string.IsNullOrEmpty(get.SecretQuestion) == false || string.IsNullOrEmpty(get.AnswerQuestion) == false || string.IsNullOrWhiteSpace(get.SecretQuestion) == false || string.IsNullOrWhiteSpace(get.AnswerQuestion) == false)
                                        {
                                            if (Settings.Default.password == "bootcamp")
                                            {
                                                new CheckSecretEmployee().Show();
                                                this.Close();

                                            }
                                            else
                                            {
                                                if (Settings.Default.role == "Manager")
                                                {
                                                    new MenuHR().Show();
                                                    this.Close();
                                                }
                                                else if (Settings.Default.role == "HR")
                                                {
                                                    new MenuHR().Show();
                                                    this.Close();
                                                }
                                                else if (Settings.Default.role == "Mentor")
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
                                            new SecretEmployee().Show();
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sorry your account was banned");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Sorry the password you entered are incorrect");
                                }
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
                    if (string.IsNullOrEmpty(passwordBoxPassword.Password) == true)
                    {
                        MessageBox.Show("Please insert password!");
                    }
                    else if (string.IsNullOrWhiteSpace(passwordBoxPassword.Password) == true)
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
                                if (get.Password == password)
                                {
                                    if (get.IsDelete == false)
                                    {
                                        Settings.Default.Id = get.Id;
                                        Settings.Default.username = get.Username;
                                        Settings.Default.password = get.Password;
                                        if (string.IsNullOrEmpty(get.SecretQuestion) == false || string.IsNullOrEmpty(get.SecretAnswer) == false || string.IsNullOrWhiteSpace(get.SecretQuestion) == false || string.IsNullOrWhiteSpace(get.SecretAnswer) == false)
                                        {
                                            if (Settings.Default.password == "bootcamp")
                                            {
                                                new CheckSecretStudent().Show();
                                                this.Close();
                                            }
                                            else
                                            {
                                                new MenuStudent().Show();
                                                this.Close();
                                            }
                                        }
                                        else
                                        {
                                            new SecretStudent().Show();
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sorry your account was banned");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Sorry the password you entered are incorrect");
                                }
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
                                if (get.Password == password)
                                {
                                    if (get.IsDelete == false)
                                    {
                                        Settings.Default.Id = get.Id;
                                        Settings.Default.username = get.Username;
                                        Settings.Default.password = get.Password;
                                        Settings.Default.role = get.Role;
                                        if (string.IsNullOrEmpty(get.SecretQuestion) == false || string.IsNullOrEmpty(get.AnswerQuestion) == false || string.IsNullOrWhiteSpace(get.SecretQuestion) == false || string.IsNullOrWhiteSpace(get.AnswerQuestion) == false)
                                        {
                                            if (Settings.Default.password == "bootcamp")
                                            {
                                                new CheckSecretEmployee().Show();
                                                this.Close();

                                            }
                                            else
                                            {
                                                if (Settings.Default.role == "Manager")
                                                {
                                                    new MenuHR().Show();
                                                    this.Close();
                                                }
                                                else if (Settings.Default.role == "HR")
                                                {
                                                    new MenuHR().Show();
                                                    this.Close();
                                                }
                                                else if (Settings.Default.role == "Mentor")
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
                                            new SecretEmployee().Show();
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sorry your account was banned");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Sorry the password you entered are incorrect");
                                }
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
            }
            else
            {
                MessageBox.Show("Please Choice Category As Login");
            }
        }

        private void buttonForgot_Click(object sender, RoutedEventArgs e)
        {
            new ForgotPass().Show();
            this.Close();
        }
    }
}
