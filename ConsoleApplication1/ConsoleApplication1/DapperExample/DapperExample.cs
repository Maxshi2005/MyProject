using ConsoleApplication1;
using ConsoleApplication1.DapperExample;
using ConsoleApplication1.DapperExample.Repository;
using ConsoleApplication1.Interface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public class DapperExample1
    {
       

        public static void Run()
        {
            Create();
            POrderRepository.GetAllPOrders();

        }

        public static void Create2()
        {
            dynamic pOrder = new ExpandoObject();

            pOrder.Order = new 
            {
                OrderNumber = 106,
                Comments = "from test program",
                CustomerNumber = 121,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(10),
                ShippedDate = DateTime.Now.AddDays(5),
                Status = "shipped"
            };

            pOrder.DetailList = new List<dynamic>
            {
                new 
                {
                     OrderLineNumber = 1,
                     PNumbers = pOrder.Order.OrderNumber,
                     PriceEach = 100M,
                     ProductCode = "S10_1678",
                     QuantityOrdered = 10
                },
                new
                {
                     OrderLineNumber = 1,
                     PNumbers = pOrder.Order.OrderNumber,
                     PriceEach = 100M,
                     ProductCode = "S10_1949",
                     QuantityOrdered = 10
                }
            };

            POrderRepository.Create(pOrder);
        }



        public static void Create()
        {
            POrder pOrder = new POrder();

            pOrder.Order = new Order()
            {
                OrderNumber = 109,
                Comments = "from test program",
                CustomerNumber = 121,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(10),
                ShippedDate = DateTime.Now.AddDays(5),
                Status = "shipped"
            };

            pOrder.DetailList = new List<Model.OrderDetail>()
            {
                new Model.OrderDetail()
                {
                     OrderLineNumber = 1,
                     PNumbers = pOrder.Order.OrderNumber,
                     PriceEach = 100M,
                     ProductCode = "S10_1678",
                     QuantityOrdered = 10
                },
                new Model.OrderDetail()
                {
                     OrderLineNumber = 1,
                     PNumbers = pOrder.Order.OrderNumber,
                     PriceEach = 100M,
                     ProductCode = "S10_1949",
                     QuantityOrdered = 10
                }
            };



            POrderRepository.Create(pOrder);
        }


       

    }
}
