using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DapperExample
{
   public class POrder
    {
        //public int OrderNumber { get; set; }
        //public DateTime OrderDate { get; set; }
        //public DateTime RequiredDate { get; set; }
        //public DateTime ShippedDate { get; set; }
        //public string Status { get; set; }
        //public string Comments { get; set; }
        //public int CustomerNumber { get; set; }

        public Order Order { get; set; }
        public List<OrderDetail> DetailList { get; set; }
    }
}
