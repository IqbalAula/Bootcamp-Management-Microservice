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
    public class PlacementRepository : IPlacementRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Placement placement = new Placement();
        public bool Delete(int? id)
        {
            var result = 0;
            var placement = Get(id);
            placement.isDelete = true;
            placement.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Delete Successfully");
            }
            return status;
        }

        public List<Placement> Get()
        {
            return _context.Placements.Where(x => x.isDelete == false).ToList();
        }

        public Placement Get(int? id)
        {
            //return _context.Placements.Where(x => (x.isDelete == false) && (x.Id == id)).SingleOrDefault();
            return _context.Placements.Find(id);
        }

        public bool Insert(PlacementParam placementParam)
        {
            var result = 0;
            placement.Name = placementParam.Name;
            placement.Address = placementParam.Address;
            placement.RT = placementParam.RT;
            placement.RW = placementParam.RW;
            placement.Kelurahan = placementParam.Kelurahan;
            placement.Kecamatan = placementParam.Kecamatan;
            placement.Kabupaten = placementParam.Kabupaten;
            placement.Phone = placementParam.Phone;
            placement.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Placements.Add(placement);
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                MessageBox.Show("Insert Successfully");
            }
            return status;
        }

        public List<Placement> Search(string keywoard, string category)
        {
            if (category == "Id")
            {
                return _context.Placements.Where(x => (x.isDelete == false) && (x.Id.ToString().Contains(keywoard))).ToList();
            }
            else if (category == "Name")
            {
                return _context.Placements.Where(x => (x.isDelete == false) && (x.Name.Contains(keywoard))).ToList();
            }
            else
            {
                return _context.Placements.Where(x => x.isDelete == false).ToList();
            }
        }

        public bool Update(int? id, PlacementParam placementParam)
        {
            var result = 0;
            var deparment = Get(id);
            placement.Name = placementParam.Name;
            placement.Address = placementParam.Address;
            placement.RT = placementParam.RT;
            placement.RW = placementParam.RW;
            placement.Kelurahan = placementParam.Kelurahan;
            placement.Kecamatan = placementParam.Kecamatan;
            placement.Kabupaten = placementParam.Kabupaten;
            placement.Phone = placementParam.Phone;
            placement.UpdateDate = DateTimeOffset.UtcNow.LocalDateTime;
            _context.Entry(placement).State = System.Data.Entity.EntityState.Modified;
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
