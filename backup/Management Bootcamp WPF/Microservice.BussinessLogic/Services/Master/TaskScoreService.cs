using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.Common.Interfaces.Master;
using Microservice.Common.Interfaces;
using System.Windows.Forms;

namespace Microservice.BussinessLogic.Services.Master
{
    public class TaskScoreService : ITaskScoreService
    {
        bool status = false;
        ITaskScoreRepository _taskScoreRepository = new TaskScoreRepository();
        public bool Delete(int? id)
        {
            if (_taskScoreRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _taskScoreRepository.Delete(id);
            }
            return status;
        }

        public List<TaskScore> Get()
        {
            return _taskScoreRepository.Get();
        }

        public TaskScore Get(int? id)
        {
            return _taskScoreRepository.Get(id);
        }

        public bool Insert(TaskScoreParam taskScoreParam)
        {
            if (taskScoreParam.Score1.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                status = _taskScoreRepository.Insert(taskScoreParam);
            }
            return status;
        }

        public List<TaskScore> Search(string keyword, string category)
        {
            return _taskScoreRepository.Search(keyword, category);
        }

        public bool Update(int? id, TaskScoreParam taskScoreParam)
        {
            if (_taskScoreRepository.Get(id) == null)
            {
                MessageBox.Show("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                MessageBox.Show("Don't insert white space in Id");
            }
            else
            {
                if (taskScoreParam.Score1.ToString() == " ")
                {
                    MessageBox.Show("Don't insert white space in Name");
                }
                else
                {
                    status = _taskScoreRepository.Update(id, taskScoreParam);
                }
            }
            return status;
        }
    }
}
