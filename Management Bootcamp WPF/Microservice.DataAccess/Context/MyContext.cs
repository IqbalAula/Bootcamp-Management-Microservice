using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.DataAccess.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("BootcampManagement") { }


    }
}
