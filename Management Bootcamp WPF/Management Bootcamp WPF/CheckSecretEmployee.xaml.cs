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
    /// Interaction logic for CheckSecretEmployee.xaml
    /// </summary>
    public partial class CheckSecretEmployee : Window
    {
        IEmployeeService _employeeService = new EmployeeService();
        public CheckSecretEmployee()
        {
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
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
                    var get = _employeeService.Get(Settings.Default.Id);
                    if (get.SecretQuestion == comboBoxQuestion.Text && get.AnswerQuestion == textBoxAnswer.Text)
                    {
                        new ChangePassEmployee().Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sorry the question and answer you entered are incorrect");
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
