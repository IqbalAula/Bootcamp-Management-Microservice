using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Context;
using System.Windows.Forms;

namespace Microservice.Common.Interfaces.Master
{
    public class SkillRepository : ISkillRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Skill skill = new Skill();
        public bool Delete(int? id)
        {
            var result = 0;
            var skill = Get(id);
            skill.IsDelete = true;
            skill.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
            }
            return status;
        }

        public List<Skill> Get()
        {
            return _context.Skills.Where(x => x.IsDelete == false).ToList();
        }

        public Skill Get(int? id)
        {
            //return _context.Skills.Where(x => (x.IsDelete == false) && (x.Id == id)).SingleOrDefault();
            return _context.Skills.Find(id);
        }

        public bool Insert(SkillParam skillParam)
        {
            var result = 0;
            skill.Name = skillParam.Name;
            skill.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Skills.Add(skill);
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Insert Successfully");
            }
            return status;
        }

        public List<Skill> Search(string keyword, string category)
        {
            if (category == "Id")
            {
                return _context.Skills.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keyword))).ToList();

            }
            else if (category == "Name")
            {                
                return _context.Skills.Where(x => (x.IsDelete == false) && (x.Name.Contains(keyword))).ToList();                
            }
            else
            {                
                return _context.Skills.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, SkillParam skillParam)
        {
            var result = 0;
            var skill = Get(id);
            skill.Name = skillParam.Name;
            skill.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Update Successfully");
            }
            else
            {
                MessageBox.Show("Update Failed");
            }
            return status;
        }
    }
}
