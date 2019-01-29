using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class SkillStudent : BaseModel
    {
        public virtual Student Students { get; set; }
        public virtual Skill Skills { get; set; }
    }
}
