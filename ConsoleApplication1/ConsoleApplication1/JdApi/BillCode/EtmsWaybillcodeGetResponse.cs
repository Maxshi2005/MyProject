using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.Train.OTS.OutService.JdApi.BillCode
{
    public class EtmsWaybillcodeGetResponse
    {
        public EtmsWaybillcodeGetReturn jingdong_etms_waybillcode_get_responce { get; set; }
        public EtmsCommonError error_response { get; set; }
    }

    public class EtmsWaybillcodeGetReturn
    {
        public EtmsWaybillcodeGetResult resultInfo { get; set; }
        public string code { get; set; }
    }

    public class EtmsWaybillcodeGetResult
    {
        public string message { get; set; }
        public int code { get; set; }
        public List<string> deliveryIdList { get; set; }
    }
}
