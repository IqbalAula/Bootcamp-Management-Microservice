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
    public class StudentRepository : IStudentRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Student student = new Student();
        public bool Delete(int? id)
        {
            var result = 0;
            var student = Get(id);
            student.IsDelete = true;
            student.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
            }
            return status;
        }

        public List<Student> Get()
        {
            return _context.Students.Where(x => x.IsDelete == false).ToList();
        }

        public Student Get(int? id)
        {
            // return _context.Emplyoees.Where(x => (x.IsDelete == false) && (x.Id == id)).SingleOrDefault();
            return _context.Students.Find(id);
        }

        public bool Insert(StudentParam studentParam)
        {
            try
            {
                var result = 0;
                student.FirstName = studentParam.FirstName;
                student.LastName = studentParam.LastName;
                //student.Dob = studentParam.Dob;
                //student.Pob = studentParam.Pob;
                //student.Gender = studentParam.Gender;
                //student.Religion = studentParam.Religion;
                //student.Address = studentParam.Address;
                //student.RT = studentParam.RT;
                //student.RW = studentParam.RW;
                //student.Village = studentParam.Village;
                //student.District = studentParam.District;
                //student.Regencie = studentParam.Regencie;
                student.Phone = studentParam.Phone;
                student.Email = studentParam.Email;
                student.Username = studentParam.Username;
                student.Password = studentParam.Password;
                student.Status = "ON BOOTCAMP";
                student.classes = _context.Classes.Find(studentParam.classes);
                student.CreateDate = DateTimeOffset.Now.LocalDateTime;
                _context.Students.Add(student);
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

        public List<Student> Search(string keyword, string category)
        {
            if (category == "Id")
            {
                return _context.Students.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keyword))).ToList();
            }
            else if (category == "Name")
            {
                return _context.Students.Where(x => (x.IsDelete == false) && (x.FirstName.Contains(keyword))).ToList();
            }
            else
            {
                return _context.Students.Where(x => x.IsDelete == false).ToList();
            }
        }
        public List<Student> Join(int? id)
        {
            return _context.Students.Where(x => (x.IsDelete == false) && (x.classes.employees.Id==id) && x.Status == "ON BOOTCAMP").ToList();
        }


        //public bool Update(int? id, StudentParam studentParam)
        //{
        //    var result = 0;
        //    var student = Get(id);
        //    student.FirstName = studentParam.FirstName;
        //    student.LastName = studentParam.LastName;
        //    student.Dob = studentParam.Dob;
        //    student.Pob = studentParam.Pob;
        //    student.Gender = studentParam.Gender;
        //    student.Religion = studentParam.Religion;
        //    student.Address = studentParam.Address;
        //    student.RT = studentParam.RT;
        //    student.RW = studentParam.RW;
        //    student.Village = studentParam.Village;
        //    student.District = studentParam.District;
        //    student.Regencie = studentParam.Regencie;
        //    student.Provience = studentParam.Provience;
        //    student.Phone = studentParam.Phone;
        //    student.Email = studentParam.Email;
        //    student.Username = studentParam.Username;
        //    student.Password = studentParam.Password;
        //    student.Status = studentParam.Status;
        //    student.SecretQuestion = studentParam.SecretQuestion;
        //    student.SecretAnswer = studentParam.SecretAnswer;
        //    student.HiringLocation = studentParam.HiringLocation;
        //    student.AccessCard = studentParam.AccessCard;
        //    student.classes = _context.Classes.Find(studentParam.classes);
        //    student.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        //    result = _context.SaveChanges();
        //    if (result > 0)
        //    {
        //        status = true;
        //        MessageBox.Show("Update Successfully");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Update Failed");
        //    }

        //    return status;
        //}


        public bool UpdateHR(int? id, StudentParam studentParam)
        {
            var result = 0;
            var student = Get(id);
            student.FirstName = studentParam.FirstName;
            student.LastName = studentParam.LastName;
            student.Phone = studentParam.Phone;
            student.Email = studentParam.Email;
            student.Username = studentParam.Username;
            student.Password = studentParam.Password;
            student.Status = studentParam.Status;
            student.SecretQuestion = studentParam.SecretQuestion;
            student.SecretAnswer = studentParam.SecretAnswer;
            student.HiringLocation = studentParam.HiringLocation;
            student.AccessCard = studentParam.AccessCard;
            student.classes = _context.Classes.Find(studentParam.classes);
            student.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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

        public bool UpdatePr(int? id, StudentParam studentParam)
        {
            var result = 0;
            var student = Get(id);
            student.FirstName = studentParam.FirstName;
            student.LastName = studentParam.LastName;
            student.Dob = studentParam.Dob;
            student.Pob = studentParam.Pob;
            student.Gender = studentParam.Gender;
            student.Religion = studentParam.Religion;
            student.Address = studentParam.Address;
            student.RT = studentParam.RT;
            student.RW = studentParam.RW;
            student.Village = studentParam.Village;
            student.District = studentParam.District;
            student.Regencie = studentParam.Regencie;
            student.Provience = studentParam.Provience;
            student.Phone = studentParam.Phone;
            student.Email = studentParam.Email;
            student.HiringLocation = studentParam.HiringLocation;
            student.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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

        public bool UpdateS(int? id, StudentParam studentParam)
        {
            var result = 0;
            var student = Get(id);
            student.SecretQuestion = studentParam.SecretQuestion;
            student.SecretAnswer = studentParam.SecretAnswer;
            student.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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

        public bool UpdateP(int? id, StudentParam studentParam)
        {
            var result = 0;
            var student = Get(id);
            student.Password = studentParam.Password;
            student.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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

