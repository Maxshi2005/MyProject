using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TCBase.Data;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using System.Runtime.Caching;
using System.Management;
using Newtonsoft.Json;
using System.Collections;
using System.Dynamic;
using ConsoleApplication1.DapperExample;
using System.Threading;
using ConsoleApplication1.Tree;
using System.Data.Common;
using System.IO;
using ConsoleApplication1.AutoMapper;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ITest<E> te = new Test<E>();
            //te.print();

            //var tree = Helper.BuildTree();
            //var t =  Helper.GetTreeHeightAndHeight(tree);
            //Console.WriteLine("Height:{0}，Left:{1}, Right:{2}, Width:{3}",t.Item1,Math.Abs(t.Item2),t.Item3,t.Item3 - t.Item2);


            //var s = t.Wait(1500);
            //if (s)
            //{
            //Console.WriteLine(t.Result);
            //}
            //else
            //{
            //    Console.WriteLine("time out...");
            //}
            //MyAutoMapper.Run();
            SqlBuilder.SqlBuilder.Run();
        }

        public enum E
        {
            Test = 't',
            Test2 = 's'
        }

        static int Test1()
        {
            Thread.Sleep(10000);
            return 1;
        }
        static int Test2()
        {
            return 2;
        }

        static bool Test3()
        {
            Console.WriteLine("Test3");
            return true;
        }

        static List<Dictionary<String, Object>> GetParamDicForSimpleObj<T>(IEnumerable<T> list, bool needProcessEnumType, Type EnumTypeRepresent) where T : new()
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            List<Dictionary<String, Object>> result = new List<Dictionary<string, object>>();

            var structTypes = new List<Type>() { typeof(int), typeof(long), typeof(float), typeof(decimal), typeof(double)
            , typeof(Byte), typeof(SByte) , typeof(UInt16), typeof(UInt32), typeof(UInt64),  typeof(Single)};

            foreach (var t in list)
            {
                var dynamicProperties = new Dictionary<String, Object>();

                foreach (var p in properties)
                {
                    var v = p.GetValue(t);

                    if (
                        (v == null) ||
                        (p.PropertyType == typeof(string) && !string.IsNullOrWhiteSpace(v as string)) ||
                        (p.PropertyType == typeof(char) && ((char)v) == char.MinValue) ||
                        (p.PropertyType == typeof(DateTime) && ((DateTime)v == DateTime.MinValue)) ||
                        ((structTypes.Contains(p.PropertyType) && double.Parse(v.ToString()) <= 0))
                       )
                    {
                        continue;
                    }

                    if (p.PropertyType.IsEnum && needProcessEnumType)
                    {
                        object temp = null;
                        if (EnumTypeRepresent == typeof(int))
                        {
                            temp = (int)Enum.Parse(p.PropertyType, v.ToString());
                        }

                        if (EnumTypeRepresent == typeof(char))
                        {
                            var obj = Enum.Parse(p.PropertyType, v.ToString());
                            temp = Convert.ChangeType(obj, typeof(char));
                        }

                        dynamicProperties.Add(p.Name, temp);
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
