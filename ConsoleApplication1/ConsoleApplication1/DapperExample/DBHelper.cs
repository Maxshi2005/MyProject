using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace ConsoleApplication1.DapperExample
{
    public class DBHelper
    {
        //private const string conStr = "";

        public static IDbConnection OpenConnection()
        {
            var cBuilder = new MySqlConnectionStringBuilder();
            cBuilder.Server = "localhost";
            cBuilder.UserID = "root";
            cBuilder.Password = "root";
            cBuilder.Database = "classicmodels";
            var conStr = cBuilder.ToString();

            var connection = new MySqlConnection(conStr);
            connection.Open();
            return connection;

            System.Data.SqlClient.SqlConnectionStringBuilder builder =
            new System.Data.SqlClient.SqlConnectionStringBuilder();

            builder.DataSource = "";
            builder.UserID = "";
            builder.Password = "";
            builder.InitialCatalog = "";
        }

      public  static List<Dictionary<String, Object>> GetParamDicForSimpleObj<T>(IEnumerable<T> list) where T : new()
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            List<Dictionary<String, Object>> result = new List<Dictionary<string, object>>();

            var structTypes = new List<Type>() { typeof(int), typeof(long), typeof(float), typeof(decimal), typeof(double)
            , typeof(Byte), typeof(SByte) , typeof(UInt16), typeof(UInt32), typeof(UInt64),  typeof(Single)};

            var simpleTypes = new List<Type>() { typeof(string), typeof(char), typeof(DateTime) };
            simpleTypes.AddRange(structTypes);

            foreach (var t in list)
            {
                var dynamicProperties = new Dictionary<String, Object>();

                foreach (var p in properties)
                {
                    var v = p.GetValue(t,null);

                    if (
                        (v == null) ||
                        (!simpleTypes.Contains(p.PropertyType)) ||
                        (p.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(v as string)) ||
                        (p.PropertyType == typeof(char) && ((char)v) == char.MinValue) ||
                        (p.PropertyType == typeof(DateTime) && ((DateTime)v == DateTime.MinValue)) ||
                        ((structTypes.Contains(p.PropertyType) && double.Parse(v.ToString()) <= 0))
                       )
                    {
                        continue;
                    }

                    dynamicProperties.Add(p.Name, v);
                }

                result.Add(dynamicProperties);
            }

            return result;
        }
    }
}
