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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Pob { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Address { get; set; }
        public int RT { get; set; }
        public int RW { get; set; }
        public string Village { get; set; }
        public string District { get; set; }
        public string Regencie { get; set; }
        public string Provience { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public string AccessCard { get; set; }
        public string HiringLocation { get; set; }
        public virtual Class classes { get; set; }

    }
}
