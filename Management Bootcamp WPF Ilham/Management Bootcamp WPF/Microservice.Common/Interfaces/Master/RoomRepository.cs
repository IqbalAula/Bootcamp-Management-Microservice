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
    public class RoomRepository : IRoomRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Room room = new Room();
        public bool Delete(int? id)
        {
            var result = 0;
            var room = Get(id);
            room.IsDelete = true;
            room.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
            }
            return status;
        }

        public List<Room> Get()
        {
            return _context.Rooms.Where(x => x.IsDelete == false).ToList();
        }

        public Room Get(int? id)
        {
            return _context.Rooms.Find(id);
        }

        public bool Insert(RoomParam roomParam)
        {
            var result = 0;
            room.Name = roomParam.Name;
            room.Capacity = roomParam.Capacity;
            room.Location = roomParam.Location;
            room.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Rooms.Add(room);
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Insert Successfully");
            }
            return status;
        }

        public List<Room> Search(string keyword, string category)
        {
            if (category == "Id")
            {
                return _context.Rooms.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keyword))).ToList();
            }
            else if (category == "Name")
            {
                return _context.Rooms.Where(x => (x.IsDelete == false) && (x.Name.Contains(keyword))).ToList();
            }
            else if (category == "Capacity")
            {
                return _context.Rooms.Where(x => (x.IsDelete == false) && (x.Capacity.ToString().Contains(keyword))).ToList();
            }
            else if (category == "Location")
            {
                return _context.Rooms.Where(x => (x.IsDelete == false) && (x.Location.Contains(keyword))).ToList();
            }
            else
            {
                return _context.Rooms.Where(x => x.IsDelete == false).ToList();
            }
        }

        public bool Update(int? id, RoomParam roomParam)
        {
            var result = 0;
            var room = Get(id);
            room.Name = roomParam.Name;
            room.Capacity = roomParam.Capacity;
            room.Location = roomParam.Location;
            room.UpdateDate = DateTimeOffset.UtcNow.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Update Successfully");
            }
            else
            {
                MessageBox.Show("Update Error");
            }
            return status;
        }
    }
}
