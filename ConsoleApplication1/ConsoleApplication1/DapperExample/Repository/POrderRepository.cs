using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using ConsoleApplication1.Model;

namespace ConsoleApplication1.DapperExample.Repository
{
  public  class POrderRepository
    {
        private static OrderRepository orderRepository = new OrderRepository();
        private static OrderDetailRepository orderDetailRepository = new OrderDetailRepository();


        public static void Create(dynamic order)
        {
            IDbTransaction transaction = null;

            try
            {
                using (var con = DBHelper.OpenConnection())
                {
                    transaction = con.BeginTransaction();

                    var p1 = DBHelper.GetParamDicForSimpleObj<Order>(new List<Order> { order.Order });
                    var p2 = DBHelper.GetParamDicForSimpleObj<OrderDetail>(order.DetailList);

                    orderRepository.Create(p1, con, transaction);
                    orderDetailRepository.Create(p2, con, transaction);
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public static List<POrder> GetAllPOrders()
        {
            var pOrderLookup = new Dictionary<int, POrder>();

            try
            {
                using (var con = DBHelper.OpenConnection())
                {
                    string sql = @"SELECT null,orders.orderNumber, orders.orderDate, orders.requiredDate, orders.shippedDate, orders.status, orders.comments, orders.customerNumber,
                                   orderDetails.orderNumber as PNumbers, orderDetails.productCode, orderDetails.quantityOrdered, orderDetails.priceEach, orderDetails.orderLineNumber
                                   From Orders AS orders
                                   JOIN OrderDetails AS orderDetails
                                   ON orders.orderNumber = orderDetails.orderNumber
                                   WHERE orders.orderNumber < 10000";

                   var list = con.Query<POrder,Order,OrderDetail, POrder>(sql, (porder,order, orderDetails ) => 
                   {
                       POrder porder1;
                       if (!pOrderLookup.TryGetValue(order.OrderNumber,out porder1))
                       {
                           porder1 = porder;
                           porder1.Order = order;
                           pOrderLookup.Add(order.OrderNumber, porder);
                       }

                       if (porder1.DetailList == null)
                       {
                           porder1.DetailList = new List<OrderDetail>();
                       }

                       porder1.DetailList.Add(orderDetails);
                       return porder;
                   }
                   ,splitOn: "orderNumber,PNumbers"//Note
                   );
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return pOrderLookup.Values.ToList();
        }



       


    }
}
