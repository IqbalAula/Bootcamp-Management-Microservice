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
    /// Interaction logic for SecretStudent.xaml
    /// </summary>
    public partial class SecretStudent : Window
    {
        IStudentService _studentService = new StudentService();
        StudentParam studentParam = new StudentParam();
        public SecretStudent()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {            
            studentParam.SecretQuestion = comboBoxQuestion.Text;            
            studentParam.SecretAnswer = textBoxAnswer.Text;
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
                    _studentService.UpdateS(Settings.Default.Id, studentParam);
                    if (Settings.Default.password == "bootcamp")
                    {
                        new ChangePassStudent().Show();
                        this.Close();
                    }
                    else
                    {
                        new MenuStudent().Show();
                        this.Close();
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
