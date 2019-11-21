using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L15.DataModels;
using L15.DataContexts;


namespace L15.Engines
{
    public class ViolationEngine
    {
        public List<string> GetWorstDistricts(DataContext context, int numberofViolations)
        {
            var violations = context.Violations.Include("Type").ToList();
            var districts = new List<string>();

            foreach(var violation in violations)
            {
                var district = violation.District;
                var buffer = new List<string>();

                for(var i = 0; i < violations.Count(); i++)
                {
                    if(district == violations[i].District)
                    {
                        buffer.Add(district);
                    }
                }

                if (buffer.Count() >= numberofViolations)
                    districts.Add(district);
            }

            return districts;
        }

        public List<string> GetWorstDistricts(List<Violation> violations, int numberofViolations)
        {
            var districts = new List<string>();

            foreach (var violation in violations)
            {
                var district = violation.District;
                var buffer = new List<string>();

                for (var i = 0; i < violations.Count(); i++)
                {
                    if (district == violations[i].District)
                    {
                        buffer.Add(district);
                    }
                }

                if (buffer.Count() >= numberofViolations)
                    districts.Add(district);
            }

            return districts;
        }

        public List<Violation> GetAllViolations(DataContext context)
        {
            var violations = context.Violations.Include("Type").ToList();
            var result = new List<Violation>();

            foreach(var violation in violations)
            {
                if (violation.IsPaid != true)
                    result.Add(violation);
            }

            return result;
        }
    }
}
