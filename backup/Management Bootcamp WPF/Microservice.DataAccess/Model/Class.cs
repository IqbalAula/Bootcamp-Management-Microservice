using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class Class : BaseModel
    {
        public string Name { get; set; }
        public Department Departments { get; set; }
        public virtual Batch Batchs { get; set; }
    }
}
