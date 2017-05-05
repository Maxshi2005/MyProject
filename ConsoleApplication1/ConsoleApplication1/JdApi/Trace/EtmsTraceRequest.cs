using System;
using System.Collections.Generic;

namespace TC.Train.OTS.OutService.JdApi.BillCode
{
    public class EtmsTraceRequest : IJdRequest
    {
        public string waybillCode { get; set; }

        public string GetApiName()
        {
            return "jingdong.etms.trace.get";
        }
    }
}

