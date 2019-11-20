using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L15.DataContexts;
using L15.Engines;
using L15.DataModels;

namespace L15
{
    class Program
    {
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
            using (var context = new DataContext())
            {
            DeedMenu:

                foreach (var deed in deedsList)
                {
                    Console.WriteLine($"{deed.Value} - {deed.Key}");
                }

                int deedValue = int.Parse(Console.ReadLine());

                switch(deedValue)
                {
                    case 0:
                        var badDrivers = carOwnerEngine.GetWorstDrivers(context);

                        foreach(var badDriver in badDrivers)
                        {
                            Console.WriteLine($"{badDriver.DriversLicenseCode} {badDriver.Firstname} {badDriver.Lastname} {badDriver.Surname} {badDriver.Violations.Count()}");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        goto DeedMenu;
                    case 1:
                        var allViolations = violationEngine.GetAllViolations(context);

                        foreach(var violation in allViolations)
                        {
                            Console.WriteLine($"{violation.Type.Name} {violation.Code} {violation.Date} {violation.District} {violation.InspectorNumber}");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        goto DeedMenu;
                    case 2:
                        Console.WriteLine("Введите количество нарушений");
                        var numberofViolations = int.Parse(Console.ReadLine());
                        var districts = violationEngine.GetWorstDistricts(context, numberofViolations);

                        foreach(var district in districts)
                            Console.WriteLine(district);
                        Console.ReadLine();
                        Console.Clear();
                        goto DeedMenu;
                }
            }
        }
    }
}
