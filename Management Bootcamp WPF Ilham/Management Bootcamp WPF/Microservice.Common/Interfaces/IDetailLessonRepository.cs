using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces.Master
{
    public interface IDetailLessonRepository
    {
        bool Insert(DetailLessonParam detailLessonParam);
        bool Update(int? id, DetailLessonParam detailLessonParam);
        bool Delete(int? id);
        List<DetailLesson> Get();
        DetailLesson Get(int? id);
        List<DetailLesson> Search(string keywoard, string category);
    }
}
