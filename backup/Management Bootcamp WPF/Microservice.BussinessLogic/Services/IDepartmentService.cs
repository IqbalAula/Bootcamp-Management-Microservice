using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.BussinessLogic.Services
{
    public interface IDepartmentService
    {
        bool Insert(DepartmentParam departmentParam);
        bool Update(int? id, DepartmentParam departmentParam);
        bool Delete(int? id);
        List<Department> Get();
        Department Get(int? id);
        List<Department> Search(string keyword, string category);
    }
}
