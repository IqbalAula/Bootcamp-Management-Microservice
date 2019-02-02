using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Context;

namespace Microservice.Common.Interfaces.Master
{
    public class LoginRepository : ILoginRepository
    {
        MyContext _context = new MyContext();
        
        public Employee Get(string username, string password)
        {
            return _context.Emplyoees.Where(x => (x.IsDelete == false) && (x.Username == username) && (x.Password == password)).SingleOrDefault();
        }
    }
}
