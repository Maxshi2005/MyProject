using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model
{
   public class OrderDetail 
    {
        public int PNumbers { get; set; }
        public string ProductCode { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal PriceEach { get; set; }
        public int OrderLineNumber { get; set; }
    }
}
