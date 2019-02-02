using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class OrganizationParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public virtual Student students { get; set; }
    }
}
