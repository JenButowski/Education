using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using L14.Parsers;
using L15.Engines;
using L15.DataModels;

namespace L14
{
    class Program
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["Data"].ConnectionString;

        static readonly CarOwnerEngine carOwnerEngine = new CarOwnerEngine();

        static readonly ViolationEngine violationEngine = new ViolationEngine();

        private static Dictionary<int, string> deedsList = new Dictionary<int, string>
        {
            { 0, "Список водителей с большим колличество нарушений" },
            { 1, "Все штрафы" },
            { 2, "Самые опасные районы" },
        };

        static void Main(string[] args)
        {
        DeedMenu:

            var connection = new SqlConnection(connectionString);
            connection.Open();

            foreach (var deed in deedsList)
            {
                Console.WriteLine($"{deed.Value} - {deed.Key}");
            }

            int deedValue = int.Parse(Console.ReadLine());

            switch (deedValue)
            {
                case 0:
                    var ownersData = DataProvider.GetData(new SqlCommand("SELECT * FROM CarOwners", connection));
                    var badDrivers = carOwnerEngine.GetWorstDrivers(CarOwnerParser.Parse(ownersData));

                    foreach (var badDriver in badDrivers)
                    {
                        Console.WriteLine($"{badDriver.DriversLicenseCode} {badDriver.Firstname} {badDriver.Lastname} {badDriver.Surname} {badDriver.Violations.Count()}");
                    }
                    Console.ReadLine();
                    Console.Clear();
                    connection.Close();
                    goto DeedMenu;
                case 1:
                    var allVioliationsData = DataProvider.GetData(new SqlCommand("SELECT * FROM Violations", connection));
                    var allViolations = ViolationsParser.Parse(allVioliationsData);

                    foreach (var violation in allViolations)
                    {
                        Console.WriteLine($"{violation.Type.Name} {violation.Code} {violation.Date} {violation.District} {violation.InspectorNumber}");
                    }
                    Console.ReadLine();
                    Console.Clear();
                    connection.Close();
                    goto DeedMenu;
                case 2:
                    Console.WriteLine("Введите количество нарушений");
                    var numberofViolations = int.Parse(Console.ReadLine());
                    var violationsData = DataProvider.GetData(new SqlCommand("SELECT * FROM Violations", connection));
                    var districts = violationEngine.GetWorstDistricts(ViolationsParser.Parse(violationsData), numberofViolations);

                    foreach (var district in districts)
                        Console.WriteLine(district);
                    Console.ReadLine();
                    Console.Clear();
                    connection.Close();
                    goto DeedMenu;
            }
        }
    }
}
