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
    public class ClassService : IClassService
    {
        bool status = false;
        IClassRepository _classRepository = new ClassRepository();
        public bool Delete(int? id)
        {
            if (_classRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _classRepository.Delete(id);
            }
            return status;
        }

        public List<Class> Get()
        {
            return _classRepository.Get();
        }

        public Class Get(int? id)
        {
            return _classRepository.Get(id);
        }

        public bool Insert(ClassParam classParam)
        {
            if (classParam.Name.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _classRepository.Insert(classParam);
            }
            return status;
        }

        public List<Class> Search(string keywoard, string category)
        {
            return _classRepository.Search(keywoard, category);
        }

        public bool Update(int? id, ClassParam classParam)
        {
            if (_classRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (classParam.Name.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else
                {
                    status = _classRepository.Update(id, classParam);
                }
            }
            return status;
        }
    }
}
