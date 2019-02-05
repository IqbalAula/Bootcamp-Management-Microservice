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
    public class ScheduleService : IScheduleService
    {
        bool status = false;        
        IScheduleRepository _scheduleRepository = new ScheduleRepository();
        public bool Delete(int? id)
        {
            if (_scheduleRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _scheduleRepository.Delete(id);
            }
            return status;
        }

        public List<Schedule> Get()
        {
            return _scheduleRepository.Get();
        }

        public Schedule Get(int? id)
        {
            return _scheduleRepository.Get(id);
        }

        public bool Insert(ScheduleParam scheduleParam)
        {
            if (scheduleParam.lessons.ToString() == null)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _scheduleRepository.Insert(scheduleParam);
            }
            return status;
            //status = _scheduleRepository.Insert(scheduleParam);
            //return status;
        }

        public List<Schedule> Search(string keyword, string category)
        {
            return _scheduleRepository.Search(keyword, category);
        }

        public bool Update(int? id, ScheduleParam scheduleParam)
        {
            if (scheduleParam.lessons.ToString() == null)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _scheduleRepository.Update(id, scheduleParam);
            }
            return status;
        }
    }
}
