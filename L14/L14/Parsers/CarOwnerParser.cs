using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using L15.DataModels;
using System.Configuration;

namespace L14.Parsers
{
    public class CarOwnerParser
    {
        public static List<CarOwner> Parse(Dictionary<int, List<object>> data)
        {
            var result = new List<CarOwner>();

            foreach (var ownerData in data.Values)
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

                carOwner.Violations = GetViolations(carOwner);
                result.Add(carOwner);
            }

            return result;
        }

        private static List<Violation> GetViolations(CarOwner carOwner)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Data"].ConnectionString))
            {
                connection.Open();
                var result = new List<Violation>();
                var command = new SqlCommand("SELECT * FROM Violations", connection);
                var data = DataProvider.GetData(command);
                var violations = ViolationsParser.Parse(data);

                foreach (var violation in violations)
                {
                    if (carOwner.DriversLicenseCode == violation.CarOwner.DriversLicenseCode)
                        result.Add(violation);
                }
                connection.Close();

                return result;
            }
        }
    }
}
