using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace L14
{
    class Program
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["Data"].ConnectionString;

        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM CarOwners", connection);
                var data = DataProvider.GetData(command);

                foreach (var stg in data.Values)
                {
                    foreach(var dt in stg)
                    {
                        Console.WriteLine(dt);
                    }
                }
            }
        }
    }
}
