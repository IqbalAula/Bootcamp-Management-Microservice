using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.Common.Interfaces.Master;
using Microservice.Common.Interfaces;
using System.Windows.Forms;

namespace Microservice.BussinessLogic.Services.Master
{
    public class DetailLessonService : IDetailLessonService
    {
        bool status = false;
        IDetailLessonRepository _detailLessonRepository = new DetailLessonRepository();
        public bool Delete(int? id)
        {
            if (_detailLessonRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _detailLessonRepository.Delete(id);
            }
            return status;
        }

        public List<DetailLesson> Get()
        {
            return _detailLessonRepository.Get();
        }

        public DetailLesson Get(int? id)
        {
            return _detailLessonRepository.Get(id);
        }

        public bool Insert(DetailLessonParam detailLessonParam)
        {
            if (detailLessonParam.Name.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _detailLessonRepository.Insert(detailLessonParam);
            }
            return status;
        }

        public List<DetailLesson> Search(string keywoard, string category)
        {
            return _detailLessonRepository.Search(keywoard, category);
        }

        public bool Update(int? id, DetailLessonParam detailLessonParam)
        {
            if (_detailLessonRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (detailLessonParam.Name.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else
                {
                    status = _detailLessonRepository.Update(id, detailLessonParam);
                }
            }
            return status;
        }
    }
}
