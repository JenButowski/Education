using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                    Date = (DateTime)violationData[1],
                    District = violationData[2].ToString(),
                    IsPaid = bool.Parse(violationData[3].ToString()),
                    InspectorNumber = violationData[4].ToString(),
                    CarOwner = new CarOwner { DriversLicenseCode = violationData[5].ToString() },
                    Type = GetViolations(violationData[6].ToString())
                };

                result.Add(violation);
            }

            return result;
        }

        private static ViolationType GetViolations(string violationCode)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Data"].ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM ViolationTypes", connection);
                var data = DataProvider.GetData(command);
                var violationTypes = ViolationTypeParser.Parse(data);

                foreach (var violationType in violationTypes)
                {
                    if (violationCode == violationType.Code)
                        return violationType;
                }
                connection.Close();

                return null;
            }
        }
    }
}

