using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class Achievement : BaseModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public virtual Student students { get; set; }
    }
}
