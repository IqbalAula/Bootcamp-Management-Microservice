using Microservice.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Model
{
    public class Student : BaseModel
    {
        public string Name { get; set; }
        public DateTimeOffset Dob { get; set; }
        public string Pob { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Address { get; set; }
        public int RT { get; set; }
        public int RW { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string Kabupaten { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public virtual Placement placements { get; set; }
        public virtual Class classes { get; set; }
    }
}
