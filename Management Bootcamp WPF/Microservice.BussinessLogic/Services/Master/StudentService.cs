using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.Common.Interfaces;
using System.Windows.Forms;
using Microservice.Common.Interfaces.Master;

namespace Microservice.BussinessLogic.Services.Master
{
    public class StudentService : IStudentService
    {
        bool status = false;
        IStudentRepository _studentRepository = new StudentRepository();
        public bool Delete(int? id)
        {
            if (_studentRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _studentRepository.Delete(id);
            }
            return status;
        }

        public List<Student> Get()
        {
            return _studentRepository.Get();
        }

        public Student Get(int? id)
        {
            return _studentRepository.Get(id);
        }

        public bool Insert(StudentParam studentParam)
        {
            return _studentRepository.Insert(studentParam);
        }

        public List<Student> Join(int? id)
        {
            return _studentRepository.Join(id);
        }

        public List<Student> Search(string keyword, string category)
        {
            return _studentRepository.Search(keyword, category);
        }

        //public bool Update(int? id, StudentParam studentParam)
        //{
        //    if (_studentRepository.Get(id) == null)
        //    {
        //        MessageBox.Show("Sorry, your data is not found");
        //    }
        //    else
        //    {
        //        status = _studentRepository.Update(id, studentParam);
        //    }
        //    return status;
        //}

        public bool UpdateHR(int? id, StudentParam studentParam)
        {

            if (_studentRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _studentRepository.UpdateHR(id, studentParam);
            }
            return status;
        }

        public bool UpdateP(int? id, StudentParam studentParam)
        {

            if (_studentRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _studentRepository.UpdateP(id, studentParam);
            }
            return status;
        }

        public bool UpdatePr(int? id, StudentParam studentParam)
        {

            if (_studentRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _studentRepository.UpdatePr(id, studentParam);
            }
            return status;
        }

        public bool UpdateS(int? id, StudentParam studentParam)
        {

            if (_studentRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _studentRepository.UpdateS(id, studentParam);
            }
            return status;
        }
    }
}
