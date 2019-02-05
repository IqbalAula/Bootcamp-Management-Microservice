using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.BussinessLogic.Services
{
    public interface IStudentService
    {
        bool Insert(StudentParam studentParam);
        bool Update(int? id, StudentParam studentParam);
        bool Delete(int? id);
        List<Student> Get();
        Student Get(int? id);
        List<Student> Search(string keyword, string category);
    }
}
