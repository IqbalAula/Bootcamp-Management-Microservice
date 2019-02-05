using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface IClassRepository
    {
        bool Insert(ClassParam classParam);
        bool Update(int? id, ClassParam classParam);
        bool Delete(int? id);
        List<Class> Get();
        Class Get(int? id);
        List<Class> Search(string keywoard, string category);
    }
}
