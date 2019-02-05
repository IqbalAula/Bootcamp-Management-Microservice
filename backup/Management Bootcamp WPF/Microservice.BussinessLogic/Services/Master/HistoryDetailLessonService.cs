using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.Common.Interfaces;
using System.Windows.Forms;

namespace Microservice.BussinessLogic.Services.Master
{
    public class HistoryDetailLessonService : IHistoryDetailLessonService
    {
        bool status = false;
        IHistoryDetailLessonRepository _historyDetailLesson = new HistoryDetailLessonRepository();
        public bool Delete(int? id)
        {
            if (_historyDetailLesson.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _historyDetailLesson.Delete(id);
            }
            return status;
        }

        public List<HistoryDetailLesson> Get()
        {
            return _historyDetailLesson.Get();
        }

        public HistoryDetailLesson Get(int? id)
        {
            return _historyDetailLesson.Get(id);
        }

        public bool Insert(HistoryDetailLessonParam historyDetailLessonParam)
        {
            if (historyDetailLessonParam.students.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _historyDetailLesson.Insert(historyDetailLessonParam);
            }
            return status;
        }

        public List<HistoryDetailLesson> Search(string keywoard, string category)
        {
            return _historyDetailLesson.Search(keywoard, category);
        }

        public bool Update(int? id, HistoryDetailLessonParam historyDetailLessonParam)
        {
            if (_historyDetailLesson.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (historyDetailLessonParam.students.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else
                {
                    status = _historyDetailLesson.Update(id, historyDetailLessonParam);
                }
            }
            return status;
        }
    }
}
