using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.Train.OTS.OutService.JdApi.AccessToken
{
    public class GetAccessTokenRequest
    {
        public string Code { get; set; }
        public string State { get; set; }
    }
}
