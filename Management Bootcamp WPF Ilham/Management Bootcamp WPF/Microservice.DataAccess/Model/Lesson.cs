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
        public string level { get; set; }

        public virtual Department Departements { get; set; }
    }
}
