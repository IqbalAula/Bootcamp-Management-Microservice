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
    public class ErrorBankService : IErrorBankService
    {
        bool status = false;
        IErrorBankRepository _errorBankRepository = new ErrorBankRepository();
        public bool Delete(int? id)
        {
            if (_errorBankRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _errorBankRepository.Delete(id);
            }
            return status;
        }

        public List<ErrorBank> Get()
        {
            return _errorBankRepository.Get();
        }

        public ErrorBank Get(int? id)
        {
            return _errorBankRepository.Get(id);
        }

        public bool Insert(ErrorBankParam errorBankParam)
        {
            if (errorBankParam.Message.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _errorBankRepository.Insert(errorBankParam);
            }
            return status;
        }

        public List<ErrorBank> Search(string keywoard, string category)
        {
            return _errorBankRepository.Search(keywoard, category);
        }

        public bool Update(int? id, ErrorBankParam errorBankParam)
        {
            if (_errorBankRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (errorBankParam.Message.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else
                {
                    status = _errorBankRepository.Update(id, errorBankParam);
                }
            }
            return status;
        }
    }
}
