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
    public class OrganizationService : IOrganizationService
    {
        bool status = false;
        IOrganizationRepository _organizationRepository = new OrganizationRepository();
        public bool Delete(int? id)
        {
            if (_organizationRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _organizationRepository.Delete(id);
            }
            return status;
        }

        public List<Organization> Get()
        {
            return _organizationRepository.Get();
        }

        public Organization Get(int? id)
        {
            return _organizationRepository.Get(id);
        }

        public List<Organization> GetStudent(int? id)
        {
            return _organizationRepository.GetStudent(id);
        }

        public bool Insert(OrganizationParam organizationParam)
        {
            return _organizationRepository.Insert(organizationParam);
        }

        public List<Organization> Search(string keyword, string category)
        {
            return _organizationRepository.Search(keyword, category);
        }
        
        public bool Update(int? id, OrganizationParam organizationParam)
        {
            if (_organizationRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _organizationRepository.Update(id, organizationParam);
            }
            return status;
        }
    }
}
