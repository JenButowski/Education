using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L15.DataModels;
using L15.DataContexts;

namespace L15.Engines
{
    public class CarOwnerEngine
    {
        public List<CarOwner> GetWorstDrivers(DataContext context)
        {
            var drivers = context.Owners.Include("Violations").ToList();

            return BubbleSort(drivers);
        }

        public List<CarOwner> GetWorstDrivers(List<CarOwner> carOwners)
        {
            return BubbleSort(carOwners);
        }

        private List<CarOwner> BubbleSort(List<CarOwner> carOwners)
        {
            for(var i = 0; i < carOwners.Count(); i++)
            {
                for(var j = i + 1; j < carOwners.Count(); j++)
                {
                    if(carOwners[i].Violations.Count() <  carOwners[j].Violations.Count())
                    {
                        var carOwner = carOwners[j];
                        carOwners[j] = carOwners[i];
                        carOwners[i] = carOwner;
                    }
                }
            }

            return carOwners;
        }
    }
}
