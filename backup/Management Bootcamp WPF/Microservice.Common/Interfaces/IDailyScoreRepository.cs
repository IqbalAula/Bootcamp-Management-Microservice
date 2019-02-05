using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface IDailyScoreRepository
    {
        bool Insert(DailyScoreParam dailyScoreParam);
        bool Update(int? id, DailyScoreParam dailyScoreParam);
        bool Delete(int? id);
        List<DailyScore> Get();
        DailyScore Get(int? id);
        List<DailyScore> Search(string keywoard, string category);
    }
}
