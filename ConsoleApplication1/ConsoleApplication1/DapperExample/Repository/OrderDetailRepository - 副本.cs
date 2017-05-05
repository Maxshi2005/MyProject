using ConsoleApplication1.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DapperExample.Repository
{
  public class OrderDetailRepository
    {
        public void Create(IEnumerable<OrderDetail> detailList, IDbConnection con,IDbTransaction trasaction = null)
        {
                var sql = @"INSERT INTO orderdetails(orderNumber, productCode, quantityOrdered, priceEach, orderLineNumber)
                            VALUES(@orderNumber, @productCode, @quantityOrdered,  @priceEach,@orderLineNumber)";

                con.Execute(sql, detailList, trasaction);
        }
    }
}
