using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class HistoryEducationParam
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string StudyProgram { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Ipk { get; set; }
        public string universitys { get; set; }
        public string students { get; set; }
    }
}
