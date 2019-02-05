using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.Common.Interfaces.Master;
using Microservice.Common.Interfaces;
using System.Windows.Forms;

namespace Microservice.BussinessLogic.Services.Master
{
    public class WeeklyScoreService : IWeeklyScoreService
    {
        bool status = false;
        IWeeklyScoreRepository _weeklyScoreRepository = new WeeklyScoreRepository();
        public bool Delete(int? id)
        {
            if (_weeklyScoreRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _weeklyScoreRepository.Delete(id);
            }
            return status;
        }

        public List<WeeklyScore> Get()
        {
            return _weeklyScoreRepository.Get();
        }

        public WeeklyScore Get(int? id)
        {
            return _weeklyScoreRepository.Get(id);
        }

        public bool Insert(WeeklyScoreParam WeeklyScoreParam)
        {
            if (WeeklyScoreParam.Score1.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _weeklyScoreRepository.Insert(WeeklyScoreParam);
            }
            return status;
        }

        public List<WeeklyScore> Search(string keyword, string category)
        {
            return _weeklyScoreRepository.Search(keyword, category);
        }

        public bool Update(int? id, WeeklyScoreParam WeeklyScoreParam)
        {
            if (_weeklyScoreRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (WeeklyScoreParam.Score1.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else
                {
                    status = _weeklyScoreRepository.Update(id, WeeklyScoreParam);
                }
            }
            return status;
        }
    }
}
