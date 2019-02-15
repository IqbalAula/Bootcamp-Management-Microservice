using Management_Bootcamp_WPF.Properties;
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
    /// Interaction logic for SecretEmployee.xaml
    /// </summary>
    public partial class SecretEmployee : Window
    {
        IEmployeeService _employeeService = new EmployeeService();
        EmployeeParam employeeParam = new EmployeeParam();
        public SecretEmployee()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            employeeParam.SecretQuestion = comboBoxQuestion.Text;
            employeeParam.AnswerQuestion = textBoxAnswer.Text;
            if (string.IsNullOrEmpty(comboBoxQuestion.Text) == false)
            {
                if (string.IsNullOrEmpty(textBoxAnswer.Text) == true)
                {
                    MessageBox.Show("Please insert answer question!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxAnswer.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _employeeService.UpdateS(Settings.Default.Id, employeeParam);                    
                    if (Settings.Default.password == "bootcamp")
                    {
                        new ChangePassEmployee().Show();
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
            }
            else
            {
                MessageBox.Show("Please choice secret question!");
            }
        }
    }
}
