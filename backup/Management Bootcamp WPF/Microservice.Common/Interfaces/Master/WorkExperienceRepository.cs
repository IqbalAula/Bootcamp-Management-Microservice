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
    public class WorkExperienceRepository : IWorkExperienceRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        WorkExperience workExperience = new WorkExperience();
        public bool Delete(int? id)
        {
            var result = 0;
            var workExperience = Get(id);
            workExperience.IsDelete = true;
            workExperience.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
            }
            return status;
        }

        public List<WorkExperience> Get()
        {
            return _context.WorkExperiences.Where(x => x.IsDelete == false).ToList();
        }

        public WorkExperience Get(int? id)
        {
            //return _context.WorkExperiences.Where(x => (x.IsDelete == false) && (x.Id == id)).SingleOrDefault();
            return _context.WorkExperiences.Find(id);
        }

        public bool Insert(WorkExperienceParam workExperienceParam)
        {
            var result = 0;
            workExperience.Name = workExperienceParam.Name;
            workExperience.Position = workExperienceParam.Position;
            workExperience.Description = workExperienceParam.Description;
            workExperience.DateStart = workExperienceParam.DateStart;
            workExperience.DateEnd = workExperienceParam.DateEnd;
            workExperience.students = _context.Students.Find(workExperienceParam.students);
            workExperience.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.WorkExperiences.Add(workExperience);
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Insert Successfully");
            }
            return status;
        }

        public List<WorkExperience> Search(string keyword, string category)
        {
            if (category == "Id")
            {
                return _context.WorkExperiences.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keyword))).ToList();
            }
            else if (category == "Name")
            {                
                return _context.WorkExperiences.Where(x => (x.IsDelete == false) && (x.Name.Contains(keyword))).ToList();                
            }
            else
            {                
                return _context.WorkExperiences.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, WorkExperienceParam workExperienceParam)
        {
            var result = 0;
            var workExperience = Get(id);
            workExperience.Name = workExperienceParam.Name;
            workExperience.Position = workExperienceParam.Position;
            workExperience.Description = workExperienceParam.Description;
            workExperience.DateStart = workExperienceParam.DateStart;
            workExperience.DateEnd = workExperienceParam.DateEnd;
            workExperience.students = _context.Students.Find(workExperienceParam.students);
            workExperience.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<WorkExperience> GetStudent(int? id)
        {
            return _context.WorkExperiences.Where(x => x.IsDelete == false && x.students.Id == id).ToList();
        }
    }
}
