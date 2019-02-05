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
    public class SkillService : ISkillService
    {
        bool status = false;
        ISkillRepository _skillRepository = new SkillRepository();
        public bool Delete(int? id)
        {
            if (_skillRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _skillRepository.Delete(id);
            }
            return status;
        }

        public List<Skill> Get()
        {
            return _skillRepository.Get();
        }

        public Skill Get(int? id)
        {
            return _skillRepository.Get(id);
        }

        public bool Insert(SkillParam skillParam)
        {
            return _skillRepository.Insert(skillParam);
        }

        public List<Skill> Search(string keyword, string category)
        {
            return _skillRepository.Search(keyword, category);
        }
        
        public bool Update(int? id, SkillParam skillParam)
        {
            if (_skillRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else
            {
                status = _skillRepository.Update(id, skillParam);
            }
            return status;
        }
    }
}
