using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Interfaces
{
    public interface ILessonRepository
    {
        bool Insert(LessonParam lessonParam);
        bool Update(int? id, LessonParam lessonParam);
        bool Delete(int? id);
        List<Lesson> Get();
        Lesson Get(int? id);
        List<Lesson> Search(string keywoard, string category);
    }
}
