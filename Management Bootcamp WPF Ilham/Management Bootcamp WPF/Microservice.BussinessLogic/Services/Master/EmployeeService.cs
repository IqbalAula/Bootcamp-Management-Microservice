using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.Common.Interfaces;
using Microservice.Common.Interfaces.Master;
using System.Windows.Forms;

namespace Microservice.BussinessLogic.Services.Master
{
    public class EmployeeService : IEmployeeService
    {
        bool status = false;
        IEmployeeRepository _employeeRepository = new EmployeeRepository();
        public bool Delete(int? id)
        {
            if (_employeeRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _employeeRepository.Delete(id);
            }
            return status;
        }

        public List<Employee> Get()
        {
            return _employeeRepository.Get();
        }

        public Employee Get(int? id)
        {
            return _employeeRepository.Get(id);
        }

        public bool Insert(EmployeeParam employeeParam)
        {
            if (employeeParam.Name.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _employeeRepository.Insert(employeeParam);
            }
            return status;
        }

        public Employee Login(string username, string password)
        {
            return _employeeRepository.Login(username, password);
        }

        public List<Employee> Search(string keywoard, string category)
        {
            return _employeeRepository.Search(keywoard, category);
        }

        public bool Update(int? id, EmployeeParam employeeParam)
        {
            if (_employeeRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (employeeParam.Name.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else
                {
                    status = _employeeRepository.Update(id, employeeParam);
                }
            }
            return status;
        }
    }
}
