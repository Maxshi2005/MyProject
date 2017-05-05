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


        public static void Create(POrder order)
        {
            IDbTransaction transaction = null;

            try
            {
                using (var con = DBHelper.OpenConnection())
                {
                    transaction = con.BeginTransaction();
                    //orderRepository.Create(order.Order, con, transaction);
                    orderDetailRepository.Create(order.DetailList, con, transaction);
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
            try
            {
                using (var con = DBHelper.OpenConnection())
                {
                    string sql = @"SELECT orders.orderNumber, orders.orderDate, orders.requiredDate, orders.shippedDate, orders.status, orders.comments, orders.customerNumber,
                                   orderDetails.orderNumber as PNumbers, orderDetails.productCode, orderDetails.quantityOrdered, orderDetails.priceEach, orderDetails.orderLineNumber
                                   From Orders AS orders
                                   JOIN OrderDetails AS orderDetails
                                   ON orders.orderNumber = orderDetails.orderNumber
                                   WHERE orders.orderNumber < 10000";

                   var list = con.Query<POrder, OrderDetail,  POrder>(sql,(p, orderDetails) => { p.DetailList = new List<OrderDetail> { orderDetails }; return p;}
                   ,splitOn: "PNumbers"
                   );
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return null;
        }


    }
}
