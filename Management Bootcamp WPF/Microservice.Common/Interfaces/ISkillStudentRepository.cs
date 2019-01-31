using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface ISkillStudentRepository
    {
        bool Insert(SkillStudentParam skillStudentParam);
        bool Update(int? id, SkillStudentParam skillStudentParam);
        bool Delete(int? id);
        List<SkillStudent> Get();
        SkillStudent Get(int? id);
        List<SkillStudent> Search(string keyword, string category);
    }
}
