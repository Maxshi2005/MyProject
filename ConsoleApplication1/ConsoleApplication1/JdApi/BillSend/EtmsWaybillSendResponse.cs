using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.Train.OTS.OutService.JdApi.BillSend
{
    public class EtmsWaybillSendResponse
    {
        public EtmsWaybillSendReturn jingdong_etms_waybill_send_responce { get; set; }
        public EtmsCommonError error_response { get; set; }
    }

    public class EtmsWaybillSendReturn
    {
        public EtmsWaybillSendResult resultInfo { get; set; }
        public string code { get; set; }
    }

    public class EtmsWaybillSendResult
    {
        public int code { get; set; }
        public string message { get; set; }
        public string deliveryId { get; set; }
        public string orderId { get; set; }
    }
}
