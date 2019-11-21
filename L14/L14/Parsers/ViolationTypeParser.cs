using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L15.DataModels;

namespace L14.Parsers
{
    public class ViolationTypeParser
    {
        public static List<ViolationType> Parse(Dictionary<int, List<object>> data)
        {
            var result = new List<ViolationType>();

            foreach(var violationTypeData in data.Values)
            {
                var violationType = new ViolationType
                {
                    Code = violationTypeData[0].ToString(),
                    Name = violationTypeData[1].ToString(),
                    PenaltySumm = double.Parse(violationTypeData[2].ToString()),
                    DrivingDeprivationDate = (DateTime)violationTypeData[3]
                };

                result.Add(violationType);
            }

            return result;
        }
    }
}
