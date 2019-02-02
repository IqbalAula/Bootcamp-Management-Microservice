using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class Placement : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int RT { get; set; }
        public int RW { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string Kabupaten { get; set; }
        public string Phone { get; set; }
    }
}
