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
    public class DailyScoreRepository : IDailyScoreRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        DailyScore dailyScore = new DailyScore();

        public bool Delete(int? id)
        {
            var result = 0;
            var dailyScore = Get(id);
            dailyScore.IsDelete = true;
            dailyScore.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
                Console.Read();
            }
            return status;
        }

        public List<DailyScore> Get()
        {
            return _context.DailyScores.Where(x => x.IsDelete == false).ToList();
        }

        public DailyScore Get(int? id)
        {
            return _context.DailyScores.Find(id);
        }

        public bool Insert(DailyScoreParam dailyScoreParam)
        {
            var result = 0;
            dailyScore.Date = DateTimeOffset.Now.LocalDateTime;
            dailyScore.Score1 = dailyScoreParam.Score1;
            dailyScore.Score2 = dailyScoreParam.Score2;
            dailyScore.Score3 = dailyScoreParam.Score3;
            dailyScore.students = _context.Students.Find(Convert.ToInt16(dailyScoreParam.Students));
            dailyScore.employees = _context.Employees.Find(Convert.ToInt16(dailyScoreParam.Employees));
            dailyScore.lessons = _context.Lessons.Find(Convert.ToInt16(dailyScoreParam.Lessons));
            dailyScore.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.DailyScores.Add(dailyScore);
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

        public List<DailyScore> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.DailyScores.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else if (category == "Lessons")
            {
                return _context.DailyScores.Where(x => (x.IsDelete == false) && (x.lessons.Name.Contains(keywoard))).ToList();
            }
            else if (category == "Student Name")
            {
                return _context.DailyScores.Where(x => (x.IsDelete == false) && (x.students.FirstName.Contains(keywoard))).ToList();
            }
            else if (category == "Employee")
            {
                return _context.DailyScores.Where(x => (x.IsDelete == false) && (x.employees.FirstName.Contains(keywoard))).ToList();
            }
            else
            {
                return _context.DailyScores.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, DailyScoreParam dailyScoreParam)
        {
            var result = 0;
            var dailyScore = Get(id);
            dailyScore.Date = DateTimeOffset.Now.LocalDateTime;
            dailyScore.Score1 = dailyScoreParam.Score1;
            dailyScore.Score2 = dailyScoreParam.Score2;
            dailyScore.Score3 = dailyScoreParam.Score3;
            dailyScore.students = _context.Students.Find(Convert.ToInt16(dailyScoreParam.Students));
            dailyScore.employees = _context.Employees.Find(Convert.ToInt16(dailyScoreParam.Employees));
            dailyScore.lessons = _context.Lessons.Find(Convert.ToInt16(dailyScoreParam.Lessons));
            dailyScore.UpdateDate = DateTimeOffset.Now.LocalDateTime;            
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

        //public bool Insert(DailyScoreParam dailyScoreParam)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Update(int? id, DailyScoreParam dailyScoreParam)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
