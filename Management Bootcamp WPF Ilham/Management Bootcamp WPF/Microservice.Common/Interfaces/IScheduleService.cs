using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface IScheduleService
    {
        bool Insert(ScheduleParam scheduleParam);
        bool Update(int? id, ScheduleParam scheduleParam);
        bool Delete(int? id);
        List<Schedule> Get();
        Schedule Get(int? id);
        List<Schedule> Search(string keyword, string category);
    }
}
