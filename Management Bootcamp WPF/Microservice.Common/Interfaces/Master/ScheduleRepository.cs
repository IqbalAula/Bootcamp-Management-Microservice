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
    public class ScheduleRepository : IScheduleRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Schedule schedule = new Schedule();
        public bool Delete(int? id)
        {
            var result = 0;
            var schedule = Get(id);
            schedule.IsDelete = true;
            schedule.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
            }
            return status;
        }

        public List<Schedule> Get()
        {
            return _context.Schedules.Where(x => x.IsDelete == false).ToList();
        }

        public Schedule Get(int? id)
        {
            return _context.Schedules.Find(id);
        }

        public bool Insert(ScheduleParam scheduleParam)
        {
            var result = 0;
            schedule.DateStart = scheduleParam.DateStart;
            schedule.DateEnd = scheduleParam.DateEnd;
            schedule.lessons = _context.Lessons.Find(Convert.ToInt16(scheduleParam.lessons));
            schedule.room = _context.Rooms.Find(Convert.ToInt16(scheduleParam.room));
            schedule.classes = _context.Classes.Find(Convert.ToInt16(scheduleParam.classes));
            schedule.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Schedules.Add(schedule);
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

        public List<Schedule> Search(string keyword, string category)
        {
            if (category == "Id")
            {
                return _context.Schedules.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keyword))).ToList();
            }
            else if (category == "Lesson")
            {
                return _context.Schedules.Where(x => (x.IsDelete == false) && (x.lessons.Name.Contains(keyword))).ToList();
            }
            else if (category == "Room")
            {
                return _context.Schedules.Where(x => (x.IsDelete == false) && (x.room.Name.Contains(keyword))).ToList();
            }
            else if (category == "Class")
            {
                return _context.Schedules.Where(x => (x.IsDelete == false) && (x.classes.Name.Contains(keyword))).ToList();
            }
            else if (category == "Date Start")
            {
                return _context.Schedules.Where(x => (x.IsDelete == false) && (x.DateStart.ToString().Contains(keyword))).ToList();
            }
            else if (category == "Date End")
            {
                return _context.Schedules.Where(x => (x.IsDelete == false) && (x.DateEnd.ToString().Contains(keyword))).ToList();
            }
            else
            {
                return _context.Schedules.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, ScheduleParam scheduleParam)
        {
            var result = 0;
            var schedule = Get(id);
            schedule.DateStart = scheduleParam.DateStart;
            schedule.DateEnd = scheduleParam.DateEnd;
            schedule.lessons = _context.Lessons.Find(Convert.ToInt16(scheduleParam.lessons));
            schedule.room = _context.Rooms.Find(Convert.ToInt16(scheduleParam.room));
            schedule.classes = _context.Classes.Find(Convert.ToInt16(scheduleParam.classes));
            schedule.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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
