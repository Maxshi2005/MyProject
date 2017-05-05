using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace ConsoleApplication1.SqlBuilder
{
   public class SqlBuilder
    {
        const string conStr = "";
        static string trimStart = "TMP";
        static string trimStart2 = "";
        static string tablName = "TrainMerchantPayRecord";
        
        static List<Columns> columns = new List<Columns>();
       static Dictionary<string, string> typeMapping = new Dictionary<string, string>()
        {
            {"varchar","string" },
            {"char","string" },
            {"bigint","long" },
            {"int","int" },
            {"tinyint","byte" },
            {"decimal","decimal" },
            {"integer","int" },
            {"datetime","DateTime" },
            {"nvarchar","string" }
        };

        public static void Run()
        {
            string connstring = string.Format("Server=10.100.156.106;Port=3500; database={0}; UID=TCTrainOffOrder_local; password=06PBAWVXPumOeKPgcIE8gG8YIAcLaV", "TCTrainOffOrder");
            var connection = new MySqlConnection(connstring);
            connection.Open();
            //suppose col0 and col1 are defined as VARCHAR in the DB
            string query = string.Format("select column_name,data_type,column_comment from information_schema.columns where table_name = '{0}'", tablName);
            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Columns c = new Columns();
                c.OriginalName = reader.GetString(0);
                if (c.OriginalName.StartsWith(trimStart))
                {
                    c.Name = c.OriginalName.Substring(trimStart.Length);
                }
                //else if (c.OriginalName.StartsWith(trimStart2))
                //{
                //    c.Name = c.OriginalName.Substring(trimStart2.Length);
                //    //throw new Exception();
                //}
                else
                {
                    throw new Exception();
                }
               
                c.DataType = reader.GetString(1);
                c.Comments = reader.GetString(2);
                columns.Add(c);
            }

            var p = BuildProperties(columns);
            var selectSql = BuildSelectSql(columns);
            var updateSql = BuildUpdateSql(columns);
            var insertSql = BuildInsertSql(columns);
        }

        static string BuildProperties(List<Columns> columns)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in columns)
            {
                if (!typeMapping.Keys.Contains(item.DataType.ToLower()))
                {
                    throw new Exception();
                }
                sb.AppendLine("/// <summary>");
                sb.AppendLine(string.Format("/// {0}", item.Comments));
                sb.AppendLine("/// </summary>");
             
                sb.Append(string.Format("public {0} {1} ", typeMapping[item.DataType.ToLower()], item.Name));
                sb.Append("{get;set;}");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        static string BuildSelectSql(List<Columns> columns)
        {
            StringBuilder sb = new StringBuilder("SELECT ");
            foreach (var item in columns)
            {
                sb.Append(item.OriginalName);
                sb.Append(" AS ");
                sb.Append(item.Name);
                sb.AppendLine(",");
            }

            sb.Remove(sb.Length - 3, 1);
            sb.AppendLine(string.Format("FROM {0}", tablName));

            return sb.ToString();
        }

        static string BuildUpdateSql(List<Columns> columns)
        {
            StringBuilder sb = new StringBuilder(String.Format( "UPDATE {0} SET ",tablName));
            foreach (var item in columns)
            {
                sb.AppendLine(string.Format(" {0} = IFNULL(@{1},{2}),", item.OriginalName, item.Name,item.OriginalName));
            }
            sb.Remove(sb.Length - 3, 1);
            return sb.ToString();
        }

        static string BuildInsertSql(List<Columns> columns)
        {
            StringBuilder sb1 = new StringBuilder(String.Format("INSERT INTO {0} (", tablName));
            StringBuilder sb2 = new StringBuilder(String.Format("VALUES("));
            foreach (var item in columns)
            {
                sb1.AppendLine(string.Format("{0},", item.OriginalName));
                sb2.AppendLine(string.Format("@{0},", item.Name));
            }
            sb1.Remove(sb1.Length - 3, 1);
            sb2.Remove(sb2.Length - 3, 1);
            sb1.Append(")");
            sb2.Append(")");

            return sb1.ToString()+sb2.ToString();
        }
    }

    public class Columns
    {
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string DataType { get; set; }
        public string Comments { get; set; }
    }
}
