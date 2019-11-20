using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L14
{
    public class DataProvider
    {
        public static Dictionary<int, List<object>> GetData(SqlCommand command)
        {
            var reader = command.ExecuteReader();
            var result = new Dictionary<int, List<object>>();

            if (reader.HasRows)
            {
                int counter = 0;

                while (reader.Read())
                {
                    var rowData = new object[reader.FieldCount];

                    reader.GetValues(rowData);
                    result.Add(counter, rowData.ToList());
                    counter++;
                }
            }


            return result;
        }
    }
}
