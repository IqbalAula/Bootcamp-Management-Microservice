using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.BussinessLogic.Services
{
    public interface IDetailLessonService
    {
        bool Insert(DetailLessonParam detailLessonParam);
        bool Update(int? id, DetailLessonParam detailLessonParam);
        bool Delete(int? id);
        List<DetailLesson> Get();
        DetailLesson Get(int? id);
        List<DetailLesson> Search(string keywoard, string category);
    }
}
