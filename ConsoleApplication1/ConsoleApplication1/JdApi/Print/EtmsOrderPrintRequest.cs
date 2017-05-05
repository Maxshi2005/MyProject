using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.Train.OTS.OutService.JdApi.Print
{
    public class EtmsOrderPrintRequest : IJdRequest
    {
        public string customerCode { get; set; }
        public string deliveryId { get; set; }
        public string GetApiName()
        {
            return "jingdong.etms.order.print";
        }
    }
}
