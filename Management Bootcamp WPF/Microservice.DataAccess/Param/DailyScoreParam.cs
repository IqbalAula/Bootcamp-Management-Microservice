using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class DailyScoreParam
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Score1 { get; set; }
        public double Score2 { get; set; }
        public double Score3 { get; set; }
        public string Students { get; set; }
        public string Employees { get; set; }
        public string Lessons { get; set; }
    }
}
