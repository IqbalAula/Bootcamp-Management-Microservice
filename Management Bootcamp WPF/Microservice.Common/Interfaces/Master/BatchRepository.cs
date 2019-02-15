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
    public class BatchRepository : IBatchRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Batch batch = new Batch();
        public bool Delete(int? id)
        {
            var result = 0;
            var batch = Get(id);
            batch.IsDelete = true;
            batch.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
                Console.Read();
            }
            return status;
        }

        public List<Batch> Get()
        {
            var get = _context.Batchs.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Batch Get(int? id)
        {
            return _context.Batchs.Find(id);
        }

        public bool Insert(BatchParam batchParam)
        {
            var result = 0;
            batch.Name = batchParam.Name;
            batch.DateStart = batchParam.DateStart;
            batch.DateEnd = batch.DateStart.AddMonths(3);
            batch.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Batchs.Add(batch);
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

        public List<Batch> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.Batchs.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else if (category == "Name")
            {
                return _context.Batchs.Where(x => (x.IsDelete == false) && (x.Name.Contains(keywoard))).ToList();
            }
            else
            {
                return _context.Batchs.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, BatchParam batchParam)
        {
            var result = 0;
            var batch = Get(id);
            batch.Name = batchParam.Name;
            batch.DateStart = batchParam.DateStart;
            batch.DateEnd = batch.DateStart.AddMonths(3);
            batch.UpdateDate = DateTimeOffset.Now.LocalDateTime;            
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
