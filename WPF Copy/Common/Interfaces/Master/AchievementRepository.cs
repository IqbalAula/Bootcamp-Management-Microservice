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
    public class AchievementRepository : IAchievementRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Achievement achievement = new Achievement();
        public bool Delete(int? id)
        {
            var result = 0;
            var achievement = Get(id);
            achievement.IsDelete = true;
            achievement.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
                Console.Read();
            }
            return status;
        }

        public List<Achievement> Get()
        {
            return _context.Achievements.Where(x => x.IsDelete == false).ToList();
        }

        public Achievement Get(int? id)
        {
            return _context.Achievements.Find(id);
        }

        public bool Insert(AchievementParam achievementParam)
        {
            var result = 0;
            achievement.Name = achievementParam.Name;
            achievement.Date = DateTimeOffset.Now.LocalDateTime; ;
            achievement.students.Id = achievementParam.students.Id;
            achievement.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Achievements.Add(achievement);
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Insert Successfully");
            }
            else
            {
                MessageBox.Show("Update Failed");
            }
            return status;
        }

        public List<Achievement> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.Achievements.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else if (category == "Name")
            {
                return _context.Achievements.Where(x => (x.IsDelete == false) && (x.Name.Contains(keywoard))).ToList();
            }
            else
            {
                return _context.Achievements.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, AchievementParam achievementParam)
        {
            var result = 0;
            var achievement = Get(id);
            achievement.Name = achievementParam.Name;
            achievement.Date = DateTimeOffset.Now.LocalDateTime;
            achievement.students.Id = achievementParam.students.Id;
            achievement.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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
