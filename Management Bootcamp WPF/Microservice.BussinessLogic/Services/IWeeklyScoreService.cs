using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.BussinessLogic.Services
{
    public interface IWeeklyScoreService
    {
        bool Insert(WeeklyScoreParam weeklyScoreParam);
        bool Update(int? id, WeeklyScoreParam weeklyScoreParam);
        bool Delete(int? id);
        List<WeeklyScore> Get();
        WeeklyScore Get(int? id);
        List<WeeklyScore> Search(string keyword, string category);
    }
}
