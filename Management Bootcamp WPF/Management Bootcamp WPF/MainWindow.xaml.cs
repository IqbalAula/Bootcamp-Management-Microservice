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
            var get = loginService.Get(username, password);
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
                new MenuHR().Show();
                this.Close();
            }
            ////new MenuStudent().Show();
            ////this.Close();
            //new MenuHR().Show();
            //this.Close();
        }
    }
}
