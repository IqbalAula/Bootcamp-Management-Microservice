using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.Common.Interfaces.Master;

namespace Microservice.BussinessLogic.Services.Master
{
    public class RoomService : IRoomService
    {
        bool status = false;        
        IRoomRepository _roomRepository = new RoomRepository();
        public bool Delete(int? id)
        {
            if (_roomRepository.Get(id) == null)
            {
                Console.WriteLine("Sorry, your data is not found");
            }
            else if (id.ToString() == " ")
            {
                Console.WriteLine("Don't insert white space");
            }
            else
            {
                status = _roomRepository.Delete(id);
            }
            return status;
        }

        public List<Room> Get()
        {
            return _roomRepository.Get();
        }

        public Room Get(int? id)
        {
            return _roomRepository.Get(id);
        }

        public bool Insert(RoomParam roomParam)
        {
            if (roomParam.Name.ToString() == null)
            {
                Console.WriteLine("Please insert data");
            }
            else if (roomParam.Name.ToString() == " ")
            {
                Console.WriteLine("Don't insert white space");
            }
            else
            {
                status = _roomRepository.Insert(roomParam);
            }
            return status;
        }

        public List<Room> Search(string keyword, string category)
        {
            return _roomRepository.Search(keyword, category);
        }

        public bool Update(int? id, RoomParam roomParam)
        {
            if (_roomRepository.Get(id) == null)
            {
                Console.WriteLine("Sorry, your data is not found");
                Console.Read();
            }
            else if (id.ToString() == " ")
            {
                Console.WriteLine("Don't insert white space");
                Console.Read();
            }
            else
            {
                if (roomParam.Name.ToString() == " ")
                {
                    Console.WriteLine("Don't insert white space");
                    Console.Read();
                }
                else
                {
                    status = _roomRepository.Update(id, roomParam);
                }
            }
            return status;
        }
    }
}
