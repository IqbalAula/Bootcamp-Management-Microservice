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
    public class LessonService : ILessonService
    {
        bool status = false;
        ILessonRepository _lessonRepository = new LessonRepository();
        public bool Delete(int? id)
        {
            if (_lessonRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _lessonRepository.Delete(id);
            }
            return status;
        }

        public List<Lesson> Get()
        {
            return _lessonRepository.Get();
        }

        public Lesson Get(int? id)
        {
            return _lessonRepository.Get(id);
        }

        public bool Insert(LessonParam lessonParam)
        {
            if (lessonParam.Name.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _lessonRepository.Insert(lessonParam);
            }
            return status;
        }

        public List<Lesson> Search(string keywoard, string category)
        {
            return _lessonRepository.Search(keywoard, category);
        }

        public bool Update(int? id, LessonParam lessonParam)
        {
            if (_lessonRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (lessonParam.Name.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else
                {
                    status = _lessonRepository.Update(id, lessonParam);
                }
            }
            return status;
        }
    }
}
