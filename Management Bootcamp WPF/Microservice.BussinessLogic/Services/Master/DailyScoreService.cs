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
    public class DailyScoreService : IDailyScoreService
    {
        bool status = false;
        IDailyScoreRepository _dailyScoreRepository = new DailyScoreRepository();
        public bool Delete(int? id)
        {
            if (_dailyScoreRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _dailyScoreRepository.Delete(id);
            }
            return status;
        }

        public List<DailyScore> Get()
        {
            return _dailyScoreRepository.Get();
        }

        public DailyScore Get(int? id)
        {
            return _dailyScoreRepository.Get(id);
        }

        public bool Insert(DailyScoreParam dailyScoreParam)
        {
            if (dailyScoreParam.Score1.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _dailyScoreRepository.Insert(dailyScoreParam);
            }
            return status;

            //return _dailyScoreRepository.Insert(dailyScoreParam);
        }

        public List<DailyScore> Search(string keywoard, string category)
        {
            return _dailyScoreRepository.Search(keywoard, category);
        }

        public bool Update(int? id, DailyScoreParam dailyScoreParam)
        {
            if (_dailyScoreRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (dailyScoreParam.Score1.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else
                {
                   status = _dailyScoreRepository.Update(id, dailyScoreParam);
                }
            }
            return status;
        }
    }
}
