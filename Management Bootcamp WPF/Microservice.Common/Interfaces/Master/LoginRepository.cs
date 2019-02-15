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
        
        public Employee GetEmployee(string username)
        {
            return _context.Employees.Where(x => x.Username == username).SingleOrDefault();
        }

        public Student GetStudent(string username)
        {
            return _context.Students.Where(x => x.Username == username).SingleOrDefault();
        }
    }
}
