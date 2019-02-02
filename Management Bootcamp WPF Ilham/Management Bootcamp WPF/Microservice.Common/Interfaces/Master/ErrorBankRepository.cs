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
    public class ErrorBankRepository : IErrorBankRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        ErrorBank errorBank = new ErrorBank();
        public bool Delete(int? id)
        {
            var result = 0;
            var errorBank = Get(id);
            errorBank.IsDelete = true;
            errorBank.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
                Console.Read();
            }
            return status;
        }

        public List<ErrorBank> Get()
        {
            return _context.ErrorBanks.Where(x => x.IsDelete == false).ToList();
        }

        public ErrorBank Get(int? id)
        {
            return _context.ErrorBanks.Find(id);
        }

        public bool Insert(ErrorBankParam errorBankParam)
        {
            var result = 0;
            errorBank.Message = errorBankParam.Message;
            errorBank.Description = errorBankParam.Description;
            errorBank.Solution = errorBankParam.Solution;
            errorBank.Date = DateTimeOffset.Now.LocalDateTime;
            errorBank.students.Id = errorBankParam.students.Id;
            errorBank.departments.Id = errorBankParam.departments.Id;
            errorBank.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.ErrorBanks.Add(errorBank);
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

        public List<ErrorBank> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.ErrorBanks.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else
            {
                return _context.ErrorBanks.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, ErrorBankParam errorBankParam)
        {
            var result = 0;
            var errorBank = Get(id);
            errorBank.Message = errorBankParam.Message;
            errorBank.Description = errorBankParam.Description;
            errorBank.Solution = errorBankParam.Solution;
            errorBank.Date = DateTimeOffset.Now.LocalDateTime;
            errorBank.students.Id = errorBankParam.students.Id;
            errorBank.departments.Id = errorBankParam.departments.Id;
            errorBank.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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
