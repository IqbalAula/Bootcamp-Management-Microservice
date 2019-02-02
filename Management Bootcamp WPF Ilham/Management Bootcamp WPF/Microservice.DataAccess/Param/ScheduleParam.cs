using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class ScheduleParam
    {
        public int Id { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public virtual Employee employees { get; set; }
        public virtual Lesson lessons { get; set; }
        public virtual Room room { get; set; }
        public virtual Class classes { get; set; }
    }
}
