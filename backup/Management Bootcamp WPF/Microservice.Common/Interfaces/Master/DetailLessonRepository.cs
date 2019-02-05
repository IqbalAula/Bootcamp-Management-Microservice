using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Context;
using System.Windows.Forms;

namespace Microservice.Common.Interfaces.Master
{
    public class DetailLessonRepository : IDetailLessonRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        DetailLesson detailLesson = new DetailLesson();
        public bool Delete(int? id)
        {
            var result = 0;
            var detailLesson = Get(id);
            detailLesson.IsDelete = true;
            detailLesson.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
                Console.Read();
            }
            return status;
        }

        public List<DetailLesson> Get()
        {
            return _context.DetailLessons.Where(x => x.IsDelete == false).ToList();
        }

        public DetailLesson Get(int? id)
        {
            return _context.DetailLessons.Where(x => (x.IsDelete == false) && (x.Id == id)).SingleOrDefault();
        }

        public bool Insert(DetailLessonParam detailLessonParam)
        {
            var result = 0;
            detailLesson.Name = detailLessonParam.Name;
            detailLesson.Date = DateTimeOffset.Now.LocalDateTime;
            detailLesson.LinkFile = detailLessonParam.LinkFile;
            //lesson.Departements = _context.Departments.Find(Convert.ToInt16(lessonParam.Departements));
            detailLesson.employees = _context.Employees.Find(Convert.ToInt16(detailLessonParam.Employees));
            detailLesson.lessons = _context.Lessons.Find(Convert.ToInt16(detailLessonParam.Lessons));
            detailLesson.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.DetailLessons.Add(detailLesson);
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

        public List<DetailLesson> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.DetailLessons.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else if (category == "Name")
            {
                return _context.DetailLessons.Where(x => (x.IsDelete == false) && (x.Name.Contains(keywoard))).ToList();
            }
            else if (category == "Link File")
            {
                return _context.DetailLessons.Where(x => (x.IsDelete == false) && (x.LinkFile.Contains(keywoard))).ToList();
            }
            else if (category == "Lesson")
            {
                return _context.DetailLessons.Where(x => (x.IsDelete == false) && (x.lessons.Name.Contains(keywoard))).ToList();
            }
            else if (category == "Employee")
            {
                return _context.DetailLessons.Where(x => (x.IsDelete == false) && (x.employees.Name.Contains(keywoard))).ToList();
            }
            else
            {
                return _context.DetailLessons.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, DetailLessonParam detailLessonParam)
        {
            var result = 0;
            var detailLesson = Get(id);
            detailLesson.Name = detailLessonParam.Name;
            detailLesson.Date = DateTimeOffset.Now.LocalDateTime;
            detailLesson.LinkFile = detailLessonParam.LinkFile;
            detailLesson.employees = _context.Employees.Find(Convert.ToInt16(detailLessonParam.Employees));
            detailLesson.lessons = _context.Lessons.Find(Convert.ToInt16(detailLessonParam.Lessons));
            detailLesson.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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
