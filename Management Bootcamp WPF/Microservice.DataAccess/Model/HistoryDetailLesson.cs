using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class HistoryDetailLesson : BaseModel
    {
        public virtual Student students { get; set; }
        public virtual DetailLesson  detailLessons { get; set; }
}
}
