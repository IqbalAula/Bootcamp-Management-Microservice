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
    public class DepartmentService : IDepartmentService
    {
        bool status = false;
        IDepartmentRepository _departmentRepository = new DepartmentRepository();
        public bool Delete(int? id)
        {
            if (_departmentRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _departmentRepository.Delete(id);
            }
            return status;
        }

        public List<Department> Get()
        {
            return _departmentRepository.Get();
        }

        public Department Get(int? id)
        {
            return _departmentRepository.Get(id);
        }

        public bool Insert(DepartmentParam departmentParam)
        {
            if (departmentParam.Name.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _departmentRepository.Insert(departmentParam);
            }
            return status;
        }

        public List<Department> Search(string keywoard, string category)
        {
            return _departmentRepository.Search(keywoard, category);
        }

        public bool Update(int? id, DepartmentParam departmentParam)
        {
            if (_departmentRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (departmentParam.Name.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");                    
                }
                else
                {
                    status = _departmentRepository.Update(id, departmentParam);
                }
            }
            return status;
        }
    }
}
