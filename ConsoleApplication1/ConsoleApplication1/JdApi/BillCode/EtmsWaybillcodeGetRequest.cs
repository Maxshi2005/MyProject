using System;
using System.Collections.Generic;

namespace TC.Train.OTS.OutService.JdApi.BillCode
{
    public class EtmsWaybillcodeGetRequest : IJdRequest
    {
        public string  preNum  { get; set; }

        public string customerCode  { get; set; }
                                             
        public int  orderType  { get; set; }

        public string GetApiName() 
        {
            return "jingdong.etms.waybillcode.get";
        }
    }
}

