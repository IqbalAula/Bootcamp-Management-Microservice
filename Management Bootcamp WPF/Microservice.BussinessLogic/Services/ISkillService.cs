using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.BussinessLogic.Services
{
    public interface ISkillService
    {
        bool Insert(SkillParam skillParam);
        bool Update(int? id, SkillParam skillParam);
        bool Delete(int? id);
        List<Skill> Get();
        Skill Get(int? id);
        List<Skill> Search(string keywoard, string category);
    }
}
