using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface IDepartmentRepository
    {
        bool Insert(DepartmentParam departmentParam);
        bool Update(int? id, DepartmentParam departmentParam);
        bool Delete(int? id);
        List<Department> Get();
        Department Get(int? id);
        List<Department> Search(string keywoard, string category);
    }
}
