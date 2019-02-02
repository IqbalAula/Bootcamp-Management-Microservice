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
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
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

        public bool Insert(AchievementParam achievementParam)
        {
            if (achievementParam.Name.ToString() == " " && achievementParam.Date.Date.ToString() == " " &&  achievementParam.students.Id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _achievementRepository.Insert(achievementParam);
            }
            return status;
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
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (achievementParam.Name.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else if (achievementParam.Date.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Date");
                }
                else
                {
                    status = _achievementRepository.Update(id, achievementParam);
                }
            }
            return status;
        }
    }
}
