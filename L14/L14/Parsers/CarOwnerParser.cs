using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L15.DataModels;

namespace L14.Parsers
{
    public class CarOwnerParser
    {
        public static List<CarOwner> Parse(Dictionary<int, List<object>> data)
        {
            var result = new List<CarOwner>();

            foreach(var ownerData in data.Values)
            {
                var carOwner = new CarOwner
                {
                    DriversLicenseCode = ownerData[0].ToString(),
                    Firstname = ownerData[1].ToString(),
                    Lastname = ownerData[2].ToString(),
                    Surname = ownerData[3].ToString(),
                    Address = ownerData[4].ToString(),
                    PhoneNumber = ownerData[5].ToString()
                };

                result.Add(carOwner);
            }

            return result;
        }
    }
}
