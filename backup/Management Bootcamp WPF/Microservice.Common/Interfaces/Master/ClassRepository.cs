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
    public class ClassRepository : IClassRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Class classes = new Class();
        public bool Delete(int? id)
        {
            var result = 0;
            var classes = Get(id);
            classes.IsDelete = true;
            classes.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
                Console.Read();
            }
            return status;
        }

        public List<Class> Get()
        {
            return _context.Classes.Where(x => x.IsDelete == false).ToList();
        }

        public Class Get(int? id)
        {
            return _context.Classes.Find(id);
        }

        public bool Insert(ClassParam classParam)
        {
            var result = 0;
            classes.Name = classParam.Name;
            classes.Departments = _context.Departments.Find(classParam.Departments);
            classes.Batchs = _context.Batchs.Find(classParam.Batchs);
            classes.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Classes.Add(classes);
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Insert Successfully");
            }
            else
            {
                MessageBox.Show("Insert Failed");
            }
            return status;
        }

        public List<Class> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.Classes.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else if (category == "Name")
            {
                return _context.Classes.Where(x => (x.IsDelete == false) && (x.Name.Contains(keywoard))).ToList();
            }
            else if (category == "Department")
            {
                return _context.Classes.Where(x => (x.IsDelete == false) && (x.Departments.Name.Contains(keywoard))).ToList();
            }
            else if (category == "Batch")
            {
                return _context.Classes.Where(x => (x.IsDelete == false) && (x.Batchs.Name.Contains(keywoard))).ToList();
            }
            else
            {
                return _context.Classes.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, ClassParam classParam)
        {
            var result = 0;
            Class classes = Get(id);
            classes.Name = classParam.Name;
            classes.Departments = _context.Departments.Find(classParam.Departments);
            classes.Batchs = _context.Batchs.Find(classParam.Batchs);
            classes.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            //_context.Entry(batch).State = System.Data.Entity.EntityState.Modified;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Update Successfully");
                Console.Read();
            }
            return status;
        }
    }
}
