using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace ConsoleApplication1.DapperExample.Repository
{
   public class OrderRepository
    {
        public void Create(Order order, IDbConnection con, IDbTransaction trasaction = null)
        {
            var sql = @"INSERT INTO orders(orderNumber, orderDate, requiredDate, shippedDate, status, comments, customerNumber)
                    VALUES(@orderNumber, @orderDate, @requiredDate, @shippedDate, @status, @comments, @customerNumber)";

            con.Execute(sql, order, trasaction);

            //throw new Exception();
        }
    }
}
