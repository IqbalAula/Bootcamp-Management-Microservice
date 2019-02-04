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
    public class WorkExperienceService : IWorkExperienceService
    {
        bool status = false;
        IWorkExperienceRepository _workExperienceRepository = new WorkExperienceRepository();
        public bool Delete(int? id)
        {
            if (_workExperienceRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _workExperienceRepository.Delete(id);
            }
            return status;
        }

        public List<WorkExperience> Get()
        {
            return _workExperienceRepository.Get();
        }

        public WorkExperience Get(int? id)
        {
            return _workExperienceRepository.Get(id);
        }

        public List<WorkExperience> GetStudent(int? id)
        {
            return _workExperienceRepository.GetStudent(id);
        }

        public bool Insert(WorkExperienceParam workExperienceParam)
        {
            return _workExperienceRepository.Insert(workExperienceParam);
        }

        public List<WorkExperience> Search(string keyword, string category)
        {
            return _workExperienceRepository.Search(keyword, category);
        }
        
        public bool Update(int? id, WorkExperienceParam workExperienceParam)
        {
            if (_workExperienceRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _workExperienceRepository.Update(id, workExperienceParam);
            }
            return status;
        }
    }
}
