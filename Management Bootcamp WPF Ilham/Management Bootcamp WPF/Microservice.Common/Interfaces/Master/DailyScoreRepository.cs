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

        public bool Insert(DailyScore dailyScoreParam)
        {
            var result = 0;
            dailyScore.Date = DateTimeOffset.Now.LocalDateTime;
            dailyScore.Score1 = dailyScoreParam.Score1;
            dailyScore.Score2 = dailyScoreParam.Score1;
            dailyScore.Score3 = dailyScoreParam.Score1;
            dailyScore.Students.Id = dailyScoreParam.Students.Id;
            dailyScore.Employees.Id = dailyScoreParam.Employees.Id;
            dailyScore.Lessons.Id = dailyScoreParam.Lessons.Id;
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
            else
            {
                return _context.DailyScores.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, DailyScore dailyScoreParam)
        {
            var result = 0;
            var dailyScore = Get(id);
            dailyScore.Date = DateTimeOffset.Now.LocalDateTime;
            dailyScore.Score1 = dailyScoreParam.Score1;
            dailyScore.Score2 = dailyScoreParam.Score1;
            dailyScore.Score3 = dailyScoreParam.Score1;
            dailyScore.Students.Id = dailyScoreParam.Students.Id;
            dailyScore.Employees.Id = dailyScoreParam.Employees.Id;
            dailyScore.Lessons.Id = dailyScoreParam.Lessons.Id;
            dailyScore.UpdateDate = DateTimeOffset.Now.LocalDateTime;            
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Update Successfully");
                Console.Read();
            }
            else
            {
                MessageBox.Show("Update Failed");
            }
            return status;
        }
    }
}
