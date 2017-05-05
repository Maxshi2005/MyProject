using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.Train.OTS.OutService.JdApi.BillSend
{
    public class EtmsWaybillSendRequest : IJdRequest
    {
        public string deliveryId { get; set; }
        public string salePlat { get; set; }
        public string customerCode { get; set; }
        public string orderId { get; set; }
        public string senderName { get; set; }
        public string senderAddress { get; set; }
        public string senderTel { get; set; }
        public string senderMobile { get; set; }
        public string receiveName { get; set; }
        public string receiveAddress { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string receiveTel { get; set; }
        public string receiveMobile { get; set; }
        public int packageCount { get; set; }
        public int weight { get; set; }
        public int vloumn { get; set; }
        public string GetApiName()
        {
            return "jingdong.etms.waybill.send";
        }
    }
}
