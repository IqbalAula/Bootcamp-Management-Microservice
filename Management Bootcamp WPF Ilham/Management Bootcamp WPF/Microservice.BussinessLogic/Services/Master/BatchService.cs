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
    public class BatchService : IBatchService
    {
        bool status = false;
        IBatchRepository _batchRepository = new BatchRepository();
        public bool Delete(int? id)
        {
            if (_batchRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _batchRepository.Delete(id);
            }
            return status;
        }

        public List<Batch> Get()
        {
            return _batchRepository.Get();
        }

        public Batch Get(int? id)
        {
            return _batchRepository.Get(id);
        }

        public bool Insert(BatchParam batchParam)
        {
            if (batchParam.Name.ToString() == " " && batchParam.DateStart.Date.ToString() == " " )
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _batchRepository.Insert(batchParam);
            }
            return status;
        }

        public List<Batch> Search(string keywoard, string category)
        {
            return _batchRepository.Search(keywoard, category);
        }

        public bool Update(int? id, BatchParam batchParam)
        {
            if (_batchRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (batchParam.Name.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else
                {
                    status = _batchRepository.Update(id, batchParam);
                }
            }
            return status;
        }
    }
}
