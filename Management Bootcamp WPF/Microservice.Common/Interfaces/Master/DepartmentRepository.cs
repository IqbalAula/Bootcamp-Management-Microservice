using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Context;

namespace Microservice.Common.Interfaces.Master
{
    public class DepartmentRepository : IDepartmentRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Department department = new Department();
        public bool Delete(int? id)
        {
            var result = 0;
            var department = Get(id);
            department.isDelete = true;
            department.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                Console.WriteLine("Delete Successfully");
                Console.Read();
            }
            return status;
        }

        public List<Department> Get()
        {
            return _context.Departments.Where(x => x.isDelete == false).ToList();
        }

        public Department Get(int? id)
        {
            return _context.Departments.Where(x => (x.isDelete == false) && (x.Id == id)).SingleOrDefault();
        }

        public bool Insert(DepartmentParam departmentParam)
        {
            var result = 0;
            department.Name = departmentParam.Name;
            department.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Departments.Add(department);
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                Console.Write("Insert Successfully");
                Console.Read();
            }
            return status;
        }

        public List<Department> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.Departments.Where(x => (x.isDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else if (category == "Name")
            {
                return _context.Departments.Where(x => (x.isDelete == false) && (x.Name.Contains(keywoard))).ToList();
            }
            else
            {
                return _context.Departments.Where(x => x.isDelete == false).ToList();
            }
        }

        public bool Update(int? id, DepartmentParam departmentParam)
        {
            var result = 0;
            Department deparment = Get(id);
            department.Name = departmentParam.Name;
            department.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Entry(department).State = System.Data.Entity.EntityState.Modified;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                Console.Write("Update Successfully");
                Console.Read();
            }
            return status;
        }
    }
}
