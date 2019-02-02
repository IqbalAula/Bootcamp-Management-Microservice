using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface ITaskScoreRepository
    {
        bool Insert(TaskScoreParam taskScoreParam);
        bool Update(int? id, TaskScoreParam taskScoreParam);
        bool Delete(int? id);
        List<TaskScore> Get();
        TaskScore Get(int? id);
        List<TaskScore> Search(string keyword, string category);
    }
}
