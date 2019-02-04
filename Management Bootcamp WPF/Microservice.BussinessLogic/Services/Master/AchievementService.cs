using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.Common.Interfaces;
using Microservice.Common.Interfaces.Master;
using System.Windows.Forms;

namespace Microservice.BussinessLogic.Services.Master
{
    public class AchievementService : IAchievementService
    {
        bool status = false;
        IAchievementRepository _achievementRepository = new AchievementRepository();
        public bool Delete(int? id)
        {
            if (_achievementRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _achievementRepository.Delete(id);
            }
            return status;
        }

        public List<Achievement> Get()
        {
            return _achievementRepository.Get();
        }

        public Achievement Get(int? id)
        {
            return _achievementRepository.Get(id);
        }

        public List<Achievement> GetStudent(int? id)
        {
            return _achievementRepository.GetStudent(id);
        }

        public bool Insert(AchievementParam achievementParam)
        {
            return _achievementRepository.Insert(achievementParam);
        }

        public List<Achievement> Search(string keywoard, string category)
        {
            return _achievementRepository.Search(keywoard, category);
        }

        public bool Update(int? id, AchievementParam achievementParam)
        {
            if (_achievementRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _achievementRepository.Update(id, achievementParam);
            }
            return status;
        }
    }
}
