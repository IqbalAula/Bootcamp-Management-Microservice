using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class DetailLessonParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public string LinkFile { get; set; }
        public string Employees { get; set; }
        public string Lessons { get; set; }
    }
}
