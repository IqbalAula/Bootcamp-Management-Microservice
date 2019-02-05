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
    public class TaskScoreRepository : ITaskScoreRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        TaskScore taskScore = new TaskScore();
        public bool Delete(int? id)
        {
            var result = 0;
            var taskScore = Get(id);
            taskScore.IsDelete = true;
            taskScore.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
            }
            return status;
        }

        public List<TaskScore> Get()
        {
            return _context.TaskScores.Where(x => x.IsDelete == false).ToList();
        }

        public TaskScore Get(int? id)
        {
            return _context.TaskScores.Find(id);
        }

        public bool Insert(TaskScoreParam taskScoreParam)
        {
            var result = 0;
            taskScore.Name = taskScoreParam.Name;
            taskScore.Date = DateTimeOffset.Now.LocalDateTime;
            taskScore.Score1 = taskScoreParam.Score1;
            taskScore.Score2 = taskScoreParam.Score2;
            taskScore.Score3 = taskScoreParam.Score3;
            taskScore.Score4 = taskScoreParam.Score4;
            taskScore.Score5 = taskScoreParam.Score5;
            taskScore.students = _context.Students.Find(Convert.ToInt16(taskScoreParam.students));
            taskScore.employees = _context.Employees.Find(Convert.ToInt16(taskScoreParam.employees));
            taskScore.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.TaskScores.Add(taskScore);
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

        public List<TaskScore> Search(string keyword, string category)
        {
            if (category == "Id")
            {
                return _context.TaskScores.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keyword))).ToList();
            }
            else if (category == "Name")
            {
                return _context.TaskScores.Where(x => (x.IsDelete == false) && (x.Name.Contains(keyword))).ToList();
            }
            else if (category == "Student Name")
            {
                return _context.TaskScores.Where(x => (x.IsDelete == false) && (x.students.Name.Contains(keyword))).ToList();
            }
            else if (category == "Employee")
            {
                return _context.TaskScores.Where(x => (x.IsDelete == false) && (x.employees.Name.Contains(keyword))).ToList();
            }
            else
            {
                return _context.TaskScores.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, TaskScoreParam taskScoreParam)
        {
            var result = 0;
            var taskScore = Get(id);
            taskScore.Name = taskScoreParam.Name;
            taskScore.Date = DateTimeOffset.Now.LocalDateTime;
            taskScore.Score1 = taskScoreParam.Score1;
            taskScore.Score2 = taskScoreParam.Score2;
            taskScore.Score3 = taskScoreParam.Score3;
            taskScore.Score4 = taskScoreParam.Score4;
            taskScore.Score5 = taskScoreParam.Score5;
            taskScore.students = _context.Students.Find(Convert.ToInt16(taskScoreParam.students));
            taskScore.employees = _context.Employees.Find(Convert.ToInt16(taskScoreParam.employees));
            taskScore.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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
