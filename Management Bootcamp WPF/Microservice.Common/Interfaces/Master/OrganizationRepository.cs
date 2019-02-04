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
    public class OrganizationRepository : IOrganizationRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Organization organization = new Organization();
        public bool Delete(int? id)
        {
            var result = 0;
            var organization = Get(id);
            organization.IsDelete = true;
            organization.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
            }
            return status;
        }

        public List<Organization> Get()
        {
            return _context.Organizations.Where(x => x.IsDelete == false).ToList();
        }

        public Organization Get(int? id)
        {
            //return _context.Organizations.Where(x => (x.IsDelete == false) && (x.Id == id)).SingleOrDefault();
            return _context.Organizations.Find(id);
        }

        public bool Insert(OrganizationParam organizationParam)
        {
            var result = 0;
            organization.Name = organizationParam.Name;
            organization.Position = organizationParam.Position;
            organization.Description = organizationParam.Description;
            organization.DateStart = organizationParam.DateStart;
            organization.DateEnd = organizationParam.DateEnd;
            organization.students = _context.Students.Find(organizationParam.students);
            organization.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Organizations.Add(organization);
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Insert Successfully");
            }
            return status;
        }

        public List<Organization> Search(string keyword, string category)
        {
            if (category == "Id")
            {
                return _context.Organizations.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keyword))).ToList();
            }
            else if (category == "Name")
            {                
                return _context.Organizations.Where(x => (x.IsDelete == false) && (x.Name.Contains(keyword))).ToList();                
            }
            else
            {                
                return _context.Organizations.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, OrganizationParam organizationParam)
        {
            var result = 0;
            var organization = Get(id);
            organization.Name = organizationParam.Name;
            organization.Position = organizationParam.Position;
            organization.Description = organizationParam.Description;
            organization.DateStart = organizationParam.DateStart;
            organization.DateEnd = organizationParam.DateEnd;
            organization.students = _context.Students.Find(organizationParam.students);
            organization.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Organization> GetStudent(int? id)
        {
            return _context.Organizations.Where(x => x.IsDelete == false && x.students.Id == id).ToList();
        }
    }
}
