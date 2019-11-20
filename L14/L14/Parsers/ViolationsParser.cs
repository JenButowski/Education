using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L15.DataModels;

namespace L14.Parsers
{
    public class ViolationsParser
    {
        public static List<Violation> Parse(Dictionary<int, List<object>> data)
        {
            var result = new List<Violation>();

            foreach (var violationData in data.Values)
            {
                var violation = new Violation
                {
                    Code = violationData[0].ToString(),
                    Date = DateTime.ParseExact(violationData[1].ToString(),"yyyy/mm/dd", System.Globalization.CultureInfo.InvariantCulture),
                    District = violationData[2].ToString(),
                    IsPaid = bool.Parse(violationData[3].ToString()),
                    InspectorNumber = violationData[4].ToString(),
                    //CarOwner = (CarOwner)violationData[5],
                    //Type = (ViolationType)violationData[6]
                };

                result.Add(violation);
            }

            return result;
        }
    }
}
