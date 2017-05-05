using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCBase.Data;

namespace ConsoleApplication1
{
   public class DataBaseProvider
    {
        const string writeDBName = "TCFlyTrainOrder";

        public static IDbConnection GetConnection(string dbName = writeDBName, bool isReadDb = false)
        {
           return DataSource.GetConnection(writeDBName, isReadDb);
        }
    }
}
