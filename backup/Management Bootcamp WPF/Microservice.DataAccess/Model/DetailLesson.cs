using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class DetailLesson : BaseModel
    {
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public string LinkFile { get; set; }
        public virtual Employee employees { get; set; }
        public virtual Lesson lessons { get; set; }
    }
}
