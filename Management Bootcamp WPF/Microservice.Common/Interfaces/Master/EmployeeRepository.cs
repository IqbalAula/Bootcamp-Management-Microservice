using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Context;
using System.Windows.Forms;
using System.Data.Entity.Validation;

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
            }
            return status;
        }

        public List<Employee> Get()
        {
            return _context.Employees.Where(x => x.IsDelete == false).ToList();
        }
        public Employee Get(int? id)
        {
            // return _context.Employees.Where(x => (x.IsDelete == false) && (x.Id == id)).SingleOrDefault();
            return _context.Employees.Find(id);
        }
        public bool Insert(EmployeeParam employeeParam)
        {
            try
            {
                var result = 0;
                employee.FirstName = employeeParam.FirstName;
                employee.LastName = employeeParam.LastName;                
                employee.Phone = employeeParam.Phone;
                employee.Email = employeeParam.Email;
                employee.Username = employeeParam.Username;
                employee.Password = employeeParam.Password;
                employee.Role = employeeParam.Role;
                employee.AccessCard = employeeParam.AccessCard;
                employee.CreateDate = DateTimeOffset.Now.LocalDateTime;
                _context.Employees.Add(employee);
                result = _context.SaveChanges();
                if (result > 0)
                {
                    status = true;
                    MessageBox.Show("Insert Successfully");
                }
            }
            catch (DbEntityValidationException e)
            {
                Console.Write(e.EntityValidationErrors);
            }            
            return status;
        }
        public List<Employee> Search(string keyword, string category)
        {
            if (category == "Id")
            {
                return _context.Employees.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keyword))).ToList();
            }
            else if (category == "Name")
            {
                return _context.Employees.Where(x => (x.IsDelete == false) && (x.FirstName.Contains(keyword))).ToList();
            }
            else if (category == "Role")
            {
                return _context.Employees.Where(x => (x.IsDelete == false) && (x.Role.Contains(keyword))).ToList();
            }
            else
            {
                return _context.Employees.Where(x => x.IsDelete == false).ToList();
            }
        }        

        public bool UpdateHR(int? id, EmployeeParam employeeParam)
        {
            var result = 0;
            var employee = Get(id);
            employee.FirstName = employeeParam.FirstName;
            employee.LastName = employeeParam.LastName;
            employee.Phone = employeeParam.Phone;
            employee.Email = employeeParam.Email;
            employee.Role = employeeParam.Role;
            employee.AccessCard = employeeParam.AccessCard;
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

        public bool UpdatePr(int? id, EmployeeParam employeeParam)
        {
            var result = 0;
            var employee = Get(id);
            employee.FirstName = employeeParam.FirstName;
            employee.LastName = employeeParam.LastName;
            employee.Dob = employeeParam.Dob;
            employee.Pob = employeeParam.Pob;
            employee.Gender = employeeParam.Gender;
            employee.Religion = employeeParam.Religion;
            employee.Address = employeeParam.Address;
            employee.RT = employeeParam.RT;
            employee.RW = employeeParam.RW;
            employee.Village = employeeParam.Village;
            employee.District = employeeParam.District;
            employee.Regencies = employeeParam.Regencies;
            employee.Provience = employeeParam.Provience;
            employee.Phone = employeeParam.Phone;
            employee.Email = employeeParam.Email;
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

        public bool UpdateS(int? id, EmployeeParam employeeParam)
        {
            var result = 0;
            var employee = Get(id);
            
            employee.SecretQuestion = employeeParam.SecretQuestion;
            employee.AnswerQuestion = employeeParam.AnswerQuestion;
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

        public bool UpdateP(int? id, EmployeeParam employeeParam)
        {
            var result = 0;
            var employee = Get(id);
            employee.Password = employeeParam.Password;
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
    }

      
}

