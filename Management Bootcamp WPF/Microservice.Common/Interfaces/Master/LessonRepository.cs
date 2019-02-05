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
    public class LessonRepository : ILessonRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Lesson lesson = new Lesson();
        public bool Delete(int? id)
        {
            var result = 0;
            var lesson = Get(id);
            lesson.IsDelete = true;
            lesson.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
                Console.Read();
            }
            return status;
        }

        public List<Lesson> Get()
        {
            return _context.Lessons.Where(x => x.IsDelete == false).ToList();
        }

        public Lesson Get(int? id)
        {
            return _context.Lessons.Find(id);
        }

        public bool Insert(LessonParam lessonParam)
        {
            var result = 0;
            lesson.Name = lessonParam.Name;
            lesson.Level = lessonParam.Level;
            //var pull = _context.Lessons.Find(Convert.ToInt16(lessonParam.Departements));
            lesson.departements = _context.Departments.Find(Convert.ToInt16(lessonParam.Departements));
            lesson.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Lessons.Add(lesson);
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

        public List<Lesson> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.Lessons.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else if (category == "Name")
            {
                return _context.Lessons.Where(x => (x.IsDelete == false) && (x.Name.Contains(keywoard))).ToList();
            }
            else if (category == "Level")
            {
                return _context.Lessons.Where(x => (x.IsDelete == false) && (x.Level.Contains(keywoard))).ToList();
            }
            else if (category == "Department")
            {
                return _context.Lessons.Where(x => (x.IsDelete == false) && (x.departements.Name.Contains(keywoard))).ToList();
            }
            else
            {
                return _context.Lessons.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, LessonParam lessonParam)
        {
            var result = 0;
            var lesson = Get(id);
            lesson.Name = lessonParam.Name;
            lesson.Level = lessonParam.Level;
            //var pull = _context.Lessons.Find(Convert.ToInt16(lessonParam.Departements));
            lesson.departements = _context.Departments.Find(Convert.ToInt16(lessonParam.Departements)); ;
            lesson.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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
