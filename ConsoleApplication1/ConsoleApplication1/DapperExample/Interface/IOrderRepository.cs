using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Interface
{
   public interface IOrderRepository
    {
        /// <summary>
        /// 返回全部Order 数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<Order> GetAllOrders();

        /// <summary>
        /// 根据传入ids参数，查找Order
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        IEnumerable<Order> GetOrders(int[]Ids);

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Order CreateOrder(Order order);

        /// <summary>
        /// 根据参数更新订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        bool UpdateOrder(Order order);
    }
}
