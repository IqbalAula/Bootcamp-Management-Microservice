using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.BussinessLogic.Services
{
    public interface IOrganizationService
    {
        bool Insert(OrganizationParam organizationParam);
        bool Update(int? id, OrganizationParam organizationParam);
        bool Delete(int? id);
        List<Organization> Get();
        Organization Get(int? id);
        List<Organization> Search(string keyword, string category);
    }
}
