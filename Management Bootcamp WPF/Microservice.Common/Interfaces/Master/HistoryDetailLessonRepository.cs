using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Context;
using System.Windows.Forms;

namespace Microservice.Common.Interfaces
{
    public class HistoryDetailLessonRepository : IHistoryDetailLessonRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        HistoryDetailLesson historyDetailLesson = new HistoryDetailLesson();
        public bool Delete(int? id)
        {
            var result = 0;
            var historyDetailLesson = Get(id);
            historyDetailLesson.IsDelete = true;
            historyDetailLesson.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
            }
            return status;
        }

        public List<HistoryDetailLesson> Get()
        {
            return _context.HistoryDetailLessons.Where(x => x.IsDelete == false).ToList();
        }

        public HistoryDetailLesson Get(int? id)
        {
            return _context.HistoryDetailLessons.Find(id);
        }

        public bool Insert(HistoryDetailLessonParam historyDetailLessonParam)
        {
            var result = 0;
            historyDetailLesson.students.Id = historyDetailLessonParam.students.Id;
            historyDetailLesson.detailLessons.Id = historyDetailLessonParam.detailLessons.Id;
            historyDetailLesson.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.HistoryDetailLessons.Add(historyDetailLesson);
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Insert Successfully");
            }
            else
            {
                MessageBox.Show("Insert Failed");
            }
            return status;
        }

        public List<HistoryDetailLesson> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.HistoryDetailLessons.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else
            {
                return _context.HistoryDetailLessons.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, HistoryDetailLessonParam historyDetailLessonParam)
        {
            var result = 0;
            var historyDetailLesson = Get(id);
            historyDetailLesson.students.Id = historyDetailLessonParam.students.Id;
            historyDetailLesson.detailLessons.Id = historyDetailLessonParam.detailLessons.Id;
            historyDetailLesson.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Update Successfully");
            }
            else
            {
                MessageBox.Show("Update Failed");
            }

            return status;
        }
    }
}
