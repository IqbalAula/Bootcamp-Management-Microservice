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
            return _employeeRepository.Insert(employeeParam);
        }

        public List<Employee> Search(string keyword, string category)
        {
            return _employeeRepository.Search(keyword, category);
        }

        public bool UpdateHR(int? id, EmployeeParam employeeParam)
        {
            if (_employeeRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _employeeRepository.UpdateHR(id, employeeParam);
            }
            return status;
        }

        public bool UpdateP(int? id, EmployeeParam employeeParam)
        {
            if (_employeeRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _employeeRepository.UpdateP(id, employeeParam);
            }
            return status;
        }

        public bool UpdatePr(int? id, EmployeeParam employeeParam)
        {
            if (_employeeRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _employeeRepository.UpdatePr(id, employeeParam);
            }
            return status;
        }

        public bool UpdateS(int? id, EmployeeParam employeeParam)
        {
            if (_employeeRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _employeeRepository.UpdateS(id, employeeParam);
            }
            return status;
        }
    }
}
