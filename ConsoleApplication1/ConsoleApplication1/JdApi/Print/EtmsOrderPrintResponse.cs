using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.Train.OTS.OutService.JdApi.Print
{
    public class EtmsOrderPrintResponse
    {
        public EtmsOrderPrintReturn jingdong_etms_order_print_responce { get; set; }
        public EtmsCommonError error_response { get; set; }
    }

    public class EtmsOrderPrintReturn
    {
        public EtmsOrderPrintResult response { get; set; }
    }

    public class EtmsOrderPrintResult
    {
        public string stateMessage { get; set; }
        public string pdfArr { get; set; }
        public string stateCode { get; set; }
    }
}
