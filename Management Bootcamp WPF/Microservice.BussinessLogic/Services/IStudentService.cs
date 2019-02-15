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
        bool UpdateHR(int? id, StudentParam studentParam);
        bool UpdatePr(int? id, StudentParam studentParam);
        bool UpdateS(int? id, StudentParam studentParam);
        bool UpdateP(int? id, StudentParam studentParam);
        bool Delete(int? id);
        List<Student> Get();
        Student Get(int? id);
        List<Student> Search(string keyword, string category);
        List<Student> Join(int? id);
    }
}
