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
    public class EmployeeRepository : IEmployeeRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Employee employee = new Employee();
        public bool Delete(int? id)
        {
            var result = 0;
            var employee = Get(id);
            employee.IsDelete = true;
            employee.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
                Console.Read();
            }
            return status;
        }

        public List<Employee> Get()
        {
            return _context.Emplyoees.Where(x => x.IsDelete == false).ToList();
        }
        public Employee Get(int? id)
        {
            // return _context.Emplyoees.Where(x => (x.IsDelete == false) && (x.Id == id)).SingleOrDefault();
            return _context.Emplyoees.Find(id);
        }
        public bool Insert(EmployeeParam employeeParam)
        {
            var result = 0;
            employee.Name = employeeParam.Name;
            employee.Dob = DateTimeOffset.Now.LocalDateTime;
            employee.Pob = employeeParam.Pob;
            employee.Gender = employeeParam.Gender;
            employee.Religion = employeeParam.Religion;
            employee.Address = employeeParam.Address;
            employee.RT = employeeParam.RT;
            employee.RW = employeeParam.RW;
            employee.Kelurahan = employeeParam.Kelurahan;
            employee.Kecamatan = employeeParam.Kecamatan;
            employee.Kabupaten = employeeParam.Kabupaten;
            employee.Phone = employeeParam.Phone;
            employee.Email = employeeParam.Email;
            employee.Username = employeeParam.Username;
            employee.Password = employeeParam.Password;
            employee.Role = employeeParam.Role;
            employee.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Emplyoees.Add(employee);
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
        public List<Employee> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.Emplyoees.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else if (category == "Name")
            {
                return _context.Emplyoees.Where(x => (x.IsDelete == false) && (x.Name.Contains(keywoard))).ToList();
            }
            else
            {
                return _context.Emplyoees.Where(x => x.IsDelete == false).ToList();
            }
        }
        public bool Update(int? id, EmployeeParam employeeParam)
        {
            var result = 0;
            var employee = Get(id);
            employee.Name = employeeParam.Name;
            employee.Dob = DateTimeOffset.Now.LocalDateTime;
            employee.Pob = employeeParam.Pob;
            employee.Gender = employeeParam.Gender;
            employee.Religion = employeeParam.Religion;
            employee.Address = employeeParam.Address;
            employee.RT = employeeParam.RT;
            employee.RW = employeeParam.RW;
            employee.Kelurahan = employeeParam.Kelurahan;
            employee.Kecamatan = employeeParam.Kecamatan;
            employee.Kabupaten = employeeParam.Kabupaten;
            employee.Phone = employeeParam.Phone;
            employee.Email = employeeParam.Email;
            employee.Username = employeeParam.Username;
            employee.Password = employeeParam.Password;
            employee.Role = employeeParam.Role;
            employee.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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

        public Employee Login(string username, string password)
        {
            //var employee = Login(username, password);
            return _context.Emplyoees.Where(x => (x.IsDelete == false) && (x.Username == username) && (x.Password == password)).SingleOrDefault();
        }
    }
}
      
    

