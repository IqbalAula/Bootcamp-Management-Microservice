using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.BussinessLogic.Services
{
    public interface IRoomService
    {
        bool Insert(RoomParam roomParam);
        bool Update(int? id, RoomParam roomParam);
        bool Delete(int? id);
        List<Room> Get();
        Room Get(int? id);
        List<Room> Search(string keyword, string category);
    }
}
