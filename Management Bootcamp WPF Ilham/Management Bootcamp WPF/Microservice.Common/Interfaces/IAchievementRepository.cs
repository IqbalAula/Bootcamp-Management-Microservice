using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface IAchievementRepository
    {
        bool Insert(AchievementParam achievementParam);
        bool Update(int? id, AchievementParam achievementParam);
        bool Delete(int? id);
        List<Achievement> Get();
        Achievement Get(int? id);
        List<Achievement> Search(string keywoard, string category);
    }
}
