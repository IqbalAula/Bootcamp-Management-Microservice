using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface IHistoryDetailLessonRepository
    {
        bool Insert(HistoryDetailLessonParam historyDetailLessonParam);
        bool Update(int? id, HistoryDetailLessonParam historyDetailLessonParam);
        bool Delete(int? id);
        List<HistoryDetailLesson> Get();
        HistoryDetailLesson Get(int? id);
        List<HistoryDetailLesson> Search(string keywoard, string category);
    }
}
