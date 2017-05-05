using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace ConsoleApplication1.AutoMapper
{
    public class MyAutoMapper
    {
        public static void Run()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Test1, Test2>();
            });

            Test1 t1 = new Test1()
            {
                MyProperty = 1,
                MyProperty1 = 2,
                MyProperty2 = 3,
                 MyProperty3 = new AutoMapper.Test3() { MyProperty = 4 }
            };

            Test2 t2 = Mapper.Map<Test2>(t1);
        }
    }

    public class Test1
    {
        public int MyProperty { get; set; }

        public int MyProperty1 { get; set; }

        public int MyProperty2 { get; set; }
        public Test3 MyProperty3 { get; set; }
    }

    public class Test2
    {
        public int MyProperty { get; set; }

        public int MyProperty1 { get; set; }

        public int MyProperty2 { get; set; }

        public Test3 MyProperty3 { get; set; }
    }

    public class Test3
    {
        public int MyProperty { get; set; }

    }

}
