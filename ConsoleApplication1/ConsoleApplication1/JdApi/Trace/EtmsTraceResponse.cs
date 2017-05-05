using System;
using System.Collections.Generic;

namespace TC.Train.OTS.OutService.JdApi.BillCode
{
    public class EtmsTraceResponse
    {
        public EtmsTraceReturn jingdong_etms_trace_get_responce { get; set; }
        public EtmsCommonError error_response { get; set; }
    }

    public class EtmsTraceReturn
    {
        public List<EtmsTraceItem> trace_api_dtos { get; set; }
    }

    public class EtmsTraceItem
    {
        public string ope_name { get; set; }
        public string ope_title { get; set; }
        public string ope_time { get; set; }
        public string ope_remark { get; set; }
    }
}

