using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.BussinessLogic.Services
{
    public interface IPlacementService
    {
        bool Insert(PlacementParam placementParam);
        bool Update(int? id, PlacementParam placementParam);
        bool Delete(int? id);
        List<Placement> Get();
        Placement Get(int? id);
        List<Placement> Search(string keywoard, string category);
    }
}
