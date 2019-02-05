using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class Lesson : BaseModel
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public string LinkFile { get; set; }
        public virtual Department departements { get; set; }
        public virtual Employee employees { get; set; }
    }
}
