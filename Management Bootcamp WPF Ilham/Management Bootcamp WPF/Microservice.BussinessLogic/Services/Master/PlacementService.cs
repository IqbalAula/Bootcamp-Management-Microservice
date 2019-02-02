using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.Common.Interfaces;
using Microservice.Common.Interfaces.Master;

namespace Microservice.BussinessLogic.Services.Master
{       
    public class PlacementService : IPlacementService
    {
        bool status = false;
        IPlacementRepository _placementRepository = new PlacementRepository();
        public bool Delete(int? id)
        {
            if (_placementRepository.Get(id) == null)
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
                status = _placementRepository.Delete(id);
            }
            return status;
        }

        public List<Placement> Get()
        {
            return _placementRepository.Get();
        }

        public Placement Get(int? id)
        {
            return _placementRepository.Get(id);
        }

        public bool Insert(PlacementParam placementParam)
        {
            if (placementParam.Name.ToString() == " ")
            {
                Console.WriteLine("Don't insert white space");
            }
            else
            {
                status = _placementRepository.Insert(placementParam);
            }
            return status;
        }

        public List<Placement> Search(string keywoard, string category)
        {
            return _placementRepository.Search(keywoard, category);
        }

        public bool Update(int? id, PlacementParam placementParam)
        {
            if (_placementRepository.Get(id) == null)
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
                if (placementParam.Name.ToString() == " ")
                {
                    Console.WriteLine("Don't insert white space");
                    Console.Read();
                }
                else
                {
                    status = _placementRepository.Update(id, placementParam);
                }
            }
            return status;
        }
    }
}
