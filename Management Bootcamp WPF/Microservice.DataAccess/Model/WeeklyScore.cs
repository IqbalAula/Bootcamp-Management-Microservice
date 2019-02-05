using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class WeeklyScore : BaseModel
    {
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Score1 { get; set; }
        public double Score2 { get; set; }
        public double Score3 { get; set; }
        public double Score4 { get; set; }
        public double Score5 { get; set; }
        public virtual Employee employees { get; set; }
        public virtual Student students { get; set; }
    }
}
