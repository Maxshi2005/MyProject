using ConsoleApplication1.Config;
using ConsoleApplication1.Interface;
using ConsoleApplication1.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private const string BaseQuerySql = @"SELECT [Order].TOId AS Id  ,[Order].TOSerialId AS OrderId ,[Order].TOChannelId AS ChannelId
                              ,[Order].TOStartDateTime AS StartDateTime ,[Order].TOEndDateTime AS EndDateTime ,[Order].TOTrainNo AS TrainNo
                              ,[Order].TOStartCN AS StartCN ,[Order].TOEndCN ,[Order].TOSeatTypeCN,[Order].TOSeatPrice
                              ,[Order].TOCreateDateTime,OrderDetail.TOLId, OrderDetail.TOLSerialId, OrderDetail.TOLQueryKey, OrderDetail.TOLSearchKeyword, 
                              OrderDetail.TOLOpenId, OrderDetail.TOLClientIp, OrderDetail.TOLAppVision, OrderDetail.TOLSessionId, 
                              OrderDetail.TOLDeviceNo, OrderDetail.TOLAutomation, OrderDetail.TOLCreateDateTime,Passengers.TPId,Passengers.TPSerialId,
                               Passengers.TPPassengerName, Passengers.TPGender, Passengers.TPType, Passengers.TPIdType, Passengers.TPIdNo, 
                               Passengers.TPBirthday, Passengers.TPSeatTypeCN, Passengers.TPSeatPrice, Passengers.TPCreateDateTime
                          FROM [TCFlyTrainOrder].[dbo].[PTTrainOrder] AS [order]
                          JOIN [dbo].[PTTrainOrderList] AS orderDetail
                          ON [Order].TOSerialId = OrderDetail.TOLSerialId
                          JOIN [dbo].[PTTrainPassenger] passengers ON 
                          [Order].TOSerialId = Passengers.TPSerialId
                         ";

        public Order CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        //public Order CreateOrder(Order order)
        //{
        //    using (var con = OpenConnection())
        //    {
        //        //con.
        //    }
        //}

        public IEnumerable<Order> GetAllOrders()
        {
            return GetOrders(BaseQuerySql, null);
        }

        public IEnumerable<Order> GetOrders(int[] ids)
        {
            string sql = BaseQuerySql;

            if (ids == null || ids.Length == 0)
            {
                return null;
            }

            sql = BaseQuerySql + " WHERE TOId in @Ids";
            var param = ToParameter(ids);

            return GetOrders(sql,param);
        }

        public bool UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        #region Private
        private IEnumerable<Order> GetOrders(string sql, object param)
        {
            using (var con = OpenConnection())
            {
                var OrderLookup = new Dictionary<string, Order>();

                var orders = con.Query<Order, OrderDetail, Passengers, Order>(sql,
                   (order, orderDetail, passengers) =>
                   {
                       order.OrderDetail = orderDetail;

                       Order order1;
                       if (!OrderLookup.TryGetValue(order.OrderId, out order1))
                       {
                           OrderLookup.Add(order.OrderId, order1 = order);
                       }

                       if (order.PassengerList == null)
                       {
                           order.PassengerList = new List<Passengers>();
                       }

                       order1.PassengerList.Add(passengers);
                       return order1;
                   },
                   param,
                   splitOn: ("TOLId,TPId")
                   );

                var orderList = OrderLookup.Values;
                return orderList;
            }
        }

        private object ToParameter(int[]ids)
        {
            List<object> list = new List<object>();

            foreach (var id in ids)
            {
                list.Add(new { Id = id});
            }

            return list;
        }

        #endregion

    }
    
}
