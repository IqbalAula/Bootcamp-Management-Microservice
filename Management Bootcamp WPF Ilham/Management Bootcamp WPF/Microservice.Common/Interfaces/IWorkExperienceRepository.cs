using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface IWorkExperienceRepository
    {
        bool Insert(WorkExperienceParam workExperienceParam);
        bool Update(int? id, WorkExperienceParam workExperienceParam);
        bool Delete(int? id);
        List<WorkExperience> Get();
        WorkExperience Get(int? id);
        List<WorkExperience> Search(string keyword, string category);
    }
}
