using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.Common.Interfaces;
using Microservice.Common.Interfaces.Master;
using System.Windows.Forms;

namespace Microservice.BussinessLogic.Services.Master
{
    public class LoginService : ILoginService
    {
        ILoginRepository _loginRepository = new LoginRepository();
        
        public Employee GetEmployee(string username)
        {
            return _loginRepository.GetEmployee(username);
        }

        public Student GetStudent(string username)
        {
            return _loginRepository.GetStudent(username);
        }
    }
}
